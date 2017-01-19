using ff14bot;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Astrologian
    {
        private AstrologianSpells _mySpells;

        private AstrologianSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new AstrologianSpells()); }
        }

        #region Job Spells

        private async Task<bool> Malefic()
        {
            return await MySpells.Malefic.Cast();
        }
        private async Task<bool> Benefic()
        {
            if (Ultima.UltSettings.AstrologianBenefic &&
                Core.Player.CurrentHealthPercent < 70)
            {
                return await MySpells.Benefic.Cast();
            }
            return false;
        }
        private async Task<bool> Combust()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Combust.Name, true, 4000))
            {
                return await MySpells.Combust.Cast();
            }
            return false;
        }
        private async Task<bool> Lightspeed()
        {
            return await MySpells.Lightspeed.Cast();
        }
        private async Task<bool> LuminiferousAether()
        {
            if (Core.Player.CurrentManaPercent <= 50)
            {
                return await MySpells.LuminiferousAether.Cast();
            }
            return false;
        }
        private async Task<bool> Helios()
        {
            return await MySpells.Helios.Cast();
        }
        private async Task<bool> Ascend()
        {
            return await MySpells.Ascend.Cast();
        }
        private async Task<bool> EssentialDignity()
        {
            if (Ultima.UltSettings.AstrologianEssentialDignity &&
                Core.Player.CurrentHealthPercent < 70)
            {
                return await MySpells.EssentialDignity.Cast();
            }
            return false;
        }
        private async Task<bool> ExaltedDetriment()
        {
            return await MySpells.ExaltedDetriment.Cast();
        }
        private async Task<bool> Stella()
        {
            return await MySpells.Stella.Cast();
        }
        private async Task<bool> BeneficII()
        {
            if (Ultima.UltSettings.AstrologianBeneficII &&
                Core.Player.CurrentHealthPercent < 50)
            {
                return await MySpells.BeneficII.Cast();
            }
            return false;
        }
        private async Task<bool> Draw()
        {
            if (Ultima.UltSettings.AstrologianDraw)
            {
                return await MySpells.Draw.Cast();
            }
            return false;
        }
        private async Task<bool> DiurnalSect()
        {
            if (!Core.Player.HasAura(MySpells.DiurnalSect.Name))
            {
                return await MySpells.DiurnalSect.Cast();
            }
            return false;
        }
        private async Task<bool> AspectedBenefic()
        {
            if (Ultima.UltSettings.AstrologianAspectedBenefic &&
                Core.Player.CurrentHealthPercent < 70 &&
                !Core.Player.HasAura(MySpells.AspectedBenefic.Name))
            {
                return await MySpells.AspectedBenefic.Cast();
            }
            return false;
        }
        private async Task<bool> RoyalRoad()
        {
            return await MySpells.RoyalRoad.Cast();
        }
        private async Task<bool> Disable()
        {
            return await MySpells.Disable.Cast();
        }
        private async Task<bool> Spread()
        {
            return await MySpells.Spread.Cast();
        }
        private async Task<bool> AspectedHelios()
        {
            return await MySpells.AspectedHelios.Cast();
        }
        private async Task<bool> Shuffle()
        {
            return await MySpells.Shuffle.Cast();
        }
        private async Task<bool> CombustII()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.CombustII.Name, true, 4000))
            {
                return await MySpells.CombustII.Cast();
            }
            return false;
        }
        private async Task<bool> NocturnalSect()
        {
            return await MySpells.NocturnalSect.Cast();
        }
        private async Task<bool> Synastry()
        {
            return await MySpells.Synastry.Cast();
        }
        private async Task<bool> Gravity()
        {
            return await MySpells.Gravity.Cast();
        }
        private async Task<bool> MaleficII()
        {
            return await MySpells.MaleficII.Cast();
        }
        private async Task<bool> TimeDilation()
        {
            return await MySpells.TimeDilation.Cast();
        }
        private async Task<bool> CollectiveUnconscious()
        {
            return await MySpells.CollectiveUnconscious.Cast();
        }
        private async Task<bool> CelestialOpposition()
        {
            return await MySpells.CelestialOpposition.Cast();
        }

        #endregion

        #region Cross Class Spells

        #region Conjurer

        private async Task<bool> Cure()
        {
            if (Ultima.UltSettings.AstrologianCure)
            {
                return await MySpells.CrossClass.Cure.Cast();
            }
            return false;
        }

        private async Task<bool> Aero()
        {
            if (Ultima.UltSettings.AstrologianAero &&
                !Core.Player.CurrentTarget.HasAura(MySpells.CrossClass.Aero.Name, true, 4000))
            {
                return await MySpells.CrossClass.Aero.Cast();
            }
            return false;
        }

        private async Task<bool> ClericStance()
        {
            if (Ultima.UltSettings.AstrologianClericStance)
            {
                return await MySpells.CrossClass.ClericStance.Cast();
            }
            return false;
        }

        private async Task<bool> Protect()
        {
            if (Ultima.UltSettings.AstrologianProtect &&
                !Core.Player.HasAura(MySpells.CrossClass.Protect.Name))
            {
                return await MySpells.CrossClass.Protect.Cast();
            }
            return false;
        }

        private async Task<bool> Raise()
        {
            if (Ultima.UltSettings.AstrologianRaise)
            {
                return await MySpells.CrossClass.Raise.Cast();
            }
            return false;
        }

        private async Task<bool> Stoneskin()
        {
            if (Ultima.UltSettings.AstrologianStoneskin &&
                !Core.Player.HasAura(MySpells.CrossClass.Stoneskin.Name))
            {
                return await MySpells.CrossClass.Stoneskin.Cast();
            }
            return false;
        }

        #endregion

        #region Thaumaturge

        private async Task<bool> Surecast()
        {
            if (Ultima.UltSettings.AstrologianSurecast)
            {
                return await MySpells.CrossClass.Surecast.Cast();
            }
            return false;
        }

        private async Task<bool> BlizzardII()
        {
            if (Ultima.UltSettings.AstrologianBlizzardII)
            {
                return await MySpells.CrossClass.BlizzardII.Cast();
            }
            return false;
        }

        private async Task<bool> Swiftcast()
        {
            if (Ultima.UltSettings.AstrologianSwiftcast)
            {
                return await MySpells.CrossClass.Swiftcast.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region PvP Spells



        #endregion

        #region Custom Spells

        private async Task<bool> Play()
        {
            if (Core.Player.HasAura(913))
            {
                return await MySpells.TheBalance.Cast();
            }
            if (Core.Player.HasAura(914))
            {
                return await MySpells.TheBole.Cast();
            }
            if (Core.Player.HasAura(915))
            {
                return await MySpells.TheArrow.Cast();
            }
            if (Core.Player.HasAura(916))
            {
                return await MySpells.TheSpear.Cast();
            }
            if (Core.Player.HasAura(917))
            {
                return await MySpells.TheEwer.Cast();
            }
            if (Core.Player.HasAura(918))
            {
                return await MySpells.TheSpire.Cast();
            }
            return false;
        }

        #endregion
    }
}