using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class BlackMage
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await Transpose()) return true;
            return await RagingStrikes();
        }
    }
}