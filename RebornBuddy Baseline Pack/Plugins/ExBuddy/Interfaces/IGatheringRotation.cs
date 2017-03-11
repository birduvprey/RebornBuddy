namespace ExBuddy.Interfaces
{
    using ExBuddy.Attributes;
    using ExBuddy.OrderBotTags.Gather;
    using System.Threading.Tasks;

    public interface IGatheringRotation
    {
        GatheringRotationAttribute Attributes { get; }

        bool CanBeOverriden { get; }

        Task<bool> ExecuteRotation(ExGatherTag tag);

        Task<bool> Gather(ExGatherTag tag);

        Task<bool> Prepare(ExGatherTag tag);

        int ResolveOverridePriority(ExGatherTag tag);

        bool ShouldForceGather(ExGatherTag tag);
    }
}