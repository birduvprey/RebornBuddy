using System;
using System.Collections.Generic;
using System.Linq;
using ff14bot;
using ff14bot.Navigation;
using TreeSharp;
using Action = TreeSharp.Action;

namespace Zekken
{
    internal class AvoidanceManager
    {
        private SpellCastDetector castDetector;
        private List<SpellCast> castsBeingAvoided = new List<SpellCast>();
        private ShapeDatabase database;
        private HashSet<uint> ignoredSpells = new HashSet<uint>();
        private SpellCapture spellCapture = new SpellCapture();
        private AvoidanceMover mover = new AvoidanceMover();

        public AvoidanceManager(ShapeDatabase database)
        {
            this.database = database;
            castDetector = new SpellCastDetector(database);
        }

        public Composite GetAvoidanceBehavior()
        {
            return new Action(r => AvoidTelegraph());
        }

        private RunStatus AvoidTelegraph()
        {
            var newCasts = castDetector.GetNewCasts();
            var presentCasts = castDetector.SpellCasts;
            castsBeingAvoided.RemoveAll(c => !presentCasts.Contains(c));

            ProcessUnknownCasts(newCasts);
            newCasts = GetAvoidable(newCasts);

            if (Navigator.PlayerMover is NullMover || Navigator.PlayerMover == null) { return RunStatus.Failure; }
            if (newCasts.Count == 0) { return mover.Continue(castsBeingAvoided); }

            var targetCast = newCasts
                .FirstOrDefault(sc => sc.Caster.CurrentTargetId == Core.Me.ObjectId);

            if (ZekkenPlugin.Settings.MultiAvoidanceEnabled)
            {
                AddNewCasts(newCasts);
                return RunStatus.Success;
            }

            if (targetCast == null) { return mover.Continue(castsBeingAvoided); }

            var targetCastList = new List<SpellCast> {targetCast};
            AddNewCasts(targetCastList);
            return RunStatus.Success;
        }

        public void AddNewCasts(IEnumerable<SpellCast> casts)
        {
            var activeCastPairs = casts
                .Select(c => new Tuple<SpellCast, AvoidanceVector>(c, VectorSelector.GetAvoidanceVector(c)))
                .Where(p => p.Item2.IsActive)
                .ToList();

            var newCastsBeingAvoided = castDetector.SpellCasts
                .Where(c => activeCastPairs.Any(p => p.Item1 == c))
                .ToList();

            castsBeingAvoided.AddRange(newCastsBeingAvoided);

            foreach (var cast in newCastsBeingAvoided)
            {
                Logger.WriteMessage("Avoiding {0} ({1}) with shape {2}.", cast.Name, cast.SpellId,
                    cast.Shape);
            }

            mover.Start(activeCastPairs.Select(p => p.Item2));
        }

        private void ProcessUnknownCasts(IEnumerable<SpellCast> casts)
        {
            var unknownCast = casts
                .FirstOrDefault(sc =>  sc.Caster.ObjectId == Core.Target.ObjectId
                    && sc.Shape == SpellShape.None 
                    && !ignoredSpells.Contains(sc.SpellId));

            if (unknownCast == null) { return; }

            spellCapture.CaptureScreenshot(unknownCast.SpellId, unknownCast.Name);
            ignoredSpells.Add(unknownCast.SpellId);
        }

        private List<SpellCast> GetAvoidable(IEnumerable<SpellCast> casts)
        {
            var avoidable = casts
                .Where(sc => database.Contains(sc.SpellId))
                .Where(sc => !sc.Shape.HasFlag(SpellShape.NotTelegraphed))
                .ToList();

            return avoidable;
        }
    }
}
