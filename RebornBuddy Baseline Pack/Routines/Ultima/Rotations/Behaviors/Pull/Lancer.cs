using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Lancer
    {
        public override async Task<bool> Pull()
        {
            if (await PiercingTalon()) return true;
            return await Combat();
        }
    }
}