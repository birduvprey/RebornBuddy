using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Scholar : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (Ultima.UltSettings.SmartTarget)
            {
                if (await BioII()) return true;
                if (await Miasma()) return true;
                if (await Bio()) return true;
                if (await Aero()) return true;
                if (await MiasmaII()) return true;
                if (await Aetherflow()) return true;
                if (await Bane()) return true;
                if (await EnergyDrain()) return true;
                if (await ShadowFlare()) return true;
                if (await Rouse()) return true;
                if (await RuinII()) return true;
                return await Ruin();
            }
            if (Ultima.UltSettings.SingleTarget)
            {
                if (await BioII()) return true;
                if (await Miasma()) return true;
                if (await Bio()) return true;
                if (await Aero()) return true;
                if (await Aetherflow()) return true;
                if (await EnergyDrain()) return true;
                if (await ShadowFlare()) return true;
                if (await Rouse()) return true;
                if (await RuinII()) return true;
                return await Ruin();
            }
            if (Ultima.UltSettings.MultiTarget)
            {
                if (await BioII()) return true;
                if (await Miasma()) return true;
                if (await Bio()) return true;
                if (await Aero()) return true;
                if (await MiasmaII()) return true;
                if (await Aetherflow()) return true;
                if (await Bane()) return true;
                if (await EnergyDrain()) return true;
                if (await ShadowFlare()) return true;
                if (await Rouse()) return true;
                if (await RuinII()) return true;
                return await Ruin();
            }
            return false;
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}