namespace ExBuddy.OrderBotTags.Fish
{
    using Clio.XmlEngine;
    using ExBuddy.Enumerations;
    using System.ComponentModel;

    [XmlElement("Keeper")]
    public class Keeper
    {
        [DefaultValue(KeeperAction.KeepAll)]
        [XmlAttribute("Action")]
        public KeeperAction Action { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return this.DynamicToString();
        }
    }
}