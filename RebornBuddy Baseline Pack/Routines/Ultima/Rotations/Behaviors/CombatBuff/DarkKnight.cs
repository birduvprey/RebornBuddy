using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class DarkKnight
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await Darkside()) return true;
            if (await BloodWeapon()) return true;
            if (await Plunge()) return true;
            if (await Reprisal()) return true;
            if (await LowBlow()) return true;
            if (await SaltedEarth()) return true;
            return await MercyStroke();
        }
    }
}