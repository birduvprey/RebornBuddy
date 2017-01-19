using System;
using System.IO;
using System.Runtime.Serialization;

namespace Zekken
{
    internal static class FileTools
    {
        public static bool PrepareDirectory(string directory)
        {
            if (Directory.Exists(directory)) { return true; }

            try { Directory.CreateDirectory(directory); }
            catch
            {
                Logger.WriteError("Failed to create directory: {0}.", directory);
                return false;
            }

            return true;
        }

        public static bool PrepareLoad(string path)
        {
            if (File.Exists(path)) { return true; }
            Logger.WriteError("Cannot find file: {0}", path);
            return false;
        }

        public static bool PrepareSave(string path,string tempPath)
        {
            var fileInfo = new FileInfo(path);

            if (fileInfo.Directory == null)
            {
                Logger.WriteError("No directory specified for file: {0}.", path);
                return false;
            }

            if (!PrepareDirectory(fileInfo.Directory.FullName)) 
			{ 
				return false; 
			}
			
            if (!fileInfo.Exists)
			{
				return true; 
			}
			
            try 
			{
				if (File.Exists(tempPath))
				{
					File.Delete(tempPath);
				}
				
				Rename(
					path,
					tempPath);
			}
            catch
            {
                Logger.WriteError("Failed to create temporary file: {0}.", tempPath);
                return false;
            }

            return true;
        }
		
		public static void Rename(string currentName,string newName)
		{
			try
			{
				File.Move(currentName, newName);
			}
			catch
			{
				Logger.WriteError("Failed to rename file: {0} to: {1}.", currentName,newName);
			}
		}
		
		public static bool Save<T>(string path,T data,Action<FileStream,T> writer)
		{
            string tempPath = path + "~";

            if (!FileTools.PrepareSave(path,tempPath)) 
            {
                return false;
            }

            try
            {
                using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
					writer(stream,data);
                }
            }
            catch
            {
				FileTools.Rename(
					tempPath,
					path);
					
                return false;
            }
			
			File.Delete(
				tempPath);
				
			return true;
		}
    }
}
