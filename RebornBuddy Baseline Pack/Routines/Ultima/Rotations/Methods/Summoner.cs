using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Summoner
    {
        private SummonerSpells _mySpells;

        private SummonerSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new SummonerSpells()); }
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
                Ultima.UltSettings.SummonerSummonPet)
            {
                if (Ultima.UltSettings.SummonerGaruda ||
                    !Actionmanager.HasSpell(MySpells.SummonII.Name) &&
                    Ultima.UltSettings.SummonerTitan ||
                    !Actionmanager.HasSpell(MySpells.SummonIII.Name) &&
                    Ultima.UltSettings.SummonerIfrit)
                {
                    return await MySpells.Summon.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.SummonerPhysick)
            {
                if (Core.Player.CurrentHealthPercent < 70)
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
                    !Actionmanager.HasSpell(MySpells.Fester.Name))
                {
                    return await MySpells.EnergyDrain.Cast();
                }
                if (Core.Player.CurrentManaPercent <= 40)
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
                Ultima.UltSettings.SummonerSummonPet &&
                Ultima.UltSettings.SummonerTitan)
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
                    Actionmanager.CanCast(MySpells.Fester.Name, Core.Player.CurrentTarget) &&
                    Helpers.EnemiesNearTarget(8) <= 1 &&
                    Ultima.UltSettings.SmartTarget ||
                    Actionmanager.CanCast(MySpells.Fester.Name, Core.Player.CurrentTarget) &&
                    Ultima.UltSettings.SingleTarget ||
                    Actionmanager.CanCast(MySpells.Bane.Name, Core.Player.CurrentTarget) &&
                    !Ultima.UltSettings.SingleTarget &&
                    Helpers.EnemiesNearTarget(8) > 1 &&
                    Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true, 8000) &&
                    Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true, 8000) &&
                    Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true, 5000) ||
                    Actionmanager.CanCast(MySpells.Rouse.Name, Core.Player) ||
                    Actionmanager.CanCast(MySpells.Spur.Name, Core.Player))
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
                        await Coroutine.Wait(3000, () => Actionmanager.CanCast(MySpells.CrossClass.Swiftcast.Name, Core.Player));
                    }
                }
                if (Actionmanager.CanCast(MySpells.CrossClass.Swiftcast.Name, Core.Player))
                {
                    if (await MySpells.CrossClass.Swiftcast.Cast())
                    {
                        await Coroutine.Wait(3000, () => Actionmanager.CanCast(MySpells.ShadowFlare.Name, Core.Player.CurrentTarget) &&
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
            if (Ultima.UltSettings.SummonerRagingStrikes)
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
            if (Ultima.UltSettings.SummonerHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.SummonerQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.SummonerSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> BlizzardII()
        {
            if (Ultima.UltSettings.SummonerBlizzardII)
            {
                return await MySpells.CrossClass.BlizzardII.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.SummonerSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> Shockwave()
        {
            return await MySpells.Shockwave.Cast();
        }

        private async Task<bool> MountainBuster()
        {
            return await MySpells.MountainBuster.Cast();
        }

        private async Task<bool> AerialSlash()
        {
            if (Core.Player.Pet != null &&
                Core.Player.Pet.Name == "Garuda-Egi")
            {
                return await MySpells.AerialSlash.Cast();
            }
            return false;
        }

        private async Task<bool> EarthenWard()
        {
            return await MySpells.EarthenWard.Cast();
        }

        private async Task<bool> SummonIII()
        {
            if (Core.Player.Pet == null &&
                Ultima.UltSettings.SummonerSummonPet &&
                Ultima.UltSettings.SummonerIfrit)
            {
                return await MySpells.SummonIII.Cast();
            }
            return false;
        }

        private async Task<bool> CrimsonCyclone()
        {
            return await MySpells.CrimsonCyclone.Cast();
        }

        private async Task<bool> RadiantShield()
        {
            return await MySpells.RadiantShield.Cast();
        }

        private async Task<bool> Contagion()
        {
            if (Core.Player.Pet != null &&
                Core.Player.Pet.Name == "Garuda-Egi" &&
                Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true))
            {
                return await MySpells.Contagion.Cast();
            }
            return false;
        }

        private async Task<bool> Landslide()
        {
            return await MySpells.Landslide.Cast();
        }

        private async Task<bool> FlamingCrush()
        {
            return await MySpells.FlamingCrush.Cast();
        }

        private async Task<bool> Fester()
        {
            if (Core.Player.HasAura(MySpells.Aetherflow.Name) &&
                Core.Player.CurrentManaPercent > 40 &&
                Core.Player.CurrentTarget.HasAura(MySpells.BioII.Name, true) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Miasma.Name, true) &&
                Core.Player.CurrentTarget.HasAura(MySpells.Bio.Name, true))
            {
                if (Helpers.EnemiesNearTarget(8) <= 1 &&
                    Ultima.UltSettings.SmartTarget ||
                    Ultima.UltSettings.SingleTarget)
                {
                    return await MySpells.Fester.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Tribind()
        {
            return await MySpells.Tribind.Cast();
        }

        private async Task<bool> Spur()
        {
            return await MySpells.Spur.Cast();
        }

        private async Task<bool> Enkindle()
        {
            if (!Actionmanager.CanCast(MySpells.Rouse.Name, Core.Player) &&
                !Actionmanager.CanCast(MySpells.Spur.Name, Core.Player))
            {
                return await MySpells.Enkindle.Cast();
            }
            return false;
        }

        private async Task<bool> Painflare()
        {
            return await MySpells.Painflare.Cast();
        }

        private async Task<bool> RuinIII()
        {
            return await MySpells.RuinIII.Cast();
        }

        private async Task<bool> Tridisaster()
        {
            return await MySpells.Tridisaster.Cast();
        }

        private async Task<bool> DreadwyrmTrance()
        {
            return await MySpells.DreadwyrmTrance.Cast();
        }

        private async Task<bool> Deathflare()
        {
            return await MySpells.Deathflare.Cast();
        }

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