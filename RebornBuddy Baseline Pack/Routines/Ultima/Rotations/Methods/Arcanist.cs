using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Arcanist
    {
        private ArcanistSpells _mySpells;

        private ArcanistSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new ArcanistSpells()); }
        }

        #region Class Spells

        private async Task<bool> Ruin()
        {
            return await MySpells.Ruin.Cast();
        }

        private async Task<bool> Bio()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true, 4000))
            {
                return await MySpells.Bio.Cast();
            }
            return false;
        }

        private async Task<bool> Summon()
        {
            if (Core.Player.Pet == null &&
                Ultima.UltSettings.ArcanistSummonPet)
            {
                if (Ultima.UltSettings.ArcanistEmeraldCarbuncle ||
                    !Actionmanager.HasSpell(MySpells.SummonII.Name))
                {
                    return await MySpells.Summon.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.ArcanistPhysick)
            {
                if (Core.Player.CurrentHealthPercent < 70 ||
                    Core.Player.Pet != null &&
                    Core.Player.Pet.CurrentHealthPercent < 70)
                {
                    return await MySpells.Physick.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Aetherflow()
        {
            if (!Core.Player.HasAura(MySpells.Aetherflow.Name))
            {
                return await MySpells.Aetherflow.Cast();
            }
            return false;
        }

        private async Task<bool> EnergyDrain()
        {
            if (Core.Player.HasAura(MySpells.Aetherflow.Name))
            {
                if (Core.Player.CurrentManaPercent <= 90 &&
                    Helpers.EnemiesNearTarget(8) <= 1 &&
                    Ultima.UltSettings.SmartTarget ||
                    Core.Player.CurrentManaPercent <= 90 &&
                    Ultima.UltSettings.SingleTarget ||
                    Core.Player.CurrentManaPercent <= 40)
                {
                    return await MySpells.EnergyDrain.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Miasma()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 5000))
            {
                return await MySpells.Miasma.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            return await MySpells.Virus.Cast();
        }

        private async Task<bool> SummonII()
        {
            if (Core.Player.Pet == null &&
                Ultima.UltSettings.ArcanistSummonPet &&
                Ultima.UltSettings.ArcanistTopazCarbuncle)
            {
                return await MySpells.SummonII.Cast();
            }
            return false;
        }

        private async Task<bool> Sustain()
        {
            if (Core.Player.Pet != null &&
                Core.Player.Pet.CurrentHealthPercent < 70 &&
                !Core.Player.Pet.HasAura(MySpells.Sustain.Name))
            {
                return await MySpells.Sustain.Cast();
            }
            return false;
        }

        private async Task<bool> Resurrection()
        {
            return await MySpells.Resurrection.Cast();
        }

        private async Task<bool> BioII()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true, 5000))
            {
                return await MySpells.BioII.Cast();
            }
            return false;
        }

        private async Task<bool> Bane()
        {
            if (Core.Player.HasAura(MySpells.Aetherflow.Name) &&
                Core.Player.CurrentManaPercent > 40 &&
                Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true, 8000) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 8000) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true, 5000))
            {
                return await MySpells.Bane.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            return await MySpells.EyeForAnEye.Cast();
        }

        private async Task<bool> RuinII()
        {
            if (MovementManager.IsMoving)
            {
                return await MySpells.RuinII.Cast();
            }
            if (Core.Player.CurrentManaPercent > 40)
            {
                if (Actionmanager.CanCast(MySpells.Aetherflow.Name, Core.Player) &&
                    !Core.Player.HasAura(MySpells.Aetherflow.Name) ||
                    Actionmanager.CanCast(MySpells.EnergyDrain.Name, Core.Player.CurrentTarget) &&
                    Core.Player.CurrentManaPercent <= 90 &&
                    Helpers.EnemiesNearTarget(8) <= 1 &&
                    Ultima.UltSettings.SmartTarget ||
                    Actionmanager.CanCast(MySpells.EnergyDrain.Name, Core.Player.CurrentTarget) &&
                    Core.Player.CurrentManaPercent <= 90 &&
                    Ultima.UltSettings.SingleTarget ||
                    Actionmanager.CanCast(MySpells.Bane.Name, Core.Player.CurrentTarget) &&
                    !Ultima.UltSettings.SingleTarget &&
                    Helpers.EnemiesNearTarget(8) > 1 &&
                    Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true, 8000) &&
                    Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 8000) &&
                    Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true, 5000) ||
                    Actionmanager.CanCast(MySpells.Rouse.Name, Core.Player))
                {
                    return await MySpells.RuinII.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Rouse()
        {
            return await MySpells.Rouse.Cast();
        }

        private async Task<bool> MiasmaII()
        {
            if (Helpers.EnemiesNearPlayer(5) > 4 &&
                Core.Player.CurrentTarget.HasAura(MySpells.MiasmaII.Name, true, 3000))
            {
                return await MySpells.MiasmaII.Cast();
            }
            return false;
        }

        private async Task<bool> ShadowFlare()
        {
            if (Actionmanager.HasSpell(MySpells.ShadowFlare.Name) &&
                !Core.Player.HasAura(MySpells.ShadowFlare.Name, true, 4000))
            {
                if (Actionmanager.CanCast(MySpells.RuinII.Name, Core.Player.CurrentTarget) &&
                    Actionmanager.CanCast(MySpells.CrossClass.Swiftcast.Name, Core.Player))
                {
                    if (await MySpells.RuinII.Cast())
                    {
                        await Coroutine.Wait(5000, () => Actionmanager.CanCast(MySpells.CrossClass.Swiftcast.Name, Core.Player));
                    }
                }
                if (Actionmanager.CanCast(MySpells.CrossClass.Swiftcast.Name, Core.Player))
                {
                    if (await MySpells.CrossClass.Swiftcast.Cast())
                    {
                        await Coroutine.Wait(5000, () => Actionmanager.CanCast(MySpells.ShadowFlare.Name, Core.Player.CurrentTarget) &&
                                                         Core.Player.HasAura(MySpells.CrossClass.Swiftcast.Name));
                    }
                }
                if (await MySpells.ShadowFlare.Cast())
                {
                    await Coroutine.Wait(3000, () => Core.Player.HasAura(MySpells.ShadowFlare.Name));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Cross Class Spells

        #region Archer

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.ArcanistRagingStrikes)
            {
                if (!Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true, 6000) ||
                    !Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 6000) ||
                    !Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true, 5000))
                {
                    return await MySpells.CrossClass.RagingStrikes.Cast();
                }
                return false;
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.ArcanistHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.ArcanistQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.ArcanistCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Aero()
        {
            if (Ultima.UltSettings.ArcanistAero &&
                !Core.Player.CurrentTarget.HasAura(MySpells.CrossClass.Aero.Name, true, 4000))
            {
                return await MySpells.CrossClass.Aero.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.ArcanistProtect &&
                !Core.Player.HasAura(MySpells.CrossClass.Protect.Name))
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.ArcanistRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.ArcanistStoneskin &&
                !Core.Player.HasAura(MySpells.CrossClass.Stoneskin.Name))
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Gladiator

        private async Task<bool> Flash()
        {
            if (Ultima.UltSettings.ArcanistFlash)
            {
                return await MySpells.CrossClass.Flash.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Ultima.UltSettings.ArcanistConvalescence)
            {
                return await MySpells.CrossClass.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Provoke()
        {
            if (Ultima.UltSettings.ArcanistProvoke)
            {
                return await MySpells.CrossClass.Provoke.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Ultima.UltSettings.ArcanistAwareness)
            {
                return await MySpells.CrossClass.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Lancer

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.ArcanistKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.ArcanistInvigorate)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.ArcanistBloodForBlood)
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.ArcanistForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.ArcanistBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.ArcanistMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.ArcanistFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.ArcanistSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.ArcanistInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.ArcanistMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.ArcanistSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> BlizzardII()
        {
            if (Ultima.UltSettings.ArcanistBlizzardII)
            {
                return await MySpells.CrossClass.BlizzardII.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.ArcanistSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region PvP Spells

        private async Task<bool> AethericBurst()
        {
            return await MySpells.PvP.AethericBurst.Cast();
        }

        private async Task<bool> Equanimity()
        {
            return await MySpells.PvP.Equanimity.Cast();
        }

        private async Task<bool> ManaDraw()
        {
            return await MySpells.PvP.ManaDraw.Cast();
        }

        private async Task<bool> MistyVeil()
        {
            return await MySpells.PvP.MistyVeil.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        private async Task<bool> Wither()
        {
            return await MySpells.PvP.Wither.Cast();
        }

        #endregion
    }
}