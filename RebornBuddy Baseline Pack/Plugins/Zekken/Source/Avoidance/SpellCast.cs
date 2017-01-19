using Clio.Utilities;
using ff14bot.Objects;

namespace Zekken
{
    internal class SpellCast
    {
        public uint CasterId { get; set; }
        public uint SpellId { get; set; }
        public Vector3 TargetLocation { get; set; }
        public SpellShape Shape { get; set; }
        public Vector3 CasterLocation { get; set; }
        public float CasterHeading { get; set; }
        public BattleCharacter Caster { get; set; }
        public string Name { get; set; }
        public bool HasAvoidanceVector { get; set; }

        public SpellCast(BattleCharacter caster, ShapeDatabase database)
        {
            CasterId = caster.NpcId;
            SpellId = caster.SpellCastInfo.ActionId;
            Name = caster.SpellCastInfo.Name;
            CasterLocation = caster.Location;
            TargetLocation = caster.TargetCharacter == null ? CasterLocation : caster.TargetCharacter.Location;
            CasterHeading = caster.Heading;
            Caster = caster;

            SpellShape shape;
            Shape = database.TryGetShape(SpellId, out shape) ? shape : SpellShape.None;
        }
    }
}
