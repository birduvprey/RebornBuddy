
namespace UltimaCR.Spells.Main
{
    public class ThaumaturgeSpells
    {
        private CrossClass.ThaumaturgeSpells.Crossclass _crossClass;
        public CrossClass.ThaumaturgeSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.ThaumaturgeSpells.Crossclass()); }
        }

        private PVP.ThaumaturgeSpells.Pvp _pvp;
        public PVP.ThaumaturgeSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.ThaumaturgeSpells.Pvp()); }
        }

        private Spell _blizzard;
        public Spell Blizzard
        {
            get
            {
                return _blizzard ??
                       (_blizzard =
                           new Spell
                           {
                               Name = "Blizzard",
                               ID = 142,
                               Level = 1,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _fire;
        public Spell Fire
        {
            get
            {
                return _fire ??
                       (_fire =
                           new Spell
                           {
                               Name = "Fire",
                               ID = 141,
                               Level = 2,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _transpose;
        public Spell Transpose
        {
            get
            {
                return _transpose ??
                       (_transpose =
                           new Spell
                           {
                               Name = "Transpose",
                               ID = 149,
                               Level = 4,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _thunder;
        public Spell Thunder
        {
            get
            {
                return _thunder ??
                       (_thunder =
                           new Spell
                           {
                               Name = "Thunder",
                               ID = 144,
                               Level = 6,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Target
                           });
            }
        }
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
        private Spell _sleep;
        public Spell Sleep
        {
            get
            {
                return _sleep ??
                       (_sleep =
                           new Spell
                           {
                               Name = "Sleep",
                               ID = 145,
                               Level = 10,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _blizzardII;
        public Spell BlizzardII
        {
            get
            {
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
        private Spell _scathe;
        public Spell Scathe
        {
            get
            {
                return _scathe ??
                       (_scathe =
                           new Spell
                           {
                               Name = "Scathe",
                               ID = 156,
                               Level = 15,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _fireII;
        public Spell FireII
        {
            get
            {
                return _fireII ??
                       (_fireII =
                           new Spell
                           {
                               Name = "Fire II",
                               ID = 147,
                               Level = 18,
                               GCDType = GCDType.On,
                               SpellType = SpellType.AoE,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _thunderII;
        public Spell ThunderII
        {
            get
            {
                return _thunderII ??
                       (_thunderII =
                           new Spell
                           {
                               Name = "Thunder II",
                               ID = 148,
                               Level = 22,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Target
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
        private Spell _manaward;
        public Spell Manaward
        {
            get
            {
                return _manaward ??
                       (_manaward =
                           new Spell
                           {
                               Name = "Manaward",
                               ID = 157,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _fireIII;
        public Spell FireIII
        {
            get
            {
                return _fireIII ??
                       (_fireIII =
                           new Spell
                           {
                               Name = "Fire III",
                               ID = 152,
                               Level = 34,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _blizzardIII;
        public Spell BlizzardIII
        {
            get
            {
                return _blizzardIII ??
                       (_blizzardIII =
                           new Spell
                           {
                               Name = "Blizzard III",
                               ID = 154,
                               Level = 38,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _lethargy;
        public Spell Lethargy
        {
            get
            {
                return _lethargy ??
                       (_lethargy =
                           new Spell
                           {
                               Name = "Lethargy",
                               ID = 151,
                               Level = 42,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _thunderIII;
        public Spell ThunderIII
        {
            get
            {
                return _thunderIII ??
                       (_thunderIII =
                           new Spell
                           {
                               Name = "Thunder III",
                               ID = 153,
                               Level = 46,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _aetherialmanipulation;
        public Spell AetherialManipulation
        {
            get
            {
                return _aetherialmanipulation ??
                       (_aetherialmanipulation =
                           new Spell
                           {
                               Name = "Aetherial Manipulation",
                               ID = 155,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Self
                           });
            }
        }
    }
}