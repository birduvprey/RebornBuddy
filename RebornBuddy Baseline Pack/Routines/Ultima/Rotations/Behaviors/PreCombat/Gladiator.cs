using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Gladiator
    {
        public override async Task<bool> PreCombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await Protect()) return true;
            return await Stoneskin();
        }
    }
}