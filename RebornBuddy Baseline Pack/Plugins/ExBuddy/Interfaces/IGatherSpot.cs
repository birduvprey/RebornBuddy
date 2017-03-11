namespace ExBuddy.Interfaces
{
    using Clio.Utilities;
    using ExBuddy.OrderBotTags.Gather;
    using System.Threading.Tasks;

    public interface IGatherSpot
    {
        Vector3 NodeLocation { get; set; }

        Task<bool> MoveFromSpot(ExGatherTag tag);

        Task<bool> MoveToSpot(ExGatherTag tag);
    }
}