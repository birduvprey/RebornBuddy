using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Pugilist
    {
        private PugilistSpells _mySpells;

        private PugilistSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new PugilistSpells()); }
        }

        #region Class Spells

        private async Task<bool> Bootshine()
        {
            return await MySpells.Bootshine.Cast();
        }

        private async Task<bool> TrueStrike()
        {
            return await MySpells.TrueStrike.Cast();
        }

        private async Task<bool> Featherfoot()
        {
            return await MySpells.Featherfoot.Cast();
        }

        private async Task<bool> SnapPunch()
        {
            if (!Core.Player.HasAura(MySpells.PerfectBalance.Name) ||
                Core.Player.HasAura(MySpells.PerfectBalance.Name) &&
                 !Core.Player.HasAura("Greased Lightning III"))
            {
                return await MySpells.SnapPunch.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            return await MySpells.SecondWind.Cast();
        }


        private async Task<bool> Haymaker()
        {
            return await MySpells.Haymaker.Cast();
        }

        private async Task<bool> InternalRelease()
        {
            return await MySpells.InternalRelease.Cast();
        }

        private async Task<bool> TouchOfDeath()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.TouchOfDeath.Name, true, 4000))
            {
                if (NoGreasedLightning ||
                    HasGreasedLightning)
                {
                    return await MySpells.TouchOfDeath.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> TwinSnakes()
        {
            if (!Core.Player.HasAura(MySpells.TwinSnakes.Name, true, 5000) ||
                !Core.Player.HasAura(MySpells.PerfectBalance.Name) &&
                Core.Player.HasTarget &&
                Core.Player.CurrentTarget.IsFlanking)
            {
                return await MySpells.TwinSnakes.Cast();
            }
            return false;
        }

        private async Task<bool> FistsOfEarth()
        {
            if (Ultima.UltSettings.MonkFistsOfEarth &&
                !Core.Player.HasAura(MySpells.FistsOfEarth.Name) ||
                !Core.Player.HasAura(MySpells.FistsOfEarth.Name) &&
                !Core.Player.HasAura(MySpells.FistsOfWind.Name))
            {
                return await MySpells.FistsOfEarth.Cast();
            }
            return false;
        }

        private async Task<bool> ArmOfTheDestroyer()
        {
            return await MySpells.ArmOfTheDestroyer.Cast();
        }

        private async Task<bool> Demolish()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Demolish.Name, true, 5000))
            {
                return await MySpells.Demolish.Cast();
            }
            return false;
        }

        private async Task<bool> FistsOfWind()
        {
            if (Ultima.UltSettings.PugilistFistsOfWind &&
                !Core.Player.HasAura(MySpells.FistsOfWind.Name))
            {
                return await MySpells.FistsOfWind.Cast();
            }
            return false;
        }

        private async Task<bool> SteelPeak()
        {
            return await MySpells.SteelPeak.Cast();
        }

        private async Task<bool> Mantra()
        {
            return await MySpells.Mantra.Cast();
        }

        private async Task<bool> HowlingFist()
        {
            return await MySpells.HowlingFist.Cast();
        }

        private async Task<bool> PerfectBalance()
        {
            if (Ultima.UltSettings.PugilistPerfectBalance &&
                Actionmanager.CanCast(MySpells.Bootshine.Name, Core.Player.CurrentTarget))
            {
                if (await MySpells.PerfectBalance.Cast())
                {
                    await Coroutine.Wait(5000, () => Core.Player.HasAura(MySpells.PerfectBalance.Name));
                    return true;
                }
                return false;
            }
            return false;
        }

        #endregion

        #region Cross Class Spells

        #region Arcanist

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.PugilistPhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.PugilistVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.PugilistEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Archer

        private async Task<bool> StraightShot()
        {
            if (Ultima.UltSettings.PugilistStraightShot)
            {
                return await MySpells.CrossClass.StraightShot.Cast();
            }
            return false;
        }

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.PugilistRagingStrikes)
            {
                return await MySpells.CrossClass.RagingStrikes.Cast();
            }
            return false;
        }

        private async Task<bool> VenomousBite()
        {
            if (Ultima.UltSettings.PugilistVenomousBite)
            {
                return await MySpells.CrossClass.VenomousBite.Cast();
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.PugilistHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.PugilistQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.PugilistCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.PugilistProtect)
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.PugilistRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.PugilistStoneskin)
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Gladiator

        private async Task<bool> SavageBlade()
        {
            if (Ultima.UltSettings.PugilistSavageBlade)
            {
                return await MySpells.CrossClass.SavageBlade.Cast();
            }
            return false;
        }

        private async Task<bool> Flash()
        {
            if (Ultima.UltSettings.PugilistFlash)
            {
                return await MySpells.CrossClass.Flash.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Ultima.UltSettings.PugilistConvalescence)
            {
                return await MySpells.CrossClass.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Provoke()
        {
            if (Ultima.UltSettings.PugilistProvoke)
            {
                return await MySpells.CrossClass.Provoke.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Ultima.UltSettings.PugilistAwareness)
            {
                return await MySpells.CrossClass.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Lancer

        private async Task<bool> Feint()
        {
            if (Ultima.UltSettings.PugilistFeint)
            {
                return await MySpells.CrossClass.Feint.Cast();
            }
            return false;
        }

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.PugilistKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.PugilistInvigorate &&
                Core.Player.CurrentTP <= 540)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.PugilistBloodForBlood)
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.PugilistForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> SkullSunder()
        {
            if (Ultima.UltSettings.PugilistSkullSunder)
            {
                return await MySpells.CrossClass.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (Ultima.UltSettings.PugilistFracture &&
                !Core.Player.CurrentTarget.HasAura(MySpells.CrossClass.Fracture.Name, true, 4000))
            {
                return await MySpells.CrossClass.Fracture.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.PugilistBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.PugilistMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #region Rogue

        private async Task<bool> ShadeShift()
        {
            if (Ultima.UltSettings.PugilistShadeShift)
            {
                return await MySpells.CrossClass.ShadeShift.Cast();
            }
            return false;
        }

        private async Task<bool> Goad()
        {
            if (Ultima.UltSettings.PugilistGoad)
            {
                return await MySpells.CrossClass.Goad.Cast();
            }
            return false;
        }

        private async Task<bool> DeathBlossom()
        {
            if (Ultima.UltSettings.PugilistDeathBlossom)
            {
                return await MySpells.CrossClass.DeathBlossom.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.PugilistSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.PugilistSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Custom Spells
        private static bool NoGreasedLightning
        {
            get
            {
                return !Core.Player.HasAura("Greased Lightning") &&
                       !Core.Player.HasAura("Greased Lightning II") &&
                       !Core.Player.HasAura("Greased Lightning III");
            }
        }
        private static bool HasGreasedLightning
        {
            get
            {
                return Core.Player.HasAura("Greased Lightning", true, 4000) ||
                       Core.Player.HasAura("Greased Lightning II", true, 4000) ||
                       Core.Player.HasAura("Greased Lightning III", true, 4000);
            }
        }

        #endregion

        #region PvP Spells

        private async Task<bool> AxeKick()
        {
            return await MySpells.PvP.AxeKick.Cast();
        }

        private async Task<bool> Enliven()
        {
            return await MySpells.PvP.Enliven.Cast();
        }

        private async Task<bool> FetterWard()
        {
            return await MySpells.PvP.FetterWard.Cast();
        }

        private async Task<bool> Somersault()
        {
            return await MySpells.PvP.Somersault.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        private async Task<bool> WeaponThrow()
        {
            return await MySpells.PvP.WeaponThrow.Cast();
        }

        #endregion
    }
}