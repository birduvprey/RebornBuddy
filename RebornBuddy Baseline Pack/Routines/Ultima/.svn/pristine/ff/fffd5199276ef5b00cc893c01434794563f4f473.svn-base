using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using System;
using System.Threading.Tasks;
using UltimaCR.Spells;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Thaumaturge
    {
        private ThaumaturgeSpells _mySpells;

        private ThaumaturgeSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new ThaumaturgeSpells()); }
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
            if (!Actionmanager.HasSpell(MySpells.BlizzardIII.Name) &&
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
            if (AstralAura &&
                !LowMP)
            {
                return await MySpells.Swiftcast.Cast();
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
                    if (await MySpells.BlizzardIII.Cast())
                    {
                        await Coroutine.Wait(5000, () => UmbralAura);
                        return true;
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
            if (Ultima.UltSettings.ThaumaturgeRuin)
            {
                return await MySpells.CrossClass.Ruin.Cast();
            }
            return false;
        }

        private async Task<bool> Physick()
        {
            if (Ultima.UltSettings.ThaumaturgePhysick)
            {
                return await MySpells.CrossClass.Physick.Cast();
            }
            return false;
        }

        private async Task<bool> Virus()
        {
            if (Ultima.UltSettings.ThaumaturgeVirus)
            {
                return await MySpells.CrossClass.Virus.Cast();
            }
            return false;
        }

        private async Task<bool> EyeForAnEye()
        {
            if (Ultima.UltSettings.ThaumaturgeEyeForAnEye)
            {
                return await MySpells.CrossClass.EyeForAnEye.Cast();
            }
            return false;
        }

        #endregion

        #region Archer

        private async Task<bool> RagingStrikes()
        {
            if (Ultima.UltSettings.ThaumaturgeRagingStrikes)
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
            if (Ultima.UltSettings.ThaumaturgeHawksEye)
            {
                return await MySpells.CrossClass.HawksEye.Cast();
            }
            return false;
        }

        private async Task<bool> QuellingStrikes()
        {
            if (Ultima.UltSettings.ThaumaturgeQuellingStrikes)
            {
                return await MySpells.CrossClass.QuellingStrikes.Cast();
            }
            return false;
        }

        #endregion

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.ThaumaturgeCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Aero()
        {
            if (Ultima.UltSettings.ThaumaturgeAero)
            {
                return await MySpells.CrossClass.Aero.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.ThaumaturgeProtect)
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.ThaumaturgeRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.ThaumaturgeStoneskin)
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Gladiator

        private async Task<bool> Flash()
        {
            if (Ultima.UltSettings.ThaumaturgeFlash)
            {
                return await MySpells.CrossClass.Flash.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Ultima.UltSettings.ThaumaturgeConvalescence)
            {
                return await MySpells.CrossClass.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Provoke()
        {
            if (Ultima.UltSettings.ThaumaturgeProvoke)
            {
                return await MySpells.CrossClass.Provoke.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Ultima.UltSettings.ThaumaturgeAwareness)
            {
                return await MySpells.CrossClass.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Lancer

        private async Task<bool> KeenFlurry()
        {
            if (Ultima.UltSettings.ThaumaturgeKeenFlurry)
            {
                return await MySpells.CrossClass.KeenFlurry.Cast();
            }
            return false;
        }

        private async Task<bool> Invigorate()
        {
            if (Ultima.UltSettings.ThaumaturgeInvigorate)
            {
                return await MySpells.CrossClass.Invigorate.Cast();
            }
            return false;
        }

        private async Task<bool> BloodForBlood()
        {
            if (Ultima.UltSettings.ThaumaturgeBloodForBlood)
            {
                return await MySpells.CrossClass.BloodForBlood.Cast();
            }
            return false;
        }

        #endregion

        #region Marauder

        private async Task<bool> Foresight()
        {
            if (Ultima.UltSettings.ThaumaturgeForesight)
            {
                return await MySpells.CrossClass.Foresight.Cast();
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            if (Ultima.UltSettings.ThaumaturgeBloodbath)
            {
                return await MySpells.CrossClass.Bloodbath.Cast();
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.ThaumaturgeMercyStroke)
            {
                return await MySpells.CrossClass.MercyStroke.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.ThaumaturgeFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.ThaumaturgeSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.ThaumaturgeInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.ThaumaturgeMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

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