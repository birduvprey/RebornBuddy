namespace ExBuddy.OrderBotTags.Behaviors.Objects
{
    public enum ShopItem
    {
#if RB_CN

        #region BlueCrafter

        BlueCrafterToken = 0,

        CommercialEngineeringManual = 1,

        SweetCreamMilk = 2,

        StoneCheese = 3,

        HeavensEgg = 4,

        CarbonFiber = 5,

        LoaghtanFilet = 6,

        GoldenApple = 7,

        SolsticeGarlic = 8,

        MatureOliveOil = 9,

        PowderedMermanHorn = 10,

        BouillonCube = 11,

        BeanSauce = 12,

        BeanPaste = 13,

        KukuruPowder = 14,

        AdeptsHat = 15,

        AdeptsGown = 16,

        AdeptsGloves = 17,

        AdeptsHose = 18,

        AdeptsThighboots = 19,

        CrpDelineation = 20,

        BsmDelineation = 21,

        ArmDelineation = 22,

        GsmDelineation = 23,

        LtwDelineation = 24,

        WvrDelineation = 25,

        AlcDelineation = 26,

        CulDelineation = 27,

        #endregion BlueCrafter

        #region RedCrafter

        SoulOfTheCrafter = -91,

        RedCrafterToken = -100,

        GoblinCup = -99,

        CompetenceIV = -98,

        CunningIV = -97,

        CommandIV = -96,

        CompetenceV = -95,

        CunningV = -94,

        CommandV = -92,

        #endregion RedCrafter

        #region BlueGatherer

        BlueGatherToken = -200,

        BlueToken = BlueGatherToken,

        HiCordial = -199,

        CommercialSurvivalManual = -198,

        TrailblazersScarf = -197,

        TrailblazersVest = -196,

        TrailblazersWristguards = -195,

        TrailblazersSlops = -194,

        TrailblazersShoes = -193,

        BruteLeech = -192,

        CraneFly = -191,

        FiendWorm = -190,

        MagmaWorm = -189,

        RedBalloon = -188,

        CrownTrout = -187,

        CrownTroutHQ = -186,

        RetributionStaff = -185,

        RetributionStaffHQ = -184,

        ThiefBetta = -183,

        ThiefBettaHQ = -182,

        GoldsmithCrab = -181,

        GoldsmithCrabHQ = -180,

        Pterodactyl = -179,

        PterodactylHQ = -178,

        Eurhinosaur = -177,

        EurhinosaurHQ = -176,

        GemMarimo = -175,

        GemMarimoHQ = -174,

        Sphalerite = -173,

        SphaleriteHQ = -172,

        WindSilk = -171,

        CloudCottonBoll = -170,

        CloudCottonBollHQ = -169,

        DinosaurLeather = -168,

        RoyalMistletoe = -167,

        RoyalMistletoeHQ = -166,

        #endregion BlueGatherer

        #region RedGatherer

        RedGatherToken = -300,

        GoblinDice = -299,

        GuerdonIV = -298,

        GuileIV = -297,

        GraspIV = -296,

        GuerdonV = -295,

        GuileV = -294,

        GraspV = -293

        #endregion RedGatherer

#else

        #region BlueCrafter

        BlueCrafterToken = 0,

        CommercialEngineeringManual = 1,

        SweetCreamMilk = 2,

        StoneCheese = 3,

        HeavensEgg = 4,

        CarbonFiber = 5,

        LoaghtanFilet = 6,

        GoldenApple = 7,

        SolsticeGarlic = 8,

        MatureOliveOil = 9,

        PowderedMermanHorn = 10,

        BouillonCube = 11,

        BeanSauce = 12,

        BeanPaste = 13,

        KukuruPowder = 14,

        AdeptsHat = 15,

        AdeptsGown = 16,

        AdeptsGloves = 17,

        AdeptsHose = 18,

        AdeptsThighboots = 19,

        CrpDelineation = 20,

        BsmDelineation = 21,

        ArmDelineation = 22,

        GsmDelineation = 23,

        LtwDelineation = 24,

        WvrDelineation = 25,

        AlcDelineation = 26,

        CulDelineation = 27,

        #endregion BlueCrafter

        #region RedCrafter

        SoulOfTheCrafter = -100,

        RedCrafterToken = -99,

        GoblinCup = -98,

        CompetenceIV = -97,

        CunningIV = -96,

        CommandIV = -95,

        CompetenceV = -94,

        CunningV = -93,

        CommandV = -92,

        #endregion RedCrafter

        #region BlueGatherer

        BlueGatherToken = -200,

        BlueToken = BlueGatherToken,

        HiCordial = -199,

        CommercialSurvivalManual = -198,

        TrailblazersScarf = -197,

        TrailblazersVest = -196,

        TrailblazersWristguards = -195,

        TrailblazersSlops = -194,

        TrailblazersShoes = -193,

        BruteLeech = -192,

        CraneFly = -191,

        FiendWorm = -190,

        MagmaWorm = -189,

        RedBalloon = -188,

        CrownTrout = -187,

        CrownTroutHQ = -186,

        RetributionStaff = -185,

        RetributionStaffHQ = -184,

        ThiefBetta = -183,

        ThiefBettaHQ = -182,

        GoldsmithCrab = -181,

        GoldsmithCrabHQ = -180,

        Pterodactyl = -179,

        PterodactylHQ = -178,

        Eurhinosaur = -177,

        EurhinosaurHQ = -176,

        GemMarimo = -175,

        GemMarimoHQ = -174,

        Sphalerite = -173,

        SphaleriteHQ = -172,

        WindSilk = -171,

        CloudCottonBoll = -170,

        CloudCottonBollHQ = -169,

        DinosaurLeather = -168,

        RoyalMistletoe = -167,

        RoyalMistletoeHQ = -166,

        #endregion BlueGatherer

        #region RedGatherer

        RedGatherToken = -300,

        GoblinDice = -299,

        GuerdonIV = -298,

        GuileIV = -297,

        GraspIV = -296,

        GuerdonV = -295,

        GuileV = -294,

        GraspV = -293

        #endregion RedGatherer

#endif
    }
}