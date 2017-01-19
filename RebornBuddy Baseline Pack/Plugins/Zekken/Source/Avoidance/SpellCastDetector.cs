using System.Collections.Generic;
using System.Linq;
using Clio.Utilities;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace Zekken
{
    internal class SpellCastDetector
    {
        private ShapeDatabase database;
        private const float NEARBY_THRESHOLD = 35;
        public List<SpellCast> SpellCasts = new List<SpellCast>();

        public SpellCastDetector(ShapeDatabase database)
        {
            this.database = database;
        }

        public List<SpellCast> GetNewCasts()
        {
            var characters = GameObjectManager.GetObjectsOfType<BattleCharacter>()
                .ToList();

            SpellCasts.RemoveAll(sc => !characters.Contains(sc.Caster) || sc.Caster.IsDead || !sc.Caster.IsCasting || !sc.Caster.IsValid);
            var previousCasters = SpellCasts.Select(sc => sc.Caster).ToList();

            var myLocation = Core.Me.Location;
            var newSpellCasts = characters
                .Where(c => c.InCombat && c.CanAttack)
                .Where(c => IsNearby(myLocation, c))
                .Where(c => c.IsCasting)
                .Where(c => c.SpellCastInfo != null)
                .Where(c => !previousCasters.Contains(c))
                .Select(c => new SpellCast(c, database))
                .ToList();

            SpellCasts.AddRange(newSpellCasts);

            return newSpellCasts;
        }

        private static bool IsNearby(Vector3 self, GameObject character)
        {
            return self.Distance(character.Location) < NEARBY_THRESHOLD;
        }
    }
}
