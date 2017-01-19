using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class BlackMage : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (Ultima.UltSettings.SmartTarget)
            {
                if (await Flare()) return true;
                if (await Firestarter()) return true;
                if (await Thundercloud()) return true;
                if (await Scathe()) return true;
                if (await ThunderIII()) return true;
                if (await Thunder()) return true;
                if (await BlizzardIII()) return true;
                if (await FireIII()) return true;
                if (await Blizzard()) return true;
                if (await Swiftcast()) return true;
                if (await FireII()) return true;
                return await Fire();
            }
            if (Ultima.UltSettings.SingleTarget)
            {
                if (await Firestarter()) return true;
                if (await Thundercloud()) return true;
                if (await Flare()) return true;
                if (await Scathe()) return true;
                if (await ThunderIII()) return true;
                if (await Thunder()) return true;
                if (await BlizzardIII()) return true;
                if (await FireIII()) return true;
                if (await Blizzard()) return true;
                if (await Swiftcast()) return true;
                return await Fire();
            }
            if (Ultima.UltSettings.MultiTarget)
            {
                if (await Flare()) return true;
                if (await Firestarter()) return true;
                if (await Thundercloud()) return true;
                if (await Scathe()) return true;
                if (await ThunderIII()) return true;
                if (await Thunder()) return true;
                if (await BlizzardIII()) return true;
                if (await FireIII()) return true;
                if (await Blizzard()) return true;
                if (await Swiftcast()) return true;
                return await FireII();
            }
            return false;
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}