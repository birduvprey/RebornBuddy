using ff14bot;
using ff14bot.Managers;
using System.Linq;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Paladin
    {
        private PaladinSpells _mySpells;

        private PaladinSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new PaladinSpells()); }
        }

        #region Class Spells

        private async Task<bool> FastBlade()
        {
            return await MySpells.FastBlade.Cast();
        }

        private async Task<bool> Rampart()
        {
            return await MySpells.Rampart.Cast();
        }

        private async Task<bool> SavageBlade()
        {
            if (Actionmanager.LastSpell.Name == MySpells.FastBlade.Name)
            {
                return await MySpells.SavageBlade.Cast();
            }
            return false;
        }

        private async Task<bool> FightOrFlight()
        {
            return await MySpells.FightOrFlight.Cast();
        }

        private async Task<bool> Flash()
        {
            return await MySpells.Flash.Cast();
        }

        private async Task<bool> Convalescence()
        {
            return await MySpells.Convalescence.Cast();
        }

        private async Task<bool> RiotBlade()
        {
            return await MySpells.RiotBlade.Cast();
        }

        private async Task<bool> ShieldLob()
        {
            if (Core.Player.TargetDistance(10))
            {
                return await MySpells.ShieldLob.Cast();
            }
            return false;
        }

        private async Task<bool> ShieldBash()
        {
            return await MySpells.ShieldBash.Cast();
        }

        private async Task<bool> Provoke()
        {
            var target = Helpers.NotTargetingPlayer.FirstOrDefault();

            if (target != null)
            {
                return await MySpells.Provoke.Cast(target);
            }
            return false;
        }

        private async Task<bool> RageOfHalone()
        {
            if (Actionmanager.LastSpell.Name == MySpells.SavageBlade.Name)
            {
                return await MySpells.RageOfHalone.Cast();
            }
            return false;
        }

        private async Task<bool> ShieldSwipe()
        {
            if (Ultima.UltSettings.PaladinShieldSwipe &&
                Core.Player.CurrentTPPercent > 40)
            {
                return await MySpells.ShieldSwipe.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            return await MySpells.Awareness.Cast();
        }

        private async Task<bool> Sentinel()
        {
            return await MySpells.Sentinel.Cast();
        }

        private async Task<bool> TemperedWill()
        {
            return await MySpells.TemperedWill.Cast();
        }

        private async Task<bool> Bulwark()
        {
            return await MySpells.Bulwark.Cast();
        }

        private async Task<bool> CircleOfScorn()
        {
            return await MySpells.CircleOfScorn.Cast();
        }

        #endregion

        #region Cross Class Spells

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.PaladinCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.PaladinProtect &&
                !Core.Player.HasAura(MySpells.CrossClass.Protect.Name))
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.PaladinRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.PaladinStoneskin &&
                !Core.Player.HasAura(MySpells.CrossClass.Stoneskin.Name))
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.PaladinForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> SkullSunder()
        {
            if (Ultima.UltSettings.PaladinSkullSunder)
            {
                return await MySpells.CrossClass.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (Ultima.UltSettings.PaladinFracture &&
                !Core.Player.CurrentTarget.HasAura(MySpells.CrossClass.Fracture.Name, true, 4000))
            {
                return await MySpells.CrossClass.Fracture.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.PaladinBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.PaladinMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> SwordOath()
        {
            if (Ultima.UltSettings.PaladinSwordOath ||
                !Actionmanager.HasSpell(MySpells.ShieldOath.Name))
            {
                if (!Core.Player.HasAura(MySpells.SwordOath.Name))
                {
                    return await MySpells.SwordOath.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Cover()
        {
            return await MySpells.Cover.Cast();
        }

        private async Task<bool> ShieldOath()
        {
            if (Ultima.UltSettings.PaladinShieldOath &&
                !Core.Player.HasAura(MySpells.ShieldOath.Name))
            {
                return await MySpells.ShieldOath.Cast();
            }
            return false;
        }

        private async Task<bool> SpiritsWithin()
        {
            if (Ultima.UltSettings.PaladinSpiritsWithin)
            {
                return await MySpells.SpiritsWithin.Cast();
            }
            return false;
        }

        private async Task<bool> HallowedGround()
        {
            return await MySpells.HallowedGround.Cast();
        }

        private async Task<bool> Sheltron()
        {
            return await MySpells.Sheltron.Cast();
        }

        private async Task<bool> GoringBlade()
        {
            return await MySpells.GoringBlade.Cast();
        }

        private async Task<bool> DivineVeil()
        {
            return await MySpells.DivineVeil.Cast();
        }

        private async Task<bool> Clemency()
        {
            return await MySpells.Clemency.Cast();
        }

        private async Task<bool> RoyalAuthority()
        {
            return await MySpells.RoyalAuthority.Cast();
        }

        #endregion

        #region PvP Spells

        private async Task<bool> Enliven()
        {
            return await MySpells.PvP.Enliven.Cast();
        }

        private async Task<bool> FullSwing()
        {
            return await MySpells.PvP.FullSwing.Cast();
        }

        private async Task<bool> GlorySlash()
        {
            return await MySpells.PvP.GlorySlash.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        private async Task<bool> Testudo()
        {
            return await MySpells.PvP.Testudo.Cast();
        }

        #endregion
    }
}