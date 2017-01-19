
namespace UltimaCR.Spells.CrossClass
{
    public class SummonerSpells
    {
        public class Crossclass
        {
            #region Archer
            private Spell _ragingstrikes;
            public Spell RagingStrikes
            {
                get {
                    return _ragingstrikes ??
                           (_ragingstrikes =
                               new Spell
                               {
                                   Name = "Raging Strikes",
                                   ID = 101,
                                   Level = 4,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _hawkseye;
            public Spell HawksEye
            {
                get {
                    return _hawkseye ??
                           (_hawkseye =
                               new Spell
                               {
                                   Name = "Hawk's Eye",
                                   ID = 99,
                                   Level = 26,
                                   GCDType = GCDType.Off,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _quellingstrikes;
            public Spell QuellingStrikes
            {
                get {
                    return _quellingstrikes ??
                           (_quellingstrikes =
                               new Spell
                               {
                                   Name = "Quelling Strikes",
                                   ID = 104,
                                   Level = 34,
                                   GCDType = GCDType.Off,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            #endregion
            #region Thaumaturge
            private Spell _surecast;
            public Spell Surecast
            {
                get {
                    return _surecast ??
                           (_surecast =
                               new Spell
                               {
                                   Name = "Surecast",
                                   ID = 143,
                                   Level = 8,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _blizzardII;
            public Spell BlizzardII
            {
                get {
                    return _blizzardII ??
                           (_blizzardII =
                               new Spell
                               {
                                   Name = "Blizzard II",
                                   ID = 146,
                                   Level = 12,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Debuff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _swiftcast;
            public Spell Swiftcast
            {
                get {
                    return _swiftcast ??
                           (_swiftcast =
                               new Spell
                               {
                                   Name = "Swiftcast",
                                   ID = 150,
                                   Level = 26,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            #endregion
        }
    }
}