
namespace UltimaCR.Spells.PVP
{
    public class MachinistSpells
    {
        public class Pvp
        {
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
            private Spell _detect;
            public Spell Detect
            {
                get
                {
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
            private Spell _recouperate;
            public Spell Recouperate
            {
                get
                {
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
            private Spell _purify;
            public Spell Purify
            {
                get
                {
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
            private Spell _manaDraw;
            public Spell ManaDraw
            {
                get
                {
                    return _manaDraw ??
                           (_manaDraw =
                               new Spell
                               {
                                   Name = "Mana Draw",
                                   ID = 1583,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Buff,
                                   CastType = CastType.Self
                               });
                }
            }
        }
    }
}
