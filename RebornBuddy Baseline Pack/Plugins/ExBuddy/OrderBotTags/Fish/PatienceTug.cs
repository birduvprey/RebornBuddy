namespace ExBuddy.OrderBotTags.Fish
{
    using Clio.XmlEngine;
    using ff14bot.Enums;
    using System;
    using System.ComponentModel;

    [XmlElement("PatienceTug")]
    public class PatienceTug : IEquatable<PatienceTug>
    {
        [XmlAttribute("MoochLevel")]
        public int MoochLevel { get; set; }

        [DefaultValue(TugType.Medium)]
        [XmlAttribute("TugType")]
        public TugType TugType { get; set; }

        #region IEquatable<PatienceTug> Members

        public bool Equals(PatienceTug other)
        {
            return MoochLevel == other.MoochLevel && TugType == other.TugType;
        }

        #endregion IEquatable<PatienceTug> Members

        public override string ToString()
        {
            return this.DynamicToString();
        }
    }
}