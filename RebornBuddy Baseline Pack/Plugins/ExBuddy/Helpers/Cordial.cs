namespace ExBuddy.Helpers
{
    using ExBuddy.Enumerations;
    using ExBuddy.Logging;
    using ff14bot.Managers;
    using ff14bot.Objects;
    using System.Linq;

    public static class Cordial
    {
        public static SpellData GetSpellData()
        {
            var cordialSpellData = DataManager.GetItem((uint)CordialType.Cordial).BackingAction;

            if (cordialSpellData == null)
            {
                var item =
                    InventoryManager.FilledSlots.FirstOrDefault(
                        bs => bs.RawItemId == (uint)CordialType.WateredCordial || bs.RawItemId == (uint)CordialType.Cordial || bs.RawItemId == (uint)CordialType.HiCordial);

                if (item != null)
                {
                    cordialSpellData = item.Item.BackingAction;
                }
            }

            if (cordialSpellData == null)
            {
                Logger.Instance.Error(Localization.Localization.Cordinal_NullSpellData);
            }

            return cordialSpellData;
        }

        public static bool HasAnyCordials()
        {
            return HasWateredCordials() || HasCordials() || HasHiCordials();
        }

        public static bool HasWateredCordials()
        {
            return DataManager.GetItem((uint)CordialType.WateredCordial).ItemCount() > 0;
        }

        public static bool HasCordials()
        {
            return DataManager.GetItem((uint)CordialType.Cordial).ItemCount() > 0;
        }

        public static bool HasHiCordials()
        {
            return DataManager.GetItem((uint)CordialType.HiCordial).ItemCount() > 0;
        }
    }
}