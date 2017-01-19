using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public interface IRotation
    {
        #region Rest

        Task<bool> Rest();

        #endregion

        #region Pre-Combat Buff

        Task<bool> PreCombatBuff();

        #endregion

        #region Pull

        Task<bool> Pull();

        #endregion

        #region Heal

        Task<bool> Heal();

        #endregion

        #region Combat Buff

        Task<bool> CombatBuff();

        #endregion

        #region Combat

        Task<bool> Combat();

        Task<bool> PVPRotation();

        #endregion
    }
}