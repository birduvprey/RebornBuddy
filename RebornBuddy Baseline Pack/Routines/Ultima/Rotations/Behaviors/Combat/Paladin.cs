using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Paladin : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (await RageOfHalone()) return true;
            if (await SavageBlade()) return true;
            if (await Fracture()) return true;
            return await FastBlade();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}