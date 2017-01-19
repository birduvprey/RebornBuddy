using System;
using System.Collections.Generic;
using System.Linq;
using Clio.Common;
using Clio.Utilities;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Navigation;
using TreeSharp;

namespace Zekken
{
    internal class AvoidanceMover
    {
        private bool isAvoiding;
        private Vector3 originalPosition = Vector3.Zero;
        private Vector3 previousPosition = Vector3.Zero;
        public AvoidanceVector CurrentVector { get; set; }

        public void Start(IEnumerable<AvoidanceVector> vectors)
        {
            CurrentVector = vectors.Aggregate(CurrentVector, VectorTools.Combine);

            var currentPosition = Core.Me.Location;
            previousPosition = currentPosition;
            originalPosition = currentPosition;
            if (!CurrentVector.IsActive) { return; }

            var point = MathEx.GetPointAt(currentPosition, CurrentVector.Magnitude, CurrentVector.Heading);
            Navigator.PlayerMover.MoveTowards(point);
            isAvoiding = true;
        }

        public RunStatus Continue(List<SpellCast> activeCasts)
        {
            if (!isAvoiding) { return RunStatus.Failure; }

            if (activeCasts.Count == 0)
            {
                Stop();

                if (CurrentVector.IsActive) { Navigator.MoveTo(originalPosition); }

                CurrentVector = AvoidanceVector.Zero;
                isAvoiding = false;
                return RunStatus.Failure;
            }

            var currentPosition = Core.Me.Location;
            var distanceMoved = previousPosition.Distance(currentPosition);
            previousPosition = currentPosition;

            var remainingDistance = Math.Max(0, CurrentVector.Magnitude - distanceMoved);
            CurrentVector = remainingDistance > 0
                ? new AvoidanceVector(CurrentVector.Heading,
                    remainingDistance, CurrentVector.FinishOnDistance)
                : new AvoidanceVector(0, 0, CurrentVector.FinishOnDistance);

            MoveIfNeeded(currentPosition);

            if (!CurrentVector.IsActive) { Stop(); }

            if (!CurrentVector.IsActive && CurrentVector.FinishOnDistance)
            {
                isAvoiding = false;
                return RunStatus.Failure;
            }

            return RunStatus.Success;
        }

        private void MoveIfNeeded(Vector3 currentPosition)
        {
            if (!CurrentVector.IsActive || MovementManager.IsMoving) { return; }

            var point = MathEx.GetPointAt(currentPosition, CurrentVector.Magnitude, CurrentVector.Heading);
            Navigator.PlayerMover.MoveTowards(point);
        }

        private static void Stop()
        {
            if (!MovementManager.IsMoving) { return; }
            Navigator.PlayerMover.MoveStop();
        }
    }
}
