using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Ninja
    {
        public override async Task<bool> Pull()
        {
            if (await Ninjutsu()) return true;
            if (await ThrowingDagger()) return true;
            return await Combat();
        }
    }
}