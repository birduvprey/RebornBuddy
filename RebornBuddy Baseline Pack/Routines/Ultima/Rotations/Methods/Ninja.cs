using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System.Linq;
using System.Threading.Tasks;
using UltimaCR.Spells;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Ninja
    {
        private NinjaSpells _mySpells;

        private NinjaSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new NinjaSpells()); }
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
            if (Ultima.UltSettings.NinjaKissOfTheWasp ||
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
            if (Core.Player.HasAura(MySpells.Huton.Name) &&
                (!Actionmanager.HasSpell(MySpells.ShadowFang.Name) ||
                Core.Player.CurrentTarget.HasAura(MySpells.ShadowFang.Name, true, 5000)))
            {
                if (!Ultima.UltSettings.NinjaDancingEdge ||
                    !Actionmanager.HasSpell(MySpells.DancingEdge.Name) ||
                    (Core.Player.CurrentTarget.HasAura(MySpells.DancingEdge.Name, false, 6000) ||
                    Core.Player.CurrentTarget.HasAura("Storm's Eye")))
                {
                    if (!Core.Player.CurrentTarget.HasAura("Mutilation", true, 5000))
                    {
                        return await MySpells.Mutilate.Cast();
                    }
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
            if (Ultima.UltSettings.NinjaAssassinate)
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
            if (Ultima.UltSettings.NinjaGoad)
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
            if (BotManager.Current.IsAutonomous &&
                Core.Player.HasTarget &&
                Core.Player.CurrentTarget.IsFacing(Core.Player) &&
                Core.Player.HasAura("Suiton"))
            {
                return await MySpells.SneakAttack.Cast();
            }
            return false;
        }

        private async Task<bool> AeolianEdge()
        {
            if (Actionmanager.LastSpell.Name == MySpells.GustSlash.Name)
            {
                if (await MySpells.Duality.Cast())
                {
                    await Coroutine.Wait(3000, () => Actionmanager.CanCast(MySpells.AeolianEdge.Name, Core.Player.CurrentTarget));
                }
                return await MySpells.AeolianEdge.Cast();
            }
            return false;
        }

        private async Task<bool> KissOfTheViper()
        {
            if (Ultima.UltSettings.NinjaKissOfTheViper &&
                !Core.Player.HasAura(MySpells.KissOfTheViper.Name))
            {
                return await MySpells.KissOfTheViper.Cast();
            }
            return false;
        }

        private async Task<bool> Jugulate()
        {
            if (Ultima.UltSettings.NinjaJugulate)
            {
                return await MySpells.Jugulate.Cast();
            }
            return false;
        }

        private async Task<bool> DancingEdge()
        {
            if (Ultima.UltSettings.NinjaDancingEdge &&
                Actionmanager.LastSpell.Name == MySpells.GustSlash.Name &&
                !Core.Player.CurrentTarget.HasAura(MySpells.DancingEdge.Name, false, 6000) &&
                !Core.Player.CurrentTarget.HasAura("Storm's Eye"))
            {
                return await MySpells.DancingEdge.Cast();
            }
            return false;
        }

        private async Task<bool> DeathBlossom()
        {
            return await MySpells.DeathBlossom.Cast();
        }

        private async Task<bool> ShadowFang()
        {
            if (Core.Player.HasAura(MySpells.Huton.Name))
            {
                if (!Ultima.UltSettings.NinjaDancingEdge ||
                    (Core.Player.CurrentTarget.HasAura(MySpells.DancingEdge.Name, false, 6000) ||
                    Core.Player.CurrentTarget.HasAura("Storm's Eye")))
                {
                    if (!Core.Player.CurrentTarget.HasAura(MySpells.ShadowFang.Name, true, 5000) &&
                        Actionmanager.LastSpell.Name == MySpells.SpinningEdge.Name)
                    {
                        return await MySpells.ShadowFang.Cast();
                    }
                }
            }
            return false;
        }

        private async Task<bool> TrickAttack()
        {
            if (Core.Player.HasTarget &&
                Core.Player.CurrentTarget.IsBehind &&
                Core.Player.HasAura("Suiton"))
            {
                return await MySpells.TrickAttack.Cast();
            }
            return false;
        }

        #endregion

        #region Cross Class Spells

        #region Lancer

        private async Task<bool> Feint()
        {
            if (Ultima.UltSettings.NinjaFeint)
            {
                return await MySpells.CrossClass.Feint.Cast();
            }
            return false;
        }

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.NinjaKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.NinjaInvigorate &&
                Core.Player.CurrentTP <= 540)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.NinjaBloodForBlood)
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.NinjaFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.NinjaSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Haymaker()
        {
            if (Ultima.UltSettings.NinjaHaymaker)
            {
                return await MySpells.CrossClass.Haymaker.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.NinjaInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.NinjaMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> Ninjutsu()
        {
            if (Actionmanager.CanCast(MySpells.Ten.ID, Core.Player) &&
                Core.Player.HasAura("Mudra"))
            {
                return await MySpells.Ninjutsu.Cast();
            }
            return false;
        }

        private async Task<bool> Shukuchi()
        {
            if (Ultima.UltSettings.NinjaShukuchi &&
                Core.Player.TargetDistance(10))
            {
                return await MySpells.Shukuchi.Cast();
            }
            return false;
        }

        private async Task<bool> Kassatsu()
        {
            if (Core.Player.CurrentTarget.HasAura("Vulnerability Up") ||
                Ultima.UltSettings.SmartTarget &&
                Helpers.EnemiesNearPlayer(5) > 2 ||
                Ultima.UltSettings.MultiTarget ||
                BotManager.Current.IsAutonomous &&
                !Actionmanager.CanCast(MySpells.Ten.ID, Core.Player) &&
                DataManager.GetSpellData(MySpells.SneakAttack.ID).Cooldown.TotalMilliseconds > 5 &&
                Core.Player.HasAura(MySpells.Huton.Name, true, 20000))
            {
                return await MySpells.Kassatsu.Cast();
            }
            return false;
        }

        private async Task<bool> FumaShuriken()
        {
            if (Ultima.UltSettings.NinjaFumaShuriken ||
                Core.Player.ClassLevel < MySpells.Raiton.Level)
            {
                if (Actionmanager.CanCast(MySpells.Ten.ID, Core.Player) &&
                    DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds <= DataManager.GetSpellData(2240).AdjustedCooldown.TotalMilliseconds - 1000 &&
                    Core.Player.TargetDistance(25, false) &&
                    Core.Player.CurrentTarget.CanAttack &&
                    Core.Player.CurrentTarget.InLineOfSight() ||
                    Core.Player.HasAura("Mudra"))
                {
                    if (!Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                    Ultima.LastSpell.ID != MySpells.Chi.ID &&
                    Ultima.LastSpell.ID != MySpells.Jin.ID &&
                    Ultima.LastSpell.ID != MySpells.Ninjutsu.ID)
                    {
                        if (await MySpells.Ten.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player));
                        }
                    }
                    if (Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                        (Ultima.LastSpell.ID == MySpells.Ten.ID ||
                        Ultima.LastSpell.ID == MySpells.FumaShuriken.ID))
                    {
                        if (await MySpells.FumaShuriken.Cast())
                        {
                            await Coroutine.Wait(2000, () => !Core.Player.HasAura("Mudra"));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private async Task<bool> Katon()
        {
            if (Actionmanager.CanCast(MySpells.Chi.ID, Core.Player) &&
                DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds <= DataManager.GetSpellData(2240).AdjustedCooldown.TotalMilliseconds - 1000 &&
                Core.Player.TargetDistance(15, false) &&
                Core.Player.CurrentTarget.CanAttack &&
                Core.Player.CurrentTarget.InLineOfSight() ||
                Core.Player.HasAura("Mudra"))
            {
                if (Helpers.EnemiesNearTarget(5) > 2 ||
                    Ultima.UltSettings.MultiTarget)
                {
                    if (!Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                    Ultima.LastSpell.ID != MySpells.Ten.ID &&
                    Ultima.LastSpell.ID != MySpells.Jin.ID &&
                    Ultima.LastSpell.ID != MySpells.Ninjutsu.ID)
                    {
                        if (await MySpells.Chi.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player));
                        }
                    }
                    if (Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                        Ultima.LastSpell.ID == MySpells.Chi.ID)
                    {
                        if (await MySpells.Ten.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Ten.ID, Core.Player));
                        }
                    }
                    if (Ultima.LastSpell.ID == MySpells.Ten.ID ||
                        Ultima.LastSpell.ID == MySpells.Katon.ID)
                    {
                        if (await MySpells.Katon.Cast())
                        {
                            await Coroutine.Wait(2000, () => !Core.Player.HasAura("Mudra"));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private async Task<bool> Raiton()
        {
            if (Ultima.UltSettings.NinjaRaiton)
            {
                if (Actionmanager.CanCast(MySpells.Chi.ID, Core.Player) &&
                    DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds <= DataManager.GetSpellData(2240).AdjustedCooldown.TotalMilliseconds - 1000 &&
                    Core.Player.TargetDistance(15, false) &&
                    Core.Player.CurrentTarget.CanAttack &&
                    Core.Player.CurrentTarget.InLineOfSight() ||
                    Core.Player.HasAura("Mudra"))
                {
                    if (!Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                    Ultima.LastSpell.ID != MySpells.Chi.ID &&
                    Ultima.LastSpell.ID != MySpells.Jin.ID &&
                    Ultima.LastSpell.ID != MySpells.Ninjutsu.ID)
                    {
                        if (await MySpells.Ten.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player));
                        }
                    }
                    if (Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                        Ultima.LastSpell.ID == MySpells.Ten.ID)
                    {
                        if (await MySpells.Chi.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Chi.ID, Core.Player));
                        }
                    }
                    if (Ultima.LastSpell.ID == MySpells.Chi.ID ||
                        Ultima.LastSpell.ID == MySpells.Raiton.ID)
                    {
                        if (await MySpells.Raiton.Cast())
                        {
                            await Coroutine.Wait(2000, () => !Core.Player.HasAura("Mudra"));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private async Task<bool> Hyoton()
        {
            if (Actionmanager.CanCast(MySpells.Jin.ID, Core.Player) &&
                DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds <= DataManager.GetSpellData(2240).AdjustedCooldown.TotalMilliseconds - 1000 &&
                Core.Player.TargetDistance(25, false) &&
                Core.Player.CurrentTarget.CanAttack &&
                Core.Player.CurrentTarget.InLineOfSight() ||
                Core.Player.HasAura("Mudra"))
            {
                if (!Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                    Ultima.LastSpell.ID != MySpells.Chi.ID &&
                    Ultima.LastSpell.ID != MySpells.Jin.ID &&
                    Ultima.LastSpell.ID != MySpells.Ninjutsu.ID)
                {
                    if (await MySpells.Ten.Cast())
                    {
                        await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player));
                    }
                }
                if (Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                        Ultima.LastSpell.ID == MySpells.Ten.ID)
                {
                    if (await MySpells.Jin.Cast())
                    {
                        await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Jin.ID, Core.Player));
                    }
                }
                if (Ultima.LastSpell.ID == MySpells.Jin.ID ||
                        Ultima.LastSpell.ID == MySpells.Hyoton.ID)
                {
                    if (await MySpells.Hyoton.Cast())
                    {
                        await Coroutine.Wait(2000, () => !Core.Player.HasAura("Mudra"));
                        return true;
                    }
                }
            }
            return false;
        }

        private async Task<bool> Huton()
        {
            if (Actionmanager.CanCast(MySpells.Jin.ID, Core.Player))
            {
                if (!Core.Player.HasAura(MySpells.Huton.Name) &&
                    DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds <= DataManager.GetSpellData(2240).AdjustedCooldown.TotalMilliseconds - 1000 ||
                    !Actionmanager.HasSpell(MySpells.ArmorCrush.Name) &&
                    !Core.Player.HasAura(MySpells.Huton.Name, true, 20000) &&
                    DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds <= DataManager.GetSpellData(2240).AdjustedCooldown.TotalMilliseconds - 1000 ||
                    Core.Player.HasAura("Mudra"))
                {
                    if (!Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                    Ultima.LastSpell.ID != MySpells.Ten.ID &&
                    Ultima.LastSpell.ID != MySpells.Jin.ID &&
                    Ultima.LastSpell.ID != MySpells.Ninjutsu.ID)
                    {
                        if (await MySpells.Chi.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player));
                        }
                    }
                    if (Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                        Ultima.LastSpell.ID == MySpells.Chi.ID)
                    {
                        if (await MySpells.Jin.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Jin.ID, Core.Player));
                        }
                    }
                    if (Ultima.LastSpell.ID == MySpells.Jin.ID)
                    {
                        if (await MySpells.Ten.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Ten.ID, Core.Player));
                        }
                    }
                    if (Ultima.LastSpell.ID == MySpells.Ten.ID ||
                        Ultima.LastSpell.ID == MySpells.Huton.ID)
                    {
                        if (await MySpells.Huton.Cast())
                        {
                            await Coroutine.Wait(2000, () => !Core.Player.HasAura("Mudra"));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private async Task<bool> Doton()
        {
            if (Actionmanager.CanCast(MySpells.Jin.ID, Core.Player) &&
                DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds <= DataManager.GetSpellData(2240).AdjustedCooldown.TotalMilliseconds - 1000 &&
                Core.Player.HasAura(MySpells.Kassatsu.Name) ||
                Core.Player.HasAura("Mudra"))
            {
                if (Ultima.UltSettings.SmartTarget &&
                    Helpers.EnemiesNearPlayer(5) > 2 ||
                    Ultima.UltSettings.MultiTarget)
                {
                    if (!Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                    Ultima.LastSpell.ID != MySpells.Chi.ID &&
                    Ultima.LastSpell.ID != MySpells.Jin.ID &&
                    Ultima.LastSpell.ID != MySpells.Ninjutsu.ID)
                    {
                        if (await MySpells.Ten.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player));
                        }
                    }
                    if (Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                        Ultima.LastSpell.ID == MySpells.Ten.ID)
                    {
                        if (await MySpells.Jin.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Jin.ID, Core.Player));
                        }
                    }
                    if (Ultima.LastSpell.ID == MySpells.Jin.ID)
                    {
                        if (await MySpells.Chi.Cast())
                        {
                            await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Chi.ID, Core.Player));
                        }
                    }
                    if (Ultima.LastSpell.ID == MySpells.Chi.ID ||
                        Ultima.LastSpell.ID == MySpells.Doton.ID)
                    {
                        if (await MySpells.Doton.Cast())
                        {
                            await Coroutine.Wait(2000, () => !Core.Player.HasAura("Mudra"));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private async Task<bool> Suiton()
        {
            if (Actionmanager.CanCast(MySpells.Jin.ID, Core.Player) &&
                DataManager.GetSpellData(2240).Cooldown.TotalMilliseconds <= DataManager.GetSpellData(2240).AdjustedCooldown.TotalMilliseconds - 1000 &&
                DataManager.GetSpellData(MySpells.TrickAttack.ID).Cooldown.TotalMilliseconds == 0 &&
                Core.Player.TargetDistance(15, false) &&
                Core.Player.CurrentTarget.CanAttack &&
                !Core.Player.CurrentTarget.HasAura(MySpells.TrickAttack.Name, false, 3000) ||
                Core.Player.HasAura("Mudra"))
            {
                if (!Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                    Ultima.LastSpell.ID != MySpells.Chi.ID &&
                    Ultima.LastSpell.ID != MySpells.Jin.ID &&
                    Ultima.LastSpell.ID != MySpells.Ninjutsu.ID)

                {
                    if (await MySpells.Ten.Cast())
                    {
                        await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player));
                    }
                }
                if (Actionmanager.CanCast(MySpells.Ninjutsu.ID, Core.Player) &&
                        Ultima.LastSpell.ID == MySpells.Ten.ID)
                {
                    if (await MySpells.Chi.Cast())
                    {
                        await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Chi.ID, Core.Player));
                    }
                }
                if (Ultima.LastSpell.ID == MySpells.Chi.ID)
                {
                    if (await MySpells.Jin.Cast())
                    {
                        await Coroutine.Wait(2000, () => Actionmanager.CanCast(MySpells.Jin.ID, Core.Player));
                    }
                }
                if (Ultima.LastSpell.ID == MySpells.Jin.ID ||
                        Ultima.LastSpell.ID == MySpells.Suiton.ID)
                {
                    if (await MySpells.Suiton.Cast())
                    {
                        await Coroutine.Wait(2000, () => !Core.Player.HasAura("Mudra"));
                        return true;
                    }
                }
            }
            return false;
        }

        private async Task<bool> SmokeScreen()
        {
            return await MySpells.SmokeScreen.Cast();
        }

        private async Task<bool> ArmorCrush()
        {
            if (Actionmanager.LastSpell.Name == MySpells.GustSlash.Name)
            {
                if (Core.Player.HasAura(MySpells.Huton.Name) &&
                    !Core.Player.HasAura(MySpells.Huton.Name, true, 40000) ||
                    Core.Player.HasTarget &&
                    Core.Player.CurrentTarget.IsFlanking &&
                    (Core.Player.CurrentTarget.HasAura(MySpells.DancingEdge.Name, false, 6000) ||
                    Core.Player.CurrentTarget.HasAura("Storm's Eye")))
                {
                    return await MySpells.ArmorCrush.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Shadewalker()
        {
            return await MySpells.Shadewalker.Cast();
        }

        private async Task<bool> Duality()
        {
            return await MySpells.Duality.Cast();
        }

        private async Task<bool> DreamWithinADream()
        {
            if (Ultima.UltSettings.NinjaDreamWithinADream)
            {
                return await MySpells.DreamWithinADream.Cast();
            }
            return false;
        }

        #endregion

        #region Custom Spells

        private static bool RecentMudra
        {
            get
            {
                return (Spell.RecentSpell.Keys.Any(rm => rm.Contains("Ten") || rm.Contains("Chi") || rm.Contains("Jin")));
            }
        }
        
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