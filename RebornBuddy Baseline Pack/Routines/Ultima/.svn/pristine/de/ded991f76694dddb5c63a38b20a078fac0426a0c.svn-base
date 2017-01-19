using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Dragoon
    {
        private DragoonSpells _mySpells;

        private DragoonSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new DragoonSpells()); }
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
            if (Ultima.UltSettings.DragoonLegSweep)
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

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.DragoonForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> SkullSunder()
        {
            if (Ultima.UltSettings.DragoonSkullSunder)
            {
                return await MySpells.CrossClass.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (Ultima.UltSettings.DragoonFracture &&
                !Core.Player.CurrentTarget.HasAura(MySpells.CrossClass.Fracture.Name, true, 4000))
            {
                return await MySpells.CrossClass.Fracture.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.DragoonBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.DragoonMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.DragoonFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.DragoonSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Haymaker()
        {
            if (Ultima.UltSettings.DragoonHaymaker)
            {
                return await MySpells.CrossClass.Haymaker.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.DragoonInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.DragoonMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> Jump()
        {
            if (Ultima.UltSettings.DragoonJump &&
                Ultima.LastSpell.Name != MySpells.SpineshatterDive.Name &&
                Ultima.LastSpell.Name != MySpells.DragonfireDive.Name)
            {
                return await MySpells.Jump.Cast();
            }
            return false;
        }

        private async Task<bool> ElusiveJump()
        {
            return await MySpells.ElusiveJump.Cast();
        }

        private async Task<bool> SpineshatterDive()
        {
            if (Ultima.UltSettings.DragoonSpineshatterDive &&
                Ultima.LastSpell.Name != MySpells.Jump.Name &&
                Ultima.LastSpell.Name != MySpells.DragonfireDive.Name)
            {
                return await MySpells.SpineshatterDive.Cast();
            }
            return false;
        }

        private async Task<bool> PowerSurge()
        {
            if (Ultima.UltSettings.DragoonPowerSurge &&
                Actionmanager.CanCast(MySpells.Jump.Name, Core.Player.CurrentTarget))
            {
                return await MySpells.PowerSurge.Cast();
            }
            return false;
        }

        private async Task<bool> DragonfireDive()
        {
            if (Ultima.UltSettings.DragoonDragonfireDive &&
                Ultima.LastSpell.Name != MySpells.Jump.Name &&
                Ultima.LastSpell.Name != MySpells.SpineshatterDive.Name)
            {
                return await MySpells.DragonfireDive.Cast();
            }
            return false;
        }

        private async Task<bool> BattleLitany()
        {
            if (Ultima.UltSettings.DragoonBattleLitany)
            {
                return await MySpells.BattleLitany.Cast();
            }
            return false;
        }

        private async Task<bool> BloodOfTheDragon()
        {
            if (!Core.Player.HasAura(MySpells.BloodOfTheDragon.Name))
            {
                if (Ultima.LastSpell.Name == MySpells.Disembowel.Name ||
                    Ultima.LastSpell.Name == MySpells.VorpalThrust.Name)
                {
                    return await MySpells.BloodOfTheDragon.Cast();
                }
            }
            return false;
        }

        private async Task<bool> FangAndClaw()
        {
            return await MySpells.FangAndClaw.Cast();
        }

        private async Task<bool> WheelingThrust()
        {
            return await MySpells.WheelingThrust.Cast();
        }

        private async Task<bool> Geirskogul()
        {
            if (Core.Player.HasAura(MySpells.BloodOfTheDragon.Name, true, 21000))
            {
                return await MySpells.Geirskogul.Cast();
            }
            return false;
        }

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