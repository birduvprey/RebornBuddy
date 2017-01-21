using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Linq;

using ff14bot;
using ff14bot.AClasses;
using ff14bot.Behavior;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Interfaces;
using ff14bot.Managers;
using ff14bot.NeoProfiles;
using ff14bot.Navigation;
using ff14bot.RemoteWindows;
using Buddy.Coroutines;

using TreeSharp;
using Action = TreeSharp.Action;
using Newtonsoft.Json;
using Clio.Utilities;
using CrystalHunter.Settings;

namespace CrystalHunter
{
    public class CrystalHunter : IBotPlugin
    {
        public string 	Author 		{ get { return "Zee"; } }
        public Version 	Version 	{ get { return new Version(2, 1); } }
        public string 	Name 		{ get { return "CrystalHunter"; } }
        public string 	Description	{ get { return "Grind FATES for Anima Relic Stage 1 Crystals. \nConcept based on Atma Hunter by ExMortem:\n https://www.thebuddyforum.com/rebornbuddy-forum/plugins/169111-atma-hunter.html"; } }

		public static readonly Color LogColor = Color.FromRgb(0,255,255);

        public static CrystalHunterSettings settings = CrystalHunterSettings.instance; 
        private Composite 	RootCrystalHunter;
        private Form 		_configForm;

		private static bool	Finished = false;
		
		public bool WantButton
        {
            get { return true; }
        }
		
        public string ButtonText
        {
            get { return "Settings"; }
        }

		public void OnButtonPress()
        {
            if (_configForm == null || _configForm.IsDisposed || _configForm.Disposing)
                _configForm = new CrystalHunterSettingsForm();

            _configForm.ShowDialog();
        }

        public bool Equals(IBotPlugin other)
        {
            throw new NotImplementedException();
        }

		#region Crystal Consts
		private const string IceCrystal 		= "Luminous Ice Crystal";
		private const string WaterCrystal 		= "Luminous Water Crystal";
		private const string WindCrystal 		= "Luminous Wind Crystal";
		private const string LightningCrystal 	= "Luminous Lightning Crystal";
		private const string EarthCrystal 		= "Luminous Earth Crystal";
		private const string FireCrystal 		= "Luminous Fire Crystal";
		
		private const string UmbralNodule		= "Umbral Nodule";
		private const string AstralNodule		= "Astral Nodule";
		#endregion
		
		#region Locations Consts
		private const string FalconsNest 		= "falcon's nest";
		private const string CampCloudtop 		= "camp cloudtop";
		private const string Helix 				= "helix";
		private const string Idyllshire 		= "idyllshire";
		private const string TailFeather 		= "tailfeather";
		private const string Moghome 			= "moghome";
		#endregion

		#region variables
        private static Dictionary<int, string> CrystalDictionary 				= new Dictionary<int, string>();
        private static Dictionary<int, string> ZoneDictionary 					= new Dictionary<int, string>();
        private static Dictionary<int, string> LocationDictionary 				= new Dictionary<int, string>();
        private static Dictionary<string, string> CrystalLocationDictionary		= new Dictionary<string, string>();

        private static Dictionary<int, string> UmbralNoduleDictionary 			= new Dictionary<int, string>();
        private static Dictionary<int, string> AstralNoduleDictionary 			= new Dictionary<int, string>();

        private static Dictionary<int, int> JobZoneDictionary 					= new Dictionary<int, int>();

		private static Vector3 IdyllshireExit 									= new Vector3("142.4168, 207, 114.1231");
		private static Vector3 IdyllshireAetheryte 								= new Vector3("71.94617, 211.2611, -18.90594");
		private static int IdyllshireAetheryteId 								= 75;

		private static int 	CrystalCount;
		private static bool JobSetChange;
		private static bool VerboseLogging;

		private static int CoerthasJob;
		private static int DravanianForelandsJob;
		private static int DravanianHinterlandsJob;
		private static int ChurningMistsJob;
		private static int SeaOfCloudsJob;
		private static int AzysLlaJob;
		#endregion

        public void OnPulse()
        {
			if (Finished && !BotManager.Current.Name.Equals("Fate Bot") && !BotManager.Current.Name.Equals("ExFateBot"))
			{
				// Do nothing
			}
			else if (!BotManager.Current.Name.Equals("Fate Bot") && !BotManager.Current.Name.Equals("ExFateBot"))
			{
				Logging.Write(LogColor, "[Crystal Hunter] This plugin will only work with Fate Bot or ExFateBot, please switch to one of these.");
				Logging.Write(LogColor, "[Crystal Hunter] Current bot is {0}", BotManager.Current.Name);
				Finished = true;
			}
			else
			{
				try
				{
					if (BotManager.Current.Name.Equals("Fate Bot") || BotManager.Current.Name.Equals("ExFateBot"))
					{
						Finished = false;
						LoadSettings();

						if (RootCrystalHunter != null)
						{
							RootCrystalHunter.Tick(null);
							if (RootCrystalHunter.LastStatus != RunStatus.Running)
							{
								RootCrystalHunter.Stop(null);
								RootCrystalHunter.Start(null);
							}
						}
					}
				}
				catch (Exception e)
				{
					Logging.WriteException(e);
					if (RootCrystalHunter != null)
					{
						RootCrystalHunter.Stop(null);
						RootCrystalHunter.Start(null);
					}
				}
			}
        }

        public void OnInitialize()
        {
			// TODO - Z - Sometimes this gets hit again and tries to re-add to existing collection
			if (UmbralNoduleDictionary.Count == 0)
			{
				#region Nodule Dictionary
				UmbralNoduleDictionary.Add(0, IceCrystal);
				UmbralNoduleDictionary.Add(1, EarthCrystal);
				UmbralNoduleDictionary.Add(2, WaterCrystal);
				
				AstralNoduleDictionary.Add(0, FireCrystal);
				AstralNoduleDictionary.Add(1, WindCrystal);
				AstralNoduleDictionary.Add(2, LightningCrystal);
				#endregion
				
				#region Crystal Dictionary
				CrystalDictionary.Add(50, IceCrystal);
				CrystalDictionary.Add(52, EarthCrystal);
				CrystalDictionary.Add(54, WindCrystal);
				CrystalDictionary.Add(56, LightningCrystal);
				CrystalDictionary.Add(57, WaterCrystal);
				CrystalDictionary.Add(59, FireCrystal);
				#endregion
				
				#region Location Dictionary
				LocationDictionary.Add(71, FalconsNest);
				LocationDictionary.Add(72, CampCloudtop);
				LocationDictionary.Add(74, Helix);
				LocationDictionary.Add(75, Idyllshire);
				LocationDictionary.Add(76, TailFeather);
				LocationDictionary.Add(78, Moghome);
				#endregion
				
				#region Zone Dictionary
				ZoneDictionary.Add(397, FalconsNest);	//"Coerthas Western Highlands"
				ZoneDictionary.Add(398, TailFeather);	//"Dravanian Forelands"
				ZoneDictionary.Add(399, Idyllshire);	//"Dravanian Hinterlands"
				ZoneDictionary.Add(400, Moghome);		//"Churning Mists"
				ZoneDictionary.Add(401, CampCloudtop);	//"Sea of Clouds"
				ZoneDictionary.Add(402, Helix);			//"Azys Lla"
				#endregion

				#region Crystal Location Dictionary
				CrystalLocationDictionary.Add(IceCrystal, FalconsNest);
				CrystalLocationDictionary.Add(EarthCrystal, TailFeather);
				CrystalLocationDictionary.Add(WindCrystal, CampCloudtop);
				CrystalLocationDictionary.Add(LightningCrystal, Moghome);
				CrystalLocationDictionary.Add(WaterCrystal, Idyllshire);
				CrystalLocationDictionary.Add(FireCrystal, Helix);
				#endregion
				
				LoadSettings();
			}
        }

		public static void LoadSettings()
		{
			#region Read In and Set Jobs
			CoerthasJob 			= settings.CoerthasJobSet;
			DravanianForelandsJob 	= settings.DravanianForelandsJobSet;
			DravanianHinterlandsJob	= settings.DravanianHinterlandsJobSet;
			ChurningMistsJob 		= settings.ChurningMistsJobSet;
			SeaOfCloudsJob 			= settings.SeaOfCloudsJobSet;
			AzysLlaJob 				= settings.AzysLlaJobSet;
			#endregion

			#region Job Zone Mapping Dictionary
			JobZoneDictionary.Clear();
			JobZoneDictionary.Add(397, CoerthasJob);
			JobZoneDictionary.Add(398, DravanianForelandsJob);
			JobZoneDictionary.Add(478, DravanianHinterlandsJob);
			JobZoneDictionary.Add(399, DravanianHinterlandsJob);
			JobZoneDictionary.Add(400, ChurningMistsJob);
			JobZoneDictionary.Add(401, SeaOfCloudsJob);
			JobZoneDictionary.Add(402, AzysLlaJob);
			#endregion

			CrystalCount 	= settings.CrystalCount;
			JobSetChange 	= settings.JobSetChange;
			VerboseLogging 	= settings.VerboseLogging;

			if (VerboseLogging)
				Logging.Write(LogColor, "[Crystal Hunter] Loading settings.");
		}
		
        public void OnShutdown() 
		{
			CleanupVariables();
		}

		public void OnEnabled()
        {
            Logging.Write(LogColor, "[Crystal Hunter] Enabled.");

			try
			{
				RootCrystalHunter = CreateBehaviorLogic();
				RootCrystalHunter.Start(null);

				Logging.Write(LogColor, "[Crystal Hunter] Aiming for {0} of each crystal.", CrystalCount);

				InventoryScan();
			}
			catch (Exception e)
			{
				Logging.WriteException(e);
				throw;
			}
        }

        public void OnDisabled()
        {
			Logging.Write(LogColor, "[Crystal Hunter] Disabled.");

			CleanupVariables();

			if (RootCrystalHunter != null)
			{
				RootCrystalHunter.Stop(null);
				RootCrystalHunter = null;
			}
        }

		private void CleanupVariables()
		{
			Finished = false;
		}
		
		private static Composite CreateBehaviorLogic()
        {
			return new PrioritySelector(
				// Done!
                new Decorator(ret => String.IsNullOrEmpty(GrindLocation()),
                    new Action(r => 
						{ 
							Logging.Write(LogColor, "[Crystal Hunter] Looks like you've finished grinding, congratulations!"); 
							Finished = true;
						}
                    )
                ),
				// Specific movement required to farm in the Dravanian Hinterlands
                new Decorator(ret => InIdyllshire(),
                    new PrioritySelector(
								// Interact with Idyllshire Aetheryte to get to Dravanian Hinterlands
								new Decorator(ret => settings.IdyllshireAetheryteUnlocked,
									new PrioritySelector(
										new Decorator(ret => Vector3.Distance(Core.Player.Location, IdyllshireAetheryte) > 3f, CommonBehaviors.MoveTo(ret => IdyllshireAetheryte)
										),
										new Decorator(ret => MovementManager.IsMoving && Vector3.Distance(Core.Player.Location, IdyllshireAetheryte) <= 3f,
											new Action(r => MovementManager.MoveForwardStop())
										),
										new Decorator(ret => Core.Me.CurrentTarget != null && Core.Me.CurrentTarget.NpcId == (uint)IdyllshireAetheryteId && SelectString.IsOpen,
											new Sequence(
												new Sleep(2,5),
												new Action(r => SelectString.ClickSlot(0)),
												new Sleep(2,5),
												new Action(r => SelectString.ClickSlot(2)), // Collector's Quarter Exit
												new Sleep(15,30)
											)
										),
										new Decorator(ret => Vector3.Distance(Core.Player.Location, IdyllshireAetheryte) <= 3f,
											new Sequence(
												new Sleep(1,2),
												new Action(r => GameObjectManager.GetObjectByNPCId((uint)IdyllshireAetheryteId).Interact()),
												new Sleep(1,2)
											)
										)
									)
								),
								// Move manually to the Dravanian Hinterlands
								new Decorator(ret => !settings.IdyllshireAetheryteUnlocked,
									new PrioritySelector(
										new Decorator(ret => Vector3.Distance(Core.Player.Location, IdyllshireExit) > 3f, CommonBehaviors.MoveTo(ret => IdyllshireExit)
										),
										new Decorator(ret => MovementManager.IsMoving && Vector3.Distance(Core.Player.Location, IdyllshireExit) <= 3f,
											new Action(r => MovementManager.MoveForwardStop())
										),
										new Decorator(ret => !MovementManager.IsMoving && Vector3.Distance(Core.Player.Location, IdyllshireExit) <= 3f,
											new Sequence(
												new Action(r => MovementManager.SetFacing(IdyllshireExit)),
												new Sleep(1,5),
												new Action(r => MovementManager.MoveForwardStart()),
												new Sleep(2,5),
												new Action(r => MovementManager.MoveForwardStop()),
												new Sleep(2,5)
											)
										)
									)
								)
							)
                ),
				// Let's grind
				new Decorator(ret => InGrindZone(),
					new Action(r => 
						{ 
							//Do nothing but grind FATE's 
						}
					)
                ),
				// Try and teleport to a new location
				new Decorator(ret => !InGrindZone() && !InIdyllshire(),
					new PrioritySelector(
						new Decorator(ret => NowLoading.IsVisible,
							new Sequence(
								new Sleep(10,10)
							)
						),
						new Decorator(ret => !NowLoading.IsVisible && MovementManager.IsMoving,
							new Action(r => MovementManager.MoveForwardStop())
						),
						new Decorator(ret => !NowLoading.IsVisible && !Core.Player.IsCasting && !MovementManager.IsMoving,
							new Sequence(
								new Action(r => TeleportToNewLocation()),
								new Sleep(2,5)
							)
						)
					)
				)
            );
        }

		private static bool TeleportToNewLocation()
		{
			if (Core.Me.IsAlive && !Core.Player.InCombat && !Core.Player.IsCasting)
			{
				string grindLocation = GrindLocation();
				
				Logging.Write(LogColor, "[Crystal Hunter] Moving to {0}.", grindLocation);
				Logging.Write(LogColor, "[Crystal Hunter] Going after {0}.", GetCrystalForLocation(grindLocation));

				ChangeJob((uint)GetZoneIdViaLocationName(grindLocation));
				Thread.Sleep(2000);
				
				WorldManager.TeleportById((uint)GrindLocationId());

				Logging.Write(LogColor, "[Crystal Hunter] Will now wait for 15 seconds for transport to complete.");
				Thread.Sleep(15000);

				return true;
			}

			return false;
		}

		public List<string> InventoryScan()
		{
			List<String> inventory = new List<String>();

			foreach(string crystal in CrystalDictionary.Values)
			{
				inventory.Add(String.Format("{0} {1} in inventory.", GetItemCount(crystal), crystal));
				Logging.Write(LogColor, "[Crystal Hunter] {0} {1} in inventory.", GetItemCount(crystal), crystal);
			}

			if (inventory.Count > 0)
			{
				int UmbralNoduleCount = GetItemCount(UmbralNodule);
				int AstralNoduleCount = GetItemCount(AstralNodule);

				inventory.Add(String.Format("{0} {1} found within inventory.", UmbralNoduleCount, UmbralNodule));
				Logging.Write(LogColor, "[Crystal Hunter] {0} {1} found within inventory.", UmbralNoduleCount, UmbralNodule);

				inventory.Add(String.Format("{0} {1} found within inventory.", AstralNoduleCount, AstralNodule));
				Logging.Write(LogColor, "[Crystal Hunter] {0} {1} found within inventory.", AstralNoduleCount, AstralNodule);
			}

			return inventory;
		}

		private static int GetItemCount(string itemName)
		{
			int itemCount = 0;

			try
			{
				itemCount = InventoryManager.FilledSlots.Where(x => x.Name == itemName).Select(s => (int)s.Count).Sum();
			}
			catch (Exception e)
			{
				Logging.WriteException(e);
			}
			
			if (VerboseLogging)
				Logging.Write(LogColor, "[Crystal Hunter] (VerboseLogging) Within method {0} - {1} of {2} in inventory.", "GetItemCount()", itemCount, itemName);

			return itemCount;
		}
		
		private static bool DoesInventoryContainUmbralNodule()
		{
			int itemCount = GetItemCount(UmbralNodule);

			if (VerboseLogging)
				Logging.Write(LogColor, "[Crystal Hunter] (VerboseLogging) {0} {1} in inventory.", itemCount, UmbralNodule);

            return (itemCount > 0) ? true : false;
		}

		private static bool DoesInventoryContainAstralNodule()
		{
			int itemCount = GetItemCount(AstralNodule);

			if (VerboseLogging)
				Logging.Write(LogColor, "[Crystal Hunter] (VerboseLogging) {0} {1} in inventory.", itemCount, AstralNodule);

            return (itemCount > 0) ? true : false;
		}

		private static bool DoesInventoryContainCrystal(string crystal)
		{
			int itemCount = GetItemCount(crystal);

			if (VerboseLogging)
				Logging.Write(LogColor, "[Crystal Hunter] (VerboseLogging) {0} {1} in inventory.", itemCount, crystal);

            return (itemCount >= CrystalCount) ? true : false;
		}

		private static string GetCrystalToGather()
		{
			foreach (string crystal in CrystalDictionary.Values)
            {
				if (VerboseLogging)
					Logging.Write(LogColor, "[Crystal Hunter] (VerboseLogging) {0} - {1}", "Within method GetCrystalToGather()", crystal);
			
				if (settings.NoduleCheck)
				{
					if (DoesInventoryContainUmbralNodule() && UmbralNoduleDictionary.ContainsValue(crystal))
						continue;

					if (DoesInventoryContainAstralNodule() && AstralNoduleDictionary.ContainsValue(crystal))
						continue;
				}
				
                if (!DoesInventoryContainCrystal(crystal))
                    return crystal;
            }
			
			return String.Empty;
		}

        private static string GrindLocation()
        {
			if (VerboseLogging)
				Logging.Write(LogColor, "[Crystal Hunter] (VerboseLogging) {0}", "Within method GrindLocation()");
	
            return GetLocationForCrystal(GetCrystalToGather());
        }

		private static int GrindLocationId()
        {
			return LocationDictionary.FirstOrDefault(x => x.Value == GrindLocation()).Key;
        }

		private static int GrindLocationZoneId()
        {
			return ZoneDictionary.FirstOrDefault(x => x.Value == GrindLocation()).Key;
        }

		private static string GetCrystalForLocation(string location)
        {
			return CrystalLocationDictionary.FirstOrDefault(x => x.Value == location).Key;
        }

        private static string GetLocationForCrystal(string crystal)
        {
			return CrystalLocationDictionary.FirstOrDefault(x => x.Key == crystal).Value;
        }
		
        private static string GetZoneNameViaZoneId(uint zoneid)
        {
			return ZoneDictionary.FirstOrDefault(x => x.Key == zoneid).Value;
        }
		
		private static int GetZoneIdViaLocationName(string location)
        {
			return ZoneDictionary.FirstOrDefault(x => x.Value == location).Key;
        }

		private static bool InGrindZone()
		{
			return WorldManager.ZoneId == GrindLocationZoneId();
		}

		private static bool InIdyllshire()
		{
			return WorldManager.ZoneId == 478;
		}

		private static bool InDravanianHinterlands()
		{
			return WorldManager.ZoneId == 399;
		}

        private static int GetJobForZone(uint zoneid)
        {
            return JobZoneDictionary.FirstOrDefault(x => x.Key == zoneid).Value;
        }

		private static void ChangeJob(uint GrindLocationId)
        {
			int JobSet = GetJobForZone(GrindLocationId);

			// Only change if a job set has been defined
			if (JobSetChange && JobSet > 0)
			{
				try
				{
					ChatManager.SendChat("/gs change " + JobSet);

					Logging.Write(LogColor, "[Crystal Hunter] Changed job using gear set: {0} ", JobSet);
				}
				catch (Exception e)
				{
					Logging.WriteException(e);
					Logging.Write(LogColor, "[Crystal Hunter] Attempted to change job using gear set: {0} ", JobSet);
				}
			}
			else
			{
				if (JobSetChange)
					Logging.Write(LogColor, "[Crystal Hunter] Left job as {0}, no gear set defined for zone {1}", Core.Me.CurrentJob, GetZoneNameViaZoneId(GrindLocationId));
			}
        }
	}
}