using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System;
using System.Threading.Tasks;
using UltimaCR.Spells;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class BlackMage
    {
        private BlackMageSpells _mySpells;

        private BlackMageSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new BlackMageSpells()); }
        }

        #region Class Spells

        private async Task<bool> Blizzard()
        {
            if (UmbralAura &&
                Core.Player.CurrentManaPercent < 90)
            {
                return await MySpells.Blizzard.Cast();
            }
            if (!UmbralAura &&
                LowMP &&
                !Actionmanager.HasSpell(MySpells.BlizzardIII.Name))
            {
                return await MySpells.Blizzard.Cast();
            }
            return false;
        }

        private async Task<bool> Fire()
        {
            if (!Actionmanager.HasSpell(MySpells.FireIII.Name))
            {
                if (UmbralAura &&
                    Core.Player.CurrentManaPercent >= 90)
                {
                    return await MySpells.Fire.Cast();
                }
            }
            if (!UmbralAura)
            {
                return await MySpells.Fire.Cast();
            }
            return false;
        }

        private async Task<bool> Transpose()
        {
            if (AstralAura)
            {
                if (!Core.Player.InCombat &&
                    LowMP)
                {
                    return await MySpells.Transpose.Cast();
                }
            }
            if (UmbralAura &&
                Core.Player.HasAura("Firestarter"))
            {
                if (Ultima.LastSpell.Name == MySpells.Scathe.Name &&
                    Core.Player.CurrentManaPercent != 100)
                {
                    await Coroutine.Wait(5000, () => Core.Player.CurrentManaPercent == 100 ||
                                                     MovementManager.IsMoving);
                }
                if (Core.Player.CurrentManaPercent == 100)
                {
                    return await MySpells.Transpose.Cast();
                }
            }
            if (!Actionmanager.HasSpell(MySpells.BlizzardIII.Name) &&
                LowMP)
            {
                return await MySpells.Transpose.Cast();
            }
            return false;
        }

        private async Task<bool> Thunder()
        {
            if (UmbralAura &&
                Core.Player.CurrentManaPercent < 100)
            {
                if (!Actionmanager.HasSpell(MySpells.BlizzardIII.Name) &&
                    !Core.Player.CurrentTarget.HasAura("Thunder", true, 3000))
                {
                    return await MySpells.Thunder.Cast();
                }
                Spell.RecentSpell.RemoveAll(t => DateTime.UtcNow > t);
                if (!RecentThunder)
                {
                    return await MySpells.Thunder.Cast();
                }
            }
            if (!AstralAura &&
                !UmbralAura)
            {
                if (!Actionmanager.HasSpell(MySpells.ThunderII.Name) &&
                    !Core.Player.CurrentTarget.HasAura("Thunder", true))
                {
                    return await MySpells.Thunder.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Surecast()
        {
            return await MySpells.Surecast.Cast();
        }

        private async Task<bool> Sleep()
        {
            return await MySpells.Sleep.Cast();
        }

        private async Task<bool> BlizzardII()
        {
            return await MySpells.BlizzardII.Cast();
        }

        private async Task<bool> Scathe()
        {
            if (MovementManager.IsMoving &&
                !LowMP &&
                !Core.Player.HasAura(MySpells.Swiftcast.Name))
            {
                return await MySpells.Scathe.Cast();
            }
            if (Actionmanager.HasSpell(MySpells.BlizzardIII.Name) &&
                UmbralAura &&
                Core.Player.CurrentManaPercent < 100)
            {
                if (Ultima.LastSpell.Name == MySpells.Blizzard.Name ||
                    Ultima.LastSpell.Name == MySpells.Thunder.Name ||
                    Ultima.LastSpell.Name == MySpells.ThunderII.Name ||
                    Ultima.LastSpell.Name == MySpells.ThunderIII.Name)
                {
                    return await MySpells.Scathe.Cast();
                }
            }
            return false;
        }

        private async Task<bool> FireII()
        {
            if (!UmbralAura)
            {
                return await MySpells.FireII.Cast();
            }
            return false;
        }

        private async Task<bool> ThunderII()
        {
            if (UmbralAura &&
                Core.Player.CurrentManaPercent < 100)
            {
                if (!Actionmanager.HasSpell(MySpells.BlizzardIII.Name) &&
                    !Core.Player.CurrentTarget.HasAura("Thunder", true, 3000))
                {
                    return await MySpells.Thunder.Cast();
                }
                Spell.RecentSpell.RemoveAll(t => DateTime.UtcNow > t);
                if (!RecentThunder)
                {
                    return await MySpells.Thunder.Cast();
                }
            }
            if (!AstralAura &&
                !UmbralAura)
            {
                if (!Actionmanager.HasSpell(MySpells.ThunderIII.Name) &&
                    !Core.Player.CurrentTarget.HasAura("Thunder", true))
                {
                    return await MySpells.Thunder.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (AstralAura)
            {
                if (!Actionmanager.CanCast(MySpells.Convert.Name, Core.Player) &&
                    !LowMP)
                {
                    return await MySpells.Swiftcast.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Manaward()
        {
            return await MySpells.Manaward.Cast();
        }

        private async Task<bool> FireIII()
        {
            if (UmbralAura)
            {
                if (Core.Player.CurrentManaPercent == 100 ||
                    Ultima.LastSpell.Name == MySpells.Scathe.Name)
                {
                    if (await MySpells.FireIII.Cast())
                    {
                        await Coroutine.Wait(5000, () => AstralAura);
                        return true;
                    }
                }
            }
            if (!AstralAura &&
                !UmbralAura)
            {
                if (await MySpells.FireIII.Cast())
                {
                    await Coroutine.Wait(5000, () => AstralAura);
                    return true;
                }
            }
            return false;
        }

        private async Task<bool> BlizzardIII()
        {
            if (LowMP)
            {
                if (AstralAura)
                {
                    if (!Actionmanager.HasSpell(MySpells.Flare.Name))
                    {
                        if (await MySpells.BlizzardIII.Cast())
                        {
                            await Coroutine.Wait(5000, () => UmbralAura);
                            return true;
                        }
                    }
                    if (!Actionmanager.CanCast(MySpells.Swiftcast.Name, Core.Player) ||
                        !Actionmanager.CanCast(MySpells.Convert.Name, Core.Player))
                    {
                        if (await MySpells.BlizzardIII.Cast())
                        {
                            await Coroutine.Wait(5000, () => UmbralAura);
                            return true;
                        }
                    }
                }
                if (!AstralAura &&
                    !UmbralAura)
                {
                    if (await MySpells.BlizzardIII.Cast())
                    {
                        await Coroutine.Wait(5000, () => UmbralAura);
                        return true;
                    }
                }
            }
            return false;
        }

        private async Task<bool> Lethargy()
        {
            return await MySpells.Lethargy.Cast();
        }

        private async Task<bool> ThunderIII()
        {
            if (!AstralAura &&
                !UmbralAura &&
                !Core.Player.CurrentTarget.HasAura("Thunder", true))
            {
                return await MySpells.ThunderIII.Cast();
            }
            return false;
        }

        private async Task<bool> AetherialManipulation()
        {
            return await MySpells.AetherialManipulation.Cast();
        }

        #endregion

        #region Cross Class Spells

        #region Arcanist

        private async Task<bool> Ruin()
        {
            if (Ultima.UltSettings.BlackMageRuin)
            {
                return await MySpells.CrossClass.Ruin.Cast();
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.BlackMagePhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.BlackMageVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.BlackMageEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Archer

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.BlackMageRagingStrikes)
            {
                if (AstralAura &&
                    Core.Player.CurrentManaPercent >= 60)
                {
                    return await MySpells.CrossClass.RagingStrikes.Cast();
                }
            }
            return false;
        }

        private async Task<bool> HawksEye()
        {
            if (Ultima.UltSettings.BlackMageHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.BlackMageQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> Freeze()
        {
            return await MySpells.Freeze.Cast();
        }

        private async Task<bool> Apocatastasis()
        {
            return await MySpells.Apocatastasis.Cast();
        }

        private async Task<bool> Manawall()
        {
            return await MySpells.Manawall.Cast();
        }

        private async Task<bool> Flare()
        {
            if (Actionmanager.HasSpell(MySpells.Flare.Name) &&
                AstralAura &&
                Actionmanager.CanCast(MySpells.Convert.Name, Core.Player))
            {
                if (Core.Player.CurrentMana <= 904 ||
                    Ultima.LastSpell.Name == MySpells.FireII.Name &&
                    Core.Player.CurrentMana <= 1116)
                {
                    if (Actionmanager.CanCast(MySpells.Swiftcast.Name, Core.Player) ||
                        Core.Player.HasAura(MySpells.Swiftcast.Name))
                    {
                        if (await MySpells.Swiftcast.Cast())
                        {
                            await Coroutine.Wait(3000, () => Actionmanager.CanCast(MySpells.Flare.Name, Core.Player.CurrentTarget));
                        }
                        if (await MySpells.Flare.Cast())
                        {
                            await Coroutine.Wait(3000, () => Actionmanager.CanCast(MySpells.Convert.Name, Core.Player));
                        }
                        if (await MySpells.Convert.Cast())
                        {
                            await Coroutine.Wait(3000, () => !Actionmanager.CanCast(MySpells.Convert.Name, Core.Player));
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        private async Task<bool> LeyLines()
        {
            return await MySpells.LeyLines.Cast();
        }

        private async Task<bool> Sharpcast()
        {
            return await MySpells.Sharpcast.Cast();
        }

        private async Task<bool> Enochian()
        {
            return await MySpells.Enochian.Cast();
        }

        private async Task<bool> BlizzardIV()
        {
            return await MySpells.BlizzardIV.Cast();
        }

        private async Task<bool> FireIV()
        {
            return await MySpells.FireIV.Cast();
        }

        #endregion

        #region Custom Spells

        private static bool UmbralAura
        {
            get
            {
                return (Core.Player.HasAura("Umbral Ice") ||
                       Core.Player.HasAura("Umbral Ice II") ||
                       Core.Player.HasAura("Umbral Ice III"));
            }
        }

        private static bool AstralAura
        {
            get
            {
                return (Core.Player.HasAura("Astral Fire") ||
                       Core.Player.HasAura("Astral Fire II") ||
                       Core.Player.HasAura("Astral Fire III"));
            }
        }

        private static bool RecentThunder
        {
            get
            {
                return (Spell.RecentSpell.ContainsKey(Core.Player.CurrentTarget.ObjectId.ToString("X") + "-" + "Thunder") ||
                       Spell.RecentSpell.ContainsKey(Core.Player.CurrentTarget.ObjectId.ToString("X") + "-" + "Thunder II") ||
                       Spell.RecentSpell.ContainsKey(Core.Player.CurrentTarget.ObjectId.ToString("X") + "-" + "Thunder III"));
            }
        }

        private static bool LowMP
        {
            get
            {
                return (Core.Player.CurrentManaPercent <= 32 &&
                    (Ultima.UltSettings.SmartTarget &&
                    Helpers.EnemiesNearTarget(5) >= 3 ||
                    Ultima.UltSettings.MultiTarget) ||
                    Core.Player.CurrentManaPercent <= 26.3);
            }
        }

        private async Task<bool> Thundercloud()
        {
            if (Core.Player.HasAura("Thundercloud"))
            {
                if (!UmbralAura)
                {
                    if (Ultima.LastSpell.Name == MySpells.Fire.Name ||
                        Ultima.LastSpell.Name == MySpells.FireII.Name ||
                        !Core.Player.HasAura("Thundercloud", false, 5000))
                    {
                        if (!Actionmanager.HasSpell(MySpells.ThunderIII.Name))
                        {
                            return await MySpells.ThunderII.Cast();
                        }
                        return await MySpells.ThunderIII.Cast();
                    }
                }
                if (UmbralAura)
                {
                    Spell.RecentSpell.RemoveAll(t => DateTime.UtcNow > t);
                    if (!RecentThunder)
                    {
                        if (!Actionmanager.HasSpell(MySpells.ThunderIII.Name))
                        {
                            return await MySpells.ThunderII.Cast();
                        }
                        return await MySpells.ThunderIII.Cast();
                    }
                }
            }
            return false;
        }

        private async Task<bool> Firestarter()
        {
            if (!UmbralAura &&
                Core.Player.HasAura("Firestarter"))
            {
                if (await MySpells.FireIII.Cast())
                {
                    await Coroutine.Wait(5000, () => AstralAura);
                    return true;
                }
            }
            return false;
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

        private async Task<bool> NightWing()
        {
            return await MySpells.PvP.NightWing.Cast();
        }

        private async Task<bool> PhantomDart()
        {
            return await MySpells.PvP.PhantomDart.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }
        #endregion
    }
}