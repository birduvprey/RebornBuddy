
namespace UltimaCR.Spells.PVP
{
    public class DarkKnightSpells
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
            private Spell _fullswing;
            public Spell FullSwing
            {
                get
                {
                    return _fullswing ??
                           (_fullswing =
                               new Spell
                               {
                                   Name = "Full Swing",
                                   ID = 1562,
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
