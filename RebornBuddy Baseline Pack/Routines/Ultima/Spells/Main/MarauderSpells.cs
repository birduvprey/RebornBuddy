
namespace UltimaCR.Spells.Main
{
    public class MarauderSpells
    {
        private CrossClass.MarauderSpells.Crossclass _crossClass;
        public CrossClass.MarauderSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.MarauderSpells.Crossclass()); }
        }

        private PVP.MarauderSpells.Pvp _pvp;
        public PVP.MarauderSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.MarauderSpells.Pvp()); }
        }

        private Spell _heavyswing;
        public Spell HeavySwing
        {
            get
            {
                return _heavyswing ??
                       (_heavyswing =
                           new Spell
                           {
                               Name = "Heavy Swing",
                               ID = 31,
                               Level = 1,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
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
        private Spell _brutalswing;
        public Spell BrutalSwing
        {
            get
            {
                return _brutalswing ??
                       (_brutalswing =
                           new Spell
                           {
                               Name = "Brutal Swing",
                               ID = 39,
                               Level = 10,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Interrupt,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _overpower;
        public Spell Overpower
        {
            get
            {
                return _overpower ??
                       (_overpower =
                           new Spell
                           {
                               Name = "Overpower",
                               ID = 41,
                               Level = 12,
                               GCDType = GCDType.On,
                               SpellType = SpellType.AoE,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _tomahawk;
        public Spell Tomahawk
        {
            get
            {
                return _tomahawk ??
                       (_tomahawk =
                           new Spell
                           {
                               Name = "Tomahawk",
                               ID = 46,
                               Level = 15,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _maim;
        public Spell Maim
        {
            get
            {
                return _maim ??
                       (_maim =
                           new Spell
                           {
                               Name = "Maim",
                               ID = 37,
                               Level = 18,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _berserk;
        public Spell Berserk
        {
            get
            {
                return _berserk ??
                       (_berserk =
                           new Spell
                           {
                               Name = "Berserk",
                               ID = 38,
                               Level = 22,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Buff,
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
        private Spell _butchersblock;
        public Spell ButchersBlock
        {
            get
            {
                return _butchersblock ??
                       (_butchersblock =
                           new Spell
                           {
                               Name = "Butcher's Block",
                               ID = 47,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _thrillofbattle;
        public Spell ThrillOfBattle
        {
            get
            {
                return _thrillofbattle ??
                       (_thrillofbattle =
                           new Spell
                           {
                               Name = "Thrill of Battle",
                               ID = 40,
                               Level = 34,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _stormspath;
        public Spell StormsPath
        {
            get
            {
                return _stormspath ??
                       (_stormspath =
                           new Spell
                           {
                               Name = "Storm's Path",
                               ID = 42,
                               Level = 38,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _holmgang;
        public Spell Holmgang
        {
            get
            {
                return _holmgang ??
                       (_holmgang =
                           new Spell
                           {
                               Name = "Holmgang",
                               ID = 43,
                               Level = 42,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _vengeance;
        public Spell Vengeance
        {
            get
            {
                return _vengeance ??
                       (_vengeance =
                           new Spell
                           {
                               Name = "Vengeance",
                               ID = 44,
                               Level = 46,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _stormseye;
        public Spell StormsEye
        {
            get
            {
                return _stormseye ??
                       (_stormseye =
                           new Spell
                           {
                               Name = "Storm's Eye",
                               ID = 45,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
    }
}