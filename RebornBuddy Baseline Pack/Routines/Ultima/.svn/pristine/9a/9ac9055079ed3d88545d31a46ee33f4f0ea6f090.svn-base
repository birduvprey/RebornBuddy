using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Warrior
    {
        public override async Task<bool> Pull()
        {
            if (await Tomahawk()) return true;
            return await Combat();
        }
    }
}