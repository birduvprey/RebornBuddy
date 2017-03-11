namespace ExBuddy.OrderBotTags.Objects
{
    using Clio.XmlEngine;
    using System.ComponentModel;

    [XmlElement("CollectableTurnIn")]
    public class CollectableTurnIn : CollectableBase
    {
        [DefaultValue(int.MaxValue)]
        [XmlAttribute("MaxValueForTurnIn")]
        public int MaxValueForTurnIn { get; set; }
    }
}