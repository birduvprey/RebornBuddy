using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Machinist
    {
        public override async Task<bool> CombatBuff()
        {
            if (await Ultima.SummonChocobo()) return true;
            if (await GaussBarrel()) return true;
            if (await RookAutoturret()) return true;
            if (await BishopAutoturret()) return true;
            if (await Reload()) return true;
            if (await QuickReload()) return true;
            if (await Invigorate()) return true;
            if (await Hypercharge()) return true;
            if (await HawksEye()) return true;
            if (await GaussRound()) return true;
            if (await RagingStrikes()) return true;
            if (await BloodForBlood()) return true;
            if (await RapidFire()) return true;
            if (await Wildfire()) return true;
            if (await Ricochet()) return true;
            if (await Blank()) return true;
            if (await HeadGraze()) return true;
            return await Heartbreak();
        }
    }
}