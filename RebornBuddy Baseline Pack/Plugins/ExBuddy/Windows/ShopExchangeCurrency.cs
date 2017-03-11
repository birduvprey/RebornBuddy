namespace ExBuddy.Windows
{
    using Buddy.Coroutines;
    using ExBuddy.Enumerations;
    using ExBuddy.Helpers;
    using ff14bot.RemoteWindows;
    using System.Threading.Tasks;

    public sealed class ShopExchangeCurrency : Window<ShopExchangeCurrency>
    {
        public ShopExchangeCurrency()
            : base("ShopExchangeCurrency") { }

        public SendActionResult PurchaseItem(uint index)
        {
            return TrySendAction(2, 0, 0, 1, index);
        }

        public SendActionResult PurchaseItem(uint index, uint qty)
        {
            return TrySendAction(3, 0, 0, 1, index, 1, qty);
        }

        public async Task<bool> PurchaseItem(uint index, uint qty, byte attempts, ushort interval = 200)
        {
            var result = SendActionResult.None;
            var purchaseAttempts = 0;
            while (result != SendActionResult.Success && !SelectYesno.IsOpen && purchaseAttempts++ < attempts
                   && Behaviors.ShouldContinue)
            {
                // result = PurchaseItem(index);
                result = PurchaseItem(index, qty);

                await Behaviors.Wait(interval, () => SelectYesno.IsOpen);
            }

            if (purchaseAttempts > attempts)
            {
                return false;
            }

            // Wait an extra second in case interval is really short.
            await Coroutine.Wait(1000, () => SelectYesno.IsOpen);

            purchaseAttempts = 0;
            while (SelectYesno.IsOpen && purchaseAttempts++ < attempts && Behaviors.ShouldContinue)
            {
                SelectYesno.ClickYes();

                await Behaviors.Wait(interval, () => !SelectYesno.IsOpen);
            }

            return !SelectYesno.IsOpen;
        }
    }
}