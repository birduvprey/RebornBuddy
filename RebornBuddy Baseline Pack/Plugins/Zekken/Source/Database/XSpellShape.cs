using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Zekken
{
    [Flags]
    public enum SpellShape
    {
        None = 0,

        Cone = 1 << 0,
        Rectangle = 1 << 1,
        Circle = 1 << 2,

        WidthSmall = 1 << 3,
        WidthMedium = 1 << 4,
        WidthLarge = 1 << 5,

        ReachSmall = 1 << 6,
        ReachMedium = 1 << 7,
        ReachLarge = 1 << 8,

        DirForward = 1 << 9,
        DirBackward = 1 << 10,
        DirLeft = 1 << 11,
        DirRight = 1 << 12,

        TargetedOnTarget = 1 << 13,
        TargetedFromCaster = 1 << 14,
        TargetedOnRandom = 1 << 15,

        Interruptible = 1 << 16,
        NotTelegraphed = 1 << 17
    }

    [Serializable]
    public class XSpellShape
    {
        [XmlElement("Id")]
        public uint Id { get; set; }

        [XmlElement("Flags")]
        public List<SpellShape> Flags { get; set; }

        public void MergeWith(XSpellShape other)
        {
            foreach (var flag in other.Flags.Where(f => !Flags.Contains(f))) { Flags.Add(flag); }
        }

        public SpellShape GetShape()
        {
            return Flags.Aggregate(SpellShape.None, (current, flag) => flag | current);
        }
    }
}