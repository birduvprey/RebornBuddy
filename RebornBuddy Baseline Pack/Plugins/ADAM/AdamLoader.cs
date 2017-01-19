using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media;
using ff14bot.AClasses;
using ff14bot.Helpers;
using ff14bot.Managers;
using ICSharpCode.SharpZipLib.Zip;

namespace ADAM
{
	internal class AdamLoader : BotPlugin
	{
		public override string Name => "Allagan Data Acquisition Module";
		public override string Author => "TheCommodore & AnExiledGod";
		public override string Description => "ADAM is a multi-functional plugin which gathers a great deal of information and allows you to monitor it all from a convenient web interface.";
		public override Version Version => new Version(2, 1, 0);
		public override bool WantButton => true;
		public override string ButtonText => "Settings";

		private static readonly string FolderPath = Path.Combine(Environment.CurrentDirectory, @"Plugins\ADAM\");
		private static readonly string LogsFolderPath = Path.Combine(Environment.CurrentDirectory, @"Plugins\ADAM\Logs\");
		private static readonly string DllPath = Path.Combine(Environment.CurrentDirectory, @"Plugins\ADAM\ADAM.dll");

		private static object Plugin { get; set; }
		private static MethodInfo Enable { get; set; }
		private static MethodInfo Disable { get; set; }
		private static MethodInfo ButtonPress { get; set; }

		private static volatile bool updaterStarted;
		private static volatile bool updaterFinished;
		private static volatile bool loaderFinished;

		private static readonly Object _logFileLock = new Object();
		private static readonly Object _loaderLock = new Object();

		private const string SiteUrl = "https://allagandata.com";
		public static string CurrentVersion = "2.1.0";

		public override void OnEnabled()
		{
			if (Plugin == null)
			{
				UpdatePlugin();
			}
			if (Plugin != null)
			{
				Enable.Invoke(Plugin, null);
			}
		}

		public override void OnDisabled()
		{
			if (Plugin == null)
			{
				UpdatePlugin();
			}
			if (Plugin != null)
			{
				Disable.Invoke(Plugin, null);
			}
		}

		public override void OnButtonPress()
		{
			if (Plugin == null)
			{
				UpdatePlugin();
			}
			if (Plugin != null)
			{
				ButtonPress.Invoke(Plugin, null);
			}
		}

		private static void Log(string message)
		{
			Logging.Write(Colors.SteelBlue, "[ADAM Loader] " + message);

			LogToFile("[ADAM Loader] " + message);
		}

		private static void FailUpdate(string reason, Exception e)
		{
			updaterFinished = true;
			Log("Updating ADAM Failed. Error Message: " + reason);

			LogToFile("[ADAM Loader][UPDATER] " + reason + "\n Exception: " + e);
		}

		private static void FailLoad(string reason, Exception e)
		{
			updaterFinished = true;
			Log("Loading ADAM Failed. Error Message: " + reason);

			LogToFile("[ADAM Loader][LOADER] " + reason + "\n Exception: " + e);
		}

		private static void LogToFile(string message)
		{
			FileInfo fileInfo = new FileInfo(LogsFolderPath);

			if (!fileInfo.Exists)
			{
				try
				{
					Directory.CreateDirectory(fileInfo.Directory.FullName);
				}
				catch (Exception e)
				{
					Log("Failed creating Logs Directory. You can probably ignore this error.");
				}
			}

			try
			{
				lock (_logFileLock)
				{
					DateTime currentUtcTime = DateTime.Now;

					TextWriter tw = new StreamWriter(LogsFolderPath + currentUtcTime.ToShortDateString().Replace("/", "-") + ".log", true);
					tw.WriteLine("[" + currentUtcTime + "]" + message);
					tw.Close();
				}
			}
			catch (Exception e)
			{
				
			}
		}

		private static void LoadPlugin()
		{
			lock (_loaderLock)
			{
				if (Plugin != null)
				{
					return;
				}
				
				try
				{
					Assembly assembly = Assembly.LoadFrom(DllPath);
					Type baseType = assembly.GetType("ADAM.Adam");
					Plugin = Activator.CreateInstance(baseType);

					Enable = Plugin.GetType().GetMethod("EnablePlugin");
					Disable = Plugin.GetType().GetMethod("DisablePlugin");
					ButtonPress = Plugin.GetType().GetMethod("OnButtonPress");

					if (PluginManager.GetEnabledPlugins().Any(n => n == "Allagan Data Acquisition Module"))
					{
						Enable.Invoke(Plugin, null);
					}
				}
				catch (Exception e)
				{
					FailLoad("Unable to load ADAM assembly.", e);
				}
			}
		}

		private static void UpdatePlugin()
		{
			updaterStarted = true;

			Stopwatch stopwatch = Stopwatch.StartNew();

			string latestVersion = GetLatestVersionNumber().Result;
			if ((!String.IsNullOrEmpty(latestVersion) && CurrentVersion == latestVersion) && File.Exists(DllPath))
			{
				Log("You're using the latest version, loading ADAM.");

				updaterFinished = true;
				LoadPlugin();

				return;
			}

			if (String.IsNullOrEmpty(latestVersion))
			{
				FailUpdate("Unable to grab Latest Version Number.", null);

				return;
			}



			Byte[] latestVersionFiles = DownloadLatestVersion().Result;

			if (latestVersionFiles == null || latestVersionFiles.Length == 0)
			{
				FailUpdate("Unable to grab Latest Plugin Files.", null);

				return;
			}



			if (!CleanupFiles())
			{
				return;
			}

			if (!ExtractLatestVersion(latestVersionFiles))
			{
				return;
			}

			Log("Checking update integrity...");

			if (
				!File.Exists(DllPath) || 
				!File.Exists(FolderPath + "ADAMLoader.cs") || 
				!File.Exists(FolderPath + "SettingsWindow.baml") || 
				!File.Exists(FolderPath + "MahApps.Metro.dll") || 
				!File.Exists(FolderPath + "System.Windows.Interactivity.dll")
			)
			{
				FailUpdate("Not all files are present after update. Please contact an admin for assistance.", null);

				return;
			}

			Log("Update integrity is good.");

			stopwatch.Stop();
			updaterFinished = true;
			Log("Update completed in " + stopwatch.ElapsedMilliseconds + " milliseconds.");

			LoadPlugin();
		}

		private static async Task<string> GetLatestVersionNumber()
		{
			Log("Grabbing the Latest Version Number from our servers.");

			using (HttpClient client = new HttpClient())
			{
				try
				{
					HttpResponseMessage response = await client.GetAsync(new Uri(SiteUrl + "/LatestVersion")).ConfigureAwait(false);
					
					if (response.StatusCode != HttpStatusCode.OK)
					{
						FailUpdate("Server returned status other than OK. Server may be down.", null);

						return "";
					}

					string latestVersionNumber = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
					
					return latestVersionNumber;
				}
				catch (Exception e)
				{
					FailUpdate("Unable to grab Latest Version Number.", e);

					return "";
				}
			}
		}

		private static async Task<byte[]> DownloadLatestVersion()
		{
			Log("Grabbing the Latest Plugin Files from our server.");

			using (HttpClient client = new HttpClient())
			{
				try
				{
					HttpResponseMessage response = await client.GetAsync(new Uri(SiteUrl + "/Plugin/ADAM.zip")).ConfigureAwait(false);

					if (response.StatusCode != HttpStatusCode.OK)
					{
						FailUpdate("Server returned status other than OK. Server may be down.", null);

						return null; 
					}

					Byte[] latestVersionFile = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

					return latestVersionFile;
				}
				catch (Exception e)
				{
					FailUpdate("Unable to grab Latest Version Number.", e);

					return null;
				}
			}
		}

		private static bool ExtractLatestVersion(byte[] pluginFiles)
		{
			Log("Extracting the Latest Plugin Files.");

			using (MemoryStream stream = new MemoryStream(pluginFiles))
			{
				var zip = new FastZip();

				try
				{
					zip.ExtractZip(stream, FolderPath, FastZip.Overwrite.Always, null, null, null, false, true);
				}
				catch (Exception e)
				{
					FailUpdate("Unable to Extract Latest Plugin Files.", e);

					return false;
				}
			}

			return true;
		}

		private static bool CleanupFiles()
		{
			Log("Cleaning up old plugin files before new files are unzipped.");

			foreach (FileInfo file in new DirectoryInfo(FolderPath).GetFiles())
			{
				try
				{
					file.Attributes = FileAttributes.Normal;
					file.Delete();
				}
				catch (Exception e)
				{
					FailUpdate("Unable to clean plugin files.", e);

					return false;
				}
			}

			return true;
		}
	}
}
