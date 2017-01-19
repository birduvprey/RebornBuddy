namespace Zekken
{
    internal struct AvoidanceVector
    {
        public bool FinishOnDistance;
        public float Heading;
        public float Magnitude;

        public AvoidanceVector(float heading, float magnitude, bool finishOnDistance)
        {
            Heading = heading;
            Magnitude = magnitude;
            FinishOnDistance = finishOnDistance;
        }

        public bool IsActive
        {
            get { return Magnitude > 0; }
        }

        public static AvoidanceVector Zero
        {
            get { return new AvoidanceVector(0f, 0f, true); }
        }

        public override string ToString()
        {
            return string.Format("Magnitude: {0} Heading: {1}", Magnitude, Heading);
        }
    }
}
