using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Summoner
    {
        public override async Task<bool> Pull()
        {
            if (await Bio()) return true;
            return await Combat();
        }
    }
}