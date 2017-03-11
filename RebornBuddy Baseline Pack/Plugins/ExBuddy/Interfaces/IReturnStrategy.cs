namespace ExBuddy.Interfaces
{
    using Clio.Utilities;
    using System.Threading.Tasks;

    public interface IReturnStrategy : ITeleportLocation
    {
        Vector3 InitialLocation { get; set; }

        Task<bool> ReturnToLocation();

        Task<bool> ReturnToZone();
    }
}