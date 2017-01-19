using System;
using Clio.Utilities;
using ff14bot;

namespace Zekken
{
    internal static class VectorSelector
    {
        private const float LARGE_MAGNITUDE = 25f;
        private const float MEDIUM_MAGNITUDE = 15f;
        private const float SMALL_MAGNITUDE = 7f;

        private const SpellShape DIRECTIONAL_FROM_CASTER =
            SpellShape.DirForward | SpellShape.TargetedFromCaster;

        private const SpellShape CIRCLE_ON_CASTER = SpellShape.Circle | SpellShape.TargetedFromCaster;

        public static AvoidanceVector GetAvoidanceVector(SpellCast cast)
        {
            return GetAvoidanceVector(cast.Shape, cast.CasterLocation, cast.CasterHeading, cast.TargetLocation);
        }

        private static AvoidanceVector GetAvoidanceVector(SpellShape shape, Vector3 enemyLocation, float enemyHeading, Vector3 targetLocation)
        {
            var myLocation = Core.Me.Location;
            var originPoint = shape.HasFlag(SpellShape.TargetedOnTarget) ? targetLocation : enemyLocation;
            var reach = GetReach(shape, myLocation, originPoint);

            if (reach <= 0f && !shape.HasFlag(SpellShape.TargetedOnTarget)) { return AvoidanceVector.Zero; }
            if (shape.HasFlag(SpellShape.TargetedOnRandom)) { return VectorTools.GetLateralVector(myLocation, enemyLocation, reach); }

            if (shape.HasFlag(CIRCLE_ON_CASTER) && ZekkenPlugin.Settings.CircleFromCasterEnabled)
            {
                return VectorTools.GetOppositeVector(myLocation,
                    originPoint, reach); 
            }

            if (shape.HasFlag(DIRECTIONAL_FROM_CASTER))
            {
                if (!VectorTools.IsFacing(originPoint, enemyHeading, myLocation))
                {
                    return AvoidanceVector.Zero;
                }

                var distance = myLocation.Distance(originPoint);
                if (distance < 7)
                {
                    return VectorTools.GetStraightVector(myLocation, originPoint, Math.Max(8f, distance * 2));
                }

                return VectorTools.GetLateralVector(myLocation, originPoint, reach);
            }

            if (shape.HasFlag(SpellShape.TargetedOnTarget) && ZekkenPlugin.Settings.TargetedOnTargetEnabled)
            {
                return VectorTools.GetOppositeVector(myLocation, originPoint, reach - 2f);
            }

            return AvoidanceVector.Zero;
        }

        private static float GetReach(SpellShape shape, Vector3 myLocation, Vector3 originPoint)
        {
            var currentDistance = myLocation.Distance(originPoint);

            if (shape.HasFlag(SpellShape.ReachLarge))
            {
                return Math.Max(0, LARGE_MAGNITUDE - currentDistance);
            }

            if (shape.HasFlag(SpellShape.ReachMedium))
            {
                return Math.Max(0, MEDIUM_MAGNITUDE - currentDistance);
            }

            return Math.Max(0, SMALL_MAGNITUDE - currentDistance);
        }
    }
}
