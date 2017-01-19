using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Lancer : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (Ultima.UltSettings.SmartTarget)
            {
                if (await RingOfThorns()) return true;
                if (await DoomSpike()) return true;
                if (await FullThrust()) return true;
                if (await VorpalThrust()) return true;
                if (await ChaosThrust()) return true;
                if (await Disembowel()) return true;
                if (await HeavyThrust()) return true;
                if (await ImpulseDrive()) return true;
                if (await Phlebotomize()) return true;
                return await TrueThrust();
            }
            if (Ultima.UltSettings.SingleTarget)
            {
                if (await FullThrust()) return true;
                if (await VorpalThrust()) return true;
                if (await ChaosThrust()) return true;
                if (await Disembowel()) return true;
                if (await HeavyThrust()) return true;
                if (await ImpulseDrive()) return true;
                if (await Phlebotomize()) return true;
                return await TrueThrust();
            }
            if (Ultima.UltSettings.MultiTarget)
            {
                if (await RingOfThorns()) return true;
                if (await HeavyThrust()) return true;
                return await DoomSpike();
            }
            return false;
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}