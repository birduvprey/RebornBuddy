
namespace UltimaCR.Spells.PVP
{
    public class SummonerSpells
    {
        public class Pvp
        {
            private Spell _aethericBurst;
            public Spell AethericBurst
            {
                get {
                    return _aethericBurst ??
                           (_aethericBurst =
                               new Spell
                               {
                                   Name = "Aetheric Burst",
                                   ID = 1581,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Cooldown,
                                   CastType = CastType.Self
                               });
                }
            }
            private Spell _equanimity;
            public Spell Equanimity
            {
                get {
                    return _equanimity ??
                           (_equanimity =
                               new Spell
                               {
                                   Name = "Equanimity",
                                   ID = 1582,
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
                get {
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
            private Spell _mistyVeil;
            public Spell MistyVeil
            {
                get {
                    return _mistyVeil ??
                           (_mistyVeil =
                               new Spell
                               {
                                   Name = "Misty Veil",
                                   ID = 1575,
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
            private Spell _wither;
            public Spell Wither
            {
                get {
                    return _wither ??
                           (_wither =
                               new Spell
                               {
                                   Name = "Wither",
                                   ID = 1576,
                                   Level = 0,
                                   GCDType = GCDType.On,
                                   SpellType = SpellType.Cooldown,
                                   CastType = CastType.Target
                               });
                }
            }
        }
    }
}
