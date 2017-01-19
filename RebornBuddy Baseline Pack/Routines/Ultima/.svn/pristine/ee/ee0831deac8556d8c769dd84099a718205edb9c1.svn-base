using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Archer : Rotation
    {
        public override async Task<bool> Combat()
        {
            if (Ultima.UltSettings.SmartTarget)
            {
                if (await StraightShot()) return true;
                if (await Windbite()) return true;
                if (await VenomousBite()) return true;
                if (await FlamingArrow()) return true;
                if (await QuickNock()) return true;
                if (await WideVolley()) return true;
                return await HeavyShot();
            }
            if (Ultima.UltSettings.SingleTarget)
            {
                if (await StraightShot()) return true;
                if (await Windbite()) return true;
                if (await VenomousBite()) return true;
                if (await FlamingArrow()) return true;
                return await HeavyShot();
            }
            if (Ultima.UltSettings.MultiTarget)
            {
                if (await StraightShot()) return true;
                if (await FlamingArrow()) return true;
                if (await QuickNock()) return true;
                return await WideVolley();
            }
            return false;
        }

        public override async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}