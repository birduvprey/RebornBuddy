using Clio.Common;
using Clio.Utilities;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UltimaCR
{
    public static class Helpers
    {
        public static bool HasAura(this GameObject unit, string auraname, bool isMyAura = false, int msLeft = 0)
        {
            var unitasc = (unit as Character);
            if (unit == null || unitasc == null)
            {
                return false;
            }
            var auras = isMyAura
                ? unitasc.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Name == auraname)
                : unitasc.CharacterAuras.Where(r => r.Name == auraname);

            return auras.Any(aura => aura.TimespanLeft.TotalMilliseconds >= msLeft);
        }

        public static bool HasAura(this GameObject unit, uint auraid, bool isMyAura = false, int msLeft = 0)
        {
            var unitasc = (unit as Character);
            if (unit == null || unitasc == null)
            {
                return false;
            }
            var auras = isMyAura
                ? unitasc.CharacterAuras.Where(r => r.CasterId == Core.Player.ObjectId && r.Id == auraid)
                : unitasc.CharacterAuras.Where(r => r.Id == auraid);

            return auras.Any(aura => aura.TimespanLeft.TotalMilliseconds >= msLeft);
        }

        public static bool InView(Vector3 PlayerLocation, float PlayerHeading, Vector3 TargetLocation)
        {
            var d = Math.Abs(MathEx.NormalizeRadian(PlayerHeading
                - MathEx.NormalizeRadian(MathHelper.CalculateHeading(PlayerLocation, TargetLocation)
                + (float)Math.PI)));

            if (d > Math.PI)
            {
                d = Math.Abs(d - 2 * (float)Math.PI);
            }
            return d < 0.78539f;
        }

        public static void RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> dic, Func<TValue, bool> predicate)
        {
            var keys = dic.Keys.Where(k => predicate(dic[k])).ToList();
            foreach (var key in keys)
            {
                dic.Remove(key);
            }
        }


        public static bool TargetDistance(this LocalPlayer cp, float range, bool useMinRange = true)
        {
            return useMinRange
                ? cp.HasTarget && cp.Distance2D(cp.CurrentTarget) - cp.CombatReach - cp.CurrentTarget.CombatReach >= range
                : cp.HasTarget && cp.Distance2D(cp.CurrentTarget) - cp.CombatReach - cp.CurrentTarget.CombatReach <= range;
        }

        private static bool IsEnemy(this BattleCharacter ie)
        {
            return
                GameObjectManager.Attackers.Contains(ie) &&
                ie.IsAlive &&
                ie.CanAttack &&
                ie.IsTargetable;
        }

        public static IEnumerable<BattleCharacter> EnemyUnit
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>(true)
                        .Where(eu => eu.IsEnemy());
            }
        }

        //Tanking (Provoke, Flash, etc.) "If something isn't targeting me"
        public static IEnumerable<BattleCharacter> NotTargetingPlayer
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>(true)
                    .Where(ntp => EnemyUnit.Contains(ntp) && ntp.CurrentTargetId != Core.Player.ObjectId)
                    .OrderByDescending(ntp => ntp.CurrentHealthPercent);
            }
        }

        //Targeted Defensive Skills "If this is targeting me"
        public static bool IsTargetingMe(this BattleCharacter tp)
        {
            return tp.IsEnemy() && tp.CurrentTargetId == Core.Player.ObjectId;
        }


        //Self Defensive Skills "If anything is targeting me"
        public static bool EnemyTargetingMe
        {
            get
            {
                return EnemyUnit.Any(tp => tp.CurrentTargetId == Core.Player.ObjectId);
            }
        }

        public static int EnemiesNearTarget(float radius)
        {
            return Core.Player.CurrentTarget == null
                ? 0
                : EnemyUnit.Count(eu => eu.Distance2D(Core.Player.CurrentTarget) - eu.CombatReach - Core.Player.CurrentTarget.CombatReach <= radius);
        }

        public static int EnemiesNearPlayer(float radius)
        {
            return EnemyUnit.Count(eu => eu.Distance2D(Core.Player) - eu.CombatReach - Core.Player.CombatReach <= radius);
        }

        public static IEnumerable<BattleCharacter> PartyMembers
        {
            get
            {
                return
                    PartyManager.VisibleMembers
                    .Select(pm => pm.GameObject as BattleCharacter)
                    .Where(pm => pm.IsTargetable);
            }
        }

        #region Heal Manager

        public static IEnumerable<BattleCharacter> HealManager
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>(true, true)
                    .Where(hm => hm.IsAlive && (PartyMembers.Contains(hm) || hm == Core.Player))
                    .OrderBy(HPScore);
            }
        }

        private static float HPScore(BattleCharacter c)
        {
            var score = c.CurrentHealthPercent;

            if (c.IsTank())
            {
                score -= 5f;
            }
            if (c.IsHealer())
            {
                score -= 3f;
            }
            return score;
        }

        #endregion

        #region Goad Manager
        public static IEnumerable<BattleCharacter> GoadManager
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>(true)
                    .Where(gm => PartyMembers.Contains(gm) && gm.Type == GameObjectType.Pc && gm.CurrentTP <= 800 && gm.InCombat && gm.IsAlive &&
                        gm.CurrentJob != ClassJobType.Arcanist &&
                        gm.CurrentJob != ClassJobType.Scholar &&
                        gm.CurrentJob != ClassJobType.Summoner &&
                        gm.CurrentJob != ClassJobType.Astrologian &&
                        gm.CurrentJob != ClassJobType.Thaumaturge &&
                        gm.CurrentJob != ClassJobType.BlackMage &&
                        gm.CurrentJob != ClassJobType.Conjurer &&
                        gm.CurrentJob != ClassJobType.WhiteMage)
                    .OrderByDescending(TPScore);
            }
        }

        private static int TPScore(BattleCharacter c)
        {
            var score = 0;

            if (c.IsTank())
            {
                score += 100;
            }
            switch (c.CurrentJob)
            {
                case ClassJobType.Archer:
                case ClassJobType.Bard:
                case ClassJobType.Pugilist:
                case ClassJobType.Monk:
                case ClassJobType.Rogue:
                case ClassJobType.Ninja:
                case ClassJobType.Machinist:
                    if (c.CurrentTP <= 400)
                    {
                        score += 200;
                    }
                    break;
            }
            switch (c.CurrentJob)
            {
                case ClassJobType.Lancer:
                case ClassJobType.Dragoon:
                    if (c.CurrentTP <= 300)
                    {
                        score += 200;
                    }
                    break;
            }
            return score;
        }

        #endregion

        #region Role Check

        public static bool IsTank(this Character c)
        {
            switch (c.CurrentJob)
            {
                case ClassJobType.Marauder:
                case ClassJobType.Warrior:
                case ClassJobType.Gladiator:
                case ClassJobType.Paladin:
                case ClassJobType.DarkKnight:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsHealer(this Character c)
        {
            switch (c.CurrentJob)
            {
                case ClassJobType.Arcanist:
                case ClassJobType.Scholar:
                case ClassJobType.Conjurer:
                case ClassJobType.WhiteMage:
                case ClassJobType.Astrologian:
                    return true;
                default:
                    return false;
            }
        }


        public static bool IsDPS(this Character c)
        {
            return
                !c.IsTank() && !c.IsHealer();
        }

        #endregion
    }
}