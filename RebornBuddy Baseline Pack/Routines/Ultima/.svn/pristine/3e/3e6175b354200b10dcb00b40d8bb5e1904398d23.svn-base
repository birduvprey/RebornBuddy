using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Arcanist
    {
        public override async Task<bool> Heal()
        {
            if (await Sustain()) return true;
            return await Physick();
        }
    }
}