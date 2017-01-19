using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class DarkKnight
    {
        private DarkKnightSpells _mySpells;

        private DarkKnightSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new DarkKnightSpells()); }
        }

        #region Job Spells

        private async Task<bool> HardSlash()
        {
            return await MySpells.HardSlash.Cast();
        }

        private async Task<bool> Shadowskin()
        {
            return await MySpells.Shadowskin.Cast();
        }

        private async Task<bool> SpinningSlash()
        {
            if (Actionmanager.LastSpell.Name == MySpells.HardSlash.Name)
            {
                return await MySpells.SpinningSlash.Cast();
            }
            return false;
        }

        private async Task<bool> Scourge()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Scourge.Name, true, 4000) &&
                !Core.Player.HasAura(MySpells.DarkArts.Name))
            {
                return await MySpells.Scourge.Cast();
            }
            return false;
        }

        private async Task<bool> Unleash()
        {
            if (Core.Player.HasAura(814) &&
                Helpers.EnemiesNearPlayer(5) > 0)
            {
                return await MySpells.Unleash.Cast();
            }
            return false;
        }

        private async Task<bool> LowBlow()
        {
            if (Ultima.UltSettings.DarkKnightLowBlow)
            {
                return await MySpells.LowBlow.Cast();
            }
            return false;
        }

        private async Task<bool> SyphonStrike()
        {
            if (Actionmanager.LastSpell.Name == MySpells.HardSlash.Name)
            {
                return await MySpells.SyphonStrike.Cast();
            }
            return false;
        }

        private async Task<bool> Unmend()
        {
            if (Core.Player.TargetDistance(10))
            {
                return await MySpells.Unmend.Cast();
            }
            return false;
        }

        private async Task<bool> BloodWeapon()
        {
            if (Ultima.UltSettings.DarkKnightBloodWeapon)
            {
                return await MySpells.BloodWeapon.Cast();
            }
            return false;
        }

        private async Task<bool> Reprisal()
        {
            if (Ultima.UltSettings.DarkKnightReprisal)
            {
                return await MySpells.Reprisal.Cast();
            }
            return false;
        }

        private async Task<bool> PowerSlash()
        {
            if (Actionmanager.LastSpell.Name == MySpells.SpinningSlash.Name)
            {
                return await MySpells.PowerSlash.Cast();
            }
            return false;
        }

        private async Task<bool> Darkside()
        {
            if (!Core.Player.HasAura(MySpells.Darkside.Name))
            {
                return await MySpells.Darkside.Cast();
            }
            return false;
        }

        private async Task<bool> Grit()
        {
            return await MySpells.Grit.Cast();
        }

        private async Task<bool> DarkDance()
        {
            return await MySpells.DarkDance.Cast();
        }

        private async Task<bool> BloodPrice()
        {
            return await MySpells.BloodPrice.Cast();
        }

        private async Task<bool> Souleater()
        {
            if (Actionmanager.LastSpell.Name == MySpells.SyphonStrike.Name)
            {
                if (Ultima.UltSettings.DarkKnightDarkArts &&
                    !Core.Player.HasAura(MySpells.DarkArts.Name) &&
                    Core.Player.TargetDistance(3, false) &&
                    Core.Player.CurrentManaPercent >= 50 &&
                    (!Actionmanager.HasSpell(MySpells.Delirium.Name) ||
                    Core.Player.CurrentTarget.HasAura(MySpells.Delirium.Name, false, 4000) ||
                    Core.Player.CurrentTarget.HasAura("Dragon Kick")))
                {
                    if (await MySpells.DarkArts.Cast())
                    {
                        await Coroutine.Wait(3000, () => Actionmanager.CanCast(MySpells.Souleater.Name, Core.Player.CurrentTarget));
                    }
                }
                return await MySpells.Souleater.Cast();
            }
            return false;
        }

        private async Task<bool> DarkPassenger()
        {
            return await MySpells.DarkPassenger.Cast();
        }

        private async Task<bool> DarkMind()
        {
            return await MySpells.DarkMind.Cast();
        }

        private async Task<bool> DarkArts()
        {
            return await MySpells.DarkArts.Cast();
        }

        private async Task<bool> ShadowWall()
        {
            return await MySpells.ShadowWall.Cast();
        }

        private async Task<bool> Delirium()
        {
            if (Ultima.UltSettings.DarkKnightDelirium &&
                Actionmanager.LastSpell.Name == MySpells.SyphonStrike.Name &&
                !Core.Player.HasAura(MySpells.DarkArts.Name) &&
                !Core.Player.CurrentTarget.HasAura(MySpells.Delirium.Name, false, 4000) &&
                !Core.Player.CurrentTarget.HasAura("Dragon Kick"))
            {
                return await MySpells.Delirium.Cast();
            }
            return false;
        }

        private async Task<bool> LivingDead()
        {
            return await MySpells.LivingDead.Cast();
        }

        private async Task<bool> SaltedEarth()
        {
            if (Ultima.UltSettings.DarkKnightSaltedEarth)
            {
                return await MySpells.SaltedEarth.Cast();
            }
            return false;
        }

        private async Task<bool> Plunge()
        {
            if (Ultima.UltSettings.DarkKnightPlunge)
            {
                return await MySpells.Plunge.Cast();
            }
            return false;
        }

        private async Task<bool> AbyssalDrain()
        {
            return await MySpells.AbyssalDrain.Cast();
        }

        private async Task<bool> SoleSurvivor()
        {
            return await MySpells.SoleSurvivor.Cast();
        }

        private async Task<bool> CarveAndSplit()
        {
            if (Core.Player.CurrentManaPercent < 70)
            {
                return await MySpells.CarveAndSplit.Cast();
            }
            return false;
        }

        #endregion

        #region Cross Class Spells

        #region Gladiator

        private async Task<bool> SavageBlade()
        {
            if (Ultima.UltSettings.DarkKnightSavageBlade)
            {
                return await MySpells.CrossClass.SavageBlade.Cast();
            }
            return false;
        }

        private async Task<bool> Flash()
        {
            if (Ultima.UltSettings.DarkKnightFlash)
            {
                return await MySpells.CrossClass.Flash.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Ultima.UltSettings.DarkKnightConvalescence)
            {
                return await MySpells.CrossClass.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Provoke()
        {
            if (Ultima.UltSettings.DarkKnightProvoke)
            {
                return await MySpells.CrossClass.Provoke.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Ultima.UltSettings.DarkKnightAwareness)
            {
                return await MySpells.CrossClass.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.DarkKnightForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> SkullSunder()
        {
            if (Ultima.UltSettings.DarkKnightSkullSunder)
            {
                return await MySpells.CrossClass.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (Ultima.UltSettings.DarkKnightFracture)
            {
                return await MySpells.CrossClass.Fracture.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.DarkKnightBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.DarkKnightMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region PvP Spells



        #endregion
    }
}