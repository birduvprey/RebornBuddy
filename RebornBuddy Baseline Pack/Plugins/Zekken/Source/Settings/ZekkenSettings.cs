using ProtoBuf;

namespace Zekken
{
    [ProtoContract]
    public class ZekkenSettings
    {
        [ProtoMember(1)]
        public bool MultiAvoidanceEnabled = true;

        [ProtoMember(2)]
        public bool TargetedOnTargetEnabled = true;

        [ProtoMember(3)]
        public bool CircleFromCasterEnabled = true;
    }
}
