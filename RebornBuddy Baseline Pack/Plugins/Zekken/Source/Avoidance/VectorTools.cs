using System;
using Clio.Common;
using Clio.Utilities;
using ff14bot.Helpers;

namespace Zekken
{
    internal class VectorTools
    {
        public static AvoidanceVector Combine(AvoidanceVector a, AvoidanceVector b)
        {
            if (a.Magnitude <= 0) { return b; }
            if (b.Magnitude <= 0) { return a; }

            var heading = (a.Heading + b.Heading) / 2f;
            var magnitude = Math.Max(a.Magnitude, b.Magnitude);
            return new AvoidanceVector(heading, magnitude, a.FinishOnDistance && b.FinishOnDistance);
        }

        public static AvoidanceVector GetLateralVector(Vector3 myLocation, Vector3 location, float magnitude)
        {
            var heading = MathEx.NormalizeRadian(3.14159265f/2f + MathHelper.CalculateHeading(location,
                myLocation));

            return new AvoidanceVector(heading, magnitude, false);
        }

        public static AvoidanceVector GetOppositeVector(Vector3 myLocation, Vector3 location, float magnitude)
        {
            var heading = MathEx.NormalizeRadian(3.14159265f + MathHelper.CalculateHeading(location,
                myLocation));

            return new AvoidanceVector(heading, magnitude, false);
        }

        public static AvoidanceVector GetStraightVector(Vector3 myLocation, Vector3 location, float magnitude)
        {
            var heading = MathEx.NormalizeRadian(MathHelper.CalculateHeading(location, 
                myLocation));

            return new AvoidanceVector(heading, magnitude, true);
        }

        public static bool IsFacing(Vector3 characterLocation, float characterHeading, Vector3 location)
        {
            var d = Math.Abs(MathEx.NormalizeRadian(characterHeading 
                - MathEx.NormalizeRadian(MathHelper.CalculateHeading(characterLocation, location) 
                + (float)Math.PI)));

            if (d > Math.PI) d = Math.Abs(d - 2 * (float)Math.PI);
            return d < 0.87266f;
        }
    }
}
