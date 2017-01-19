
namespace UltimaCR.Spells.Main
{
    public class ArcanistSpells
    {
        private CrossClass.ArcanistSpells.Crossclass _crossClass;
        public CrossClass.ArcanistSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.ArcanistSpells.Crossclass()); }
        }

        private PVP.ArcanistSpells.Pvp _pvp;
        public PVP.ArcanistSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.ArcanistSpells.Pvp()); }
        }

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
        private Spell _bio;
        public Spell Bio
        {
            get
            {
                return _bio ??
                       (_bio =
                           new Spell
                           {
                               Name = "Bio",
                               ID = 164,
                               Level = 2,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _summon;
        public Spell Summon
        {
            get
            {
                return _summon ??
                       (_summon =
                           new Spell
                           {
                               Name = "Summon",
                               ID = 165,
                               Level = 4,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Summon,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _backdraft;
        public Spell Backdraft
        {
            get
            {
                return _backdraft ??
                       (_backdraft =
                           new Spell
                           {
                               Name = "Backdraft",
                               ID = 10,
                               Level = 4,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
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
        private Spell _aetherflow;
        public Spell Aetherflow
        {
            get
            {
                return _aetherflow ??
                       (_aetherflow =
                           new Spell
                           {
                               Name = "Aetherflow",
                               ID = 166,
                               Level = 6,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _energyDrain;
        public Spell EnergyDrain
        {
            get
            {
                return _energyDrain ??
                       (_energyDrain =
                           new Spell
                           {
                               Name = "Energy Drain",
                               ID = 167,
                               Level = 8,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Cooldown,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _miasma;
        public Spell Miasma
        {
            get
            {
                return _miasma ??
                       (_miasma =
                           new Spell
                           {
                               Name = "Miasma",
                               ID = 168,
                               Level = 10,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
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
        private Spell _summonII;
        public Spell SummonII
        {
            get
            {
                return _summonII ??
                       (_summonII =
                           new Spell
                           {
                               Name = "Summon II",
                               ID = 170,
                               Level = 15,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Summon,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _shiningtopaz;
        public Spell ShiningTopaz
        {
            get
            {
                return _shiningtopaz ??
                       (_shiningtopaz =
                           new Spell
                           {
                               Name = "Shining Topaz",
                               ID = 12,
                               Level = 15,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _sustain;
        public Spell Sustain
        {
            get
            {
                return _sustain ??
                       (_sustain =
                           new Spell
                           {
                               Name = "Sustain",
                               ID = 171,
                               Level = 18,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _downburst;
        public Spell Downburst
        {
            get
            {
                return _downburst ??
                       (_downburst =
                           new Spell
                           {
                               Name = "Downburst",
                               ID = 11,
                               Level = 20,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _curl;
        public Spell Curl
        {
            get
            {
                return _curl ??
                       (_curl =
                           new Spell
                           {
                               Name = "Curl",
                               ID = 15,
                               Level = 20,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _resurrection;
        public Spell Resurrection
        {
            get
            {
                return _resurrection ??
                       (_resurrection =
                           new Spell
                           {
                               Name = "Resurrection",
                               ID = 173,
                               Level = 22,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _bioII;
        public Spell BioII
        {
            get
            {
                return _bioII ??
                       (_bioII =
                           new Spell
                           {
                               Name = "Bio II",
                               ID = 178,
                               Level = 26,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _bane;
        public Spell Bane
        {
            get
            {
                return _bane ??
                       (_bane =
                           new Spell
                           {
                               Name = "Bane",
                               ID = 174,
                               Level = 30,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.AoE,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _eyeForAnEye;
        public Spell EyeForAnEye
        {
            get
            {
                return _eyeForAnEye ??
                       (_eyeForAnEye =
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
        private Spell _ruinII;
        public Spell RuinII
        {
            get
            {
                return _ruinII ??
                       (_ruinII =
                           new Spell
                           {
                               Name = "Ruin II",
                               ID = 172,
                               Level = 38,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _shiningemerald;
        public Spell ShiningEmerald
        {
            get
            {
                return _shiningemerald ??
                       (_shiningemerald =
                           new Spell
                           {
                               Name = "Shining Emerald",
                               ID = 12,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _storm;
        public Spell Storm
        {
            get
            {
                return _storm ??
                       (_storm =
                           new Spell
                           {
                               Name = "Storm",
                               ID = 16,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Pet,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _rouse;
        public Spell Rouse
        {
            get
            {
                return _rouse ??
                       (_rouse =
                           new Spell
                           {
                               Name = "Rouse",
                               ID = 176,
                               Level = 42,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _miasmaII;
        public Spell MiasmaII
        {
            get
            {
                return _miasmaII ??
                       (_miasmaII =
                           new Spell
                           {
                               Name = "Miasma II",
                               ID = 177,
                               Level = 46,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _shadowFlare;
        public Spell ShadowFlare
        {
            get
            {
                return _shadowFlare ??
                       (_shadowFlare =
                           new Spell
                           {
                               Name = "Shadow Flare",
                               ID = 179,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.TargetLocation
                           });
            }
        }
    }
}