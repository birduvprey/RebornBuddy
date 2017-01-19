using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Astrologian
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await LuminiferousAether()) return true;
            if (await Play()) return true;
            return await Draw();
        }
    }
}