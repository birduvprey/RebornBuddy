using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Warrior : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (await StormsEye()) return true;
            if (await StormsPath()) return true;
            if (await Maim()) return true;
            if (await ButchersBlock()) return true;
            if (await SkullSunder()) return true;
            return await HeavySwing();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}