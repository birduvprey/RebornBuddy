using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Paladin
    {
        public override async Task<bool> Pull()
        {
            if (await ShieldLob()) return true;
            return await Combat();
        }
    }
}