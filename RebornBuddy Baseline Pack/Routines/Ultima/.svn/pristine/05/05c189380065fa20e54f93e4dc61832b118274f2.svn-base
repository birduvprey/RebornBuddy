using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Scholar
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await SummonII()) return true;
            return await Summon();
        }
    }
}