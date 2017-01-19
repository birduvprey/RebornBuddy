
namespace UltimaCR.Spells.CrossClass
{
    public class MonkSpells
    {
        public class Crossclass
        {
            #region Lancer
            private Spell _feint;
            public Spell Feint
            {
                get {
                    return _feint ??
                           (_feint =
                               new Spell
                               {
                                   Name = "Feint",
                                   ID = 76,
                                   Level = 2,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Debuff,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _keenflurry;
            public Spell KeenFlurry
            {
                get {
                    return _keenflurry ??
                           (_keenflurry =
                               new Spell
                               {
                                   Name = "Keen Flurry",
                                   ID = 77,
                                   Level = 6,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _invigorate;
            public Spell Invigorate
            {
                get {
                    return _invigorate ??
                           (_invigorate =
                               new Spell
                               {
                                   Name = "Invigorate",
                                   ID = 80,
                                   Level = 22,
                                   GCDType = GCDType.Off,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _bloodforblood;
            public Spell BloodForBlood
            {
                get {
                    return _bloodforblood ??
                           (_bloodforblood =
                               new Spell
                               {
                                   Name = "Blood for Blood",
                                   ID = 85,
                                   Level = 34,
                                   GCDType = GCDType.Off,
                                   SpellType = SpellType.Buff,
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
