using ff14bot.Helpers;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;

namespace UltimaCR.Settings
{
    public class UltimaSettings : JsonSettings
    {
        [JsonIgnore]
        private static UltimaSettings _instance;
        public static UltimaSettings Instance
        {
            get { return _instance ?? (_instance = new UltimaSettings("UltimaSettings")); }
        }

        private UltimaSettings(string filename) : base(Path.Combine(CharacterSettingsDirectory, filename + ".json"))
        {
        }

        #region Ultima Settings

        #region Chocobo Settings

        [Setting, DefaultValue(false)]
        public bool SummonChocobo { get; set; }

        [Setting, DefaultValue(true)]
        public bool ChocoboFreeStance { get; set; }

        [Setting, DefaultValue(false)]
        public bool ChocoboDefenderStance { get; set; }

        [Setting, DefaultValue(false)]
        public bool ChocoboAttackerStance { get; set; }

        [Setting, DefaultValue(false)]
        public bool ChocoboHealerStance { get; set; }

        #endregion

        #region Rotation Settings

        #region Overlay Settings

        [Setting, DefaultValue(true)]
        public bool UseOverlay { get; set; }

        #endregion

        #region Rotation Combo Settings

        [Setting, DefaultValue(true)]
        public bool SmartTarget { get; set; }

        [Setting, DefaultValue(false)]
        public bool SingleTarget { get; set; }

        [Setting, DefaultValue(false)]
        public bool MultiTarget { get; set; }

        #endregion

        #region Rotation Hotkey Settings

        [Setting, DefaultValue(Keys.None)]
        public Keys HotKey { get; set; }

        [Setting, DefaultValue(ModifierKeys.None)]
        public ModifierKeys ModKey { get; set; }

        #endregion
        
        #endregion

        [Setting, DefaultValue(true)]
        public bool DefaultCRCheck { get; set; }

        [Setting, DefaultValue(false)]
        public bool QueueSpells { get; set; }

        [Setting, DefaultValue(false)]
        public bool RandomCastLocation { get; set; }

        #endregion

        #region Class Settings

        #region Arcanist Settings

        #region Archer Cross-Class

        [Setting, DefaultValue(true)]
        public bool ArcanistRagingStrikes { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistQuellingStrikes { get; set; }

        #endregion

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcanistCure { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistAero { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcanistProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistRaise { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcanistStoneskin { get; set; }

        #endregion

        #region Gladiator Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcanistFlash { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistConvalescence { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistProvoke { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistAwareness { get; set; }

        #endregion

        #region Lancer Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcanistKeenFlurry { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistInvigorate { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistBloodForBlood { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcanistForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistBloodbath { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistMercyStroke { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcanistFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistMantra { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcanistSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistBlizzardII { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcanistSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool ArcanistSummonPet { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcanistEmeraldCarbuncle { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcanistTopazCarbuncle { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcanistPhysick { get; set; }

        #endregion

        #region Archer Settings

        #region Arcanist Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcherPhysick { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherVirus { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherEyeForAnEye { get; set; }

        #endregion

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcherCure { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherRaise { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherStoneskin { get; set; }

        #endregion

        #region Gladiator Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcherSavageBlade { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherFlash { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherConvalescence { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherProvoke { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherAwareness { get; set; }

        #endregion

        #region Lancer Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcherFeint { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherKeenFlurry { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcherInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcherBloodForBlood { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcherForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherSkullSunder { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherFracture { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherBloodbath { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherMercyStroke { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcherFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherHaymaker { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcherInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherMantra { get; set; }

        #endregion

        #region Rogue Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcherShadeShift { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool ArcherSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool ArcherSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool ArcherBluntArrow { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcherMiserysEnd { get; set; }

        [Setting, DefaultValue(true)]
        public bool ArcherFlamingArrow { get; set; }

        #endregion

        #region Conjurer Settings

        #region Arcanist Cross-Class

        [Setting, DefaultValue(false)]
        public bool ConjurerRuin { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerPhysick { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerVirus { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerEyeForAnEye { get; set; }

        #endregion

        #region Archer Cross-Class

        [Setting, DefaultValue(false)]
        public bool ConjurerRagingStrikes { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerQuellingStrikes { get; set; }

        #endregion

        #region Gladiator Cross-Class

        [Setting, DefaultValue(false)]
        public bool ConjurerFlash { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerConvalescence { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerProvoke { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerAwareness { get; set; }

        #endregion

        #region Lancer Cross-Class

        [Setting, DefaultValue(false)]
        public bool ConjurerKeenFlurry { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerInvigorate { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerBloodForBlood { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool ConjurerForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerBloodbath { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerMercyStroke { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool ConjurerFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerMantra { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool ConjurerSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool ConjurerBlizzardII { get; set; }

        [Setting, DefaultValue(true)]
        public bool ConjurerSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool ConjurerRaise { get; set; }

        [Setting, DefaultValue(true)]
        public bool ConjurerProtect { get; set; }

        [Setting, DefaultValue(true)]
        public bool ConjurerStoneskin { get; set; }

        [Setting, DefaultValue(true)]
        public bool ConjurerStoneskinII { get; set; }

        [Setting, DefaultValue(true)]
        public bool ConjurerShroudOfSaints { get; set; }

        #endregion

        #region Gladiator Settings

        #region Arcanist Cross-Class

        [Setting, DefaultValue(false)]
        public bool GladiatorPhysick { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorVirus { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorEyeForAnEye { get; set; }

        #endregion

        #region Archer Cross-Class

        [Setting, DefaultValue(false)]
        public bool GladiatorStraightShot { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorRagingStrikes { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorVenomousBite { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorQuellingStrikes { get; set; }

        #endregion

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool GladiatorCure { get; set; }

        [Setting, DefaultValue(true)]
        public bool GladiatorProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorRaise { get; set; }

        [Setting, DefaultValue(true)]
        public bool GladiatorStoneskin { get; set; }

        #endregion

        #region Lancer Cross-Class

        [Setting, DefaultValue(false)]
        public bool GladiatorFeint { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorKeenFlurry { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorInvigorate { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorBloodForBlood { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool GladiatorForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorSkullSunder { get; set; }

        [Setting, DefaultValue(true)]
        public bool GladiatorFracture { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool GladiatorMercyStroke { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool GladiatorFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorHaymaker { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorMantra { get; set; }

        #endregion

        #region Rogue Cross-Class

        [Setting, DefaultValue(false)]
        public bool GladiatorShadeShift { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorGoad { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorDeathBlossom { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool GladiatorSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool GladiatorSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool GladiatorShieldSwipe { get; set; }

        #endregion

        #region Lancer Settings

        #region Arcanist Cross-Class

        [Setting, DefaultValue(false)]
        public bool LancerPhysick { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerVirus { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerEyeForAnEye { get; set; }

        #endregion

        #region Archer Cross-Class

        [Setting, DefaultValue(false)]
        public bool LancerStraightShot { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerRagingStrikes { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerVenomousBite { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerQuellingStrikes { get; set; }

        #endregion

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool LancerCure { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerRaise { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerStoneskin { get; set; }

        #endregion

        #region Gladiator Cross-Class

        [Setting, DefaultValue(false)]
        public bool LancerSavageBlade { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerFlash { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerConvalescence { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerProvoke { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerAwareness { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool LancerForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerSkullSunder { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerFracture { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool LancerMercyStroke { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool LancerFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerHaymaker { get; set; }

        [Setting, DefaultValue(true)]
        public bool LancerInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerMantra { get; set; }

        #endregion

        #region Rogue Cross-Class

        [Setting, DefaultValue(false)]
        public bool LancerShadeShift { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerGoad { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerDeathBlossom { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool LancerSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool LancerSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool LancerLegSweep { get; set; }

        #endregion

        #region Marauder Settings

        #region Arcanist Cross-Class

        [Setting, DefaultValue(false)]
        public bool MarauderPhysick { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderVirus { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderEyeForAnEye { get; set; }

        #endregion

        #region Archer Cross-Class

        [Setting, DefaultValue(false)]
        public bool MarauderStraightShot { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderRagingStrikes { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderVenomousBite { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderQuellingStrikes { get; set; }

        #endregion

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool MarauderCure { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderRaise { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderStoneskin { get; set; }

        #endregion

        #region Gladiator Cross-Class

        [Setting, DefaultValue(false)]
        public bool MarauderSavageBlade { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderFlash { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderConvalescence { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderProvoke { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderAwareness { get; set; }

        #endregion

        #region Lancer Cross-Class

        [Setting, DefaultValue(false)]
        public bool MarauderFeint { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderKeenFlurry { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderInvigorate { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderBloodForBlood { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool MarauderFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderHaymaker { get; set; }

        [Setting, DefaultValue(true)]
        public bool MarauderInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderMantra { get; set; }

        #endregion

        #region Rogue Cross-Class

        [Setting, DefaultValue(false)]
        public bool MarauderShadeShift { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderGoad { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderDeathBlossom { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool MarauderSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool MarauderSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool MarauderBrutalSwing { get; set; }

        [Setting, DefaultValue(true)]
        public bool MarauderMercyStroke { get; set; }

        #endregion

        #region Pugilist Settings

        #region Arcanist Cross-Class

        [Setting, DefaultValue(false)]
        public bool PugilistPhysick { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistVirus { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistEyeForAnEye { get; set; }

        #endregion

        #region Archer Cross-Class

        [Setting, DefaultValue(false)]
        public bool PugilistStraightShot { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistRagingStrikes { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistVenomousBite { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistQuellingStrikes { get; set; }

        #endregion

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool PugilistCure { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistRaise { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistStoneskin { get; set; }

        #endregion

        #region Gladiator Cross-Class

        [Setting, DefaultValue(false)]
        public bool PugilistSavageBlade { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistFlash { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistConvalescence { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistProvoke { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistAwareness { get; set; }

        #endregion

        #region Lancer Cross-Class

        [Setting, DefaultValue(false)]
        public bool PugilistFeint { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistKeenFlurry { get; set; }

        [Setting, DefaultValue(true)]
        public bool PugilistInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool PugilistBloodForBlood { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool PugilistForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistSkullSunder { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistFracture { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool PugilistMercyStroke { get; set; }

        #endregion

        #region Rogue Cross-Class

        [Setting, DefaultValue(false)]
        public bool PugilistShadeShift { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistGoad { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistDeathBlossom { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool PugilistSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool PugilistPerfectBalance { get; set; }

        [Setting, DefaultValue(true)]
        public bool PugilistFistsOfEarth { get; set; }

        [Setting, DefaultValue(false)]
        public bool PugilistFistsOfWind { get; set; }

        #endregion

        #region Rogue Settings

        #region Arcanist Cross-Class

        [Setting, DefaultValue(false)]
        public bool RoguePhysick { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueVirus { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueEyeForAnEye { get; set; }

        #endregion

        #region Archer Cross-Class

        [Setting, DefaultValue(false)]
        public bool RogueStraightShot { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueRagingStrikes { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueVenomousBite { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueQuellingStrikes { get; set; }

        #endregion

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool RogueCure { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueRaise { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueStoneskin { get; set; }

        #endregion

        #region Gladitor Cross-Class

        [Setting, DefaultValue(false)]
        public bool RogueSavageBlade { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueFlash { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueConvalescence { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueProvoke { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueAwareness { get; set; }

        #endregion

        #region Lancer Cross-Class

        [Setting, DefaultValue(false)]
        public bool RogueFeint { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueKeenFlurry { get; set; }

        [Setting, DefaultValue(true)]
        public bool RogueInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool RogueBloodForBlood { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool RogueForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueSkullSunder { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueFracture { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueBloodbath { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueMercyStroke { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool RogueFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueHaymaker { get; set; }

        [Setting, DefaultValue(true)]
        public bool RogueInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueMantra { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool RogueSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool RogueJugulate { get; set; }

        [Setting, DefaultValue(true)]
        public bool RogueAssassinate { get; set; }

        [Setting, DefaultValue(true)]
        public bool RogueDancingEdge { get; set; }

        [Setting, DefaultValue(false)]
        public bool RogueKissOfTheWasp { get; set; }

        [Setting, DefaultValue(true)]
        public bool RogueKissOfTheViper { get; set; }

        [Setting, DefaultValue(true)]
        public bool RogueGoad { get; set; }

        #endregion

        #region Thaumaturge Settings

        #region Arcanist Cross-Class

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeRuin { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgePhysick { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeVirus { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeEyeForAnEye { get; set; }

        #endregion

        #region Archer Cross-Class

        [Setting, DefaultValue(true)]
        public bool ThaumaturgeRagingStrikes { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeQuellingStrikes { get; set; }

        #endregion

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeCure { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeAero { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeRaise { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeStoneskin { get; set; }

        #endregion

        #region Gladiator Cross-Class

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeFlash { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeConvalescence { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeProvoke { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeAwareness { get; set; }

        #endregion

        #region Lancer Cross-Class

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeKeenFlurry { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeInvigorate { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeBloodForBlood { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeBloodbath { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeMercyStroke { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool ThaumaturgeMantra { get; set; }

        #endregion

        #endregion

        #endregion

        #region Job Settings

        #region Astrologian Settings

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool AstrologianCure { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianAero { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianClericStance { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool AstrologianRaise { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianStoneskin { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool AstrologianSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool AstrologianBlizzardII { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool AstrologianBenefic { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianBeneficII { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianAspectedBenefic { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianEssentialDignity { get; set; }

        [Setting, DefaultValue(true)]
        public bool AstrologianDraw { get; set; }

        #endregion

        #region Bard Settings

        #region Lancer Cross-Class

        [Setting, DefaultValue(true)]
        public bool BardFeint { get; set; }

        [Setting, DefaultValue(false)]
        public bool BardKeenFlurry { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardBloodForBlood { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool BardFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool BardSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool BardHaymaker { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool BardMantra { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool BardBluntArrow { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardMiserysEnd { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardTheWanderersMinuet { get; set; }

        [Setting, DefaultValue(true)]
        public bool BardFlamingArrow { get; set; }

        #endregion

        #region Black Mage Settings

        #region Arcanist Cross-Class

        [Setting, DefaultValue(false)]
        public bool BlackMageRuin { get; set; }

        [Setting, DefaultValue(false)]
        public bool BlackMagePhysick { get; set; }

        [Setting, DefaultValue(false)]
        public bool BlackMageVirus { get; set; }

        [Setting, DefaultValue(false)]
        public bool BlackMageEyeForAnEye { get; set; }

        #endregion

        #region Archer Cross-Class

        [Setting, DefaultValue(true)]
        public bool BlackMageRagingStrikes { get; set; }

        [Setting, DefaultValue(false)]
        public bool BlackMageHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool BlackMageQuellingStrikes { get; set; }

        #endregion

        #endregion

        #region Dark Knight Settings

        #region Gladiator Cross-Class

        [Setting, DefaultValue(false)]
        public bool DarkKnightSavageBlade { get; set; }

        [Setting, DefaultValue(false)]
        public bool DarkKnightFlash { get; set; }

        [Setting, DefaultValue(false)]
        public bool DarkKnightConvalescence { get; set; }

        [Setting, DefaultValue(false)]
        public bool DarkKnightProvoke { get; set; }

        [Setting, DefaultValue(false)]
        public bool DarkKnightAwareness { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool DarkKnightForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool DarkKnightSkullSunder { get; set; }

        [Setting, DefaultValue(false)]
        public bool DarkKnightFracture { get; set; }

        [Setting, DefaultValue(false)]
        public bool DarkKnightBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightMercyStroke { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool DarkKnightBloodWeapon { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightDarkArts { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightReprisal { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightDelirium { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightPlunge { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightLowBlow { get; set; }

        [Setting, DefaultValue(true)]
        public bool DarkKnightSaltedEarth { get; set; }

        #endregion

        #region Dragoon Settings

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool DragoonForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool DragoonSkullSunder { get; set; }

        [Setting, DefaultValue(false)]
        public bool DragoonFracture { get; set; }

        [Setting, DefaultValue(false)]
        public bool DragoonBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonMercyStroke { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool DragoonFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool DragoonSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool DragoonHaymaker { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool DragoonMantra { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool DragoonLegSweep { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonJump { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonSpineshatterDive { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonPowerSurge { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonDragonfireDive { get; set; }

        [Setting, DefaultValue(true)]
        public bool DragoonBattleLitany { get; set; }


        #endregion

        #region Machinist Settings

        #region Archer Cross-Class

        [Setting, DefaultValue(true)]
        public bool MachinistRagingStrikes { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool MachinistQuellingStrikes { get; set; }

        #endregion

        #region Lancer Cross-Class

        [Setting, DefaultValue(true)]
        public bool MachinistFeint { get; set; }

        [Setting, DefaultValue(false)]
        public bool MachinistKeenFlurry { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistBloodForBlood { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool MachinistSummonTurret { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistRook { get; set; }

        [Setting, DefaultValue(false)]
        public bool MachinistBishop { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistHeadGraze { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistHypercharge { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistBlank { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistHeartbreak { get; set; }

        [Setting, DefaultValue(true)]
        public bool MachinistGaussBarrel { get; set; }

        #endregion

        #region Monk Settings

        #region Lancer Cross-Class

        [Setting, DefaultValue(false)]
        public bool MonkFeint { get; set; }

        [Setting, DefaultValue(false)]
        public bool MonkKeenFlurry { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkBloodForBlood { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool MonkForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool MonkSkullSunder { get; set; }

        [Setting, DefaultValue(false)]
        public bool MonkFracture { get; set; }

        [Setting, DefaultValue(false)]
        public bool MonkBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkMercyStroke { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool MonkShoulderTackle { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkPerfectBalance { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkFistsOfEarth { get; set; }

        [Setting, DefaultValue(false)]
        public bool MonkFistsOfWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool MonkFistsOfFire { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkMeditation { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkTheForbiddenChakra { get; set; }

        [Setting, DefaultValue(true)]
        public bool MonkElixirField { get; set; }

        #endregion

        #region Ninja Settings

        #region Lancer Cross-Class

        [Setting, DefaultValue(false)]
        public bool NinjaFeint { get; set; }

        [Setting, DefaultValue(false)]
        public bool NinjaKeenFlurry { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaInvigorate { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaBloodForBlood { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool NinjaFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool NinjaSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool NinjaHaymaker { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool NinjaMantra { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool NinjaShukuchi { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaJugulate { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaAssassinate { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaRaiton { get; set; }

        [Setting, DefaultValue(false)]
        public bool NinjaFumaShuriken { get; set; }

        [Setting, DefaultValue(false)]
        public bool NinjaKissOfTheWasp { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaKissOfTheViper { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaDancingEdge { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaGoad { get; set; }

        [Setting, DefaultValue(true)]
        public bool NinjaDreamWithinADream { get; set; }

        #endregion

        #region Paladin Settings

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool PaladinCure { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool PaladinRaise { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinStoneskin { get; set; }

        #endregion

        #region Marauder Cross-Class

        [Setting, DefaultValue(false)]
        public bool PaladinForesight { get; set; }

        [Setting, DefaultValue(false)]
        public bool PaladinSkullSunder { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinFracture { get; set; }

        [Setting, DefaultValue(false)]
        public bool PaladinBloodbath { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinMercyStroke { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool PaladinShieldSwipe { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinSpiritsWithin { get; set; }

        [Setting, DefaultValue(true)]
        public bool PaladinSwordOath { get; set; }

        [Setting, DefaultValue(false)]
        public bool PaladinShieldOath { get; set; }
        
        #endregion

        #region Scholar Settings

        #region Conjurer Cross-Class

        [Setting, DefaultValue(false)]
        public bool ScholarCure { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarAero { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarClericStance { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarProtect { get; set; }

        [Setting, DefaultValue(false)]
        public bool ScholarRaise { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarStoneskin { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool ScholarSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool ScholarBlizzardII { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool ScholarSummonPet { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarEos { get; set; }

        [Setting, DefaultValue(false)]
        public bool ScholarSelene { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarPhysick { get; set; }

        [Setting, DefaultValue(true)]
        public bool ScholarAdloquium { get; set; }

        #endregion

        #region Summoner Settings

        #region Archer Cross-Class

        [Setting, DefaultValue(true)]
        public bool SummonerRagingStrikes { get; set; }

        [Setting, DefaultValue(false)]
        public bool SummonerHawksEye { get; set; }

        [Setting, DefaultValue(false)]
        public bool SummonerQuellingStrikes { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool SummonerSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool SummonerBlizzardII { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerSwiftcast { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool SummonerSummonPet { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerGaruda { get; set; }

        [Setting, DefaultValue(false)]
        public bool SummonerTitan { get; set; }

        [Setting, DefaultValue(false)]
        public bool SummonerIfrit { get; set; }

        [Setting, DefaultValue(true)]
        public bool SummonerPhysick { get; set; }

        #endregion

        #region Warrior Settings

        #region Gladiator Cross-Class

        [Setting, DefaultValue(false)]
        public bool WarriorSavageBlade { get; set; }

        [Setting, DefaultValue(false)]
        public bool WarriorFlash { get; set; }

        [Setting, DefaultValue(false)]
        public bool WarriorConvalescence { get; set; }

        [Setting, DefaultValue(false)]
        public bool WarriorProvoke { get; set; }

        [Setting, DefaultValue(false)]
        public bool WarriorAwareness { get; set; }

        #endregion

        #region Pugilist Cross-Class

        [Setting, DefaultValue(false)]
        public bool WarriorFeatherfoot { get; set; }

        [Setting, DefaultValue(false)]
        public bool WarriorSecondWind { get; set; }

        [Setting, DefaultValue(false)]
        public bool WarriorHaymaker { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorInternalRelease { get; set; }

        [Setting, DefaultValue(false)]
        public bool WarriorMantra { get; set; }

        #endregion

        [Setting, DefaultValue(true)]
        public bool WarriorBrutalSwing { get; set; }

        [Setting, DefaultValue(true)]
        public bool WarriorMercyStroke { get; set; }

        #endregion

        #region White Mage Settings

        #region Arcanist Cross-Class

        [Setting, DefaultValue(false)]
        public bool WhiteMageRuin { get; set; }

        [Setting, DefaultValue(false)]
        public bool WhiteMagePhysick { get; set; }

        [Setting, DefaultValue(false)]
        public bool WhiteMageVirus { get; set; }

        [Setting, DefaultValue(false)]
        public bool WhiteMageEyeForAnEye { get; set; }

        #endregion

        #region Thaumaturge Cross-Class

        [Setting, DefaultValue(false)]
        public bool WhiteMageSurecast { get; set; }

        [Setting, DefaultValue(false)]
        public bool WhiteMageBlizzardII { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageSwiftcast { get; set; }

        #endregion


        [Setting, DefaultValue(true)]
        public bool WhiteMageRaise { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageBenediction { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageTetragrammaton { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageShroudOfSaints { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMagePresenceOfMind { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageDivineSeal { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageProtect { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageStoneskin { get; set; }

        [Setting, DefaultValue(true)]
        public bool WhiteMageStoneskinII { get; set; }

        #endregion

        #endregion
    }
}