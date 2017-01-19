
namespace UltimaCR.Spells.Main
{
    public class LancerSpells
    {
        private CrossClass.LancerSpells.Crossclass _crossClass;
        public CrossClass.LancerSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.LancerSpells.Crossclass()); }
        }

        private PVP.LancerSpells.Pvp _pvp;
        public PVP.LancerSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.LancerSpells.Pvp()); }
        }

        private Spell _truethrust;
        public Spell TrueThrust
        {
            get
            {
                return _truethrust ??
                       (_truethrust =
                           new Spell
                           {
                               Name = "True Thrust",
                               ID = 75,
                               Level = 1,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _feint;
        public Spell Feint
        {
            get
            {
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
        private Spell _vorpalthrust;
        public Spell VorpalThrust
        {
            get
            {
                return _vorpalthrust ??
                       (_vorpalthrust =
                           new Spell
                           {
                               Name = "Vorpal Thrust",
                               ID = 78,
                               Level = 4,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
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
        private Spell _impulsedrive;
        public Spell ImpulseDrive
        {
            get
            {
                return _impulsedrive ??
                       (_impulsedrive =
                           new Spell
                           {
                               Name = "Impulse Drive",
                               ID = 81,
                               Level = 8,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _legsweep;
        public Spell LegSweep
        {
            get
            {
                return _legsweep ??
                       (_legsweep =
                           new Spell
                           {
                               Name = "Leg Sweep",
                               ID = 82,
                               Level = 10,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Interrupt,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _heavythrust;
        public Spell HeavyThrust
        {
            get
            {
                return _heavythrust ??
                       (_heavythrust =
                           new Spell
                           {
                               Name = "Heavy Thrust",
                               ID = 79,
                               Level = 12,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Flank,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _piercingtalon;
        public Spell PiercingTalon
        {
            get
            {
                return _piercingtalon ??
                       (_piercingtalon =
                           new Spell
                           {
                               Name = "Piercing Talon",
                               ID = 90,
                               Level = 15,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _lifesurge;
        public Spell LifeSurge
        {
            get
            {
                return _lifesurge ??
                       (_lifesurge =
                           new Spell
                           {
                               Name = "Life Surge",
                               ID = 83,
                               Level = 18,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
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
        private Spell _fullthrust;
        public Spell FullThrust
        {
            get
            {
                return _fullthrust ??
                       (_fullthrust =
                           new Spell
                           {
                               Name = "Full Thrust",
                               ID = 84,
                               Level = 26,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _phlebotomize;
        public Spell Phlebotomize
        {
            get
            {
                return _phlebotomize ??
                       (_phlebotomize =
                           new Spell
                           {
                               Name = "Phlebotomize",
                               ID = 91,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Target
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
        private Spell _disembowel;
        public Spell Disembowel
        {
            get
            {
                return _disembowel ??
                       (_disembowel =
                           new Spell
                           {
                               Name = "Disembowel",
                               ID = 87,
                               Level = 38,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _doomspike;
        public Spell DoomSpike
        {
            get
            {
                return _doomspike ??
                       (_doomspike =
                           new Spell
                           {
                               Name = "Doom Spike",
                               ID = 86,
                               Level = 42,
                               GCDType = GCDType.On,
                               SpellType = SpellType.AoE,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _ringofthorns;
        public Spell RingOfThorns
        {
            get
            {
                return _ringofthorns ??
                       (_ringofthorns =
                           new Spell
                           {
                               Name = "Ring of Thorns",
                               ID = 89,
                               Level = 46,
                               GCDType = GCDType.On,
                               SpellType = SpellType.AoE,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _chaosthrust;
        public Spell ChaosThrust
        {
            get
            {
                return _chaosthrust ??
                       (_chaosthrust =
                           new Spell
                           {
                               Name = "Chaos Thrust",
                               ID = 88,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Behind,
                               CastType = CastType.Target
                           });
            }
        }
    }
}