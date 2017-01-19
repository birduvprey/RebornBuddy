using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Pugilist : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (await TouchOfDeath()) return true;
            if (await PerfectBalance()) return true;
            if (await Demolish()) return true;
            if (await SnapPunch()) return true;
            if (await TwinSnakes()) return true;
            if (await TrueStrike()) return true;
            return await Bootshine();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}