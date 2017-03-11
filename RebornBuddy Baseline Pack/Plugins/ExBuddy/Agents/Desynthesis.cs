namespace ExBuddy.Agents
{
    using ExBuddy.Offsets;
    using ff14bot;
    using System;

    public sealed class Desynthesis : Agent<Desynthesis>
    {
        public Desynthesis()
            : base(114) { }

        public IntPtr CurrentBagSlot
        {
            get { return Core.Memory.Read<IntPtr>(Pointer + DesynthesisOffsets.CurrentBagSlotOffset); }
        }
    }
}