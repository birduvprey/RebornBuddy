using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Conjurer
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await ShroudOfSaints()) return true;
            return await Protect();
        }
    }
}