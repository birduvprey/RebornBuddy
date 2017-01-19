using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Scholar
    {
        private ScholarSpells _mySpells;

        private ScholarSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new ScholarSpells()); }
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
                Ultima.UltSettings.ScholarSummonPet)
            {
                if (Ultima.UltSettings.ScholarEos ||
                    !Actionmanager.HasSpell(MySpells.SummonII.Name))
                {
                    return await MySpells.Summon.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.ScholarPhysick)
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
                Ultima.UltSettings.ScholarSummonPet &&
                Ultima.UltSettings.ScholarSelene)
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

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.ScholarCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Aero()
        {
            if (Ultima.UltSettings.ScholarAero &&
                !Core.Player.CurrentTarget.HasAura(MySpells.CrossClass.Aero.Name, true, 4000))
            {
                return await MySpells.CrossClass.Aero.Cast();
            }
            return false;
        }

        private async Task<bool> ClericStance()
        {
            if (Ultima.UltSettings.ScholarClericStance)
            {
                return await MySpells.CrossClass.ClericStance.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.ScholarProtect &&
                !Core.Player.HasAura(MySpells.CrossClass.Protect.Name))
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.ScholarRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.ScholarStoneskin &&
                !Core.Player.HasAura(MySpells.CrossClass.Stoneskin.Name))
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.ScholarSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> BlizzardII()
        {
            if (Ultima.UltSettings.ScholarBlizzardII)
            {
                return await MySpells.CrossClass.BlizzardII.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.ScholarSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> Adloquium()
        {
            if (Ultima.UltSettings.ScholarAdloquium)
            {
                if (Core.Player.CurrentHealthPercent < 70 ||
                    Core.Player.Pet != null &&
                    Core.Player.Pet.CurrentHealthPercent < 70)
                {
                    return await MySpells.Adloquium.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Succor()
        {
            return await MySpells.Succor.Cast();
        }

        private async Task<bool> Leeches()
        {
            return await MySpells.Leeches.Cast();
        }

        private async Task<bool> SacredSoil()
        {
            return await MySpells.SacredSoil.Cast();
        }

        private async Task<bool> Lustrate()
        {
            return await MySpells.Lustrate.Cast();
        }

        private async Task<bool> Indomitability()
        {
            return await MySpells.Indomitability.Cast();
        }

        private async Task<bool> Broil()
        {
            return await MySpells.Broil.Cast();
        }

        private async Task<bool> DeploymentTactics()
        {
            return await MySpells.DeploymentTactics.Cast();
        }

        private async Task<bool> EmergencyTactics()
        {
            return await MySpells.EmergencyTactics.Cast();
        }

        private async Task<bool> Dissipation()
        {
            return await MySpells.Dissipation.Cast();
        }

        #endregion

        #region PvP Spells

        private async Task<bool> Attunement()
        {
            return await MySpells.PvP.Attunement.Cast();
        }

        private async Task<bool> AuraBlast()
        {
            return await MySpells.PvP.AuraBlast.Cast();
        }

        private async Task<bool> Focalization()
        {
            return await MySpells.PvP.Focalization.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        #endregion
    }
}