using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class BlackMage
    {
        public override async Task<bool> Pull()
        {
            if (!LowMP)
            {
                if (await MySpells.Scathe.Cast()) return true;
            }
            return await Combat();
        }
    }
}