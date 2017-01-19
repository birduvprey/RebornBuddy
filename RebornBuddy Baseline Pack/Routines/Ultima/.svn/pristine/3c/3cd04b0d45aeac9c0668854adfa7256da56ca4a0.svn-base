using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Lancer
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await Invigorate()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await LegSweep()) return true;
            return await MercyStroke();
        }
    }
}