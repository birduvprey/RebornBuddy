
namespace UltimaCR.Spells.CrossClass
{
    public class BlackMageSpells
    {
        public class Crossclass
        {
            #region Arcanist
            private Spell _ruin;
            public Spell Ruin
            {
                get {
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
                get {
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
                get {
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
                get {
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
        }
    }
}
