using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Gladiator
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await FightOrFlight()) return true;
            if (await ShieldSwipe()) return true;
            if (await CircleOfScorn()) return true;
            return await MercyStroke();
        }
    }
}