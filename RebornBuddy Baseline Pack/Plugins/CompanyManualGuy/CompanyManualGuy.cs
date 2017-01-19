using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.AClasses;
using ff14bot.Behavior;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.RemoteWindows;
using Newtonsoft.Json;
using TreeSharp;

namespace CompanyManualGuyPlugin
{
    // ReSharper disable once UnusedMember.Global
    public class CompanyManualGuyPlugin : BotPlugin
    {
        #region Properties

        private static bool HasCompanyManualBuff
        {
            get { return (Core.Me.HasAura(45) || Core.Me.HasAura(46)); }
        }

        #endregion

        #region Drink companyManual Logic

        private static async Task<bool> UseCompanyManual()
        {
            if (string.IsNullOrEmpty(Settings.Instance.CompanyManualName))
            {
                Logging.Write(Colors.Aqua, "[CompanyManualGuyPlugin] Please select a new companyManual Item from the settings window.");
                return false;
            }

            var CompanyManualSetting = Settings.Instance.CompanyManualName;
            var index = CompanyManualSetting.IndexOf('(');
            var companyManual = index > 0 ? CompanyManualSetting.Substring(0, index) : CompanyManualSetting;

            var item =
                InventoryManager.FilledSlots.InventoryItems()
                    .CompanyManualItems()
                    .FirstOrDefault(x => x.Item.EnglishName == companyManual && x.CanUse());

            if (item == null) return false;

            if (FishingManager.State != FishingState.None)
            {
                Actionmanager.DoAction(299, Core.Me);
                await Coroutine.Wait(5000, () => FishingManager.State == FishingState.None);
            }

            if (GatheringManager.WindowOpen)
            {
                Logging.Write(Colors.Aqua, "[CompanyManualGuy] Currently Gathering Items, waiting until we are done.");
                return false;
            }

            if (CraftingManager.IsCrafting)
            {
                Logging.Write(Colors.Pink, "[CompanyManualGuy] Currently Crafting Items, waiting until we are done.");
                return false;
            }

            if (CraftingLog.IsOpen)
            {
                Logging.Write(Colors.Pink, "[CompanyManualGuy] Closing Crafting Log so we can drink companyManual.");
                CraftingLog.Close();
            }

            if (Core.Me.IsMounted)
            {
                Logging.Write(Colors.Aqua, "[CompanyManualGuy] Dismounting so we can drink companyManual.");
                await CommonTasks.StopAndDismount();
            }

            Logging.Write(Colors.Aqua, "[CompanyManualGuy] Now drinking " + item.Item.EnglishName);
            item.UseItem();
            await Coroutine.Wait(5000, () => HasCompanyManualBuff);

            return true;
        }

        #endregion

        #region Fields

        private Composite _coroutine;
        private Gui _settingsForm;

        #endregion

        #region Required Overrides

        public override string Author
        {
            get { return "Cloud30000"; }
        }

        public override string Name
        {
            get { return "CompanyManualGuy"; }
        }

        public override Version Version
        {
            get { return new Version(1, 0, 0, 0); }
        }

        #endregion

        #region Optional Overrides

        public override void OnInitialize()
        {
            _coroutine = new Decorator(c => Core.Me.IsAlive && !HasCompanyManualBuff && !Core.Me.InCombat, new ActionRunCoroutine(r => UseCompanyManual()));
        }

        public override void OnEnabled()
        {
            TreeRoot.OnStart += OnBotStart;
            TreeRoot.OnStop += OnBotStop;
            TreeHooks.Instance.OnHooksCleared += OnOnHooksCleared;

            if (TreeRoot.IsRunning)
            {
                AddHooks();
            }
        }

        public override void OnDisabled()
        {
            TreeRoot.OnStart -= OnBotStart;
            TreeRoot.OnStop -= OnBotStop;
            TreeHooks.Instance.OnHooksCleared -= OnOnHooksCleared;
            RemoveHooks();
        }

        public override void OnShutdown()
        {
            TreeRoot.OnStart -= OnBotStart;
            TreeRoot.OnStop -= OnBotStop;
            TreeHooks.Instance.OnHooksCleared -= OnOnHooksCleared;
            RemoveHooks();
        }

        public override bool WantButton
        {
            get { return true; }
        }

        public override void OnButtonPress()
        {
            if (_settingsForm == null || _settingsForm.IsDisposed || _settingsForm.Disposing)
                _settingsForm = new Gui();

            _settingsForm.ShowDialog();
        }

        #endregion

        #region Hook Logic

        private void AddHooks()
        {
            Logging.Write(Colors.Aqua, "Adding CompanyManualGuy Hook");
            TreeHooks.Instance.InsertHook("TreeStart", 0, _coroutine);
        }

        private void RemoveHooks()
        {
            Logging.Write(Colors.Aqua, "Removing CompanyManualGuy Hook");
            TreeHooks.Instance.RemoveHook("TreeStart", _coroutine);
        }

        #endregion

        #region Event Handlers

        private void OnBotStop(BotBase bot)
        {
            RemoveHooks();
        }

        private void OnBotStart(BotBase bot)
        {
            AddHooks();
        }

        private void OnOnHooksCleared(object sender, EventArgs e)
        {
            AddHooks();
        }

        #endregion
    }

    #region Extensions Class

    public static class Extensions
    {
        public static IEnumerable<BagSlot> CompanyManualItems(this IEnumerable<BagSlot> inventory)
        {
            return inventory.Where(x => x.companyManualItem());
        }

        public static IEnumerable<BagSlot> InventoryItems(this IEnumerable<BagSlot> inventory)
        {
            return
                inventory.Where(
                    x =>
                        x.BagId == InventoryBagId.Bag1 || x.BagId == InventoryBagId.Bag2 ||
                        x.BagId == InventoryBagId.Bag3 || x.BagId == InventoryBagId.Bag4);
        }

        private static bool companyManualItem(this BagSlot slot)
        {
            return (slot.Item.EquipmentCatagory == ItemUiCategory.Other) && (int)slot.Item.ItemRole == 7;
        }
    }

    #endregion

    #region Settings Class

    public class Settings : JsonSettings
    {
        [JsonIgnore]
        private static Settings _instance;
        // ReSharper disable once UnusedParameter.Local
        // ReSharper disable once MemberCanBePrivate.Global
        public Settings(string filename)
            : base(Path.Combine(CharacterSettingsDirectory, "CompanyManualGuy.json"))
        {
        }

        public static Settings Instance
        {
            get { return _instance ?? (_instance = new Settings("Settings")); }
        }

        [Setting]
        public string CompanyManualName { get; set; }
    }

    #endregion
}