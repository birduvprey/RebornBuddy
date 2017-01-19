using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Bard : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (Ultima.UltSettings.SmartTarget)
            {
                if (await StraightShot()) return true;
                if (await IronJaws()) return true;
                if (await Windbite()) return true;
                if (await VenomousBite()) return true;
                if (await EmpyrealArrow()) return true;
                if (await QuickNock()) return true;
                if (await WideVolley()) return true;
                if (await HeavyShot()) return true;
                return await Feint();
            }
            if (Ultima.UltSettings.SingleTarget)
            {
                if (await StraightShot()) return true;
                if (await IronJaws()) return true;
                if (await Windbite()) return true;
                if (await VenomousBite()) return true;
                if (await EmpyrealArrow()) return true;
                if (await HeavyShot()) return true;
                return await Feint();
            }
            if (Ultima.UltSettings.MultiTarget)
            {
                if (await StraightShot()) return true;
                if (await QuickNock()) return true;
                if (await WideVolley()) return true;
                return await Feint();
            }
            return false;
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}