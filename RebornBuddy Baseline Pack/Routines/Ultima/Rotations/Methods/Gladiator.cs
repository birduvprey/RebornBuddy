using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Gladiator
    {
        private GladiatorSpells _mySpells;

        private GladiatorSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new GladiatorSpells()); }
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
            return await MySpells.Provoke.Cast();
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
            if (Ultima.UltSettings.GladiatorShieldSwipe &&
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

        #region Arcanist

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.GladiatorPhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.GladiatorVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.GladiatorEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Archer

        private async Task<bool> StraightShot()
        {
            if (Ultima.UltSettings.GladiatorStraightShot)
            {
                return await MySpells.CrossClass.StraightShot.Cast();
            }
            return false;
        }

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.GladiatorRagingStrikes)
            {
                return await MySpells.CrossClass.RagingStrikes.Cast();
            }
            return false;
        }

        private async Task<bool> VenomousBite()
        {
            if (Ultima.UltSettings.GladiatorVenomousBite)
            {
                return await MySpells.CrossClass.VenomousBite.Cast();
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.GladiatorHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.GladiatorQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.GladiatorCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.GladiatorProtect &&
                !Core.Player.HasAura(MySpells.CrossClass.Protect.Name))
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.GladiatorRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.GladiatorStoneskin &&
                !Core.Player.HasAura(MySpells.CrossClass.Stoneskin.Name))
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Lancer

        private async Task<bool> Feint()
        {
            if (Ultima.UltSettings.GladiatorFeint)
            {
                return await MySpells.CrossClass.Feint.Cast();
            }
            return false;
        }

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.GladiatorKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.GladiatorInvigorate)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.GladiatorBloodForBlood)
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.GladiatorForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> SkullSunder()
        {
            if (Ultima.UltSettings.GladiatorSkullSunder)
            {
                return await MySpells.CrossClass.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (Ultima.UltSettings.GladiatorFracture &&
                !Core.Player.CurrentTarget.HasAura(MySpells.CrossClass.Fracture.Name, true, 4000))
            {
                return await MySpells.CrossClass.Fracture.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.GladiatorBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.GladiatorMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.GladiatorFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.GladiatorSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Haymaker()
        {
            if (Ultima.UltSettings.GladiatorHaymaker)
            {
                return await MySpells.CrossClass.Haymaker.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.GladiatorInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.GladiatorMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #region Rogue

        private async Task<bool> ShadeShift()
        {
            if (Ultima.UltSettings.GladiatorShadeShift)
            {
                return await MySpells.CrossClass.ShadeShift.Cast();
            }
            return false;
        }

        private async Task<bool> Goad()
        {
            if (Ultima.UltSettings.GladiatorGoad)
            {
                return await MySpells.CrossClass.Goad.Cast();
            }
            return false;
        }

        private async Task<bool> DeathBlossom()
        {
            if (Ultima.UltSettings.GladiatorDeathBlossom)
            {
                return await MySpells.CrossClass.DeathBlossom.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.GladiatorSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.GladiatorSwiftcast)
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