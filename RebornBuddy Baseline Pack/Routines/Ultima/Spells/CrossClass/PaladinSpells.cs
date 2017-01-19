
namespace UltimaCR.Spells.CrossClass
{
    public class PaladinSpells
    {
        public class Crossclass
        {
            #region Conjurer
            private Spell _cure;
            public Spell Cure
            {
                get {
                    return _cure ??
                           (_cure =
                               new Spell
                               {
                                   Name = "Cure",
                                   ID = 120,
                                   Level = 2,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Heal,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _protect;
            public Spell Protect
            {
                get {
                    return _protect ??
                           (_protect =
                               new Spell
                               {
                                   Name = "Protect",
                                   ID = 123,
                                   Level = 8,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _raise;
            public Spell Raise
            {
                get {
                    return _raise ??
                           (_raise =
                               new Spell
                               {
                                   Name = "Raise",
                                   ID = 125,
                                   Level = 12,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Heal,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _stoneskin;
            public Spell Stoneskin
            {
                get {
                    return _stoneskin ??
                           (_stoneskin =
                               new Spell
                               {
                                   Name = "Stoneskin",
                                   ID = 129,
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
                get {
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
                get {
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
                get {
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
                get {
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
                get {
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