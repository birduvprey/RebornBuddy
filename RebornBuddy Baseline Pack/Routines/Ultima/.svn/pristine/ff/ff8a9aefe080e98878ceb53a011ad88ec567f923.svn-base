using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Ninja
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await KissOfTheViper()) return true;
            return await KissOfTheWasp();
        }
    }
}