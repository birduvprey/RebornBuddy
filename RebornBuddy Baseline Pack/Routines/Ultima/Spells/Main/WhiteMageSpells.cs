
namespace UltimaCR.Spells.Main
{
    public class WhiteMageSpells : ConjurerSpells
    {
        private CrossClass.WhiteMageSpells.Crossclass _crossClass;
        public new CrossClass.WhiteMageSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.WhiteMageSpells.Crossclass()); }
        }

        private PVP.WhiteMageSpells.Pvp _pvp;
        public new PVP.WhiteMageSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.WhiteMageSpells.Pvp()); }
        }

        private Spell _presenceofmind;
        public Spell PresenceOfMind
        {
            get
            {
                return _presenceofmind ??
                       (_presenceofmind =
                           new Spell
                           {
                               Name = "Presence of Mind",
                               ID = 136,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _regen;
        public Spell Regen
        {
            get
            {
                return _regen ??
                       (_regen =
                           new Spell
                           {
                               Name = "Regen",
                               ID = 137,
                               Level = 35,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _divineseal;
        public Spell DivineSeal
        {
            get
            {
                return _divineseal ??
                       (_divineseal =
                           new Spell
                           {
                               Name = "Divine Seal",
                               ID = 138,
                               Level = 40,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Buff,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _holy;
        public Spell Holy
        {
            get
            {
                return _holy ??
                       (_holy =
                           new Spell
                           {
                               Name = "Holy",
                               ID = 139,
                               Level = 45,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _benediction;
        public Spell Benediction
        {
            get
            {
                return _benediction ??
                       (_benediction =
                           new Spell
                           {
                               Name = "Benediction",
                               ID = 140,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _asylum;
        public Spell Asylum
        {
            get
            {
                return _asylum ??
                       (_asylum =
                           new Spell
                           {
                               Name = "Asylum",
                               ID = 3569,
                               Level = 52,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.TargetLocation
                           });
            }
        }
        private Spell _stoneIII;
        public Spell StoneIII
        {
            get
            {
                return _stoneIII ??
                       (_stoneIII =
                           new Spell
                           {
                               Name = "Stone III",
                               ID = 3568,
                               Level = 54,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _assize;
        public Spell Assize
        {
            get
            {
                return _assize ??
                       (_assize =
                           new Spell
                           {
                               Name = "Assize",
                               ID = 3571,
                               Level = 56,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _aeroIII;
        public Spell AeroIII
        {
            get
            {
                return _aeroIII ??
                       (_aeroIII =
                           new Spell
                           {
                               Name = "Aero III",
                               ID = 3572,
                               Level = 58,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _tetragrammaton;
        public Spell Tetragrammaton
        {
            get
            {
                return _tetragrammaton ??
                       (_tetragrammaton =
                           new Spell
                           {
                               Name = "Tetragrammaton",
                               ID = 3570,
                               Level = 60,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Target
                           });
            }
        }
    }
}