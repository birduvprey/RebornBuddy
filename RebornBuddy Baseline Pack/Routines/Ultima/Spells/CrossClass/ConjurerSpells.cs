﻿
namespace UltimaCR.Spells.CrossClass
{
    public class ConjurerSpells
    {
        public class Crossclass
        {
            #region Arcanist
            private Spell _ruin;
            public Spell Ruin
            {
                get
                {
                    return _ruin ??
                           (_ruin =
                               new Spell
                               {
                                   Name = "Ruin",
                                   ID = 163,
                                   Level = 1,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Damage,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _physick;
            public Spell Physick
            {
                get
                {
                    return _physick ??
                           (_physick =
                               new Spell
                               {
                                   Name = "Physick",
                                   ID = 190,
                                   Level = 4,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Heal,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _virus;
            public Spell Virus
            {
                get
                {
                    return _virus ??
                           (_virus =
                               new Spell
                               {
                                   Name = "Virus",
                                   ID = 169,
                                   Level = 12,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Debuff,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _eyeforaneye;
            public Spell EyeForAnEye
            {
                get
                {
                    return _eyeforaneye ??
                           (_eyeforaneye =
                               new Spell
                               {
                                   Name = "Eye for an Eye",
                                   ID = 175,
                                   Level = 34,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Target
                               });
                }
            }
            #endregion
            #region Archer
            private Spell _ragingstrikes;
            public Spell RagingStrikes
            {
                get
                {
                    return _ragingstrikes ??
                           (_ragingstrikes =
                               new Spell
                               {
                                   Name = "Raging Strikes",
                                   ID = 101,
                                   Level = 4,
                                   GCDType = GCDType.Off,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _hawkseye;
            public Spell HawksEye
            {
                get
                {
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
                get
                {
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
            #region Gladiator
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
            #region Lancer
            private Spell _keenflurry;
            public Spell KeenFlurry
            {
                get
                {
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
                get
                {
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
                get
                {
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
            #region Pugilist
            private Spell _featherfoot;
            public Spell Featherfoot
            {
                get
                {
                    return _featherfoot ??
                           (_featherfoot =
                               new Spell
                               {
                                   Name = "Featherfoot",
                                   ID = 55,
                                   Level = 4,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _secondwind;
            public Spell SecondWind
            {
                get
                {
                    return _secondwind ??
                           (_secondwind =
                               new Spell
                               {
                                   Name = "Second Wind",
                                   ID = 57,
                                   Level = 8,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Heal,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _internalrelease;
            public Spell InternalRelease
            {
                get
                {
                    return _internalrelease ??
                           (_internalrelease =
                               new Spell
                               {
                                   Name = "Internal Release",
                                   ID = 59,
                                   Level = 12,
                                   GCDType = GCDType.Off,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _mantra;
            public Spell Mantra
            {
                get
                {
                    return _mantra ??
                           (_mantra =
                               new Spell
                               {
                                   Name = "Mantra",
                                   ID = 65,
                                   Level = 42,
                                   GCDType = GCDType.On,
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
                get
                {
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
            private Spell _swiftcast;
            public Spell Swiftcast
            {
                get
                {
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