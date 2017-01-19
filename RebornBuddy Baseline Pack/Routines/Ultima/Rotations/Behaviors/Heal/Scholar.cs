using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Scholar
    {
        public override async Task<bool> Heal()
        {
            if (await Sustain()) return true;
            if (await Adloquium()) return true;
            return await Physick();
        }
    }
}