using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class WhiteMage
    {
        public override async Task<bool> Heal()
        {
            if (await Benediction()) return true;
            if (await Tetragrammaton()) return true;
            if (await Regen()) return true;
            if (await MedicaII()) return true;
            if (await Medica()) return true;
            if (await CureIII()) return true;
            if (await CureII()) return true;
            if (await Raise()) return true;
            return await Cure();
        }
    }
}