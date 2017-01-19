using System.Collections.Concurrent;
using System.IO;
using ProtoBuf;

namespace Zekken
{
    public class ShapeDatabase
    {
        private ConcurrentDictionary<uint, SpellShape> shapes = new ConcurrentDictionary<uint, SpellShape>();

        public bool Load()
        {
            return Load(Directories.DEFAULT_DATA_PATH);
        }

        public bool Load(string path)
        {
            if (!FileTools.PrepareLoad(path)) 
            {
                if (ShapeCompiler.CompileShapes() && !FileTools.PrepareLoad(path))
                {
                    Logger.WriteError("Failed to load spell shape data from: {0}.", path);

                    return false;
                }
            }

            ConcurrentDictionary<uint, SpellShape> loadedShapes = null;

            try
            {
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    loadedShapes = Serializer.Deserialize<ConcurrentDictionary<uint, SpellShape>>(stream);
                }
            }
            catch
            {
                Logger.WriteError("Failed to load spell shape data from: {0}.", path);

                return false;
            }

            shapes = loadedShapes;
            Logger.WriteMessage("Loaded spell shape data from: {0}.", path);

            return true;
        }

        public bool Save()
        {
            return Save(Directories.DEFAULT_DATA_PATH);
        }

        public bool Save(string path)
        {
			if (!FileTools.Save(path,shapes,(stream,data)=>{Serializer.Serialize(stream, data);}))
			{
				Logger.WriteError("Failed to save spell shape data to: {0}.", path);
				
				return false;
			}

            Logger.WriteMessage("Saved spell shape data to: {0}", path);

            return true;
        }

        public bool TryGetShape(uint spellId, out SpellShape shape)
        {
            return shapes.TryGetValue(spellId, out shape);
        }

        public void SetShape(uint spellId, SpellShape shape)
        {
            shapes[spellId] = shape;
        }

        public bool Contains(uint spellId)
        {
            return shapes.ContainsKey(spellId);
        }
    }
}
