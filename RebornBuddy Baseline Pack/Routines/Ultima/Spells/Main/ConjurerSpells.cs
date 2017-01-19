
namespace UltimaCR.Spells.Main
{
    public class ConjurerSpells
    {
        private CrossClass.ConjurerSpells.Crossclass _crossClass;
        public CrossClass.ConjurerSpells.Crossclass CrossClass
        {
            get { return _crossClass ?? (_crossClass = new CrossClass.ConjurerSpells.Crossclass()); }
        }

        private PVP.ConjurerSpells.Pvp _pvp;
        public PVP.ConjurerSpells.Pvp PvP
        {
            get { return _pvp ?? (_pvp = new PVP.ConjurerSpells.Pvp()); }
        }

        private Spell _stone;
        public Spell Stone
        {
            get
            {
                return _stone ??
                       (_stone =
                           new Spell
                           {
                               Name = "Stone",
                               ID = 119,
                               Level = 1,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _cure;
        public Spell Cure
        {
            get
            {
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
        private Spell _aero;
        public Spell Aero
        {
            get
            {
                return _aero ??
                       (_aero =
                           new Spell
                           {
                               Name = "Aero",
                               ID = 121,
                               Level = 4,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _clericstance;
        public Spell ClericStance
        {
            get
            {
                return _clericstance ??
                       (_clericstance =
                           new Spell
                           {
                               Name = "Cleric Stance",
                               ID = 122,
                               Level = 6,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Aura,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _protect;
        public Spell Protect
        {
            get
            {
                return _protect ??
                       (_protect =
                           new Spell
                           {
                               Name = "Protect",
                               ID = 123,
                               Level = 8,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _medica;
        public Spell Medica
        {
            get
            {
                return _medica ??
                       (_medica =
                           new Spell
                           {
                               Name = "Medica",
                               ID = 124,
                               Level = 10,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _raise;
        public Spell Raise
        {
            get
            {
                return _raise ??
                       (_raise =
                           new Spell
                           {
                               Name = "Raise",
                               ID = 125,
                               Level = 12,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _fluidaura;
        public Spell FluidAura
        {
            get
            {
                return _fluidaura ??
                       (_fluidaura =
                           new Spell
                           {
                               Name = "Fluid Aura",
                               ID = 134,
                               Level = 15,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Knockback,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _esuna;
        public Spell Esuna
        {
            get
            {
                return _esuna ??
                       (_esuna =
                           new Spell
                           {
                               Name = "Esuna",
                               ID = 126,
                               Level = 18,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _stoneII;
        public Spell StoneII
        {
            get
            {
                return _stoneII ??
                       (_stoneII =
                           new Spell
                           {
                               Name = "Stone II",
                               ID = 127,
                               Level = 22,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Damage,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _repose;
        public Spell Repose
        {
            get
            {
                return _repose ??
                       (_repose =
                           new Spell
                           {
                               Name = "Repose",
                               ID = 128,
                               Level = 26,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Debuff,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _cureII;
        public Spell CureII
        {
            get
            {
                return _cureII ??
                       (_cureII =
                           new Spell
                           {
                               Name = "Cure II",
                               ID = 135,
                               Level = 30,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _stoneskin;
        public Spell Stoneskin
        {
            get
            {
                return _stoneskin ??
                       (_stoneskin =
                           new Spell
                           {
                               Name = "Stoneskin",
                               ID = 129,
                               Level = 34,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _shroudofsaints;
        public Spell ShroudOfSaints
        {
            get
            {
                return _shroudofsaints ??
                       (_shroudofsaints =
                           new Spell
                           {
                               Name = "Shroud of Saints",
                               ID = 130,
                               Level = 38,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _cureIII;
        public Spell CureIII
        {
            get
            {
                return _cureIII ??
                       (_cureIII =
                           new Spell
                           {
                               Name = "Cure III",
                               ID = 131,
                               Level = 42,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _aeroII;
        public Spell AeroII
        {
            get
            {
                return _aeroII ??
                       (_aeroII =
                           new Spell
                           {
                               Name = "Aero II",
                               ID = 132,
                               Level = 46,
                               GCDType = GCDType.On,
                               SpellType = SpellType.DoT,
                               CastType = CastType.Target
                           });
            }
        }
        private Spell _medicaII;
        public Spell MedicaII
        {
            get
            {
                return _medicaII ??
                       (_medicaII =
                           new Spell
                           {
                               Name = "Medica II",
                               ID = 133,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Heal,
                               CastType = CastType.Self
                           });
            }
        }
        private Spell _stoneskinII;
        public Spell StoneskinII
        {
            get
            {
                return _stoneskinII ??
                       (_stoneskinII =
                           new Spell
                           {
                               Name = "Stoneskin II",
                               ID = 191,
                               Level = 50,
                               GCDType = GCDType.On,
                               SpellType = SpellType.Defensive,
                               CastType = CastType.Self
                           });
            }
        }
    }
}