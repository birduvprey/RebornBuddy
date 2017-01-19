using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Bard
    {
        private BardSpells _mySpells;

        private BardSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new BardSpells()); }
        }

        #region Class Spells

        private async Task<bool> HeavyShot()
        {
            return await MySpells.HeavyShot.Cast();
        }

        private async Task<bool> StraightShot()
        {
            if (Core.Player.HasAura("Straighter Shot") ||
                !Core.Player.HasAura(MySpells.StraightShot.Name, true, 4000))
            {
                return await MySpells.StraightShot.Cast();
            }
            return false;
        }

        private async Task<bool> RagingStrikes()
        {
            return await MySpells.RagingStrikes.Cast();
        }

        private async Task<bool> VenomousBite()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.VenomousBite.Name, true, 4000))
            {
                return await MySpells.VenomousBite.Cast();
            }
            return false;
        }

        private async Task<bool> MiserysEnd()
        {
            if (Ultima.UltSettings.BardMiserysEnd)
            {
                return await MySpells.MiserysEnd.Cast();
            }
            return false;
        }

        private async Task<bool> Shadowbind()
        {
            return await MySpells.Shadowbind.Cast();
        }

        private async Task<bool> Bloodletter()
        {
            return await MySpells.Bloodletter.Cast();
        }

        private async Task<bool> RepellingShot()
        {
            if (Core.Player.TargetDistance(5, false))
            {
                return await MySpells.RepellingShot.Cast();
            }
            return false;
        }

        private async Task<bool> QuickNock()
        {
            return await MySpells.QuickNock.Cast();
        }

        private async Task<bool> Swiftsong()
        {
            if (!Core.Player.InCombat &&
                !Core.Player.HasAura(MySpells.Swiftsong.Name))
            {
                return await MySpells.Swiftsong.Cast();
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            return await MySpells.HawksEye.Cast();
        }

        private async Task<bool> Windbite()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Windbite.Name, true, 4000))
            {
                return await MySpells.Windbite.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            return await MySpells.QuellingStrikes.Cast();
        }

        private async Task<bool> Barrage()
        {
            if (!Actionmanager.HasSpell(MySpells.EmpyrealArrow.Name) &&
                DataManager.GetSpellData(97).Cooldown.TotalMilliseconds <= 1000)
            {
                return await MySpells.Barrage.Cast();
            }
            return false;
        }

        private async Task<bool> BluntArrow()
        {
            if (Ultima.UltSettings.BardBluntArrow)
            {
                return await MySpells.BluntArrow.Cast();
            }
            return false;
        }

        private async Task<bool> FlamingArrow()
        {
            if (Ultima.UltSettings.BardFlamingArrow)
            {
                return await MySpells.FlamingArrow.Cast();
            }
            return false;
        }

        private async Task<bool> WideVolley()
        {
            return await MySpells.WideVolley.Cast();
        }

        #endregion

        #region Cross Class Spells

        #region Lancer

        private async Task<bool> Feint()
        {
            if (Ultima.UltSettings.BardFeint &&
                MovementManager.IsMoving)
            {
                return await MySpells.CrossClass.Feint.Cast();
            }
            return false;
        }

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.BardKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.BardInvigorate &&
                Core.Player.CurrentTP <= 540)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.BardBloodForBlood)
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.BardFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.BardSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Haymaker()
        {
            if (Ultima.UltSettings.BardHaymaker)
            {
                return await MySpells.CrossClass.Haymaker.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.BardInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.BardMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> MagesBallad()
        {
            return await MySpells.MagesBallad.Cast();
        }

        private async Task<bool> FoeRequiem()
        {
            return await MySpells.FoeRequiem.Cast();
        }

        private async Task<bool> ArmysPaeon()
        {
            return await MySpells.ArmysPaeon.Cast();
        }

        private async Task<bool> RainOfDeath()
        {
            if (Ultima.UltSettings.MultiTarget ||
                Ultima.UltSettings.SmartTarget &&
                Helpers.EnemiesNearTarget(8) >= 3)
            {
                return await MySpells.RainOfDeath.Cast();
            }
            return false;
        }

        private async Task<bool> BattleVoice()
        {
            return await MySpells.BattleVoice.Cast();
        }

        private async Task<bool> WanderersMinuet()
        {
            if (Ultima.UltSettings.BardTheWanderersMinuet)
            {
                if (!Core.Player.HasAura(865))
                {
                    return await MySpells.WanderersMinuet.Cast();
                }
            }
            return false;
        }

        private async Task<bool> EmpyrealArrow()
        {
            if (Core.Player.HasAura(MySpells.StraightShot.Name, true, 4000) &&
                Core.Player.CurrentTarget.HasAura(MySpells.VenomousBite.Name, true, 4000) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Windbite.Name, true, 4000) &&
                DataManager.GetSpellData(97).Cooldown.TotalMilliseconds <= 700)
            {
                if (Actionmanager.CanCast(MySpells.EmpyrealArrow.Name, Core.Player.CurrentTarget))
                {
                    if (await MySpells.Barrage.Cast())
                    {
                        await Coroutine.Wait(3000, () => Actionmanager.CanCast(MySpells.EmpyrealArrow.Name, Core.Player.CurrentTarget));
                    }
                }
                return await MySpells.EmpyrealArrow.Cast();
            }
            return false;
        }

        private async Task<bool> IronJaws()
        {
            if (Core.Player.CurrentTarget.HasAura(MySpells.VenomousBite.Name, true) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Windbite.Name, true))
            {
                if (!Core.Player.CurrentTarget.HasAura(MySpells.VenomousBite.Name, true, 5000) ||
                    !Core.Player.CurrentTarget.HasAura(MySpells.Windbite.Name, true, 5000))
                {
                    return await MySpells.IronJaws.Cast();
                }
            }
            return false;
        }

        private async Task<bool> TheWardensPaean()
        {
            return await MySpells.TheWardensPaean.Cast();
        }

        private async Task<bool> Sidewinder()
        {
            if (Core.Player.CurrentTarget.HasAura(MySpells.VenomousBite.Name, true, 4000) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Windbite.Name, true, 4000))
            {
                return await MySpells.Sidewinder.Cast();
            }
            return false;
        }

        #endregion

        #region PvP Spells

        private async Task<bool> BlastShot()
        {
            return await MySpells.PvP.BlastShot.Cast();
        }

        private async Task<bool> Farshot()
        {
            return await MySpells.PvP.Farshot.Cast();
        }

        private async Task<bool> ManaDraw()
        {
            return await MySpells.PvP.ManaDraw.Cast();
        }

        private async Task<bool> Manasong()
        {
            return await MySpells.PvP.Manasong.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        #endregion
    }
}