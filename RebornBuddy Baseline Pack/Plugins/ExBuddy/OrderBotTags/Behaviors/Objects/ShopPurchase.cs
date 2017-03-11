namespace ExBuddy.OrderBotTags.Behaviors.Objects
{
    using Clio.XmlEngine;
    using System.ComponentModel;

    [XmlElement("ShopPurchase")]
    public class ShopPurchase
    {
        [DefaultValue(198)]
        [XmlAttribute("MaxCount")]
        public int MaxCount { get; set; }

        [DefaultValue(ShopItem.HiCordial)]
        [XmlAttribute("ShopItem")]
        public ShopItem ShopItem { get; set; }

        public override string ToString()
        {
            return this.DynamicToString();
        }
    }
}