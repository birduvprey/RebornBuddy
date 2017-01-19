using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Archer
    {
        private ArcherSpells _mySpells;

        private ArcherSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new ArcherSpells()); }
        }

        #region Class Spells

        private async Task<bool> HeavyShot()
        {
            return await MySpells.HeavyShot.Cast();
        }

        private async Task<bool> StraightShot()
        {
            if (Core.Player.HasAura("Straighter Shot") ||
                !Core.Player.HasAura(MySpells.StraightShot.Name))
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
            if (Ultima.UltSettings.ArcherMiserysEnd)
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
            if (Core.Player.HasAura(MySpells.CrossClass.BloodForBlood.Name))
            {
                return await MySpells.HawksEye.Cast();
            }
            if (!Actionmanager.HasSpell(MySpells.CrossClass.BloodForBlood.Name))
            {
                return await MySpells.HawksEye.Cast();
            }
            return false;
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
            return await MySpells.Barrage.Cast();
        }

        private async Task<bool> BluntArrow()
        {
            if (Ultima.UltSettings.ArcherBluntArrow)
            {
                return await MySpells.BluntArrow.Cast();
            }
            return false;
        }

        private async Task<bool> FlamingArrow()
        {
            if (Ultima.UltSettings.ArcherFlamingArrow)
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

        #region Arcanist

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.ArcherPhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.ArcherVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.ArcherEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.ArcherCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.ArcherProtect)
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.ArcherRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.ArcherStoneskin)
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Gladiator

        private async Task<bool> SavageBlade()
        {
            if (Ultima.UltSettings.ArcherSavageBlade)
            {
                return await MySpells.CrossClass.SavageBlade.Cast();
            }
            return false;
        }

        private async Task<bool> Flash()
        {
            if (Ultima.UltSettings.ArcherFlash)
            {
                return await MySpells.CrossClass.Flash.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Ultima.UltSettings.ArcherConvalescence)
            {
                return await MySpells.CrossClass.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Provoke()
        {
            if (Ultima.UltSettings.ArcherProvoke)
            {
                return await MySpells.CrossClass.Provoke.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Ultima.UltSettings.ArcherAwareness)
            {
                return await MySpells.CrossClass.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Lancer

        private async Task<bool> Feint()
        {
            if (Ultima.UltSettings.ArcherFeint)
            {
                return await MySpells.CrossClass.Feint.Cast();
            }
            return false;
        }

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.ArcherKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.ArcherInvigorate &&
                Core.Player.CurrentTP <= 540)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.ArcherBloodForBlood)
            {
                if (Actionmanager.HasSpell(MySpells.Barrage.Name) &&
                    Actionmanager.CanCast(MySpells.HawksEye.Name, Core.Player) &&
                    Actionmanager.CanCast(MySpells.Barrage.Name, Core.Player))
                {
                    return await MySpells.CrossClass.BloodForBlood.Cast();
                }
                if (!Actionmanager.HasSpell(MySpells.Barrage.Name))
                {
                    return await MySpells.CrossClass.BloodForBlood.Cast();
                }
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.ArcherForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> SkullSunder()
        {
            if (Ultima.UltSettings.ArcherSkullSunder)
            {
                return await MySpells.CrossClass.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (Ultima.UltSettings.ArcherFracture)
            {
                return await MySpells.CrossClass.Fracture.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.ArcherBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.ArcherMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.ArcherFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.ArcherSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Haymaker()
        {
            if (Ultima.UltSettings.ArcherHaymaker)
            {
                return await MySpells.CrossClass.Haymaker.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.ArcherInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.ArcherMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #region Rogue

        private async Task<bool> ShadeShift()
        {
            if (Ultima.UltSettings.ArcherShadeShift)
            {
                return await MySpells.CrossClass.ShadeShift.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.ArcherSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.ArcherSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

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