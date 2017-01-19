using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CombatPotGuyPlugin
{
    // ReSharper disable once UnusedMember.Global
    public class CombatPotGuyPlugin : BotPlugin
    {
        #region Properties

        private static bool HasMedicineBuff
        {
            get { return Core.Me.HasAura(49); }
        }

        private static bool LowHealth
        {
            get { return (Core.Player.CurrentHealthPercent < Settings.Instance.HealthThreshold); }
        }

        private static bool LowMana
        {
            get { return (Core.Player.CurrentManaPercent < Settings.Instance.ManaThreshold); }
        }

        private static bool LowTP
        {
            get { return (Core.Player.CurrentTPPercent < Settings.Instance.TPThreshold); }
        }

        #endregion

        #region Drink Medicine Logic

        private static async Task<bool> DrinkMedicine()
        {
            if (Settings.Instance.UseHealthMedicine && string.IsNullOrEmpty(Settings.Instance.HealthMedicineName))
            {
                Logging.Write(Colors.Aqua, "[CombatPotGuyPlugin] Please select a new Health Medicine Item from the settings window.");
                return false;
            }

            if (Settings.Instance.UseManaMedicine && string.IsNullOrEmpty(Settings.Instance.ManaMedicineName))
            {
                Logging.Write(Colors.Aqua, "[CombatPotGuyPlugin] Please select a new Mana Medicine Item from the settings window.");
                return false;
            }

            if (Settings.Instance.UseTPMedicine && string.IsNullOrEmpty(Settings.Instance.TPMedicineName))
            {
                Logging.Write(Colors.Aqua, "[CombatPotGuyPlugin] Please select a new TP Medicine Item from the settings window.");
                return false;
            }

            BagSlot item = null;

            if (Settings.Instance.UseHealthMedicine && LowHealth)
            {
                var medicineSetting = Settings.Instance.HealthMedicineName;
                var index = medicineSetting.IndexOf('(');
                var medicine = index > 0 ? medicineSetting.Substring(0, index) : medicineSetting;

                item =
                    InventoryManager.FilledSlots.InventoryItems()
                        .HealthMedicineItems()
                        .FirstOrDefault(x => x.Item.EnglishName == medicine && x.CanUse());
            }
            else if (Settings.Instance.UseManaMedicine && LowMana)
            {
                var medicineSetting = Settings.Instance.ManaMedicineName;
                var index = medicineSetting.IndexOf('(');
                var medicine = index > 0 ? medicineSetting.Substring(0, index) : medicineSetting;

                item =
                    InventoryManager.FilledSlots.InventoryItems()
                        .ManaMedicineItems()
                        .FirstOrDefault(x => x.Item.EnglishName == medicine && x.CanUse());
            }
            else if (Settings.Instance.UseTPMedicine && LowTP)
            {
                var medicineSetting = Settings.Instance.TPMedicineName;
                var index = medicineSetting.IndexOf('(');
                var medicine = index > 0 ? medicineSetting.Substring(0, index) : medicineSetting;

                item =
                    InventoryManager.FilledSlots.InventoryItems()
                        .TPMedicineItems()
                        .FirstOrDefault(x => x.Item.EnglishName == medicine && x.CanUse());
            }

            if (item == null) return false;

            if (FishingManager.State != FishingState.None)
            {
                Actionmanager.DoAction(299, Core.Me);
                await Coroutine.Wait(5000, () => FishingManager.State == FishingState.None);
            }

            if (GatheringManager.WindowOpen)
            {
                Logging.Write(Colors.Aqua, "[CombatPotGuy] Currently Gathering Items, waiting until we are done.");
                return false;
            }

            if (CraftingManager.IsCrafting)
            {
                Logging.Write(Colors.Pink, "[CombatPotGuy] Currently Crafting Items, waiting until we are done.");
                return false;
            }

            if (CraftingLog.IsOpen)
            {
                Logging.Write(Colors.Pink, "[CombatPotGuy] Closing Crafting Log so we can drink medicine.");
                CraftingLog.Close();
            }

            if (Core.Me.IsMounted)
            {
                Logging.Write(Colors.Aqua, "[CombatPotGuy] Dismounting so we can drink medicine.");
                await CommonTasks.StopAndDismount();
            }

            Logging.Write(Colors.Aqua, "[CombatPotGuy] Now drinking " + item.Item.EnglishName);
            item.UseItem();
            await Coroutine.Wait(2000, () => !item.CanUse());

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
            get { return "CombatPotGuy"; }
        }

        public override Version Version
        {
            get { return new Version(1, 0, 0, 0); }
        }

        #endregion

        #region Optional Overrides

        public override void OnInitialize()
        {
            _coroutine = new Decorator(c => (Core.Me.IsAlive && (Settings.Instance.UseHealthMedicine && LowHealth) || (Settings.Instance.UseManaMedicine && LowMana) || (Settings.Instance.UseTPMedicine && LowTP)) && Core.Player.InCombat, new ActionRunCoroutine(r => DrinkMedicine()));
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
            Logging.Write(Colors.Aqua, "Adding CombatPotGuy Hook");
            TreeHooks.Instance.InsertHook("TreeStart", 0, _coroutine);
        }

        private void RemoveHooks()
        {
            Logging.Write(Colors.Aqua, "Removing CombatPotGuy Hook");
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
        public static IEnumerable<BagSlot> HealthMedicineItems(this IEnumerable<BagSlot> inventory)
        {
            return inventory.Where(x => x.HealthMedicineItem());
        }

        private static bool HealthMedicineItem(this BagSlot slot)
        {
            return (slot.Item.EquipmentCatagory == ItemUiCategory.Medicine) && ((int)slot.Item.ItemRole == 8 || (int)slot.Item.ItemRole == 10);
        }


        public static IEnumerable<BagSlot> ManaMedicineItems(this IEnumerable<BagSlot> inventory)
        {
            return inventory.Where(x => x.ManaMedicineItem());
        }

        private static bool ManaMedicineItem(this BagSlot slot)
        {
            return (slot.Item.EquipmentCatagory == ItemUiCategory.Medicine) && ((int)slot.Item.ItemRole == 9 || (int)slot.Item.ItemRole == 10);
        }


        public static IEnumerable<BagSlot> TPMedicineItems(this IEnumerable<BagSlot> inventory)
        {
            return inventory.Where(x => x.TPMedicineItem());
        }

        private static bool TPMedicineItem(this BagSlot slot)
        {
            return (slot.Item.EquipmentCatagory == ItemUiCategory.Medicine) && ((int)slot.Item.ItemRole == 7); //Update with TP Item Role
        }

        public static IEnumerable<BagSlot> InventoryItems(this IEnumerable<BagSlot> inventory)
        {
            return
                inventory.Where(
                    x =>
                        x.BagId == InventoryBagId.Bag1 || x.BagId == InventoryBagId.Bag2 ||
                        x.BagId == InventoryBagId.Bag3 || x.BagId == InventoryBagId.Bag4);
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
            : base(Path.Combine(CharacterSettingsDirectory, "CombatPotGuy.json"))
        {
        }

        public static Settings Instance
        {
            get { return _instance ?? (_instance = new Settings("Settings")); }
        }

        [Setting]
        public string HealthMedicineName { get; set; }
        [Setting]
        public string ManaMedicineName { get; set; }
        [Setting]
        public string TPMedicineName { get; set; }
        [Setting]
        [DefaultValue(70.0f)]
        public float HealthThreshold { get; set; }
        [Setting]
        [DefaultValue(70.0f)]
        public float ManaThreshold { get; set; }
        [Setting]
        [DefaultValue(30.0f)]
        public float TPThreshold { get; set; }
        [Setting]
        [DefaultValue(false)]
        public bool UseHealthMedicine { get; set; }
        [Setting]
        [DefaultValue(false)]
        public bool UseManaMedicine { get; set; }
        [Setting]
        [DefaultValue(false)]
        public bool UseTPMedicine { get; set; }
    }

    #endregion
}