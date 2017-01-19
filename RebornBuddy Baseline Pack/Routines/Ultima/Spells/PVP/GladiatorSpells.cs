
namespace UltimaCR.Spells.PVP
{
    public class GladiatorSpells
    {
        public class Pvp
        {
            private Spell _enliven;
            public Spell Enliven
            {
                get {
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
            private Spell _fullswing;
            public Spell FullSwing
            {
                get {
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
            private Spell _gloryslash;
            public Spell GlorySlash
            {
                get {
                    return _gloryslash ??
                           (_gloryslash =
                               new Spell
                               {
                                   Name = "Glory Slash",
                                   ID = 1559,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Debuff,
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
            private Spell _testudo;
            public Spell Testudo
            {
                get {
                    return _testudo ??
                           (_testudo =
                               new Spell
                               {
                                   Name = "Testudo",
                                   ID = 1558,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Defensive,
                                   CastType = CastType.Target
                               });
                }
            }
        }
    }
}
