
namespace UltimaCR.Spells.Main
{
    public class MachinistSpells
    {
        private CrossClass.MachinistSpells.Crossclass _crossClass;
        public CrossClass.MachinistSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.MachinistSpells.Crossclass()); }
        }

        private PVP.MachinistSpells.Pvp _pvp;
        public PVP.MachinistSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.MachinistSpells.Pvp()); }
        }

        private Spell _splitshot;
        public Spell SplitShot
        {
            get
            {
                return _splitshot ??
                       (_splitshot =
                           new Spell
                           {
                               Name = "Split Shot",
                               ID = 2866,
                               Level = 1,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _slugshot;
        public Spell SlugShot
        {
            get
            {
                return _slugshot ??
                       (_slugshot =
                           new Spell
                           {
                               Name = "Slug Shot",
                               ID = 2868,
                               Level = 2,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _reload;
        public Spell Reload
        {
            get
            {
                return _reload ??
                       (_reload =
                           new Spell
                           {
                               Name = "Reload",
                               ID = 2867,
                               Level = 4,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _leadshot;
        public Spell LeadShot
        {
            get
            {
                return _leadshot ??
                       (_leadshot =
                           new Spell
                           {
                               Name = "Lead Shot",
                               ID = 2869,
                               Level = 6,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _heartbreak;
        public Spell Heartbreak
        {
            get
            {
                return _heartbreak ??
                       (_heartbreak =
                           new Spell
                           {
                               Name = "Heartbreak",
                               ID = 2875,
                               Level = 8,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Execute,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _leggraze;
        public Spell LegGraze
        {
            get
            {
                return _leggraze ??
                       (_leggraze =
                           new Spell
                           {
                               Name = "Leg Graze",
                               ID = 2877,
                               Level = 10,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _reassemble;
        public Spell Reassemble
        {
            get
            {
                return _reassemble ??
                       (_reassemble =
                           new Spell
                           {
                               Name = "Reassemble",
                               ID = 2876,
                               Level = 12,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _blank;
        public Spell Blank
        {
            get
            {
                return _blank ??
                       (_blank =
                           new Spell
                           {
                               Name = "Blank",
                               ID = 2888,
                               Level = 15,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Knockback,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _spreadshot;
        public Spell SpreadShot
        {
            get
            {
                return _spreadshot ??
                       (_spreadshot =
                           new Spell
                           {
                               Name = "Spread Shot",
                               ID = 2870,
                               Level = 18,
                               GCDType = GCDType.On,
                               SpellType = SpellType.AoE,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _footgraze;
        public Spell FootGraze
        {
            get
            {
                return _footgraze ??
                       (_footgraze =
                           new Spell
                           {
                               Name = "Foot Graze",
                               ID = 2884,
                               Level = 22,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _quickreload;
        public Spell QuickReload
        {
            get
            {
                return _quickreload ??
                       (_quickreload =
                           new Spell
                           {
                               Name = "Quick Reload",
                               ID = 2879,
                               Level = 26,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _hotshot;
        public Spell HotShot
        {
            get
            {
                return _hotshot ??
                       (_hotshot =
                           new Spell
                           {
                               Name = "Hot Shot",
                               ID = 2872,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _rapidfire;
        public Spell RapidFire
        {
            get
            {
                return _rapidfire ??
                       (_rapidfire =
                           new Spell
                           {
                               Name = "Rapid Fire",
                               ID = 2881,
                               Level = 30,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _headgraze;
        public Spell HeadGraze
        {
            get
            {
                return _headgraze ??
                       (_headgraze =
                           new Spell
                           {
                               Name = "Head Graze",
                               ID = 2886,
                               Level = 34,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Interrupt,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _cleanshot;
        public Spell CleanShot
        {
            get
            {
                return _cleanshot ??
                       (_cleanshot =
                           new Spell
                           {
                               Name = "Clean Shot",
                               ID = 2873,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _wildfire;
        public Spell Wildfire
        {
            get
            {
                return _wildfire ??
                       (_wildfire =
                           new Spell
                           {
                               Name = "Wildfire",
                               ID = 2878,
                               Level = 38,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Cooldown,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _rookautoturret;
        public Spell RookAutoturret
        {
            get
            {
                return _rookautoturret ??
                       (_rookautoturret =
                           new Spell
                           {
                               Name = "Rook Autoturret",
                               ID = 2864,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Summon,
                               CastType = CastType.TargetLocation
                           });
            }
        }
        private Spell _turretretrieval;
        public Spell TurretRetrieval
        {
            get
            {
                return _turretretrieval ??
                       (_turretretrieval =
                           new Spell
                           {
                               Name = "Turret Retrieval",
                               ID = 3487,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Summon,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _promotion;
        public Spell Promotion
        {
            get
            {
                return _promotion ??
                       (_promotion =
                           new Spell
                           {
                               Name = "Promotion",
                               ID = 2889,
                               Level = 42,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Aura,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _suppressivefire;
        public Spell SuppressiveFire
        {
            get
            {
                return _suppressivefire ??
                       (_suppressivefire =
                           new Spell
                           {
                               Name = "Suppressive Fire",
                               ID = 2883,
                               Level = 45,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Interrupt,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _grenadoshot;
        public Spell GrenadoShot
        {
            get
            {
                return _grenadoshot ??
                       (_grenadoshot =
                           new Spell
                           {
                               Name = "Grenado Shot",
                               ID = 2871,
                               Level = 46,
                               GCDType = GCDType.On,
                               SpellType = SpellType.AoE,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _bishopautoturret;
        public Spell BishopAutoturret
        {
            get
            {
                return _bishopautoturret ??
                       (_bishopautoturret =
                           new Spell
                           {
                               Name = "Bishop Autoturret",
                               ID = 2865,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Summon,
                               CastType = CastType.TargetLocation
                           });
            }
        }
        private Spell _dismantle;
        public Spell Dismantle
        {
            get
            {
                return _dismantle ??
                       (_dismantle =
                           new Spell
                           {
                               Name = "Dismantle",
                               ID = 2887,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _gaussbarrel;
        public Spell GaussBarrel
        {
            get
            {
                return _gaussbarrel ??
                       (_gaussbarrel =
                           new Spell
                           {
                               Name = "Gauss Barrel",
                               ID = 2880,
                               Level = 52,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Aura,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _gaussround;
        public Spell GaussRound
        {
            get
            {
                return _gaussround ??
                       (_gaussround =
                           new Spell
                           {
                               Name = "Gauss Round",
                               ID = 2874,
                               Level = 54,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Cooldown,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _rendmind;
        public Spell RendMind
        {
            get
            {
                return _rendmind ??
                       (_rendmind =
                           new Spell
                           {
                               Name = "Rend Mind",
                               ID = 2882,
                               Level = 56,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _hypercharge;
        public Spell Hypercharge
        {
            get
            {
                return _hypercharge ??
                       (_hypercharge =
                           new Spell
                           {
                               Name = "Hypercharge",
                               ID = 2885,
                               Level = 58,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _ricochet;
        public Spell Ricochet
        {
            get
            {
                return _ricochet ??
                       (_ricochet =
                           new Spell
                           {
                               Name = "Ricochet",
                               ID = 2890,
                               Level = 60,
                               GCDType = GCDType.Off,
                               SpellType = SpellType.Cooldown,
                               CastType = CastType.Target
                           });
            }
        }
    }
}