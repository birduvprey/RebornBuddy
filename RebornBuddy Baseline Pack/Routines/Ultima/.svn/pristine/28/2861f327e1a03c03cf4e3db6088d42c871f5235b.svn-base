using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Warrior
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await InternalRelease()) return true;
            if (await Berserk()) return true;
            if (await BrutalSwing()) return true;
            return await MercyStroke();
        }
    }
}