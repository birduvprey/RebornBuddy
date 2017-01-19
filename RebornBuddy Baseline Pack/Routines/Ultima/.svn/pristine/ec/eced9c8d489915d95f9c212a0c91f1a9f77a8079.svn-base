using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Ninja : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (Ultima.UltSettings.SmartTarget)
            {
                if (await Huton()) return true;
                if (await Doton()) return true;
                if (await Suiton()) return true;
                if (await TrickAttack()) return true;
                if (await SneakAttack()) return true;
                if (await Kassatsu()) return true;
                if (await Katon()) return true;
                if (await Raiton()) return true;
                if (await FumaShuriken()) return true;
                if (await Invigorate()) return true;
                if (await InternalRelease()) return true;
                if (await BloodForBlood()) return true;
                if (await Shukuchi()) return true;
                if (await ArmorCrush()) return true;
                if (await DancingEdge()) return true;
                if (await AeolianEdge()) return true;
                if (await ShadowFang()) return true;
                if (await GustSlash()) return true;
                if (await Mutilate()) return true;
                if (await DreamWithinADream()) return true;
                if (await Mug()) return true;
                if (await Jugulate()) return true;
                if (await Assassinate()) return true;
                if (await Goad()) return true;
                if (await DeathBlossom()) return true;
                return await SpinningEdge();
            }
            if (Ultima.UltSettings.SingleTarget)
            {
                if (await Huton()) return true;
                if (await Suiton()) return true;
                if (await TrickAttack()) return true;
                if (await SneakAttack()) return true;
                if (await Kassatsu()) return true;
                if (await Raiton()) return true;
                if (await FumaShuriken()) return true;
                if (await Invigorate()) return true;
                if (await InternalRelease()) return true;
                if (await BloodForBlood()) return true;
                if (await Shukuchi()) return true;
                if (await ArmorCrush()) return true;
                if (await DancingEdge()) return true;
                if (await AeolianEdge()) return true;
                if (await ShadowFang()) return true;
                if (await GustSlash()) return true;
                if (await Mutilate()) return true;
                if (await DreamWithinADream()) return true;
                if (await Mug()) return true;
                if (await Jugulate()) return true;
                if (await Assassinate()) return true;
                if (await Goad()) return true;
                return await SpinningEdge();
            }
            if (Ultima.UltSettings.MultiTarget)
            {
                if (await Huton()) return true;
                if (await Doton()) return true;
                if (await Kassatsu()) return true;
                if (await Katon()) return true;
                if (await Invigorate()) return true;
                if (await InternalRelease()) return true;
                if (await BloodForBlood()) return true;
                if (await Shukuchi()) return true;
                if (await Duality()) return true;
                if (await DreamWithinADream()) return true;
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