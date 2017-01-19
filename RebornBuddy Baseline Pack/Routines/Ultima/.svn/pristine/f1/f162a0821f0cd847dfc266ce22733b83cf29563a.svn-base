using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Bard
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await WanderersMinuet()) return true;
            if (await Invigorate()) return true;
            if (await RagingStrikes()) return true;
            if (await HawksEye()) return true;
            if (await BloodForBlood()) return true;
            if (await InternalRelease()) return true;
            if (await Barrage()) return true;
            if (await FlamingArrow()) return true;
            if (await Sidewinder()) return true;
            if (await BluntArrow()) return true;
            if (await MiserysEnd()) return true;
            if (await RainOfDeath()) return true;
            return await Bloodletter();
        }
    }
}