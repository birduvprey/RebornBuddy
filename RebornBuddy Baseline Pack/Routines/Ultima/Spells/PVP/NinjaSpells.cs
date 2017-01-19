
namespace UltimaCR.Spells.PVP
{
    public class NinjaSpells
    {
        public class Pvp
        {
            private Spell _detect;
            public Spell Detect
            {
                get {
                    return _detect ??
                           (_detect =
                               new Spell
                               {
                                   Name = "Detect",
                                   ID = 1586,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _illwind;
            public Spell IllWind
            {
                get {
                    return _illwind ??
                           (_illwind =
                               new Spell
                               {
                                   Name = "Ill Wind",
                                   ID = 1589,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Interrupt,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _malmsight;
            public Spell Malmsight
            {
                get {
                    return _malmsight ??
                           (_malmsight =
                               new Spell
                               {
                                   Name = "Malmsight",
                                   ID = 1587,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _overwhelm;
            public Spell Overwhelm
            {
                get {
                    return _overwhelm ??
                           (_overwhelm =
                               new Spell
                               {
                                   Name = "Overwhelm",
                                   ID = 1588,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Cooldown,
                                   CastType = CastType.Target
                               });
                }
            }
            private Spell _purify;
            public Spell Purify
            {
                get {
                    return _purify ??
                           (_purify =
                               new Spell
                               {
                                   Name = "Purify",
                                   ID = 1584,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _recouperate;
            public Spell Recouperate
            {
                get {
                    return _recouperate ??
                           (_recouperate =
                               new Spell
                               {
                                   Name = "Recouperate",
                                   ID = 1590,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Heal,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _enliven;
            public Spell Enliven
            {
                get
                {
                    return _enliven ??
                           (_enliven =
                               new Spell
                               {
                                   Name = "Enliven",
                                   ID = 1580,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _weaponthrow;
            public Spell WeaponThrow
            {
                get
                {
                    return _weaponthrow ??
                           (_weaponthrow =
                               new Spell
                               {
                                   Name = "Weapon Throw",
                                   ID = 1579,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Debuff,
                                   CastType = CastType.Target
                               });
                }
            }
        }
    }
}