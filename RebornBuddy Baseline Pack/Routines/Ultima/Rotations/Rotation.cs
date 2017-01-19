using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public abstract class Rotation : IRotation
    {
        #region IRotation

        #region Rest

        public abstract Task<bool> Rest();

        #endregion

        #region Pre-Combat Buff

        public abstract Task<bool> PreCombatBuff();

        #endregion

        #region Pull

        public abstract Task<bool> Pull();

        #endregion

        #region Heal

        public abstract Task<bool> Heal();

        #endregion

        #region Combat Buff

        public abstract Task<bool> CombatBuff();

        #endregion

        #region Combat

        public abstract Task<bool> Combat();

        public abstract Task<bool> PVPRotation();

        #endregion

        #endregion
    }
}