
namespace UltimaCR.Spells.CrossClass
{
    public class DarkKnightSpells
    {
        public class Crossclass
        {
            #region Gladiator
            private Spell _savageblade;
            public Spell SavageBlade
            {
                get
                {
                    return _savageblade ??
                           (_savageblade =
                               new Spell
                               {
                                   Name = "Savage Blade",
                                   ID = 11,
                                   Level = 4,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Damage,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _flash;
            public Spell Flash
            {
                get
                {
                    return _flash ??
                           (_flash =
                               new Spell
                               {
                                   Name = "Flash",
                                   ID = 14,
                                   Level = 8,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Debuff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _convalescence;
            public Spell Convalescence
            {
                get
                {
                    return _convalescence ??
                           (_convalescence =
                               new Spell
                               {
                                   Name = "Convalescence",
                                   ID = 12,
                                   Level = 10,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _provoke;
            public Spell Provoke
            {
                get
                {
                    return _provoke ??
                           (_provoke =
                               new Spell
                               {
                                   Name = "Provoke",
                                   ID = 18,
                                   Level = 22,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Debuff,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _awareness;
            public Spell Awareness
            {
                get
                {
                    return _awareness ??
                           (_awareness =
                               new Spell
                               {
                                   Name = "Awareness",
                                   ID = 13,
                                   Level = 34,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            #endregion
            #region Marauder
            private Spell _foresight;
            public Spell Foresight
            {
                get
                {
                    return _foresight ??
                           (_foresight =
                               new Spell
                               {
                                   Name = "Foresight",
                                   ID = 32,
                                   Level = 2,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _skullsunder;
            public Spell SkullSunder
            {
                get
                {
                    return _skullsunder ??
                           (_skullsunder =
                               new Spell
                               {
                                   Name = "Skull Sunder",
                                   ID = 35,
                                   Level = 4,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Damage,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _fracture;
            public Spell Fracture
            {
                get
                {
                    return _fracture ??
                           (_fracture =
                               new Spell
                               {
                                   Name = "Fracture",
                                   ID = 33,
                                   Level = 6,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.DoT,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _bloodbath;
            public Spell Bloodbath
            {
                get
                {
                    return _bloodbath ??
                           (_bloodbath =
                               new Spell
                               {
                                   Name = "Bloodbath",
                                   ID = 34,
                                   Level = 8,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _mercystroke;
            public Spell MercyStroke
            {
                get
                {
                    return _mercystroke ??
                           (_mercystroke =
                               new Spell
                               {
                                   Name = "Mercy Stroke",
                                   ID = 36,
                                   Level = 26,
                                   GCDType = GCDType.Off,
                                   SpellType = SpellType.Execute,
                                   CastType = CastType.Target
                               });
                }
            }
            #endregion
        }
    }
}