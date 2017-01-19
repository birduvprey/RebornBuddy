using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;
using UltimaCR.Spells.Main;

namespace UltimaCR.Rotations
{
    public sealed partial class Warrior
    {
        private WarriorSpells _mySpells;

        private WarriorSpells MySpells
        {
            get { return _mySpells ?? (_mySpells = new WarriorSpells()); }
        }

        #region Class Spells

        private async Task<bool> HeavySwing()
        {
            return await MySpells.HeavySwing.Cast();
        }

        private async Task<bool> Foresight()
        {
            return await MySpells.Foresight.Cast();
        }

        private async Task<bool> SkullSunder()
        {
            if (Actionmanager.LastSpell.Name == MySpells.HeavySwing.Name)
            {
                return await MySpells.SkullSunder.Cast();
            }
            return false;
        }

        private async Task<bool> Fracture()
        {
            if (!Core.Player.CurrentTarget.HasAura(MySpells.Fracture.Name, true, 4000))
            {
                if (!Actionmanager.HasSpell(MySpells.StormsEye.Name) &&
                    !Actionmanager.HasSpell(MySpells.StormsPath.Name) ||

                    !Actionmanager.HasSpell(MySpells.StormsEye.Name) &&
                    Core.Player.CurrentTarget.HasAura(MySpells.StormsPath.Name, false, 8000) ||
                    
                    !Actionmanager.HasSpell(MySpells.StormsPath.Name) &&
                    (Core.Player.CurrentTarget.HasAura(MySpells.StormsEye.Name, false, 8000) ||
                    Core.Player.CurrentTarget.HasAura("Dancing Edge")) ||

                    (Core.Player.CurrentTarget.HasAura(MySpells.StormsEye.Name, false, 8000) ||
                    Core.Player.CurrentTarget.HasAura("Dancing Edge")) &&
                    Core.Player.CurrentTarget.HasAura(MySpells.StormsPath.Name, false, 8000))
                {
                    return await MySpells.Fracture.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Bloodbath()
        {
            return await MySpells.Bloodbath.Cast();
        }

        private async Task<bool> BrutalSwing()
        {
            if (Ultima.UltSettings.WarriorBrutalSwing)
            {
                return await MySpells.BrutalSwing.Cast();
            }
            return false;
        }

        private async Task<bool> Overpower()
        {
            return await MySpells.Overpower.Cast();
        }

        private async Task<bool> Tomahawk()
        {
            if (Core.Player.TargetDistance(10))
            {
                return await MySpells.Tomahawk.Cast();
            }
            return false;
        }

        private async Task<bool> Maim()
        {
            if (Actionmanager.LastSpell.Name == MySpells.HeavySwing.Name)
            {
                if (!Core.Player.HasAura(MySpells.Maim.Name, true, 4000) ||
                    Actionmanager.HasSpell(MySpells.StormsEye.Name) &&
                    !Core.Player.CurrentTarget.HasAura(MySpells.StormsEye.Name, false, 8000) &&
                    !Core.Player.CurrentTarget.HasAura("Dancing Edge") ||
                    Actionmanager.HasSpell(MySpells.StormsPath.Name) &&
                    !Core.Player.CurrentTarget.HasAura(MySpells.StormsPath.Name, false, 8000))
                {
                    return await MySpells.Maim.Cast();
                }
            }
            return false;
        }

        private async Task<bool> Berserk()
        {
            if (Core.Player.HasAura(MySpells.Maim.Name, true, 4000))
            {
                if (!Actionmanager.HasSpell(MySpells.StormsEye.Name) ||
                    Actionmanager.HasSpell(MySpells.StormsEye.Name) &&
                    (Core.Player.CurrentTarget.HasAura(MySpells.StormsEye.Name, false, 8000) ||
                    Core.Player.CurrentTarget.HasAura("Dancing Edge")))
                {
                    return await MySpells.Berserk.Cast();
                }
            }
            return false;
        }

        private async Task<bool> MercyStroke()
        {
            if (Ultima.UltSettings.WarriorMercyStroke)
            {
                return await MySpells.MercyStroke.Cast();
            }
            return false;
        }

        private async Task<bool> ButchersBlock()
        {
            if (Actionmanager.LastSpell.Name == MySpells.SkullSunder.Name)
            {
                return await MySpells.ButchersBlock.Cast();
            }
            return false;
        }

        private async Task<bool> ThrillOfBattle()
        {
            return await MySpells.ThrillOfBattle.Cast();
        }

        private async Task<bool> StormsPath()
        {
            if (Actionmanager.LastSpell.Name == MySpells.Maim.Name)
            {
                return await MySpells.StormsPath.Cast();
            }
            return false;
        }

        private async Task<bool> Holmgang()
        {
            return await MySpells.Holmgang.Cast();
        }

        private async Task<bool> Vengeance()
        {
            return await MySpells.Vengeance.Cast();
        }

        private async Task<bool> StormsEye()
        {
            if (Actionmanager.LastSpell.Name == MySpells.Maim.Name &&
                !Core.Player.CurrentTarget.HasAura(MySpells.StormsEye.Name, false, 8000) &&
                !Core.Player.CurrentTarget.HasAura("Dancing Edge"))
            {
                return await MySpells.StormsEye.Cast();
            }
            return false;
        }

        #endregion

        #region Cross Class Spells

        #region Gladiator

        private async Task<bool> SavageBlade()
        {
            if (Ultima.UltSettings.WarriorSavageBlade)
            {
                return await MySpells.CrossClass.SavageBlade.Cast();
            }
            return false;
        }

        private async Task<bool> Flash()
        {
            if (Ultima.UltSettings.WarriorFlash)
            {
                return await MySpells.CrossClass.Flash.Cast();
            }
            return false;
        }

        private async Task<bool> Convalescence()
        {
            if (Ultima.UltSettings.WarriorConvalescence)
            {
                return await MySpells.CrossClass.Convalescence.Cast();
            }
            return false;
        }

        private async Task<bool> Provoke()
        {
            if (Ultima.UltSettings.WarriorProvoke)
            {
                return await MySpells.CrossClass.Provoke.Cast();
            }
            return false;
        }

        private async Task<bool> Awareness()
        {
            if (Ultima.UltSettings.WarriorAwareness)
            {
                return await MySpells.CrossClass.Awareness.Cast();
            }
            return false;
        }

        #endregion

        #region Pugilist

        private async Task<bool> Featherfoot()
        {
            if (Ultima.UltSettings.WarriorFeatherfoot)
            {
                return await MySpells.CrossClass.Featherfoot.Cast();
            }
            return false;
        }

        private async Task<bool> SecondWind()
        {
            if (Ultima.UltSettings.WarriorSecondWind)
            {
                return await MySpells.CrossClass.SecondWind.Cast();
            }
            return false;
        }

        private async Task<bool> Haymaker()
        {
            if (Ultima.UltSettings.WarriorHaymaker)
            {
                return await MySpells.CrossClass.Haymaker.Cast();
            }
            return false;
        }

        private async Task<bool> InternalRelease()
        {
            if (Ultima.UltSettings.WarriorInternalRelease)
            {
                return await MySpells.CrossClass.InternalRelease.Cast();
            }
            return false;
        }

        private async Task<bool> Mantra()
        {
            if (Ultima.UltSettings.WarriorMantra)
            {
                return await MySpells.CrossClass.Mantra.Cast();
            }
            return false;
        }

        #endregion

        #endregion

        #region Job Spells

        private async Task<bool> Defiance()
        {
            return await MySpells.Defiance.Cast();
        }

        private async Task<bool> InnerBeast()
        {
            return await MySpells.InnerBeast.Cast();
        }

        private async Task<bool> Unchained()
        {
            return await MySpells.Unchained.Cast();
        }

        private async Task<bool> SteelCyclone()
        {
            return await MySpells.SteelCyclone.Cast();
        }

        private async Task<bool> Infuriate()
        {
            return await MySpells.Infuriate.Cast();
        }

        private async Task<bool> Deliverance()
        {
            return await MySpells.Deliverance.Cast();
        }

        private async Task<bool> FellCleave()
        {
            return await MySpells.FellCleave.Cast();
        }

        private async Task<bool> RawIntuition()
        {
            return await MySpells.RawIntuition.Cast();
        }

        private async Task<bool> Equilibrium()
        {
            return await MySpells.Equilibrium.Cast();
        }

        private async Task<bool> Decimate()
        {
            return await MySpells.Decimate.Cast();
        }

        #endregion

        #region PvP Spells

        private async Task<bool> FullSwing()
        {
            return await MySpells.PvP.FullSwing.Cast();
        }

        private async Task<bool> MythrilTempest()
        {
            return await MySpells.PvP.MythrilTempest.Cast();
        }

        private async Task<bool> Purify()
        {
            return await MySpells.PvP.Purify.Cast();
        }

        private async Task<bool> ThrillOfWar()
        {
            return await MySpells.PvP.ThrillOfWar.Cast();
        }

        #endregion
    }
}