using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Rogue
    {
        public override async Task<bool> Pull()
        {
            if (await ThrowingDagger()) return true;
            return await Combat();
        }
    }
}