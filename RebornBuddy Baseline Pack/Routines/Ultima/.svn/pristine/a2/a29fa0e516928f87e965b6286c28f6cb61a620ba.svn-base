using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Monk : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (Ultima.UltSettings.SmartTarget)
            {
                if (await TouchOfDeath()) return true;
                if (await PerfectBalance()) return true;
                if (await Rockbreaker()) return true;
                if (await Demolish()) return true;
                if (await SnapPunch()) return true;
                if (await TwinSnakes()) return true;
                if (await DragonKick()) return true;
                if (await TrueStrike()) return true;
                if (await Meditation()) return true;
                return await Bootshine();
            }
            if (Ultima.UltSettings.SingleTarget)
            {
                if (await TouchOfDeath()) return true;
                if (await PerfectBalance()) return true;
                if (await Demolish()) return true;
                if (await SnapPunch()) return true;
                if (await TwinSnakes()) return true;
                if (await DragonKick()) return true;
                if (await TrueStrike()) return true;
                if (await Meditation()) return true;
                return await Bootshine();
            }
            if (Ultima.UltSettings.MultiTarget)
            {
                if (await TouchOfDeath()) return true;
                if (await PerfectBalance()) return true;
                if (await Rockbreaker()) return true;
                if (await TwinSnakes()) return true;
                if (await DragonKick()) return true;
                if (await TrueStrike()) return true;
                if (await Meditation()) return true;
                return await Bootshine();
            }
            return false;

        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}