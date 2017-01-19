using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Archer
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await Invigorate()) return true;
            if (await RagingStrikes()) return true;
            if (await InternalRelease()) return true;
            if (await BloodForBlood()) return true;
            if (await HawksEye()) return true;
            if (await Barrage()) return true;
            if (await BluntArrow()) return true;
            if (await MiserysEnd()) return true;
            return await Bloodletter();
        }
    }
}