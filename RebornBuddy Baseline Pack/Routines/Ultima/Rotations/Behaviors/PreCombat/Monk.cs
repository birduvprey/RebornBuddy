using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Monk
    {
        public override async Task<bool> PreCombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await FistsOfFire()) return true;
            if (await FistsOfWind()) return true;
            if (await FistsOfEarth()) return true;
            return await Meditation();
        }
    }
}