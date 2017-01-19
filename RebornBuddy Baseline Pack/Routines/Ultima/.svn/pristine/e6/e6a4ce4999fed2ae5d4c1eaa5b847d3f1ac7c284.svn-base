using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Marauder
    {
        private MarauderSpells _mySpells;

        private MarauderSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new MarauderSpells()); }
        }

        #region Class Spells

        private async Task<bool> HeavySwing()
        {
            return await MySpells.HeavySwing.Cast();
        }

        private async Task<bool> Foresight()
        {
            return await MySpells.Foresight.Cast();
        }

        private async Task<bool> SkullSunder()
        {
            if (Actionmanager.LastSpell.Name == MySpells.HeavySwing.Name)
            {
                return await MySpells.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Fracture.Name, true, 4000))
            {
                return await MySpells.Fracture.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            return await MySpells.Bloodbath.Cast();
        }

        private async Task<bool> BrutalSwing()
        {
            if (Ultima.UltSettings.MarauderBrutalSwing)
            {
                return await MySpells.BrutalSwing.Cast();
            }
            return false;
        }

        private async Task<bool> Overpower()
        {
            return await MySpells.Overpower.Cast();
        }

        private async Task<bool> Tomahawk()
        {
            if (Core.Player.TargetDistance(10))
            {
                return await MySpells.Tomahawk.Cast();
            }
            return false;
        }

        private async Task<bool> Maim()
        {
            if (Actionmanager.LastSpell.Name == MySpells.HeavySwing.Name)
            {
                //if (!Core.Player.CurrentTarget.HasAura(MySpells.StormsEye.Name, false, 4000) &&
                //    !Core.Player.CurrentTarget.HasAura("Dancing Edge", false, 4000) ||
                //    !Core.Player.HasAura(MySpells.StormsPath.Name, true, 4000) ||
                if (!Core.Player.HasAura(MySpells.Maim.Name, true, 4000))
                {
                    return await MySpells.Maim.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> Berserk()
        {
            return await MySpells.Berserk.Cast();
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.MarauderMercyStroke)
            {
                return await MySpells.MercyStroke.Cast();
            }
            return false;
        }

        private async Task<bool> ButchersBlock()
        {
            if (Actionmanager.LastSpell.Name == MySpells.SkullSunder.Name)
            {
                return await MySpells.ButchersBlock.Cast();
            }
            return false;
        }

        private async Task<bool> ThrillOfBattle()
        {
            return await MySpells.ThrillOfBattle.Cast();
        }

        private async Task<bool> StormsPath()
        {
            if (Actionmanager.LastSpell.Name == MySpells.Maim.Name)
            {
                return await MySpells.StormsPath.Cast();
            }
            return false;
        }

        private async Task<bool> Holmgang()
        {
            return await MySpells.Holmgang.Cast();
        }

        private async Task<bool> Vengeance()
        {
            return await MySpells.Vengeance.Cast();
        }

        private async Task<bool> StormsEye()
        {
            if (Actionmanager.LastSpell.Name == MySpells.Maim.Name &&
                !Core.Player.CurrentTarget.HasAura(MySpells.StormsEye.Name, false, 4000) &&
                !Core.Player.CurrentTarget.HasAura("Dancing Edge", false, 4000))
            {
                return await MySpells.StormsEye.Cast();
            }
            return false;
        }

        #endregion

        #region Cross Class Spells

        #region Arcanist

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.MarauderPhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.MarauderVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.MarauderEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Archer

        private async Task<bool> StraightShot()
        {
            if (Ultima.UltSettings.MarauderStraightShot)
            {
                return await MySpells.CrossClass.StraightShot.Cast();
            }
            return false;
        }

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.MarauderRagingStrikes)
            {
                return await MySpells.CrossClass.RagingStrikes.Cast();
            }
            return false;
        }

        private async Task<bool> VenomousBite()
        {
            if (Ultima.UltSettings.MarauderVenomousBite)
            {
                return await MySpells.CrossClass.VenomousBite.Cast();
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.MarauderHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.MarauderQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.MarauderCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.MarauderProtect)
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.MarauderRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.MarauderStoneskin)
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Gladiator

        private async Task<bool> SavageBlade()
        {
            if (Ultima.UltSettings.MarauderSavageBlade)
            {
                return await MySpells.CrossClass.SavageBlade.Cast();
            }
            return false;
        }

        private async Task<bool> Flash()
        {
            if (Ultima.UltSettings.MarauderFlash)
            {
                return await MySpells.CrossClass.Flash.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Ultima.UltSettings.MarauderConvalescence)
            {
                return await MySpells.CrossClass.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Provoke()
        {
            if (Ultima.UltSettings.MarauderProvoke)
            {
                return await MySpells.CrossClass.Provoke.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Ultima.UltSettings.MarauderAwareness)
            {
                return await MySpells.CrossClass.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Lancer

        private async Task<bool> Feint()
        {
            if (Ultima.UltSettings.MarauderFeint)
            {
                return await MySpells.CrossClass.Feint.Cast();
            }
            return false;
        }

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.MarauderKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.MarauderInvigorate)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.MarauderBloodForBlood)
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.MarauderFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.MarauderSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Haymaker()
        {
            if (Ultima.UltSettings.MarauderHaymaker)
            {
                return await MySpells.CrossClass.Haymaker.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.MarauderInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.MarauderMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #region Rogue

        private async Task<bool> ShadeShift()
        {
            if (Ultima.UltSettings.MarauderShadeShift)
            {
                return await MySpells.CrossClass.ShadeShift.Cast();
            }
            return false;
        }

        private async Task<bool> Goad()
        {
            if (Ultima.UltSettings.MarauderGoad)
            {
                return await MySpells.CrossClass.Goad.Cast();
            }
            return false;
        }

        private async Task<bool> DeathBlossom()
        {
            if (Ultima.UltSettings.MarauderDeathBlossom)
            {
                return await MySpells.CrossClass.DeathBlossom.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.MarauderSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.MarauderSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region PvP Spells

        private async Task<bool> FullSwing()
        {
            return await MySpells.PvP.FullSwing.Cast();
        }

        private async Task<bool> MythrilTempest()
        {
            return await MySpells.PvP.MythrilTempest.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        private async Task<bool> ThrillOfWar()
        {
            return await MySpells.PvP.ThrillOfWar.Cast();
        }

        #endregion
    }
}