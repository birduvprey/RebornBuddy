using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Machinist : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (await Feint()) return true;
            if (await HotShot()) return true;
            if (await LeadShot()) return true;
            if (await CleanShot()) return true;
            if (await SlugShot()) return true;
            return await SplitShot();
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}