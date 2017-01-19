using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Pugilist
    {
        public override async Task<bool> PreCombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await FistsOfWind()) return true;
            return await FistsOfEarth();
        }
    }
}