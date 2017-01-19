using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Lancer
    {
        private LancerSpells _mySpells;

        private LancerSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new LancerSpells()); }
        }

        #region Class Spells

        private async Task<bool> TrueThrust()
        {
            return await MySpells.TrueThrust.Cast();
        }

        private async Task<bool> Feint()
        {
            return await MySpells.Feint.Cast();
        }

        private async Task<bool> VorpalThrust()
        {
            if (Actionmanager.LastSpell.Name == MySpells.TrueThrust.Name)
            {
                return await MySpells.VorpalThrust.Cast();
            }
            return false;
        }

        private async Task<bool> KeenFlurry()
        {
            return await MySpells.KeenFlurry.Cast();
        }

        private async Task<bool> ImpulseDrive()
        {
            if (Actionmanager.HasSpell(MySpells.Disembowel.Name) &&
                !Core.Player.CurrentTarget.HasAura(MySpells.Disembowel.Name, false, 5000) ||
                Actionmanager.HasSpell(MySpells.ChaosThrust.Name) &&
                !Core.Player.CurrentTarget.HasAura(MySpells.ChaosThrust.Name, true, 5000))
            {
                return await MySpells.ImpulseDrive.Cast();
            }
            return false;
        }

        private async Task<bool> LegSweep()
        {
            if (Ultima.UltSettings.LancerLegSweep)
            {
                return await MySpells.LegSweep.Cast();
            }
            return false;
        }

        private async Task<bool> HeavyThrust()
        {
            if (!Core.Player.HasAura(MySpells.HeavyThrust.Name, true, 6000))
            {
                return await MySpells.HeavyThrust.Cast();
            }
            return false;
        }

        private async Task<bool> PiercingTalon()
        {
            if (Core.Player.TargetDistance(10))
            {
                return await MySpells.PiercingTalon.Cast();
            }
            return false;
        }

        private async Task<bool> LifeSurge()
        {
            if (Actionmanager.LastSpell.Name == MySpells.TrueThrust.Name)
            {
                return await MySpells.LifeSurge.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Core.Player.CurrentTP <= 440)
            {
                return await MySpells.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> FullThrust()
        {
            if (Actionmanager.LastSpell.Name == MySpells.VorpalThrust.Name)
            {
                if (await MySpells.LifeSurge.Cast())
                {
                    await Coroutine.Wait(3000, () => Actionmanager.CanCast(MySpells.FullThrust.Name, Core.Player.CurrentTarget));
                }
                return await MySpells.FullThrust.Cast();
            }
            return false;
        }

        private async Task<bool> Phlebotomize()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Phlebotomize.Name, true, 6000))
            {
                return await MySpells.Phlebotomize.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            return await MySpells.BloodForBlood.Cast();
        }

        private async Task<bool> Disembowel()
        {
            if (Actionmanager.LastSpell.Name == MySpells.ImpulseDrive.Name)
            {
                return await MySpells.Disembowel.Cast();
            }
            return false;
        }

        private async Task<bool> DoomSpike()
        {
            return await MySpells.DoomSpike.Cast();
        }

        private async Task<bool> RingOfThorns()
        {
            if (Actionmanager.LastSpell.Name == MySpells.HeavyThrust.Name)
            {
                return await MySpells.RingOfThorns.Cast();
            }
            return false;
        }

        private async Task<bool> ChaosThrust()
        {
            if (Actionmanager.LastSpell.Name == MySpells.Disembowel.Name)
            {
                return await MySpells.ChaosThrust.Cast();
            }
            return false;
        }

        #endregion

        #region Cross Class Spells

        #region Arcanist

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.LancerPhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.LancerVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.LancerEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Archer

        private async Task<bool> StraightShot()
        {
            if (Ultima.UltSettings.LancerStraightShot)
            {
                return await MySpells.CrossClass.StraightShot.Cast();
            }
            return false;
        }

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.LancerRagingStrikes)
            {
                return await MySpells.CrossClass.RagingStrikes.Cast();
            }
            return false;
        }

        private async Task<bool> VenomousBite()
        {
            if (Ultima.UltSettings.LancerVenomousBite)
            {
                return await MySpells.CrossClass.VenomousBite.Cast();
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.LancerHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.LancerQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.LancerCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.LancerProtect)
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.LancerRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.LancerStoneskin)
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Gladiator

        private async Task<bool> SavageBlade()
        {
            if (Ultima.UltSettings.LancerSavageBlade)
            {
                return await MySpells.CrossClass.SavageBlade.Cast();
            }
            return false;
        }

        private async Task<bool> Flash()
        {
            if (Ultima.UltSettings.LancerFlash)
            {
                return await MySpells.CrossClass.Flash.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Ultima.UltSettings.LancerConvalescence)
            {
                return await MySpells.CrossClass.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Provoke()
        {
            if (Ultima.UltSettings.LancerProvoke)
            {
                return await MySpells.CrossClass.Provoke.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Ultima.UltSettings.LancerAwareness)
            {
                return await MySpells.CrossClass.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.LancerForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> SkullSunder()
        {
            if (Ultima.UltSettings.LancerSkullSunder)
            {
                return await MySpells.CrossClass.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (Ultima.UltSettings.LancerFracture &&
                !Core.Player.CurrentTarget.HasAura(MySpells.CrossClass.Fracture.Name, true, 4000))
            {
                return await MySpells.CrossClass.Fracture.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.LancerBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.LancerMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.LancerFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.LancerSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Haymaker()
        {
            if (Ultima.UltSettings.LancerHaymaker)
            {
                return await MySpells.CrossClass.Haymaker.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.LancerInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.LancerMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #region Rogue

        private async Task<bool> ShadeShift()
        {
            if (Ultima.UltSettings.LancerShadeShift)
            {
                return await MySpells.CrossClass.ShadeShift.Cast();
            }
            return false;
        }

        private async Task<bool> Goad()
        {
            if (Ultima.UltSettings.LancerGoad)
            {
                return await MySpells.CrossClass.Goad.Cast();
            }
            return false;
        }

        private async Task<bool> DeathBlossom()
        {
            if (Ultima.UltSettings.LancerDeathBlossom)
            {
                return await MySpells.CrossClass.DeathBlossom.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.LancerSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.LancerSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region PvP Spells

        private async Task<bool> Enliven()
        {
            return await MySpells.PvP.Enliven.Cast();
        }

        private async Task<bool> FetterWard()
        {
            return await MySpells.PvP.FetterWard.Cast();
        }

        private async Task<bool> ImpulseRush()
        {
            return await MySpells.PvP.ImpulseRush.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        private async Task<bool> Skewer()
        {
            return await MySpells.PvP.Skewer.Cast();
        }

        private async Task<bool> WeaponThrow()
        {
            return await MySpells.PvP.WeaponThrow.Cast();
        }

        #endregion
    }
}