using System.Linq;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using TreeSharp;
using UltimaCR.Rotations;
using UltimaCR.Settings;
using UltimaCR.Settings.Forms;
using UltimaCR.Spells;

namespace UltimaCR
{
    public class Ultima : CombatRoutine
    {
        #region RebornBuddy Overrides

        public override sealed string Name
        {
            get {return "Ultima"; }
        }

        public override sealed float PullRange
        {
            get { return 15f; }
        }

        public override sealed void Initialize()
        {
            if (UltSettings.DefaultCRCheck)
            {
                RoutineManager.PreferedRoutine = "Ultima";
            }
            #region Overlay
            UltimaForm.Overlay.Visible = UltSettings.UseOverlay;
            if (UltSettings.SmartTarget)
            {
                UltimaForm.Overlay.UpdateLabel(@"Smart Target");
            }
            if (UltSettings.SingleTarget)
            {
                UltimaForm.Overlay.UpdateLabel(@"Single Target");
            }
            if (UltSettings.MultiTarget)
            {
                UltimaForm.Overlay.UpdateLabel(@"Multi Target");
            }
            #endregion
            HotkeyManager.Register("[Ultima] Cycle Rotation", UltSettings.HotKey, UltSettings.ModKey, hk => CycleRotation());
        }

        public override sealed void Pulse()
        {
            var _class = CurrentClass;
        }

        public override sealed void ShutDown()
        {
            HotkeyManager.Unregister("[Ultima] Cycle Rotation");
        }

        #endregion

        #region Settings

        public static readonly UltimaSettings UltSettings = UltimaSettings.Instance;

        private Form _uForm;

        public override sealed bool WantButton
        {
            get { return true; }
        }

        public override sealed void OnButtonPress()
        {
            if (_uForm == null || _uForm.IsDisposed || _uForm.Disposing)
                _uForm = new UltimaForm();

            _uForm.ShowDialog();
        }

        public static void CycleRotation()
        {
            if (UltSettings.SmartTarget)
            {
                UltSettings.SmartTarget = false;
                UltSettings.SingleTarget = true;
                UltSettings.MultiTarget = false;
                UltimaForm.Overlay.UpdateLabel(@"Single Target");
                return;
            }

            if (UltSettings.SingleTarget)
            {
                UltSettings.SmartTarget = false;
                UltSettings.SingleTarget = false;
                UltSettings.MultiTarget = true;
                UltimaForm.Overlay.UpdateLabel(@"Multi Target");
                return;
            }

            if (UltSettings.MultiTarget)
            {
                UltSettings.SmartTarget = true;
                UltSettings.SingleTarget = false;
                UltSettings.MultiTarget = false;
                UltimaForm.Overlay.UpdateLabel(@"Smart Target");
            }
        }

        #endregion

        #region Class Handlers

        private IRotation _myRotation;
        private IRotation MyRotation
        {
            get { return _myRotation ?? (_myRotation = GetRotation(CurrentClass)); }
        }

        private ClassJobType _currentClass;
        private ClassJobType CurrentClass
        {
            get
            {
                if (_currentClass == Core.Player.CurrentJob) return _currentClass;
                _currentClass = Core.Player.CurrentJob;
                _myRotation = GetRotation(_currentClass);
                Logging.Write(Colors.Yellow, @"[Ultima] Loading: " + _currentClass);
                return _currentClass;
            }
        }

        public override sealed ClassJobType[] Class
        {
            get
            {
                return new[]
                {
                    Core.Player.CurrentJob
                };
            }
        }

        private static IRotation GetRotation(ClassJobType ClassJob)
        {
            switch (ClassJob)
            {
                #region Combat
                #region Class
                case ClassJobType.Arcanist:
                    return new Arcanist();
                case ClassJobType.Archer:
                    return new Archer();
                case ClassJobType.Conjurer:
                    return new Conjurer();
                case ClassJobType.Gladiator:
                    return new Gladiator();
                case ClassJobType.Lancer:
                    return new Lancer();
                case ClassJobType.Marauder:
                    return new Marauder();
                case ClassJobType.Pugilist:
                    return new Pugilist();
                case ClassJobType.Rogue:
                    return new Rogue();
                case ClassJobType.Thaumaturge:
                    return new Thaumaturge();
                #endregion
                #region Job
                case ClassJobType.Astrologian:
                    return new Astrologian();
                case ClassJobType.Bard:
                    return new Bard();
                case ClassJobType.BlackMage:
                    return new BlackMage();
                case ClassJobType.DarkKnight:
                    return new DarkKnight();
                case ClassJobType.Dragoon:
                    return new Dragoon();
                case ClassJobType.Machinist:
                    return new Machinist();
                case ClassJobType.Monk:
                    return new Monk();
                case ClassJobType.Ninja:
                    return new Ninja();
                case ClassJobType.Paladin:
                    return new Paladin();
                case ClassJobType.Scholar:
                    return new Scholar();
                case ClassJobType.Summoner:
                    return new Summoner();
                case ClassJobType.Warrior:
                    return new Warrior();
                case ClassJobType.WhiteMage:
                    return new WhiteMage();
                #endregion
                #endregion
                #region Crafting
                case ClassJobType.Alchemist:
                    return new HandLand();
                case ClassJobType.Armorer:
                    return new HandLand();
                case ClassJobType.Blacksmith:
                    return new HandLand();
                case ClassJobType.Carpenter:
                    return new HandLand();
                case ClassJobType.Culinarian:
                    return new HandLand();
                case ClassJobType.Goldsmith:
                    return new HandLand();
                case ClassJobType.Leatherworker:
                    return new HandLand();
                case ClassJobType.Weaver:
                    return new HandLand();
                #endregion
                #region Gathering
                case ClassJobType.Botanist:
                    return new HandLand();
                case ClassJobType.Fisher:
                    return new HandLand();
                case ClassJobType.Miner:
                    return new HandLand();
                #endregion
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion

        #region Behavior Composites

        /*
        *These are the behaviors that RebornBuddy will use in its Combat Logic
        *The general order that the behaviors are pulsed in are:
        *  1. Rest                 (Not used in the Combat Assist Botbase)
        *  2. Pre-Combat Buff      (Not used in the Combat Assist Botbase)
        *  3. Pull                 (Not used in the Combat Assist Botbase)
        *  4. Heal
        *  5. Combat Buff
        *  6. Combat
        */

        public override Composite RestBehavior
        {
            get { return new ActionRunCoroutine(ctx => MyRotation.Rest()); }
        }

        public override Composite PreCombatBuffBehavior
        {
            get { return new ActionRunCoroutine(ctx => MyRotation.PreCombatBuff()); }
        }

        public override Composite PullBehavior
        {
            get { return new ActionRunCoroutine(ctx => MyRotation.Pull()); }
        }

        public override Composite HealBehavior
        {
            get { return new ActionRunCoroutine(ctx => MyRotation.Heal()); }
        }

        public override Composite CombatBuffBehavior
        {
            get { return new ActionRunCoroutine(ctx => MyRotation.CombatBuff()); }
        }

        public override Composite CombatBehavior
        {
            get { return new ActionRunCoroutine(ctx => MyRotation.Combat()); }
        }

        #region Unused Behavior Composites

        /*
        * These behaviors have been put in the CombatRoutine class,
        * but RebornBuddy does not use them in any current Botbase.
        */
        public override Composite DeathBehavior { get; set; }
        public override Composite PullBuffBehavior { get; set; }

        #endregion

        #endregion

        #region Summon Chocobo

        public static async Task<bool> SummonChocobo()
        {
            if (UltSettings.SummonChocobo &&
                BotManager.Current.IsAutonomous &&
                !MovementManager.IsMoving &&
                Chocobo.CanSummon &&
                Helpers.PartyMembers.All(c => c.SummonerObjectId != Core.Player.ObjectId))
            {
                Chocobo.Summon();
                await Coroutine.Wait(1000, () => Chocobo.Summoned);
                if (!Chocobo.Summoned)
                {
                    return await SummonChocobo();
                }
                if (Chocobo.Summoned)
                {
                    if (UltSettings.ChocoboFreeStance &&
                        Chocobo.Stance != CompanionStance.Free)
                    {
                        Chocobo.FreeStance();
                        await Coroutine.Wait(2000, () => Chocobo.Stance == CompanionStance.Free);
                        return true;
                    }

                    if (UltSettings.ChocoboDefenderStance &&
                        Chocobo.Stance != CompanionStance.Defender)
                    {
                        Chocobo.DefenderStance();
                        await Coroutine.Wait(2000, () => Chocobo.Stance == CompanionStance.Defender);
                        return true;
                    }

                    if (UltSettings.ChocoboAttackerStance &&
                        Chocobo.Stance != CompanionStance.Attacker)
                    {
                        Chocobo.AttackerStance();
                        await Coroutine.Wait(2000, () => Chocobo.Stance == CompanionStance.Attacker);
                        return true;
                    }

                    if (UltSettings.ChocoboHealerStance &&
                        Chocobo.Stance != CompanionStance.Healer)
                    {
                        Chocobo.HealerStance();
                        await Coroutine.Wait(2000, () => Chocobo.Stance == CompanionStance.Healer);
                        return true;
                    }
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Ultima LastSpell

        private static Spell _lastSpell;
        public static Spell LastSpell
        {
            get { return _lastSpell ?? (_lastSpell = new Spell()); }
            set { _lastSpell = value; }
        }

        #endregion
    }
}