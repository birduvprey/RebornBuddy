using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Navigation;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UltimaCR.Rotations
{
    public sealed partial class BlackMage
    {
        public override async Task<bool> Rest()
        {
            if (!WorldManager.InSanctuary &&
                !Core.Player.HasAura("Sprint"))
            {
                if (Core.Player.CurrentHealthPercent < 70)
                {
                    if (MovementManager.IsMoving)
                    {
                        Navigator.PlayerMover.MoveStop();
                    }
                    Logging.Write(Colors.Yellow, @"[Ultima] Resting...");
                    return true;
                }
            }
            return false;
        }
    }
}