using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class DarkKnight
    {
        public override async Task<bool> Pull()
        {
            if (await Unmend()) return true;
            return await Combat();
        }
    }
}