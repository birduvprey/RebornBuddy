using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class DarkKnight : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (await SyphonStrike()) return true;
            if (await Delirium()) return true;
            if (await Souleater()) return true;
            if (await CarveAndSplit()) return true;
            if (await Unmend()) return true;
            if (await Unleash()) return true;
            if (await Scourge()) return true;
            return await HardSlash();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}