using ff14bot;
using ff14bot.Managers;
using System.Linq;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Rogue
    {
        private RogueSpells _mySpells;

        private RogueSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new RogueSpells()); }
        }

        #region Class Spells

        private async Task<bool> SpinningEdge()
        {
            return await MySpells.SpinningEdge.Cast();
        }

        private async Task<bool> ShadeShift()
        {
            return await MySpells.ShadeShift.Cast();
        }

        private async Task<bool> GustSlash()
        {
            if (Actionmanager.LastSpell.Name == MySpells.SpinningEdge.Name)
            {
                return await MySpells.GustSlash.Cast();
            }
            return false;
        }

        private async Task<bool> KissOfTheWasp()
        {
            if (Ultima.UltSettings.RogueKissOfTheWasp ||
                !Actionmanager.HasSpell(MySpells.KissOfTheViper.Name))
            {
                if (!Core.Player.HasAura(MySpells.KissOfTheWasp.Name))
                {
                    return await MySpells.KissOfTheWasp.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Mutilate()
        {
            if (!Actionmanager.HasSpell(MySpells.ShadowFang.Name) ||
                Core.Player.CurrentTarget.HasAura(MySpells.ShadowFang.Name, true, 4000))
            {
                if (!Core.Player.CurrentTarget.HasAura("Mutilation", true, 4000))
                {
                    return await MySpells.Mutilate.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Hide()
        {
            return await MySpells.Hide.Cast();
        }

        private async Task<bool> Assassinate()
        {
            if (Ultima.UltSettings.RogueAssassinate)
            {
                return await MySpells.Assassinate.Cast();
            }
            return false;
        }

        private async Task<bool> ThrowingDagger()
        {
            if (Core.Player.TargetDistance(10))
            {
                return await MySpells.ThrowingDagger.Cast();
            }
            return false;
        }

        private async Task<bool> Mug()
        {
            return await MySpells.Mug.Cast();
        }

        private async Task<bool> Goad()
        {
            if (Ultima.UltSettings.RogueGoad)
            {
                var target = Helpers.GoadManager.FirstOrDefault();

                if (target != null)
                {
                    return await MySpells.Goad.Cast(target);
                }
            }
            return false;
        }

        private async Task<bool> SneakAttack()
        {
            return await MySpells.SneakAttack.Cast();
        }

        private async Task<bool> AeolianEdge()
        {
            if (Actionmanager.LastSpell.Name == MySpells.GustSlash.Name)
            {
                return await MySpells.AeolianEdge.Cast();
            }
            return false;
        }

        private async Task<bool> KissOfTheViper()
        {
            if (Ultima.UltSettings.RogueKissOfTheViper &&
                !Core.Player.HasAura(MySpells.KissOfTheViper.Name))
            {
                return await MySpells.KissOfTheViper.Cast();
            }
            return false;
        }

        private async Task<bool> Jugulate()
        {
            if (Ultima.UltSettings.RogueJugulate)
            {
                return await MySpells.Jugulate.Cast();
            }
            return false;
        }

        private async Task<bool> DancingEdge()
        {
            if (Ultima.UltSettings.RogueDancingEdge)
            {
                if (!Core.Player.CurrentTarget.HasAura(MySpells.DancingEdge.Name, false, 6000) &&
                    !Core.Player.CurrentTarget.HasAura("Storm's Eye", false, 6000) &&
                    Actionmanager.LastSpell.Name == MySpells.GustSlash.Name)
                {
                    return await MySpells.DancingEdge.Cast();
                }
            }
            return false;
        }

        private async Task<bool> DeathBlossom()
        {
            return await MySpells.DeathBlossom.Cast();
        }

        private async Task<bool> ShadowFang()
        {
            if (Core.Player.CurrentTarget.HasAura(MySpells.DancingEdge.Name, false, 6000) ||
                Core.Player.CurrentTarget.HasAura("Storm's Eye", false, 6000) ||
                !Ultima.UltSettings.RogueDancingEdge)
            {
                if (!Core.Player.CurrentTarget.HasAura(MySpells.ShadowFang.Name, true, 4000) &&
                    Actionmanager.LastSpell.Name == MySpells.SpinningEdge.Name)
                {
                    return await MySpells.ShadowFang.Cast();
                }
            }
            return false;
        }

        private async Task<bool> TrickAttack()
        {
            return await MySpells.TrickAttack.Cast();
        }

        #endregion

        #region Cross Class Spells

        #region Arcanist

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.RoguePhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.RogueVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.RogueEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Archer

        private async Task<bool> StraightShot()
        {
            if (Ultima.UltSettings.RogueStraightShot)
            {
                return await MySpells.CrossClass.StraightShot.Cast();
            }
            return false;
        }

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.RogueRagingStrikes)
            {
                return await MySpells.CrossClass.RagingStrikes.Cast();
            }
            return false;
        }

        private async Task<bool> VenomousBite()
        {
            if (Ultima.UltSettings.RogueVenomousBite)
            {
                return await MySpells.CrossClass.VenomousBite.Cast();
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.RogueHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.RogueQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.RogueCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.RogueProtect)
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.RogueRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.RogueStoneskin)
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Gladiator

        private async Task<bool> SavageBlade()
        {
            if (Ultima.UltSettings.RogueSavageBlade)
            {
                return await MySpells.CrossClass.SavageBlade.Cast();
            }
            return false;
        }

        private async Task<bool> Flash()
        {
            if (Ultima.UltSettings.RogueFlash)
            {
                return await MySpells.CrossClass.Flash.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Ultima.UltSettings.RogueConvalescence)
            {
                return await MySpells.CrossClass.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Provoke()
        {
            if (Ultima.UltSettings.RogueProvoke)
            {
                return await MySpells.CrossClass.Provoke.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Ultima.UltSettings.RogueAwareness)
            {
                return await MySpells.CrossClass.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Lancer

        private async Task<bool> Feint()
        {
            if (Ultima.UltSettings.RogueFeint)
            {
                return await MySpells.CrossClass.Feint.Cast();
            }
            return false;
        }

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.RogueKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.RogueInvigorate &&
                Core.Player.CurrentTP <= 540)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.RogueBloodForBlood)
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.RogueForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> SkullSunder()
        {
            if (Ultima.UltSettings.RogueSkullSunder)
            {
                return await MySpells.CrossClass.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (Ultima.UltSettings.RogueFracture)
            {
                return await MySpells.CrossClass.Fracture.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.RogueBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.RogueMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.RogueFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.RogueSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Haymaker()
        {
            if (Ultima.UltSettings.RogueHaymaker)
            {
                return await MySpells.CrossClass.Haymaker.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.RogueInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.RogueMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.RogueSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.RogueSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region PvP Spells

        private async Task<bool> Detect()
        {
            return await MySpells.PvP.Detect.Cast();
        }

        private async Task<bool> IllWind()
        {
            return await MySpells.PvP.IllWind.Cast();
        }

        private async Task<bool> Malmsight()
        {
            return await MySpells.PvP.Malmsight.Cast();
        }

        private async Task<bool> Overwhelm()
        {
            return await MySpells.PvP.Overwhelm.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        private async Task<bool> Recouperate()
        {
            return await MySpells.PvP.Recouperate.Cast();
        }

        #endregion
    }
}