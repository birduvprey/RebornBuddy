using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ProtoBuf;

namespace Zekken
{
    public class ShapeCompiler
    {
        public class BadFile : System.Exception
        {
            public string Path { get; set; }

            public BadFile(
                string path)
            {
                Path = path;
            }
        }

        private static XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<XSpellShape>));

        public static bool CompileShapes()
        {
            if (!FileTools.PrepareDirectory(Directories.DEFAULT_SHAPES_DIR)) 
            {
                Logger.WriteError("The spell database directory {0} was inaccessible. Spell database is unchanged.", Directories.DEFAULT_SHAPES_DIR);

                return false;
            }

            var files = GetXmlFilesFrom(Directories.DEFAULT_SHAPES_DIR).ToList();

            if (files.Count == 0)
            {
                Logger.WriteError("No shape data files were found in the spell database directory {0}. Spell database is unchanged.", Directories.DEFAULT_SHAPES_DIR);

                return false;
            }

            try
            {
                foreach (var file in files) 
                { 
                    CleanFile(file); 
                }
            }
            catch (BadFile e)
            {
                Logger.WriteError("Failed to clean spell shape data file: {0}. Spell database is unchanged.", e.Path);

                return false;
            }

            List<XSpellShape> shapes = null;

            try
            {
                shapes = files.SelectMany(LoadShapes).ToList();
            }
            catch (BadFile e)
            {
                Logger.WriteError("Failed to load spell shape data file: {0}. Spell database is unchanged.", e.Path);

                return false;
            }

            foreach (var shape in shapes)
            {
                shape.Flags = shape.Flags.Distinct().ToList();
            }

            List<XSpellShape> purgedShapes = GetPurgedShapes(shapes).OrderBy(s => s.Id).ToList();

            try
            {
                Save(
                    Directories.DEFAULT_XDB_PATH, 
                    purgedShapes);
            }
            catch (BadFile e)
            {
                Logger.WriteError("Failed to save spell shape data file: {0}. Spell database is unchanged", e.Path);

                return false;
            }

            try
            {
                var compiledData = new ConcurrentDictionary<uint, SpellShape>();

                foreach (
                    var shape in purgedShapes) 
                { 
                    compiledData[shape.Id] = shape.GetShape();
                }

                Save(
                    compiledData);
            }
            catch (BadFile e)
            {
                Logger.WriteError("Failed to save spell shape binary file: {0}. Spell database is in an inconsistent state.", e.Path);

                return false;
            }

            foreach (var file in files)
            {
                if (!file.Equals(Directories.DEFAULT_XDB_PATH))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch
                    {
                        Logger.WriteError("Failed to delete spell shape data file: {0}.", file);
                    }
                }
            }

            Logger.WriteMessage("Finished compiling {0} spell shapes. New spell database was sucessfully created.", purgedShapes.Count);

            return true;
        }

        public ConcurrentDictionary<uint, SpellShape> Load()
        {
            return Load(Directories.DEFAULT_DATA_PATH);
        }

        public ConcurrentDictionary<uint, SpellShape> Load(string path)
        {
            if (!FileTools.PrepareLoad(path))
            { 
                throw new BadFile(path); 
            }

            ConcurrentDictionary<uint, SpellShape> loadedShapes = null;

            try
            {
                using  (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    loadedShapes = Serializer.Deserialize<ConcurrentDictionary<uint, SpellShape>>(stream);
                }
            }
            catch
            {
                throw new BadFile(path); 
            }

            return loadedShapes;
        }

        public static void Save(ConcurrentDictionary<uint, SpellShape> data)
        {
            Save(
                Directories.DEFAULT_DATA_PATH, 
                data);
        }

        public static void Save(string path, ConcurrentDictionary<uint, SpellShape> shapeData)
        {
			if (!FileTools.Save(path,shapeData,(stream,data)=>{Serializer.Serialize(stream,data);}))
			{
				throw new BadFile(path);				
			}
			
            Logger.WriteMessage("Saved spell shape database binary data to: {0}", path);
        }

        public static List<XSpellShape> LoadShapes(string path)
        {
            List<XSpellShape> shapes = null;

            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    shapes = (List<XSpellShape>)xmlSerializer.Deserialize(stream);
                }
            }
            catch
            {
                throw new BadFile(path);
            }

            return shapes;
        }

        public static void Save(string path, List<XSpellShape> shapes)
        {
			if (!FileTools.Save(path,shapes,(stream,data)=>{xmlSerializer.Serialize(stream, data);}))
			{
				throw new BadFile(path);				
			}
			
            Logger.WriteMessage("Saved spell shape database xml data to: {0}", path);
 		}

        public static IEnumerable<string> GetXmlFilesFrom(string directory)
        {
            try
            {
                return Directory.EnumerateFiles(directory, "*.xml");
            }
            catch
            {
                Logger.WriteError("Failed to enumerate spell shape data files in directory: {0}.", directory);
            }

            return new List<string>();
        }

        public static void Merge(XSpellShape a, XSpellShape b)
        {
            foreach (var flag in b.Flags) { a.Flags.Add(flag); }
        }

        public static List<XSpellShape> GetPurgedShapes(IEnumerable<XSpellShape> shapes)
        {
            var purgedShapes = new List<XSpellShape>();

            foreach (var shape in shapes)
            {
                var repeated = purgedShapes.FirstOrDefault(s => s.Id == shape.Id);

                if (repeated != null) 
                { 
                    repeated.MergeWith(shape); 
                }
                else 
                {
                    purgedShapes.Add(shape); 
                }
            }

            return purgedShapes;
        }

        public static void CleanFile(string path)
        {
            try
            {
                var text = File.ReadAllText(path);

                text = text.Replace("AngleSmall", "WidthSmall");
                text = text.Replace("AngleMedium", "WidthMedium");
                text = text.Replace("AngleLarge", "WidthLarge");
                text = text.Replace("HeightSmall", "ReachSmall");
                text = text.Replace("HeightMedium", "ReachMedium");
                text = text.Replace("HeightLarge", "ReachLarge");
                text = text.Replace("RadiusSmall", "ReachSmall");
                text = text.Replace("RadiusMedium", "ReachMedium");
                text = text.Replace("RadiusLarge", "ReachLarge");
                text = text.Replace("<Flags>TargetedOnOther</Flags>", "TargetedOnRandom");

                File.WriteAllText(path, text);
            }
            catch 
            {
                throw new BadFile(path);
            }
        }
    }
}