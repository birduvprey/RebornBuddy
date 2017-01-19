using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Astrologian
    {
        public override async Task<bool> Heal()
        {
            if (await EssentialDignity()) return true;
            if (await AspectedBenefic()) return true;
            if (await BeneficII()) return true;
            return await Benefic();
        }
    }
}