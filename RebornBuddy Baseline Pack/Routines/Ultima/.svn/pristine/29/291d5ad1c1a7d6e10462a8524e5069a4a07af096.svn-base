using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Rogue : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (Ultima.UltSettings.SmartTarget)
            {
                if (await Invigorate()) return true;
                if (await InternalRelease()) return true;
                if (await BloodForBlood()) return true;
                if (await DancingEdge()) return true;
                if (await AeolianEdge()) return true;
                if (await ShadowFang()) return true;
                if (await GustSlash()) return true;
                if (await Mutilate()) return true;
                if (await Mug()) return true;
                if (await Jugulate()) return true;
                if (await Assassinate()) return true;
                if (await Goad()) return true;
                if (await DeathBlossom()) return true;
                return await SpinningEdge();
            }
            if (Ultima.UltSettings.SingleTarget)
            {
                if (await Invigorate()) return true;
                if (await InternalRelease()) return true;
                if (await BloodForBlood()) return true;
                if (await DancingEdge()) return true;
                if (await AeolianEdge()) return true;
                if (await ShadowFang()) return true;
                if (await GustSlash()) return true;
                if (await Mutilate()) return true;
                if (await Mug()) return true;
                if (await Jugulate()) return true;
                if (await Assassinate()) return true;
                if (await Goad()) return true;
                return await SpinningEdge();
            }
            if (Ultima.UltSettings.MultiTarget)
            {
                if (await Invigorate()) return true;
                if (await InternalRelease()) return true;
                if (await BloodForBlood()) return true;
                if (await Mug()) return true;
                if (await Jugulate()) return true;
                if (await Assassinate()) return true;
                if (await Goad()) return true;
                return await DeathBlossom();
            }
            return false;
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}