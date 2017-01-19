using ff14bot.Managers;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UltimaCR.Properties;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace UltimaCR.Settings.Forms
{
    public partial class UltimaForm : Form
    {
        #region Images

        private Image UltimaBannerImage = Resources.UltimaBannerImage;
        private Image UltimaDonateImage = Resources.UltimaDonateImage;

        private void UltimaDonateBox_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=3EN6H5PB7W7QW&lc=US&item_name=Ultima%20Combat%20Routine&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_LG%2egif%3aNonHosted");
        }

        #endregion

        #region Mouse Drag/Move Form

        private const int WmNclbuttondown = 0xA1;
        private const int HtCaption = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void UltimaForm_MouseDrag(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
        }

        #endregion

        public static readonly RotationOverlay Overlay = new RotationOverlay();

        public UltimaForm()
        {
            InitializeComponent();
        }

        private void UltimaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Ultima.UltSettings.Save();
            RegisterHotkeys();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UltimaForm_Load(object sender, EventArgs e)
        {
            #region Ultima Settings

            #region Images

            UltimaBanner.Image = UltimaBannerImage;
            UltimaDonateBox.Image = UltimaDonateImage;

            #endregion

            #region Chocobo Settings

            SummonChocobo.Checked = Ultima.UltSettings.SummonChocobo;
            if (Ultima.UltSettings.ChocoboFreeStance)
            {
                ChocoboStanceCombo.Text = @"Free Stance";
            }

            if (Ultima.UltSettings.ChocoboDefenderStance)
            {
                ChocoboStanceCombo.Text = @"Defender Stance";
            }

            if (Ultima.UltSettings.ChocoboAttackerStance)
            {
                ChocoboStanceCombo.Text = @"Attacker Stance";
            }

            if (Ultima.UltSettings.ChocoboHealerStance)
            {
                ChocoboStanceCombo.Text = @"Healer Stance";
            }

            #endregion

            #region Rotation Settings

            #region Overlay Settings

            OverlayCheck.Checked = Ultima.UltSettings.UseOverlay;

            #endregion

            #region Rotation Combo Settings

            if (Ultima.UltSettings.SmartTarget)
            {
                RotationModeCombo.Text = @"Smart Target";
            }

            if (Ultima.UltSettings.SingleTarget)
            {
                RotationModeCombo.Text = @"Single Target";
            }

            if (Ultima.UltSettings.MultiTarget)
            {
                RotationModeCombo.Text = @"Multi Target";
            }
            Overlay.UpdateLabel(RotationModeCombo.Text);

            #endregion

            #region Rotation Hotkey Settings

            UnregisterHotkeys();

            #region Rotation Modifier Key Settings

            if (Ultima.UltSettings.ModKey == System.Windows.Input.ModifierKeys.None)
            {
                RotationModifierCombo.Text = @"None";
            }

            if (Ultima.UltSettings.ModKey == System.Windows.Input.ModifierKeys.Alt)
            {
                RotationModifierCombo.Text = @"Alt";
            }

            if (Ultima.UltSettings.ModKey == System.Windows.Input.ModifierKeys.Control)
            {
                RotationModifierCombo.Text = @"Control";
            }

            if (Ultima.UltSettings.ModKey == System.Windows.Input.ModifierKeys.Shift)
            {
                RotationModifierCombo.Text = @"Shift";
            }

            if (Ultima.UltSettings.ModKey == System.Windows.Input.ModifierKeys.Windows)
            {
                RotationModifierCombo.Text = @"Windows";
            }

            #endregion

            #region Rotation Hotkey Settings

            if (Ultima.UltSettings.HotKey == Keys.None)
            {
                RotationHotkeyCombo.Text = @"None";
            }

            if (Ultima.UltSettings.HotKey == Keys.LButton)
            {
                RotationHotkeyCombo.Text = @"Left Mouse";
            }

            if (Ultima.UltSettings.HotKey == Keys.MButton)
            {
                RotationHotkeyCombo.Text = @"Middle Mouse";
            }

            if (Ultima.UltSettings.HotKey == Keys.RButton)
            {
                RotationHotkeyCombo.Text = @"Right Mouse";
            }

            if (Ultima.UltSettings.HotKey == Keys.XButton1)
            {
                RotationHotkeyCombo.Text = @"Mouse 1";
            }

            if (Ultima.UltSettings.HotKey == Keys.XButton2)
            {
                RotationHotkeyCombo.Text = @"Mouse 2";
            }

            if (Ultima.UltSettings.HotKey == Keys.Space)
            {
                RotationHotkeyCombo.Text = @"Space";
            }

            if (Ultima.UltSettings.HotKey == Keys.Oemtilde)
            {
                RotationHotkeyCombo.Text = @"Tilde";
            }

            if (Ultima.UltSettings.HotKey == Keys.Q)
            {
                RotationHotkeyCombo.Text = @"Q";
            }

            if (Ultima.UltSettings.HotKey == Keys.E)
            {
                RotationHotkeyCombo.Text = @"E";
            }

            if (Ultima.UltSettings.HotKey == Keys.Z)
            {
                RotationHotkeyCombo.Text = @"Z";
            }

            if (Ultima.UltSettings.HotKey == Keys.X)
            {
                RotationHotkeyCombo.Text = @"X";
            }

            if (Ultima.UltSettings.HotKey == Keys.C)
            {
                RotationHotkeyCombo.Text = @"C";
            }

            #endregion

            #endregion

            #endregion

            DefaultCRCheck.Checked = Ultima.UltSettings.DefaultCRCheck;
            QueueSpells.Checked = Ultima.UltSettings.QueueSpells;
            RandomCastLocation.Checked = Ultima.UltSettings.RandomCastLocation;

            #endregion

            #region Class Settings

            #region Arcanist Settings

            #region Archer Cross-Class

            ArcanistRagingStrikes.Checked = Ultima.UltSettings.ArcanistRagingStrikes;
            ArcanistHawksEye.Checked = Ultima.UltSettings.ArcanistHawksEye;
            ArcanistQuellingStrikes.Checked = Ultima.UltSettings.ArcanistQuellingStrikes;

            #endregion

            #region Conjurer Cross-Class

            ArcanistCure.Checked = Ultima.UltSettings.ArcanistCure;
            ArcanistAero.Checked = Ultima.UltSettings.ArcanistAero;
            ArcanistProtect.Checked = Ultima.UltSettings.ArcanistProtect;
            ArcanistRaise.Checked = Ultima.UltSettings.ArcanistRaise;
            ArcanistStoneskin.Checked = Ultima.UltSettings.ArcanistStoneskin;

            #endregion

            #region Gladiator Cross-Class

            ArcanistFlash.Checked = Ultima.UltSettings.ArcanistFlash;
            ArcanistConvalescence.Checked = Ultima.UltSettings.ArcanistConvalescence;
            ArcanistProvoke.Checked = Ultima.UltSettings.ArcanistProvoke;
            ArcanistAwareness.Checked = Ultima.UltSettings.ArcanistAwareness;

            #endregion

            #region Lancer Cross-Class

            ArcanistKeenFlurry.Checked = Ultima.UltSettings.ArcanistKeenFlurry;
            ArcanistInvigorate.Checked = Ultima.UltSettings.ArcanistInvigorate;
            ArcanistBloodForBlood.Checked = Ultima.UltSettings.ArcanistBloodForBlood;

            #endregion

            #region Marauder Cross-Class

            ArcanistForesight.Checked = Ultima.UltSettings.ArcanistForesight;
            ArcanistBloodbath.Checked = Ultima.UltSettings.ArcanistBloodbath;
            ArcanistMercyStroke.Checked = Ultima.UltSettings.ArcanistMercyStroke;

            #endregion

            #region Pugilist Cross-Class

            ArcanistFeatherfoot.Checked = Ultima.UltSettings.ArcanistFeatherfoot;
            ArcanistSecondWind.Checked = Ultima.UltSettings.ArcanistSecondWind;
            ArcanistInternalRelease.Checked = Ultima.UltSettings.ArcanistInternalRelease;
            ArcanistMantra.Checked = Ultima.UltSettings.ArcanistMantra;

            #endregion

            #region Thaumaturge Cross-Class

            ArcanistSurecast.Checked = Ultima.UltSettings.ArcanistSurecast;
            ArcanistBlizzardII.Checked = Ultima.UltSettings.ArcanistBlizzardII;
            ArcanistSwiftcast.Checked = Ultima.UltSettings.ArcanistSwiftcast;

            #endregion

            ArcanistSummonPet.Checked = Ultima.UltSettings.ArcanistSummonPet;
            if (Ultima.UltSettings.ArcanistEmeraldCarbuncle)
            {
                ArcanistSummonPetCombo.Text = @"Emerald Carbuncle";
            }
            if (Ultima.UltSettings.ArcanistTopazCarbuncle)
            {
                ArcanistSummonPetCombo.Text = @"Topaz Carbuncle";
            }
            ArcanistPhysick.Checked = Ultima.UltSettings.ArcanistPhysick;

            #endregion

            #region Archer Settings

            #region Arcanist Cross-Class

            ArcherPhysick.Checked = Ultima.UltSettings.ArcherPhysick;
            ArcherVirus.Checked = Ultima.UltSettings.ArcherVirus;
            ArcherEyeForAnEye.Checked = Ultima.UltSettings.ArcherEyeForAnEye;

            #endregion

            #region Conjurer Cross-Class

            ArcherCure.Checked = Ultima.UltSettings.ArcherCure;
            ArcherProtect.Checked = Ultima.UltSettings.ArcherProtect;
            ArcherRaise.Checked = Ultima.UltSettings.ArcherRaise;
            ArcherStoneskin.Checked = Ultima.UltSettings.ArcherStoneskin;

            #endregion

            #region Gladiator Cross-Class

            ArcherSavageBlade.Checked = Ultima.UltSettings.ArcherSavageBlade;
            ArcherFlash.Checked = Ultima.UltSettings.ArcherFlash;
            ArcherConvalescence.Checked = Ultima.UltSettings.ArcherConvalescence;
            ArcherProvoke.Checked = Ultima.UltSettings.ArcherProvoke;
            ArcherAwareness.Checked = Ultima.UltSettings.ArcherAwareness;

            #endregion

            #region Lancer Cross-Class

            ArcherFeint.Checked = Ultima.UltSettings.ArcherFeint;
            ArcherKeenFlurry.Checked = Ultima.UltSettings.ArcherKeenFlurry;
            ArcherInvigorate.Checked = Ultima.UltSettings.ArcherInvigorate;
            ArcherBloodForBlood.Checked = Ultima.UltSettings.ArcherBloodForBlood;

            #endregion

            #region Marauder Cross-Class

            ArcherForesight.Checked = Ultima.UltSettings.ArcherForesight;
            ArcherSkullSunder.Checked = Ultima.UltSettings.ArcherSkullSunder;
            ArcherFracture.Checked = Ultima.UltSettings.ArcherFracture;
            ArcherBloodbath.Checked = Ultima.UltSettings.ArcherBloodbath;
            ArcherMercyStroke.Checked = Ultima.UltSettings.ArcherMercyStroke;

            #endregion

            #region Pugilist Cross-Class

            ArcherFeatherfoot.Checked = Ultima.UltSettings.ArcherFeatherfoot;
            ArcherSecondWind.Checked = Ultima.UltSettings.ArcherSecondWind;
            ArcherHaymaker.Checked = Ultima.UltSettings.ArcherHaymaker;
            ArcherInternalRelease.Checked = Ultima.UltSettings.ArcherInternalRelease;
            ArcherMantra.Checked = Ultima.UltSettings.ArcherMantra;

            #endregion

            #region Rogue Cross-Class

            ArcherShadeShift.Checked = Ultima.UltSettings.ArcherShadeShift;

            #endregion

            #region Thaumaturge Cross-Class

            ArcherSurecast.Checked = Ultima.UltSettings.ArcherSurecast;
            ArcherSwiftcast.Checked = Ultima.UltSettings.ArcherSwiftcast;

            #endregion

            ArcherBluntArrow.Checked = Ultima.UltSettings.ArcherBluntArrow;
            ArcherMiserysEnd.Checked = Ultima.UltSettings.ArcherMiserysEnd;
            ArcherFlamingArrow.Checked = Ultima.UltSettings.ArcherFlamingArrow;

            #endregion

            #region Conjurer Settings

            #region Arcanist Cross-Class

            ConjurerRuin.Checked = Ultima.UltSettings.ConjurerRuin;
            ConjurerPhysick.Checked = Ultima.UltSettings.ConjurerPhysick;
            ConjurerVirus.Checked = Ultima.UltSettings.ConjurerVirus;
            ConjurerEyeForAnEye.Checked = Ultima.UltSettings.ConjurerEyeForAnEye;

            #endregion

            #region Archer Cross-Class

            ConjurerRagingStrikes.Checked = Ultima.UltSettings.ConjurerRagingStrikes;
            ConjurerHawksEye.Checked = Ultima.UltSettings.ConjurerHawksEye;
            ConjurerQuellingStrikes.Checked = Ultima.UltSettings.ConjurerQuellingStrikes;

            #endregion

            #region Gladiator Cross-Class

            ConjurerFlash.Checked = Ultima.UltSettings.ConjurerFlash;
            ConjurerConvalescence.Checked = Ultima.UltSettings.ConjurerConvalescence;
            ConjurerProvoke.Checked = Ultima.UltSettings.ConjurerProvoke;
            ConjurerAwareness.Checked = Ultima.UltSettings.ConjurerAwareness;

            #endregion

            #region Lancer Cross-Class

            ConjurerKeenFlurry.Checked = Ultima.UltSettings.ConjurerKeenFlurry;
            ConjurerInvigorate.Checked = Ultima.UltSettings.ConjurerInvigorate;
            ConjurerBloodForBlood.Checked = Ultima.UltSettings.ConjurerBloodForBlood;

            #endregion

            #region Marauder Cross-Class

            ConjurerForesight.Checked = Ultima.UltSettings.ConjurerForesight;
            ConjurerBloodbath.Checked = Ultima.UltSettings.ConjurerBloodbath;
            ConjurerMercyStroke.Checked = Ultima.UltSettings.ConjurerMercyStroke;

            #endregion

            #region Pugilist Cross-Class

            ConjurerFeatherfoot.Checked = Ultima.UltSettings.ConjurerFeatherfoot;
            ConjurerSecondWind.Checked = Ultima.UltSettings.ConjurerSecondWind;
            ConjurerInternalRelease.Checked = Ultima.UltSettings.ConjurerInternalRelease;
            ConjurerMantra.Checked = Ultima.UltSettings.ConjurerMantra;

            #endregion

            #region Thaumaturge Cross-Class

            ConjurerSurecast.Checked = Ultima.UltSettings.ConjurerSurecast;
            ConjurerBlizzardII.Checked = Ultima.UltSettings.ConjurerBlizzardII;
            ConjurerSwiftcast.Checked = Ultima.UltSettings.ConjurerSwiftcast;

            #endregion

            ConjurerRaise.Checked = Ultima.UltSettings.ConjurerRaise;
            ConjurerProtect.Checked = Ultima.UltSettings.ConjurerProtect;
            ConjurerStoneskin.Checked = Ultima.UltSettings.ConjurerStoneskin;
            ConjurerStoneskinII.Checked = Ultima.UltSettings.ConjurerStoneskinII;
            ConjurerShroudOfSaints.Checked = Ultima.UltSettings.ConjurerShroudOfSaints;

            #endregion

            #region Gladiator Settings

            #region Arcanist Cross-Class

            GladiatorPhysick.Checked = Ultima.UltSettings.GladiatorPhysick;
            GladiatorVirus.Checked = Ultima.UltSettings.GladiatorVirus;
            GladiatorEyeForAnEye.Checked = Ultima.UltSettings.GladiatorEyeForAnEye;

            #endregion

            #region Archer Cross-Class

            GladiatorStraightShot.Checked = Ultima.UltSettings.GladiatorStraightShot;
            GladiatorRagingStrikes.Checked = Ultima.UltSettings.GladiatorRagingStrikes;
            GladiatorVenomousBite.Checked = Ultima.UltSettings.GladiatorVenomousBite;
            GladiatorHawksEye.Checked = Ultima.UltSettings.GladiatorHawksEye;
            GladiatorQuellingStrikes.Checked = Ultima.UltSettings.GladiatorQuellingStrikes;

            #endregion

            #region Conjurer Cross-Class

            GladiatorCure.Checked = Ultima.UltSettings.GladiatorCure;
            GladiatorProtect.Checked = Ultima.UltSettings.GladiatorProtect;
            GladiatorRaise.Checked = Ultima.UltSettings.GladiatorRaise;
            GladiatorStoneskin.Checked = Ultima.UltSettings.GladiatorStoneskin;

            #endregion

            #region Lancer Cross-Class

            GladiatorFeint.Checked = Ultima.UltSettings.GladiatorFeint;
            GladiatorKeenFlurry.Checked = Ultima.UltSettings.GladiatorKeenFlurry;
            GladiatorInvigorate.Checked = Ultima.UltSettings.GladiatorInvigorate;
            GladiatorBloodForBlood.Checked = Ultima.UltSettings.GladiatorBloodForBlood;

            #endregion

            #region Marauder Cross-Class

            GladiatorForesight.Checked = Ultima.UltSettings.GladiatorForesight;
            GladiatorSkullSunder.Checked = Ultima.UltSettings.GladiatorSkullSunder;
            GladiatorFracture.Checked = Ultima.UltSettings.GladiatorFracture;
            GladiatorBloodbath.Checked = Ultima.UltSettings.GladiatorBloodbath;
            GladiatorMercyStroke.Checked = Ultima.UltSettings.GladiatorMercyStroke;

            #endregion

            #region Pugilist Cross-Class

            GladiatorFeatherfoot.Checked = Ultima.UltSettings.GladiatorFeatherfoot;
            GladiatorSecondWind.Checked = Ultima.UltSettings.GladiatorSecondWind;
            GladiatorHaymaker.Checked = Ultima.UltSettings.GladiatorHaymaker;
            GladiatorInternalRelease.Checked = Ultima.UltSettings.GladiatorInternalRelease;
            GladiatorMantra.Checked = Ultima.UltSettings.GladiatorMantra;

            #endregion

            #region Rogue Cross-Class

            GladiatorShadeShift.Checked = Ultima.UltSettings.GladiatorShadeShift;
            GladiatorGoad.Checked = Ultima.UltSettings.GladiatorGoad;
            GladiatorDeathBlossom.Checked = Ultima.UltSettings.GladiatorDeathBlossom;

            #endregion

            #region Thaumaturge Cross-Class

            GladiatorSurecast.Checked = Ultima.UltSettings.GladiatorSurecast;
            GladiatorSwiftcast.Checked = Ultima.UltSettings.GladiatorSwiftcast;

            #endregion

            GladiatorShieldSwipe.Checked = Ultima.UltSettings.GladiatorShieldSwipe;

            #endregion

            #region Lancer Settings

            #region Arcanist Cross-Class

            LancerPhysick.Checked = Ultima.UltSettings.LancerPhysick;
            LancerVirus.Checked = Ultima.UltSettings.LancerVirus;
            LancerEyeForAnEye.Checked = Ultima.UltSettings.LancerEyeForAnEye;

            #endregion

            #region Archer Cross-Class

            LancerStraightShot.Checked = Ultima.UltSettings.LancerStraightShot;
            LancerRagingStrikes.Checked = Ultima.UltSettings.LancerRagingStrikes;
            LancerVenomousBite.Checked = Ultima.UltSettings.LancerVenomousBite;
            LancerHawksEye.Checked = Ultima.UltSettings.LancerHawksEye;
            LancerQuellingStrikes.Checked = Ultima.UltSettings.LancerQuellingStrikes;

            #endregion

            #region Conjurer Cross-Class

            LancerCure.Checked = Ultima.UltSettings.LancerCure;
            LancerProtect.Checked = Ultima.UltSettings.LancerProtect;
            LancerRaise.Checked = Ultima.UltSettings.LancerRaise;
            LancerStoneskin.Checked = Ultima.UltSettings.LancerStoneskin;

            #endregion

            #region Gladiator Cross-Class

            LancerSavageBlade.Checked = Ultima.UltSettings.LancerSavageBlade;
            LancerFlash.Checked = Ultima.UltSettings.LancerFlash;
            LancerConvalescence.Checked = Ultima.UltSettings.LancerConvalescence;
            LancerProvoke.Checked = Ultima.UltSettings.LancerProvoke;
            LancerAwareness.Checked = Ultima.UltSettings.LancerAwareness;

            #endregion

            #region Marauder Cross-Class

            LancerForesight.Checked = Ultima.UltSettings.LancerForesight;
            LancerSkullSunder.Checked = Ultima.UltSettings.LancerSkullSunder;
            LancerFracture.Checked = Ultima.UltSettings.LancerFracture;
            LancerBloodbath.Checked = Ultima.UltSettings.LancerBloodbath;
            LancerMercyStroke.Checked = Ultima.UltSettings.LancerMercyStroke;

            #endregion

            #region Pugilist Cross-Class

            LancerFeatherfoot.Checked = Ultima.UltSettings.LancerFeatherfoot;
            LancerSecondWind.Checked = Ultima.UltSettings.LancerSecondWind;
            LancerHaymaker.Checked = Ultima.UltSettings.LancerHaymaker;
            LancerInternalRelease.Checked = Ultima.UltSettings.LancerInternalRelease;
            LancerMantra.Checked = Ultima.UltSettings.LancerMantra;

            #endregion

            #region Rogue Cross-Class

            LancerShadeShift.Checked = Ultima.UltSettings.LancerShadeShift;
            LancerGoad.Checked = Ultima.UltSettings.LancerGoad;
            LancerDeathBlossom.Checked = Ultima.UltSettings.LancerDeathBlossom;

            #endregion

            #region Thaumaturge Cross-Class

            LancerSurecast.Checked = Ultima.UltSettings.LancerSurecast;
            LancerSwiftcast.Checked = Ultima.UltSettings.LancerSwiftcast;

            #endregion

            LancerLegSweep.Checked = Ultima.UltSettings.LancerLegSweep;

            #endregion

            #region Marauder Settings

            #region Arcanist Cross-Class

            MarauderPhysick.Checked = Ultima.UltSettings.MarauderPhysick;
            MarauderVirus.Checked = Ultima.UltSettings.MarauderVirus;
            MarauderEyeForAnEye.Checked = Ultima.UltSettings.MarauderEyeForAnEye;

            #endregion

            #region Archer Cross-Class

            MarauderStraightShot.Checked = Ultima.UltSettings.MarauderStraightShot;
            MarauderRagingStrikes.Checked = Ultima.UltSettings.MarauderRagingStrikes;
            MarauderVenomousBite.Checked = Ultima.UltSettings.MarauderVenomousBite;
            MarauderHawksEye.Checked = Ultima.UltSettings.MarauderHawksEye;
            MarauderQuellingStrikes.Checked = Ultima.UltSettings.MarauderQuellingStrikes;

            #endregion

            #region Conjurer Cross-Class

            MarauderCure.Checked = Ultima.UltSettings.MarauderCure;
            MarauderProtect.Checked = Ultima.UltSettings.MarauderProtect;
            MarauderRaise.Checked = Ultima.UltSettings.MarauderRaise;
            MarauderStoneskin.Checked = Ultima.UltSettings.MarauderStoneskin;

            #endregion

            #region Gladiator Cross-Class

            MarauderSavageBlade.Checked = Ultima.UltSettings.MarauderSavageBlade;
            MarauderFlash.Checked = Ultima.UltSettings.MarauderFlash;
            MarauderConvalescence.Checked = Ultima.UltSettings.MarauderConvalescence;
            MarauderProvoke.Checked = Ultima.UltSettings.MarauderProvoke;
            MarauderAwareness.Checked = Ultima.UltSettings.MarauderAwareness;

            #endregion

            #region Lancer Cross-Class

            MarauderFeint.Checked = Ultima.UltSettings.MarauderFeint;
            MarauderKeenFlurry.Checked = Ultima.UltSettings.MarauderKeenFlurry;
            MarauderInvigorate.Checked = Ultima.UltSettings.MarauderInvigorate;
            MarauderBloodForBlood.Checked = Ultima.UltSettings.MarauderBloodForBlood;

            #endregion

            #region Pugilist Cross-Class

            MarauderFeatherfoot.Checked = Ultima.UltSettings.MarauderFeatherfoot;
            MarauderSecondWind.Checked = Ultima.UltSettings.MarauderSecondWind;
            MarauderHaymaker.Checked = Ultima.UltSettings.MarauderHaymaker;
            MarauderInternalRelease.Checked = Ultima.UltSettings.MarauderInternalRelease;
            MarauderMantra.Checked = Ultima.UltSettings.MarauderMantra;

            #endregion

            #region Rogue Cross-Class

            MarauderShadeShift.Checked = Ultima.UltSettings.MarauderShadeShift;
            MarauderGoad.Checked = Ultima.UltSettings.MarauderGoad;
            MarauderDeathBlossom.Checked = Ultima.UltSettings.MarauderDeathBlossom;

            #endregion

            #region Thaumaturge Cross-Class

            MarauderSurecast.Checked = Ultima.UltSettings.MarauderSurecast;
            MarauderSwiftcast.Checked = Ultima.UltSettings.MarauderSwiftcast;

            #endregion

            MarauderBrutalSwing.Checked = Ultima.UltSettings.MarauderBrutalSwing;
            MarauderMercyStroke.Checked = Ultima.UltSettings.MarauderMercyStroke;

            #endregion

            #region Pugilist Settings

            #region Arcanist Cross-Class

            PugilistPhysick.Checked = Ultima.UltSettings.PugilistPhysick;
            PugilistVirus.Checked = Ultima.UltSettings.PugilistVirus;
            PugilistEyeForAnEye.Checked = Ultima.UltSettings.PugilistEyeForAnEye;

            #endregion

            #region Archer Cross-Class

            PugilistStraightShot.Checked = Ultima.UltSettings.PugilistStraightShot;
            PugilistRagingStrikes.Checked = Ultima.UltSettings.PugilistRagingStrikes;
            PugilistVenomousBite.Checked = Ultima.UltSettings.PugilistVenomousBite;
            PugilistHawksEye.Checked = Ultima.UltSettings.PugilistHawksEye;
            PugilistQuellingStrikes.Checked = Ultima.UltSettings.PugilistQuellingStrikes;

            #endregion

            #region Conjurer Cross-Class

            PugilistCure.Checked = Ultima.UltSettings.PugilistCure;
            PugilistProtect.Checked = Ultima.UltSettings.PugilistProtect;
            PugilistRaise.Checked = Ultima.UltSettings.PugilistRaise;
            PugilistStoneskin.Checked = Ultima.UltSettings.PugilistStoneskin;

            #endregion

            #region Gladiator Cross-Class

            PugilistSavageBlade.Checked = Ultima.UltSettings.PugilistSavageBlade;
            PugilistFlash.Checked = Ultima.UltSettings.PugilistFlash;
            PugilistConvalescence.Checked = Ultima.UltSettings.PugilistConvalescence;
            PugilistProvoke.Checked = Ultima.UltSettings.PugilistProvoke;
            PugilistAwareness.Checked = Ultima.UltSettings.PugilistAwareness;

            #endregion

            #region Lancer Cross-Class

            PugilistFeint.Checked = Ultima.UltSettings.PugilistFeint;
            PugilistKeenFlurry.Checked = Ultima.UltSettings.PugilistKeenFlurry;
            PugilistInvigorate.Checked = Ultima.UltSettings.PugilistInvigorate;
            PugilistBloodForBlood.Checked = Ultima.UltSettings.PugilistBloodForBlood;

            #endregion

            #region Marauder Cross-Class

            PugilistForesight.Checked = Ultima.UltSettings.PugilistForesight;
            PugilistSkullSunder.Checked = Ultima.UltSettings.PugilistSkullSunder;
            PugilistFracture.Checked = Ultima.UltSettings.PugilistFracture;
            PugilistBloodbath.Checked = Ultima.UltSettings.PugilistBloodbath;
            PugilistMercyStroke.Checked = Ultima.UltSettings.PugilistMercyStroke;

            #endregion

            #region Rogue Cross-CLass

            PugilistShadeShift.Checked = Ultima.UltSettings.PugilistShadeShift;
            PugilistGoad.Checked = Ultima.UltSettings.PugilistGoad;
            PugilistDeathBlossom.Checked = Ultima.UltSettings.PugilistDeathBlossom;

            #endregion

            #region Thaumaturge Cross-Class

            PugilistSurecast.Checked = Ultima.UltSettings.PugilistSurecast;
            PugilistSwiftcast.Checked = Ultima.UltSettings.PugilistSwiftcast;

            #endregion

            PugilistPerfectBalance.Checked = Ultima.UltSettings.PugilistPerfectBalance;
            PugilistFistsOfEarth.Checked = Ultima.UltSettings.PugilistFistsOfEarth;
            PugilistFistsOfWind.Checked = Ultima.UltSettings.PugilistFistsOfWind;

            #endregion

            #region Rogue Settings

            #region Arcanist Cross-Class

            RoguePhysick.Checked = Ultima.UltSettings.RoguePhysick;
            RogueVirus.Checked = Ultima.UltSettings.RogueVirus;
            RogueEyeForAnEye.Checked = Ultima.UltSettings.RogueEyeForAnEye;

            #endregion

            #region Archer Cross-Class

            RogueStraightShot.Checked = Ultima.UltSettings.RogueStraightShot;
            RogueRagingStrikes.Checked = Ultima.UltSettings.RogueRagingStrikes;
            RogueVenomousBite.Checked = Ultima.UltSettings.RogueVenomousBite;
            RogueHawksEye.Checked = Ultima.UltSettings.RogueHawksEye;
            RogueQuellingStrikes.Checked = Ultima.UltSettings.RogueQuellingStrikes;

            #endregion

            #region Conjurer Cross-Class

            RogueCure.Checked = Ultima.UltSettings.RogueCure;
            RogueProtect.Checked = Ultima.UltSettings.RogueProtect;
            RogueRaise.Checked = Ultima.UltSettings.RogueRaise;
            RogueStoneskin.Checked = Ultima.UltSettings.RogueStoneskin;

            #endregion

            #region Gladiator Cross-Class

            RogueSavageBlade.Checked = Ultima.UltSettings.RogueSavageBlade;
            RogueFlash.Checked = Ultima.UltSettings.RogueFlash;
            RogueConvalescence.Checked = Ultima.UltSettings.RogueConvalescence;
            RogueProvoke.Checked = Ultima.UltSettings.RogueProvoke;
            RogueAwareness.Checked = Ultima.UltSettings.RogueAwareness;

            #endregion

            #region Lancer Cross-Class

            RogueFeint.Checked = Ultima.UltSettings.RogueFeint;
            RogueKeenFlurry.Checked = Ultima.UltSettings.RogueKeenFlurry;
            RogueInvigorate.Checked = Ultima.UltSettings.RogueInvigorate;
            RogueBloodForBlood.Checked = Ultima.UltSettings.RogueBloodForBlood;

            #endregion

            #region Marauder Cross-Class

            RogueForesight.Checked = Ultima.UltSettings.RogueForesight;
            RogueSkullSunder.Checked = Ultima.UltSettings.RogueSkullSunder;
            RogueFracture.Checked = Ultima.UltSettings.RogueFracture;
            RogueBloodbath.Checked = Ultima.UltSettings.RogueBloodbath;
            RogueMercyStroke.Checked = Ultima.UltSettings.RogueMercyStroke;

            #endregion

            #region Pugilist Cross-Class

            RogueFeatherfoot.Checked = Ultima.UltSettings.RogueFeatherfoot;
            RogueSecondWind.Checked = Ultima.UltSettings.RogueSecondWind;
            RogueHaymaker.Checked = Ultima.UltSettings.RogueHaymaker;
            RogueInternalRelease.Checked = Ultima.UltSettings.RogueInternalRelease;
            RogueMantra.Checked = Ultima.UltSettings.RogueMantra;

            #endregion

            #region Thaumaturge Cross-Class

            RogueSurecast.Checked = Ultima.UltSettings.RogueSurecast;
            RogueSwiftcast.Checked = Ultima.UltSettings.RogueSwiftcast;

            #endregion

            RogueJugulate.Checked = Ultima.UltSettings.RogueJugulate;
            RogueAssassinate.Checked = Ultima.UltSettings.RogueAssassinate;
            RogueDancingEdge.Checked = Ultima.UltSettings.RogueDancingEdge;
            RogueKissOfTheWasp.Checked = Ultima.UltSettings.RogueKissOfTheWasp;
            RogueKissOfTheViper.Checked = Ultima.UltSettings.RogueKissOfTheViper;
            RogueGoad.Checked = Ultima.UltSettings.RogueGoad;

            #endregion

            #region Thaumaturge Settings

            #region Arcanist Cross-Class

            ThaumaturgeRuin.Checked = Ultima.UltSettings.ThaumaturgeRuin;
            ThaumaturgePhysick.Checked = Ultima.UltSettings.ThaumaturgePhysick;
            ThaumaturgeVirus.Checked = Ultima.UltSettings.ThaumaturgeVirus;
            ThaumaturgeEyeForAnEye.Checked = Ultima.UltSettings.ThaumaturgeEyeForAnEye;

            #endregion

            #region Archer Cross-Class

            ThaumaturgeRagingStrikes.Checked = Ultima.UltSettings.ThaumaturgeRagingStrikes;
            ThaumaturgeHawksEye.Checked = Ultima.UltSettings.ThaumaturgeHawksEye;
            ThaumaturgeQuellingStrikes.Checked = Ultima.UltSettings.ThaumaturgeQuellingStrikes;

            #endregion

            #region Conjurer Cross-Class

            ThaumaturgeCure.Checked = Ultima.UltSettings.ThaumaturgeCure;
            ThaumaturgeAero.Checked = Ultima.UltSettings.ThaumaturgeAero;
            ThaumaturgeProtect.Checked = Ultima.UltSettings.ThaumaturgeProtect;
            ThaumaturgeRaise.Checked = Ultima.UltSettings.ThaumaturgeRaise;
            ThaumaturgeStoneskin.Checked = Ultima.UltSettings.ThaumaturgeStoneskin;

            #endregion

            #region Gladiator Cross-Class

            ThaumaturgeFlash.Checked = Ultima.UltSettings.ThaumaturgeFlash;
            ThaumaturgeConvalescence.Checked = Ultima.UltSettings.ThaumaturgeConvalescence;
            ThaumaturgeProvoke.Checked = Ultima.UltSettings.ThaumaturgeProvoke;
            ThaumaturgeAwareness.Checked = Ultima.UltSettings.ThaumaturgeAwareness;

            #endregion

            #region Lancer Cross-Class

            ThaumaturgeKeenFlurry.Checked = Ultima.UltSettings.ThaumaturgeKeenFlurry;
            ThaumaturgeInvigorate.Checked = Ultima.UltSettings.ThaumaturgeInvigorate;
            ThaumaturgeBloodForBlood.Checked = Ultima.UltSettings.ThaumaturgeBloodForBlood;

            #endregion

            #region Marauder Cross-Class

            ThaumaturgeForesight.Checked = Ultima.UltSettings.ThaumaturgeForesight;
            ThaumaturgeBloodbath.Checked = Ultima.UltSettings.ThaumaturgeBloodbath;
            ThaumaturgeMercyStroke.Checked = Ultima.UltSettings.ThaumaturgeMercyStroke;

            #endregion

            #region Pugilist Cross-Class

            ThaumaturgeFeatherfoot.Checked = Ultima.UltSettings.ThaumaturgeFeatherfoot;
            ThaumaturgeSecondWind.Checked = Ultima.UltSettings.ThaumaturgeSecondWind;
            ThaumaturgeInternalRelease.Checked = Ultima.UltSettings.ThaumaturgeInternalRelease;
            ThaumaturgeMantra.Checked = Ultima.UltSettings.ThaumaturgeMantra;

            #endregion

            #endregion

            #endregion

            #region Job Settings

            #region Astrologian Settings

            #region Conjurer Cross-Class

            AstrologianCure.Checked = Ultima.UltSettings.AstrologianCure;
            AstrologianAero.Checked = Ultima.UltSettings.AstrologianAero;
            AstrologianClericStance.Checked = Ultima.UltSettings.AstrologianClericStance;
            AstrologianProtect.Checked = Ultima.UltSettings.AstrologianProtect;
            AstrologianRaise.Checked = Ultima.UltSettings.AstrologianRaise;
            AstrologianStoneskin.Checked = Ultima.UltSettings.AstrologianStoneskin;
            
            #endregion

            #region Thaumaturge Cross-Class

            AstrologianSurecast.Checked = Ultima.UltSettings.AstrologianSurecast;
            AstrologianBlizzardII.Checked = Ultima.UltSettings.AstrologianBlizzardII;
            AstrologianSwiftcast.Checked = Ultima.UltSettings.AstrologianSwiftcast;

            #endregion

            AstrologianBenefic.Checked = Ultima.UltSettings.AstrologianBenefic;
            AstrologianBeneficII.Checked = Ultima.UltSettings.AstrologianBeneficII;
            AstrologianAspectedBenefic.Checked = Ultima.UltSettings.AstrologianAspectedBenefic;
            AstrologianEssentialDignity.Checked = Ultima.UltSettings.AstrologianEssentialDignity;
            AstrologianDraw.Checked = Ultima.UltSettings.AstrologianDraw;

            #endregion

            #region Bard Settings

            #region Lancer Cross-Class

            BardFeint.Checked = Ultima.UltSettings.BardFeint;
            BardKeenFlurry.Checked = Ultima.UltSettings.BardKeenFlurry;
            BardInvigorate.Checked = Ultima.UltSettings.BardInvigorate;
            BardBloodForBlood.Checked = Ultima.UltSettings.BardBloodForBlood;

            #endregion

            #region Pugilist Cross-Class

            BardFeatherfoot.Checked = Ultima.UltSettings.BardFeatherfoot;
            BardSecondWind.Checked = Ultima.UltSettings.BardSecondWind;
            BardHaymaker.Checked = Ultima.UltSettings.BardHaymaker;
            BardInternalRelease.Checked = Ultima.UltSettings.BardInternalRelease;
            BardMantra.Checked = Ultima.UltSettings.BardMantra;

            #endregion

            BardBluntArrow.Checked = Ultima.UltSettings.BardBluntArrow;
            BardMiserysEnd.Checked = Ultima.UltSettings.BardMiserysEnd;
            BardTheWanderersMinuet.Checked = Ultima.UltSettings.BardTheWanderersMinuet;
            BardFlamingArrow.Checked = Ultima.UltSettings.BardFlamingArrow;

            #endregion

            #region Black Mage Settings

            #region Arcanist Cross-Class

            BlackMageRuin.Checked = Ultima.UltSettings.BlackMageRuin;
            BlackMagePhysick.Checked = Ultima.UltSettings.BlackMagePhysick;
            BlackMageVirus.Checked = Ultima.UltSettings.BlackMageVirus;
            BlackMageEyeForAnEye.Checked = Ultima.UltSettings.BlackMageEyeForAnEye;

            #endregion

            #region Archer Cross-Class

            BlackMageRagingStrikes.Checked = Ultima.UltSettings.BlackMageRagingStrikes;
            BlackMageHawksEye.Checked = Ultima.UltSettings.BlackMageHawksEye;
            BlackMageQuellingStrikes.Checked = Ultima.UltSettings.BlackMageQuellingStrikes;

            #endregion

            #endregion

            #region Dark Knight Settings

            #region Gladiator Cross-Class

            DarkKnightSavageBlade.Checked = Ultima.UltSettings.DarkKnightSavageBlade;
            DarkKnightFlash.Checked = Ultima.UltSettings.DarkKnightFlash;
            DarkKnightConvalescence.Checked = Ultima.UltSettings.DarkKnightConvalescence;
            DarkKnightProvoke.Checked = Ultima.UltSettings.DarkKnightProvoke;
            DarkKnightAwareness.Checked = Ultima.UltSettings.DarkKnightAwareness;

            #endregion

            #region Marauder Cross-Class

            DarkKnightForesight.Checked = Ultima.UltSettings.DarkKnightForesight;
            DarkKnightSkullSunder.Checked = Ultima.UltSettings.DarkKnightSkullSunder;
            DarkKnightFracture.Checked = Ultima.UltSettings.DarkKnightFracture;
            DarkKnightBloodbath.Checked = Ultima.UltSettings.DarkKnightBloodbath;
            DarkKnightMercyStroke.Checked = Ultima.UltSettings.DarkKnightMercyStroke;

            #endregion

            DarkKnightBloodWeapon.Checked = Ultima.UltSettings.DarkKnightBloodWeapon;
            DarkKnightDarkArts.Checked = Ultima.UltSettings.DarkKnightDarkArts;
            DarkKnightReprisal.Checked = Ultima.UltSettings.DarkKnightReprisal;
            DarkKnightDelirium.Checked = Ultima.UltSettings.DarkKnightDelirium;
            DarkKnightPlunge.Checked = Ultima.UltSettings.DarkKnightPlunge;
            DarkKnightLowBlow.Checked = Ultima.UltSettings.DarkKnightLowBlow;
            DarkKnightSaltedEarth.Checked = Ultima.UltSettings.DarkKnightSaltedEarth;

            #endregion

            #region Dragoon Settings

            #region Marauder Cross-Class

            DragoonForesight.Checked = Ultima.UltSettings.DragoonForesight;
            DragoonSkullSunder.Checked = Ultima.UltSettings.DragoonSkullSunder;
            DragoonFracture.Checked = Ultima.UltSettings.DragoonFracture;
            DragoonBloodbath.Checked = Ultima.UltSettings.DragoonBloodbath;
            DragoonMercyStroke.Checked = Ultima.UltSettings.DragoonMercyStroke;

            #endregion

            #region Pugilist Cross-Class

            DragoonFeatherfoot.Checked = Ultima.UltSettings.DragoonFeatherfoot;
            DragoonSecondWind.Checked = Ultima.UltSettings.DragoonSecondWind;
            DragoonHaymaker.Checked = Ultima.UltSettings.DragoonHaymaker;
            DragoonInternalRelease.Checked = Ultima.UltSettings.DragoonInternalRelease;
            DragoonMantra.Checked = Ultima.UltSettings.DragoonMantra;

            #endregion

            DragoonLegSweep.Checked = Ultima.UltSettings.DragoonLegSweep;
            DragoonJump.Checked = Ultima.UltSettings.DragoonJump;
            DragoonSpineshatterDive.Checked = Ultima.UltSettings.DragoonSpineshatterDive;
            DragoonPowerSurge.Checked = Ultima.UltSettings.DragoonPowerSurge;
            DragoonDragonfireDive.Checked = Ultima.UltSettings.DragoonDragonfireDive;
            DragoonBattleLitany.Checked = Ultima.UltSettings.DragoonBattleLitany;

            #endregion

            #region Machinist Settings

            #region Archer Cross-Class

            MachinistRagingStrikes.Checked = Ultima.UltSettings.MachinistRagingStrikes;
            MachinistHawksEye.Checked = Ultima.UltSettings.MachinistHawksEye;
            MachinistQuellingStrikes.Checked = Ultima.UltSettings.MachinistQuellingStrikes;

            #endregion

            #region Lancer Cross-Class

            MachinistFeint.Checked = Ultima.UltSettings.MachinistFeint;
            MachinistKeenFlurry.Checked = Ultima.UltSettings.MachinistKeenFlurry;
            MachinistInvigorate.Checked = Ultima.UltSettings.MachinistInvigorate;
            MachinistBloodForBlood.Checked = Ultima.UltSettings.MachinistBloodForBlood;

            #endregion

            MachinistSummonTurret.Checked = Ultima.UltSettings.MachinistSummonTurret;
            if (Ultima.UltSettings.MachinistRook)
            {
                MachinistSummonTurretCombo.Text = @"Rook Autoturret";
            }
            if (Ultima.UltSettings.MachinistBishop)
            {
                MachinistSummonTurretCombo.Text = @"Bishop Autoturret";
            }
            MachinistHeadGraze.Checked = Ultima.UltSettings.MachinistHeadGraze;
            MachinistHypercharge.Checked = Ultima.UltSettings.MachinistHypercharge;
            MachinistBlank.Checked = Ultima.UltSettings.MachinistBlank;
            MachinistHeartbreak.Checked = Ultima.UltSettings.MachinistHeartbreak;
            MachinistGaussBarrel.Checked = Ultima.UltSettings.MachinistGaussBarrel;

            #endregion

            #region Monk Settings

            #region Lancer Cross-Class

            MonkFeint.Checked = Ultima.UltSettings.MonkFeint;
            MonkKeenFlurry.Checked = Ultima.UltSettings.MonkKeenFlurry;
            MonkInvigorate.Checked = Ultima.UltSettings.MonkInvigorate;
            MonkBloodForBlood.Checked = Ultima.UltSettings.MonkBloodForBlood;

            #endregion

            #region Marauder Cross-Class

            MonkForesight.Checked = Ultima.UltSettings.MonkForesight;
            MonkSkullSunder.Checked = Ultima.UltSettings.MonkSkullSunder;
            MonkFracture.Checked = Ultima.UltSettings.MonkFracture;
            MonkBloodbath.Checked = Ultima.UltSettings.MonkBloodbath;
            MonkMercyStroke.Checked = Ultima.UltSettings.MonkMercyStroke;

            #endregion

            MonkShoulderTackle.Checked = Ultima.UltSettings.MonkShoulderTackle;
            MonkPerfectBalance.Checked = Ultima.UltSettings.MonkPerfectBalance;
            MonkFistsOfEarth.Checked = Ultima.UltSettings.MonkFistsOfEarth;
            MonkFistsOfWind.Checked = Ultima.UltSettings.MonkFistsOfWind;
            MonkFistsOfFire.Checked = Ultima.UltSettings.MonkFistsOfFire;
            MonkMeditation.Checked = Ultima.UltSettings.MonkMeditation;
            MonkTheForbiddenChakra.Checked = Ultima.UltSettings.MonkTheForbiddenChakra;
            MonkElixirField.Checked = Ultima.UltSettings.MonkElixirField;

            #endregion

            #region Ninja Settings

            #region Lancer Cross-Class

            NinjaFeint.Checked = Ultima.UltSettings.NinjaFeint;
            NinjaKeenFlurry.Checked = Ultima.UltSettings.NinjaKeenFlurry;
            NinjaInvigorate.Checked = Ultima.UltSettings.NinjaInvigorate;
            NinjaBloodForBlood.Checked = Ultima.UltSettings.NinjaBloodForBlood;

            #endregion

            #region Pugilist Cross-Class

            NinjaFeatherfoot.Checked = Ultima.UltSettings.NinjaFeatherfoot;
            NinjaSecondWind.Checked = Ultima.UltSettings.NinjaSecondWind;
            NinjaHaymaker.Checked = Ultima.UltSettings.NinjaHaymaker;
            NinjaInternalRelease.Checked = Ultima.UltSettings.NinjaInternalRelease;
            NinjaMantra.Checked = Ultima.UltSettings.NinjaMantra;

            #endregion

            NinjaShukuchi.Checked = Ultima.UltSettings.NinjaShukuchi;
            NinjaJugulate.Checked = Ultima.UltSettings.NinjaJugulate;
            NinjaAssassinate.Checked = Ultima.UltSettings.NinjaAssassinate;
            NinjaRaiton.Checked = Ultima.UltSettings.NinjaRaiton;
            NinjaFumaShuriken.Checked = Ultima.UltSettings.NinjaFumaShuriken;
            NinjaKissOfTheWasp.Checked = Ultima.UltSettings.NinjaKissOfTheWasp;
            NinjaKissOfTheViper.Checked = Ultima.UltSettings.NinjaKissOfTheViper;
            NinjaDancingEdge.Checked = Ultima.UltSettings.NinjaDancingEdge;
            NinjaGoad.Checked = Ultima.UltSettings.NinjaGoad;
            NinjaDreamWithinADream.Checked = Ultima.UltSettings.NinjaDreamWithinADream;

            #endregion

            #region Paladin Settings

            #region Conjurer Cross-Class

            PaladinCure.Checked = Ultima.UltSettings.PaladinCure;
            PaladinProtect.Checked = Ultima.UltSettings.PaladinProtect;
            PaladinRaise.Checked = Ultima.UltSettings.PaladinRaise;
            PaladinStoneskin.Checked = Ultima.UltSettings.PaladinStoneskin;

            #endregion

            #region Marauder Cross-Class

            PaladinForesight.Checked = Ultima.UltSettings.PaladinForesight;
            PaladinSkullSunder.Checked = Ultima.UltSettings.PaladinSkullSunder;
            PaladinFracture.Checked = Ultima.UltSettings.PaladinFracture;
            PaladinBloodbath.Checked = Ultima.UltSettings.PaladinBloodbath;
            PaladinMercyStroke.Checked = Ultima.UltSettings.PaladinMercyStroke;

            #endregion

            PaladinShieldSwipe.Checked = Ultima.UltSettings.PaladinShieldSwipe;
            PaladinSpiritsWithin.Checked = Ultima.UltSettings.PaladinSpiritsWithin;
            PaladinSwordOath.Checked = Ultima.UltSettings.PaladinSwordOath;
            PaladinShieldOath.Checked = Ultima.UltSettings.PaladinShieldOath;

            #endregion

            #region Scholar Settings

            #region Conjurer Cross-Class

            ScholarCure.Checked = Ultima.UltSettings.ScholarCure;
            ScholarAero.Checked = Ultima.UltSettings.ScholarAero;
            ScholarClericStance.Checked = Ultima.UltSettings.ScholarClericStance;
            ScholarProtect.Checked = Ultima.UltSettings.ScholarProtect;
            ScholarRaise.Checked = Ultima.UltSettings.ScholarRaise;
            ScholarStoneskin.Checked = Ultima.UltSettings.ScholarStoneskin;

            #endregion

            #region Thaumaturge Cross-Class

            ScholarSurecast.Checked = Ultima.UltSettings.ScholarSurecast;
            ScholarBlizzardII.Checked = Ultima.UltSettings.ScholarBlizzardII;
            ScholarSwiftcast.Checked = Ultima.UltSettings.ScholarSwiftcast;

            #endregion

            ScholarSummonPet.Checked = Ultima.UltSettings.ScholarSummonPet;
            if (Ultima.UltSettings.ScholarEos)
            {
                ScholarSummonPetCombo.Text = @"Eos";
            }
            if (Ultima.UltSettings.ScholarSelene)
            {
                ScholarSummonPetCombo.Text = @"Selene";
            }
            ScholarPhysick.Checked = Ultima.UltSettings.ScholarPhysick;
            ScholarAdloquium.Checked = Ultima.UltSettings.ScholarAdloquium;

            #endregion

            #region Summoner Settings

            #region Archer Cross-Class

            SummonerRagingStrikes.Checked = Ultima.UltSettings.SummonerRagingStrikes;
            SummonerHawksEye.Checked = Ultima.UltSettings.SummonerHawksEye;
            SummonerQuellingStrikes.Checked = Ultima.UltSettings.SummonerQuellingStrikes;

            #endregion

            #region Thaumaturge Cross-Class

            SummonerSurecast.Checked = Ultima.UltSettings.SummonerSurecast;
            SummonerBlizzardII.Checked = Ultima.UltSettings.SummonerBlizzardII;
            SummonerSwiftcast.Checked = Ultima.UltSettings.SummonerSwiftcast;

            #endregion

            SummonerSummonPet.Checked = Ultima.UltSettings.SummonerSummonPet;
            if (Ultima.UltSettings.SummonerGaruda)
            {
                SummonerSummonPetCombo.Text = @"Garuda-Egi";
            }
            if (Ultima.UltSettings.SummonerTitan)
            {
                SummonerSummonPetCombo.Text = @"Titan-Egi";
            }
            if (Ultima.UltSettings.SummonerIfrit)
            {
                SummonerSummonPetCombo.Text = @"Ifrit-Egi";
            }
            SummonerPhysick.Checked = Ultima.UltSettings.SummonerPhysick;

            #endregion

            #region Warrior Settings

            #region Gladiator Cross-Class

            WarriorSavageBlade.Checked = Ultima.UltSettings.WarriorSavageBlade;
            WarriorFlash.Checked = Ultima.UltSettings.WarriorFlash;
            WarriorConvalescence.Checked = Ultima.UltSettings.WarriorConvalescence;
            WarriorProvoke.Checked = Ultima.UltSettings.WarriorProvoke;
            WarriorAwareness.Checked = Ultima.UltSettings.WarriorAwareness;

            #endregion

            #region Pugilist Cross-Class

            WarriorFeatherfoot.Checked = Ultima.UltSettings.WarriorFeatherfoot;
            WarriorSecondWind.Checked = Ultima.UltSettings.WarriorSecondWind;
            WarriorHaymaker.Checked = Ultima.UltSettings.WarriorHaymaker;
            WarriorInternalRelease.Checked = Ultima.UltSettings.WarriorInternalRelease;
            WarriorMantra.Checked = Ultima.UltSettings.WarriorMantra;

            #endregion

            WarriorBrutalSwing.Checked = Ultima.UltSettings.WarriorBrutalSwing;
            WarriorMercyStroke.Checked = Ultima.UltSettings.WarriorMercyStroke;

            #endregion

            #region White Mage Settings

            #region Arcanist Cross-Class

            WhiteMageRuin.Checked = Ultima.UltSettings.WhiteMageRuin;
            WhiteMagePhysick.Checked = Ultima.UltSettings.WhiteMagePhysick;
            WhiteMageVirus.Checked = Ultima.UltSettings.WhiteMageVirus;
            WhiteMageEyeForAnEye.Checked = Ultima.UltSettings.WhiteMageEyeForAnEye;

            #endregion

            #region Thaumaturge Cross-Class

            WhiteMageSurecast.Checked = Ultima.UltSettings.WhiteMageSurecast;
            WhiteMageBlizzardII.Checked = Ultima.UltSettings.WhiteMageBlizzardII;
            WhiteMageSwiftcast.Checked = Ultima.UltSettings.WhiteMageSwiftcast;

            #endregion

            WhiteMageRaise.Checked = Ultima.UltSettings.WhiteMageRaise;
            WhiteMageBenediction.Checked = Ultima.UltSettings.WhiteMageBenediction;
            WhiteMageTetragrammaton.Checked = Ultima.UltSettings.WhiteMageTetragrammaton;
            WhiteMageShroudOfSaints.Checked = Ultima.UltSettings.WhiteMageShroudOfSaints;
            WhiteMagePresenceOfMind.Checked = Ultima.UltSettings.WhiteMagePresenceOfMind;
            WhiteMageDivineSeal.Checked = Ultima.UltSettings.WhiteMageDivineSeal;
            WhiteMageProtect.Checked = Ultima.UltSettings.WhiteMageProtect;
            WhiteMageStoneskin.Checked = Ultima.UltSettings.WhiteMageStoneskin;
            WhiteMageStoneskinII.Checked = Ultima.UltSettings.WhiteMageStoneskinII;

            #endregion

            #endregion
        }

        #region Ultima Settings

        #region Chocobo Settings

        private void SummonChocobo_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.SummonChocobo = SummonChocobo.Checked;
        }

        private void ChocoboStanceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChocoboStanceCombo.Text == @"Free Stance")
            {
                Ultima.UltSettings.ChocoboFreeStance = true;
                Ultima.UltSettings.ChocoboDefenderStance = false;
                Ultima.UltSettings.ChocoboAttackerStance = false;
                Ultima.UltSettings.ChocoboHealerStance = false;
            }

            if (ChocoboStanceCombo.Text == @"Defender Stance")
            {
                Ultima.UltSettings.ChocoboFreeStance = false;
                Ultima.UltSettings.ChocoboDefenderStance = true;
                Ultima.UltSettings.ChocoboAttackerStance = false;
                Ultima.UltSettings.ChocoboHealerStance = false;
            }

            if (ChocoboStanceCombo.Text == @"Attacker Stance")
            {
                Ultima.UltSettings.ChocoboFreeStance = false;
                Ultima.UltSettings.ChocoboDefenderStance = false;
                Ultima.UltSettings.ChocoboAttackerStance = true;
                Ultima.UltSettings.ChocoboHealerStance = false;
            }

            if (ChocoboStanceCombo.Text == @"Healer Stance")
            {
                Ultima.UltSettings.ChocoboFreeStance = false;
                Ultima.UltSettings.ChocoboDefenderStance = false;
                Ultima.UltSettings.ChocoboAttackerStance = false;
                Ultima.UltSettings.ChocoboHealerStance = true;
            }
        }

        #endregion

        #region Rotation Settings

        #region Overlay Settings

        private void OverlayCheck_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.UseOverlay = OverlayCheck.Checked;
            Overlay.Visible = OverlayCheck.Checked;
        }

        #endregion

        #region Rotation Combo Settings

        private void RotationModeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RotationModeCombo.Text == @"Smart Target")
            {
                Ultima.UltSettings.SmartTarget = true;
                Ultima.UltSettings.SingleTarget = false;
                Ultima.UltSettings.MultiTarget = false;
                Overlay.UpdateLabel(RotationModeCombo.Text);
            }

            if (RotationModeCombo.Text == @"Single Target")
            {
                Ultima.UltSettings.SmartTarget = false;
                Ultima.UltSettings.SingleTarget = true;
                Ultima.UltSettings.MultiTarget = false;
                Overlay.UpdateLabel(RotationModeCombo.Text);
            }

            if (RotationModeCombo.Text == @"Multi Target")
            {
                Ultima.UltSettings.SmartTarget = false;
                Ultima.UltSettings.SingleTarget = false;
                Ultima.UltSettings.MultiTarget = true;
                Overlay.UpdateLabel(RotationModeCombo.Text);
            }
        }

        #endregion

        #region Rotation Hotkey Settings

        private static void RegisterHotkeys()
    {
        HotkeyManager.Register("[Ultima] Cycle Rotation", Ultima.UltSettings.HotKey, Ultima.UltSettings.ModKey, hk => Ultima.CycleRotation());
    }

        private static void UnregisterHotkeys()
        {
            HotkeyManager.Unregister("[Ultima] Cycle Rotation");
        }

        #region Rotation Modifier Key Settings

        private void RotationModifierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RotationModifierCombo.Text == @"None")
            {
                Ultima.UltSettings.ModKey = System.Windows.Input.ModifierKeys.None;
            }

            if (RotationModifierCombo.Text == @"Alt")
            {
                Ultima.UltSettings.ModKey = System.Windows.Input.ModifierKeys.Alt;
            }

            if (RotationModifierCombo.Text == @"Control")
            {
                Ultima.UltSettings.ModKey = System.Windows.Input.ModifierKeys.Control;
            }

            if (RotationModifierCombo.Text == @"Shift")
            {
                Ultima.UltSettings.ModKey = System.Windows.Input.ModifierKeys.Shift;
            }

            if (RotationModifierCombo.Text == @"Windows")
            {
                Ultima.UltSettings.ModKey = System.Windows.Input.ModifierKeys.Windows;
            }
        }

        #endregion

        #region Rotation Hotkey Settings

        private void RotationHotkeyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RotationHotkeyCombo.Text == @"None")
            {
                Ultima.UltSettings.HotKey = Keys.None;
            }

            if (RotationHotkeyCombo.Text == @"Left Mouse")
            {
                Ultima.UltSettings.HotKey = Keys.LButton;
            }

            if (RotationHotkeyCombo.Text == @"Middle Mouse")
            {
                Ultima.UltSettings.HotKey = Keys.MButton;
            }

            if (RotationHotkeyCombo.Text == @"Right Mouse")
            {
                Ultima.UltSettings.HotKey = Keys.RButton;
            }

            if (RotationHotkeyCombo.Text == @"Mouse 1")
            {
                Ultima.UltSettings.HotKey = Keys.XButton1;
            }

            if (RotationHotkeyCombo.Text == @"Mouse 2")
            {
                Ultima.UltSettings.HotKey = Keys.XButton2;
            }

            if (RotationHotkeyCombo.Text == @"Space")
            {
                Ultima.UltSettings.HotKey = Keys.Space;
            }

            if (RotationHotkeyCombo.Text == @"Tilde")
            {
                Ultima.UltSettings.HotKey = Keys.Oemtilde;
            }

            if (RotationHotkeyCombo.Text == @"Q")
            {
                Ultima.UltSettings.HotKey = Keys.Q;
            }

            if (RotationHotkeyCombo.Text == @"E")
            {
                Ultima.UltSettings.HotKey = Keys.E;
            }

            if (RotationHotkeyCombo.Text == @"Z")
            {
                Ultima.UltSettings.HotKey = Keys.Z;
            }

            if (RotationHotkeyCombo.Text == @"X")
            {
                Ultima.UltSettings.HotKey = Keys.X;
            }

            if (RotationHotkeyCombo.Text == @"C")
            {
                Ultima.UltSettings.HotKey = Keys.C;
            }
        }

        #endregion

        #endregion

        #endregion

        private void DefaultCRCheck_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DefaultCRCheck = DefaultCRCheck.Checked;
            RoutineManager.PreferedRoutine = Ultima.UltSettings.DefaultCRCheck ? "Ultima" : null;
        }

        private void QueueSpells_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.QueueSpells = QueueSpells.Checked;
        }
        private void RandomCastLocation_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RandomCastLocation = RandomCastLocation.Checked;
        }

        #endregion

        #region Class Settings

        #region Arcanist Settings

        #region Archer Cross-Class

        private void ArcanistRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistRagingStrikes = ArcanistRagingStrikes.Checked;
        }

        private void ArcanistHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistHawksEye = ArcanistHawksEye.Checked;
        }

        private void ArcanistQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistQuellingStrikes = ArcanistQuellingStrikes.Checked;
        }

        #endregion

        #region Conjurer Cross-Class

        private void ArcanistCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistCure = ArcanistCure.Checked;
        }

        private void ArcanistAero_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistAero = ArcanistAero.Checked;
        }

        private void ArcanistProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistProtect = ArcanistProtect.Checked;
        }

        private void ArcanistRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistRaise = ArcanistRaise.Checked;
        }

        private void ArcanistStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistStoneskin = ArcanistStoneskin.Checked;
        }

        #endregion

        #region Gladiator Cross-Class

        private void ArcanistFlash_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistFlash = ArcanistFlash.Checked;
        }

        private void ArcanistConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistConvalescence = ArcanistConvalescence.Checked;
        }

        private void ArcanistProvoke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistProvoke = ArcanistProvoke.Checked;
        }

        private void ArcanistAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistAwareness = ArcanistAwareness.Checked;
        }

        #endregion

        #region Lancer Cross-Class

        private void ArcanistKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistKeenFlurry = ArcanistKeenFlurry.Checked;
        }

        private void ArcanistInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistInvigorate = ArcanistInvigorate.Checked;
        }

        private void ArcanistBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistBloodForBlood = ArcanistBloodForBlood.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void ArcanistForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistForesight = ArcanistForesight.Checked;
        }

        private void ArcanistBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistBloodbath = ArcanistBloodbath.Checked;
        }

        private void ArcanistMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistMercyStroke = ArcanistMercyStroke.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void ArcanistFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistFeatherfoot = ArcanistFeatherfoot.Checked;
        }

        private void ArcanistSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistSecondWind = ArcanistSecondWind.Checked;
        }

        private void ArcanistInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistInternalRelease = ArcanistInternalRelease.Checked;
        }

        private void ArcanistMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistMantra = ArcanistMantra.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void ArcanistSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistSurecast = ArcanistSurecast.Checked;
        }

        private void ArcanistBlizzardII_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistBlizzardII = ArcanistBlizzardII.Checked;
        }

        private void ArcanistSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistSwiftcast = ArcanistSwiftcast.Checked;
        }

        #endregion

        private void ArcanistSummonPet_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistSummonPet = ArcanistSummonPet.Checked;
        }

        private void ArcanistSummonPetCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ArcanistSummonPetCombo.Text == @"Emerald Carbuncle")
            {
                Ultima.UltSettings.ArcanistEmeraldCarbuncle = true;
                Ultima.UltSettings.ArcanistTopazCarbuncle = false;
            }

            if (ArcanistSummonPetCombo.Text == @"Topaz Carbuncle")
            {
                Ultima.UltSettings.ArcanistEmeraldCarbuncle = false;
                Ultima.UltSettings.ArcanistTopazCarbuncle = true;
            }
        }

        private void ArcanistPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcanistPhysick = ArcanistPhysick.Checked;
        }

        #endregion

        #region Archer Settings

        #region Arcanist Cross-Class

        private void ArcherPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherPhysick = ArcherPhysick.Checked;
        }

        private void ArcherVirus_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherVirus = ArcherVirus.Checked;
        }

        private void ArcherEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherEyeForAnEye = ArcherEyeForAnEye.Checked;
        }

        #endregion

        #region Conjurer Cross-Class

        private void ArcherCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherCure = ArcherCure.Checked;
        }

        private void ArcherProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherProtect = ArcherProtect.Checked;
        }

        private void ArcherRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherRaise = ArcherRaise.Checked;
        }

        private void ArcherStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherStoneskin = ArcherStoneskin.Checked;
        }

        #endregion

        #region Gladiator Cross-Class

        private void ArcherSavageBlade_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherSavageBlade = ArcherSavageBlade.Checked;
        }

        private void ArcherFlash_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherFlash = ArcherFlash.Checked;
        }

        private void ArcherConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherConvalescence = ArcherConvalescence.Checked;
        }

        private void ArcherProvoke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherProvoke = ArcherProvoke.Checked;
        }

        private void ArcherAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherAwareness = ArcherAwareness.Checked;
        }

        #endregion

        #region Lancer Cross-Class

        private void ArcherFeint_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherFeint = ArcherFeint.Checked;
        }

        private void ArcherKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherKeenFlurry = ArcherKeenFlurry.Checked;
        }

        private void ArcherInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherInvigorate = ArcherInvigorate.Checked;
        }

        private void ArcherBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherBloodForBlood = ArcherBloodForBlood.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void ArcherForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherForesight = ArcherForesight.Checked;
        }

        private void ArcherSkullSunder_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherSkullSunder = ArcherSkullSunder.Checked;
        }

        private void ArcherFracture_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherFracture = ArcherFracture.Checked;
        }

        private void ArcherBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherBloodbath = ArcherBloodbath.Checked;
        }

        private void ArcherMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherMercyStroke = ArcherMercyStroke.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void ArcherFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherFeatherfoot = ArcherFeatherfoot.Checked;
        }

        private void ArcherSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherSecondWind = ArcherSecondWind.Checked;
        }

        private void ArcherHaymaker_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherHaymaker = ArcherHaymaker.Checked;
        }

        private void ArcherInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherInternalRelease = ArcherInternalRelease.Checked;
        }

        private void ArcherMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherMantra = ArcherMantra.Checked;
        }

        #endregion

        #region Rogue Cross-Class

        private void ArcherShadeShift_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherShadeShift = ArcherShadeShift.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void ArcherSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherSurecast = ArcherSurecast.Checked;
        }

        private void ArcherSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherSwiftcast = ArcherSwiftcast.Checked;
        }

        #endregion

        private void ArcherBluntArrow_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherBluntArrow = ArcherBluntArrow.Checked;
        }

        private void ArcherMiserysEnd_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherMiserysEnd = ArcherMiserysEnd.Checked;
        }

        private void ArcherFlamingArrow_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ArcherFlamingArrow = ArcherFlamingArrow.Checked;
        }

        #endregion

        #region Conjurer Settings

        #region Arcanist Cross-Class

        private void ConjurerRuin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerRuin = ConjurerRuin.Checked;
        }

        private void ConjurerPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerPhysick = ConjurerPhysick.Checked;
        }

        private void ConjurerVirus_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerVirus = ConjurerVirus.Checked;
        }

        private void ConjurerEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerEyeForAnEye = ConjurerEyeForAnEye.Checked;
        }

        #endregion

        #region Archer Cross-Class

        private void ConjurerRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerRagingStrikes = ConjurerRagingStrikes.Checked;
        }

        private void ConjurerHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerHawksEye = ConjurerHawksEye.Checked;
        }

        private void ConjurerQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerQuellingStrikes = ConjurerQuellingStrikes.Checked;
        }

        #endregion

        #region Gladiator Cross-Class

        private void ConjurerFlash_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerFlash = ConjurerFlash.Checked;
        }

        private void ConjurerConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerConvalescence = ConjurerConvalescence.Checked;
        }

        private void ConjurerProvoke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerProvoke = ConjurerProvoke.Checked;
        }

        private void ConjurerAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerAwareness = ConjurerAwareness.Checked;
        }

        #endregion

        #region Lancer Cross-Class

        private void ConjurerKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerKeenFlurry = ConjurerKeenFlurry.Checked;
        }

        private void ConjurerInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerInvigorate = ConjurerInvigorate.Checked;
        }

        private void ConjurerBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerBloodForBlood = ConjurerBloodForBlood.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void ConjurerForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerForesight = ConjurerForesight.Checked;
        }

        private void ConjurerBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerBloodbath = ConjurerBloodbath.Checked;
        }

        private void ConjurerMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerMercyStroke = ConjurerMercyStroke.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void ConjurerFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerFeatherfoot = ConjurerFeatherfoot.Checked;
        }

        private void ConjurerSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerSecondWind = ConjurerSecondWind.Checked;
        }

        private void ConjurerInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerInternalRelease = ConjurerInternalRelease.Checked;
        }

        private void ConjurerMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerMantra = ConjurerMantra.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void ConjurerSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerSurecast = ConjurerSurecast.Checked;
        }

        private void ConjurerBlizzardII_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerBlizzardII = ConjurerBlizzardII.Checked;
        }

        private void ConjurerSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerSwiftcast = ConjurerSwiftcast.Checked;
        }

        #endregion

        private void ConjurerRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerRaise = ConjurerRaise.Checked;
        }

        private void ConjurerProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerProtect = ConjurerProtect.Checked;
        }

        private void ConjurerStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerStoneskin = ConjurerStoneskin.Checked;
        }

        private void ConjurerStoneskinII_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerStoneskinII = ConjurerStoneskinII.Checked;
        }

        private void ConjurerShroudOfSaints_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ConjurerShroudOfSaints = ConjurerShroudOfSaints.Checked;
        }

        #endregion

        #region Gladiator Settings

        #region Arcanist Cross-Class

        private void GladiatorPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorPhysick = GladiatorPhysick.Checked;
        }

        private void GladiatorVirus_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorVirus = GladiatorVirus.Checked;
        }

        private void GladiatorEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorEyeForAnEye = GladiatorEyeForAnEye.Checked;
        }

        #endregion

        #region Archer Cross-Class

        private void GladiatorStraightShot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorStraightShot = GladiatorStraightShot.Checked;
        }

        private void GladiatorRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorRagingStrikes = GladiatorRagingStrikes.Checked;
        }

        private void GladiatorVenomousBite_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorVenomousBite = GladiatorVenomousBite.Checked;
        }

        private void GladiatorHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorHawksEye = GladiatorHawksEye.Checked;
        }

        private void GladiatorQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorQuellingStrikes = GladiatorQuellingStrikes.Checked;
        }

        #endregion

        #region Conjurer Cross-Class

        private void GladiatorCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorCure = GladiatorCure.Checked;
        }

        private void GladiatorProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorProtect = GladiatorProtect.Checked;
        }

        private void GladiatorRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorRaise = GladiatorRaise.Checked;
        }

        private void GladiatorStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorStoneskin = GladiatorStoneskin.Checked;
        }

        #endregion

        #region Lancer Cross-Class

        private void GladiatorFeint_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorFeint = GladiatorFeint.Checked;
        }

        private void GladiatorKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorKeenFlurry = GladiatorKeenFlurry.Checked;
        }

        private void GladiatorInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorInvigorate = GladiatorInvigorate.Checked;
        }

        private void GladiatorBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorBloodForBlood = GladiatorBloodForBlood.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void GladiatorForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorForesight = GladiatorForesight.Checked;
        }

        private void GladiatorSkullSunder_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorSkullSunder = GladiatorSkullSunder.Checked;
        }

        private void GladiatorFracture_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorFracture = GladiatorFracture.Checked;
        }

        private void GladiatorBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorBloodbath = GladiatorBloodbath.Checked;
        }

        private void GladiatorMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorMercyStroke = GladiatorMercyStroke.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void GladiatorFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorFeatherfoot = GladiatorFeatherfoot.Checked;
        }

        private void GladiatorSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorSecondWind = GladiatorSecondWind.Checked;
        }

        private void GladiatorHaymaker_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorHaymaker = GladiatorHaymaker.Checked;
        }

        private void GladiatorInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorInternalRelease = GladiatorInternalRelease.Checked;
        }

        private void GladiatorMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorMantra = GladiatorMantra.Checked;
        }

        #endregion

        #region Rogue Cross-Class

        private void GladiatorShadeShift_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorShadeShift = GladiatorShadeShift.Checked;
        }

        private void GladiatorGoad_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorGoad = GladiatorGoad.Checked;
        }

        private void GladiatorDeathBlossom_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorDeathBlossom = GladiatorDeathBlossom.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void GladiatorSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorSurecast = GladiatorSurecast.Checked;
        }

        private void GladiatorSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorSwiftcast = GladiatorSwiftcast.Checked;
        }

        #endregion

        private void GladiatorShieldSwipe_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.GladiatorShieldSwipe = GladiatorShieldSwipe.Checked;
        }

        #endregion

        #region Lancer Settings

        #region Arcanist Cross-Class

        private void LancerPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerPhysick = LancerPhysick.Checked;
        }

        private void LancerVirus_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerVirus = LancerVirus.Checked;
        }

        private void LancerEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerEyeForAnEye = LancerEyeForAnEye.Checked;
        }

        #endregion

        #region Archer Cross-Class

        private void LancerStraightShot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerStraightShot = LancerStraightShot.Checked;
        }

        private void LancerRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerRagingStrikes = LancerRagingStrikes.Checked;
        }

        private void LancerVenomousBite_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerVenomousBite = LancerVenomousBite.Checked;
        }

        private void LancerHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerHawksEye = LancerHawksEye.Checked;
        }

        private void LancerQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerQuellingStrikes = LancerQuellingStrikes.Checked;
        }

        #endregion

        #region Conjurer Cross-Class

        private void LancerCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerCure = LancerCure.Checked;
        }

        private void LancerProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerProtect = LancerProtect.Checked;
        }

        private void LancerRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerRaise = LancerRaise.Checked;
        }

        private void LancerStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerStoneskin = LancerStoneskin.Checked;
        }

        #endregion

        #region Gladiator Cross-Class

        private void LancerSavageBlade_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerSavageBlade = LancerSavageBlade.Checked;
        }

        private void LancerFlash_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerFlash = LancerFlash.Checked;
        }

        private void LancerConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerConvalescence = LancerConvalescence.Checked;
        }

        private void LancerProvoke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerProvoke = LancerProvoke.Checked;
        }

        private void LancerAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerAwareness = LancerAwareness.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void LancerForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerForesight = LancerForesight.Checked;
        }

        private void LancerSkullSunder_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerSkullSunder = LancerSkullSunder.Checked;
        }

        private void LancerFracture_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerFracture = LancerFracture.Checked;
        }

        private void LancerBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerBloodbath = LancerBloodbath.Checked;
        }

        private void LancerMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerMercyStroke = LancerMercyStroke.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void LancerFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerFeatherfoot = LancerFeatherfoot.Checked;
        }

        private void LancerSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerSecondWind = LancerSecondWind.Checked;
        }

        private void LancerHaymaker_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerHaymaker = LancerHaymaker.Checked;
        }

        private void LancerInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerInternalRelease = LancerInternalRelease.Checked;
        }

        private void LancerMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerMantra = LancerMantra.Checked;
        }

        #endregion

        #region Rogue Cross-Class

        private void LancerShadeShift_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerShadeShift = LancerShadeShift.Checked;
        }

        private void LancerGoad_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerGoad = LancerGoad.Checked;
        }

        private void LancerDeathBlossom_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerDeathBlossom = LancerDeathBlossom.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void LancerSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerSurecast = LancerSurecast.Checked;
        }

        private void LancerSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerSwiftcast = LancerSwiftcast.Checked;
        }

        #endregion

        private void LancerLegSweep_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.LancerLegSweep = LancerLegSweep.Checked;
        }

        #endregion

        #region Marauder Settings

        #region Arcanist Cross-Class

        private void MarauderPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderPhysick = MarauderPhysick.Checked;
        }

        private void MarauderVirus_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderVirus = MarauderVirus.Checked;
        }

        private void MarauderEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderEyeForAnEye = MarauderEyeForAnEye.Checked;
        }

        #endregion

        #region Archer Cross-Class

        private void MarauderStraightShot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderStraightShot = MarauderStraightShot.Checked;
        }

        private void MarauderRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderRagingStrikes = MarauderRagingStrikes.Checked;
        }

        private void MarauderVenomousBite_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderVenomousBite = MarauderVenomousBite.Checked;
        }

        private void MarauderHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderHawksEye = MarauderHawksEye.Checked;
        }

        private void MarauderQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderQuellingStrikes = MarauderQuellingStrikes.Checked;
        }

        #endregion

        #region Conjurer Cross-Class

        private void MarauderCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderCure = MarauderCure.Checked;
        }

        private void MarauderProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderProtect = MarauderProtect.Checked;
        }

        private void MarauderRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderRaise = MarauderRaise.Checked;
        }

        private void MarauderStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderStoneskin = MarauderStoneskin.Checked;
        }

        #endregion

        #region Gladiator Cross-Class

        private void MarauderSavageBlade_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderSavageBlade = MarauderSavageBlade.Checked;
        }

        private void MarauderFlash_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderFlash = MarauderFlash.Checked;
        }

        private void MarauderConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderConvalescence = MarauderConvalescence.Checked;
        }

        private void MarauderProvoke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderProvoke = MarauderProvoke.Checked;
        }

        private void MarauderAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderAwareness = MarauderAwareness.Checked;
        }

        #endregion

        #region Lancer Cross-Class

        private void MarauderFeint_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderFeint = MarauderFeint.Checked;
        }

        private void MarauderKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderKeenFlurry = MarauderKeenFlurry.Checked;
        }

        private void MarauderInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderInvigorate = MarauderInvigorate.Checked;
        }

        private void MarauderBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderBloodForBlood = MarauderBloodForBlood.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void MarauderFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderFeatherfoot = MarauderFeatherfoot.Checked;
        }

        private void MarauderSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderSecondWind = MarauderSecondWind.Checked;
        }

        private void MarauderHaymaker_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderHaymaker = MarauderHaymaker.Checked;
        }

        private void MarauderInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderInternalRelease = MarauderInternalRelease.Checked;
        }

        private void MarauderMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderMantra = MarauderMantra.Checked;
        }

        #endregion

        #region Rogue Cross-Class

        private void MarauderShadeShift_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderShadeShift = MarauderShadeShift.Checked;
        }

        private void MarauderGoad_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderGoad = MarauderGoad.Checked;
        }

        private void MarauderDeathBlossom_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderDeathBlossom = MarauderDeathBlossom.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void MarauderSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderSurecast = MarauderSurecast.Checked;
        }

        private void MarauderSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderSwiftcast = MarauderSwiftcast.Checked;
        }

        #endregion

        private void MarauderBrutalSwing_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderBrutalSwing = MarauderBrutalSwing.Checked;
        }

        private void MarauderMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MarauderMercyStroke = MarauderMercyStroke.Checked;
        }

        #endregion

        #region Pugilist Settings

        #region Arcanist Cross-Class

        private void PugilistPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistPhysick = PugilistPhysick.Checked;
        }

        private void PugilistVirus_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistVirus = PugilistVirus.Checked;
        }

        private void PugilistEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistEyeForAnEye = PugilistEyeForAnEye.Checked;
        }

        #endregion

        #region Archer Cross-Class

        private void PugilistStraightShot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistStraightShot = PugilistStraightShot.Checked;
        }

        private void PugilistRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistRagingStrikes = PugilistRagingStrikes.Checked;
        }

        private void PugilistVenomousBite_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistVenomousBite = PugilistVenomousBite.Checked;
        }

        private void PugilistHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistHawksEye = PugilistHawksEye.Checked;
        }

        private void PugilistQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistQuellingStrikes = PugilistQuellingStrikes.Checked;
        }

        #endregion

        #region Conjurer Cross-Class

        private void PugilistCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistCure = PugilistCure.Checked;
        }

        private void PugilistProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistProtect = PugilistProtect.Checked;
        }

        private void PugilistRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistRaise = PugilistRaise.Checked;
        }

        private void PugilistStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistStoneskin = PugilistStoneskin.Checked;
        }

        #endregion

        #region Gladiator Cross-Class

        private void PugilistSavageBlade_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistSavageBlade = PugilistSavageBlade.Checked;
        }

        private void PugilistFlash_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistFlash = PugilistFlash.Checked;
        }

        private void PugilistConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistConvalescence = PugilistConvalescence.Checked;
        }

        private void PugilistProvoke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistProvoke = PugilistProvoke.Checked;
        }

        private void PugilistAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistAwareness = PugilistAwareness.Checked;
        }

        #endregion

        #region Lancer Cross-Class

        private void PugilistFeint_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistFeint = PugilistFeint.Checked;
        }

        private void PugilistKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistKeenFlurry = PugilistKeenFlurry.Checked;
        }

        private void PugilistInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistInvigorate = PugilistInvigorate.Checked;
        }

        private void PugilistBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistBloodForBlood = PugilistBloodForBlood.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void PugilistForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistForesight = PugilistForesight.Checked;
        }

        private void PugilistSkullSunder_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistSkullSunder = PugilistSkullSunder.Checked;
        }

        private void PugilistFracture_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistFracture = PugilistFracture.Checked;
        }

        private void PugilistBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistBloodbath = PugilistBloodbath.Checked;
        }

        private void PugilistMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistMercyStroke = PugilistMercyStroke.Checked;
        }

        #endregion

        #region Rogue Cross-Class

        private void PugilistShadeShift_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistShadeShift = PugilistShadeShift.Checked;
        }

        private void PugilistGoad_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistGoad = PugilistGoad.Checked;
        }

        private void PugilistDeathBlossom_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistDeathBlossom = PugilistDeathBlossom.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void PugilistSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistSurecast = PugilistSurecast.Checked;
        }

        private void PugilistSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistSwiftcast = PugilistSwiftcast.Checked;
        }

        #endregion

        private void PugilistPerfectBalance_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistPerfectBalance = PugilistPerfectBalance.Checked;
        }
        private void PugilistFistsOfEarth_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistFistsOfEarth = PugilistFistsOfEarth.Checked;
        }

        private void PugilistFistsOfWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PugilistFistsOfWind = PugilistFistsOfWind.Checked;
        }

        #endregion

        #region Rogue Settings

        #region Arcanist Cross-Class

        private void RoguePhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RoguePhysick = RoguePhysick.Checked;
        }

        private void RogueVirus_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueVirus = RogueVirus.Checked;
        }

        private void RogueEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueEyeForAnEye = RogueEyeForAnEye.Checked;
        }

        #endregion

        #region Archer Cross-Class

        private void RogueStraightShot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueStraightShot = RogueStraightShot.Checked;
        }

        private void RogueRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueRagingStrikes = RogueRagingStrikes.Checked;
        }

        private void RogueVenomousBite_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueVenomousBite = RogueVenomousBite.Checked;
        }

        private void RogueHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueHawksEye = RogueHawksEye.Checked;
        }

        private void RogueQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueQuellingStrikes = RogueQuellingStrikes.Checked;
        }

        #endregion

        #region Conjurer Cross-Class

        private void RogueCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueCure = RogueCure.Checked;
        }

        private void RogueProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueProtect = RogueProtect.Checked;
        }

        private void RogueRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueRaise = RogueRaise.Checked;
        }

        private void RogueStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueStoneskin = RogueStoneskin.Checked;
        }

        #endregion

        #region Gladiator Cross-Class

        private void RogueSavageBlade_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueSavageBlade = RogueSavageBlade.Checked;
        }

        private void RogueFlash_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueFlash = RogueFlash.Checked;
        }

        private void RogueConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueConvalescence = RogueConvalescence.Checked;
        }

        private void RogueProvoke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueProvoke = RogueProvoke.Checked;
        }

        private void RogueAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueAwareness = RogueAwareness.Checked;
        }

        #endregion

        #region Lancer Cross-Class

        private void RogueFeint_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueFeint = RogueFeint.Checked;
        }

        private void RogueKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueKeenFlurry = RogueKeenFlurry.Checked;
        }

        private void RogueInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueInvigorate = RogueInvigorate.Checked;
        }

        private void RogueBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueBloodForBlood = RogueBloodForBlood.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void RogueForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueForesight = RogueForesight.Checked;
        }

        private void RogueSkullSunder_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueSkullSunder = RogueSkullSunder.Checked;
        }

        private void RogueFracture_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueFracture = RogueFracture.Checked;
        }

        private void RogueBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueBloodbath = RogueBloodbath.Checked;
        }

        private void RogueMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueMercyStroke = RogueMercyStroke.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void RogueFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueFeatherfoot = RogueFeatherfoot.Checked;
        }

        private void RogueSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueSecondWind = RogueSecondWind.Checked;
        }

        private void RogueHaymaker_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueHaymaker = RogueHaymaker.Checked;
        }

        private void RogueInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueInternalRelease = RogueInternalRelease.Checked;
        }

        private void RogueMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueMantra = RogueMantra.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void RogueSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueSurecast = RogueSurecast.Checked;
        }

        private void RogueSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueSwiftcast = RogueSwiftcast.Checked;
        }

        #endregion

        private void RogueJugulate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueJugulate = RogueJugulate.Checked;
        }

        private void RogueAssassinate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueAssassinate = RogueAssassinate.Checked;
        }

        private void RogueDancingEdge_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueDancingEdge = RogueDancingEdge.Checked;
        }
        private void RogueKissOfTheWasp_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueKissOfTheWasp = RogueKissOfTheWasp.Checked;
        }

        private void RogueKissOfTheViper_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueKissOfTheViper = RogueKissOfTheViper.Checked;
        }

        private void RogueGoad_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.RogueGoad = RogueGoad.Checked;
        }

        #endregion

        #region Thaumaturge Settings

        #region Arcanist Cross-Class

        private void ThaumaturgeRuin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeRuin = ThaumaturgeRuin.Checked;
        }

        private void ThaumaturgePhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgePhysick = ThaumaturgePhysick.Checked;
        }

        private void ThaumaturgeVirus_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeVirus = ThaumaturgeVirus.Checked;
        }

        private void ThaumaturgeEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeEyeForAnEye = ThaumaturgeEyeForAnEye.Checked;
        }

        #endregion

        #region Archer Cross-Class

        private void ThaumaturgeRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeRagingStrikes = ThaumaturgeRagingStrikes.Checked;
        }

        private void ThaumaturgeHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeHawksEye = ThaumaturgeHawksEye.Checked;
        }

        private void ThaumaturgeQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeQuellingStrikes = ThaumaturgeQuellingStrikes.Checked;
        }

        #endregion

        #region Conjurer Cross-Class

        private void ThaumaturgeCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeCure = ThaumaturgeCure.Checked;
        }

        private void ThaumaturgeAero_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeAero = ThaumaturgeAero.Checked;
        }

        private void ThaumaturgeProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeProtect = ThaumaturgeProtect.Checked;
        }

        private void ThaumaturgeRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeRaise = ThaumaturgeRaise.Checked;
        }

        private void ThaumaturgeStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeStoneskin = ThaumaturgeStoneskin.Checked;
        }

        #endregion

        #region Gladiator Cross-Class

        private void ThaumaturgeFlash_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeFlash = ThaumaturgeFlash.Checked;
        }

        private void ThaumaturgeConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeConvalescence = ThaumaturgeConvalescence.Checked;
        }

        private void ThaumaturgeProvoke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeProvoke = ThaumaturgeProvoke.Checked;
        }

        private void ThaumaturgeAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeAwareness = ThaumaturgeAwareness.Checked;
        }

        #endregion

        #region Lancer Cross-Class

        private void ThaumaturgeKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeKeenFlurry = ThaumaturgeKeenFlurry.Checked;
        }

        private void ThaumaturgeInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeInvigorate = ThaumaturgeInvigorate.Checked;
        }

        private void ThaumaturgeBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeBloodForBlood = ThaumaturgeBloodForBlood.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void ThaumaturgeForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeForesight = ThaumaturgeForesight.Checked;
        }

        private void ThaumaturgeBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeBloodbath = ThaumaturgeBloodbath.Checked;
        }

        private void ThaumaturgeMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeMercyStroke = ThaumaturgeMercyStroke.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void ThaumaturgeFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeFeatherfoot = ThaumaturgeFeatherfoot.Checked;
        }

        private void ThaumaturgeSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeSecondWind = ThaumaturgeSecondWind.Checked;
        }

        private void ThaumaturgeInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeInternalRelease = ThaumaturgeInternalRelease.Checked;
        }

        private void ThaumaturgeMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ThaumaturgeMantra = ThaumaturgeMantra.Checked;
        }

        #endregion

        #endregion

        #endregion

        #region Job Settings

        #region Astrologian Settings

        #region Conjurer Cross-Class

        private void AstrologianCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianCure = AstrologianCure.Checked;
        }

        private void AstrologianAero_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianAero = AstrologianAero.Checked;
        }

        private void AstrologianClericStance_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianClericStance = AstrologianClericStance.Checked;
        }

        private void AstrologianProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianProtect = AstrologianProtect.Checked;
        }

        private void AstrologianRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianRaise = AstrologianRaise.Checked;
        }

        private void AstrologianStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianStoneskin = AstrologianStoneskin.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void AstrologianSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianSurecast = AstrologianSurecast.Checked;
        }

        private void AstrologianBlizzardII_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianBlizzardII = AstrologianBlizzardII.Checked;
        }

        private void AstrologianSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianSwiftcast = AstrologianSwiftcast.Checked;
        }

        #endregion

        private void AstrologianBenefic_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianBenefic = AstrologianBenefic.Checked;
        }

        private void AstrologianBeneficII_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianBeneficII = AstrologianBeneficII.Checked;
        }

        private void AstrologianAspectedBenefic_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianAspectedBenefic = AstrologianAspectedBenefic.Checked;
        }

        private void AstrologianEssentialDignity_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianEssentialDignity = AstrologianEssentialDignity.Checked;
        }

        private void AstrologianDraw_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.AstrologianDraw = AstrologianDraw.Checked;
        }

        #endregion

        #region Bard Settings

        #region Lancer Cross-Class

        private void BardFeint_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardFeint = BardFeint.Checked;
        }

        private void BardKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardKeenFlurry = BardKeenFlurry.Checked;
        }

        private void BardInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardInvigorate = BardInvigorate.Checked;
        }

        private void BardBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardBloodForBlood = BardBloodForBlood.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void BardFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardFeatherfoot = BardFeatherfoot.Checked;
        }

        private void BardSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardSecondWind = BardSecondWind.Checked;
        }

        private void BardHaymaker_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardHaymaker = BardHaymaker.Checked;
        }

        private void BardInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardInternalRelease = BardInternalRelease.Checked;
        }

        private void BardMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardMantra = BardMantra.Checked;
        }

        #endregion

        private void BardBluntArrow_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardBluntArrow = BardBluntArrow.Checked;
        }

        private void BardMiserysEnd_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardMiserysEnd = BardMiserysEnd.Checked;
        }

        private void BardTheWanderersMinuet_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardTheWanderersMinuet = BardTheWanderersMinuet.Checked;
        }

        private void BardFlamingArrow_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BardFlamingArrow = BardFlamingArrow.Checked;
        }

        #endregion

        #region Black Mage Settings

        #region Arcanist Cross-Class

        private void BlackMageRuin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BlackMageRuin = BlackMageRuin.Checked;
        }

        private void BlackMagePhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BlackMagePhysick = BlackMagePhysick.Checked;
        }

        private void BlackMageVirus_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BlackMageVirus = BlackMageVirus.Checked;
        }

        private void BlackMageEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BlackMageEyeForAnEye = BlackMageEyeForAnEye.Checked;
        }

        #endregion

        #region Archer Cross-Class

        private void BlackMageRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BlackMageRagingStrikes = BlackMageRagingStrikes.Checked;
        }

        private void BlackMageHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BlackMageHawksEye = BlackMageHawksEye.Checked;
        }

        private void BlackMageQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.BlackMageQuellingStrikes = BlackMageQuellingStrikes.Checked;
        }

        #endregion

        #endregion

        #region Dark Knight Settings

        #region Gladiator Cross-Class

        private void DarkKnightSavageBlade_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightSavageBlade = DarkKnightSavageBlade.Checked;
        }

        private void DarkKnightFlash_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightFlash = DarkKnightFlash.Checked;
        }

        private void DarkKnightConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightConvalescence = DarkKnightConvalescence.Checked;
        }

        private void DarkKnightProvoke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightProvoke = DarkKnightProvoke.Checked;
        }

        private void DarkKnightAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightAwareness = DarkKnightAwareness.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void DarkKnightForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightForesight = DarkKnightForesight.Checked;
        }

        private void DarkKnightSkullSunder_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightSkullSunder = DarkKnightSkullSunder.Checked;
        }

        private void DarkKnightFracture_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightFracture = DarkKnightFracture.Checked;
        }

        private void DarkKnightBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightBloodbath = DarkKnightBloodbath.Checked;
        }

        private void DarkKnightMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightMercyStroke = DarkKnightMercyStroke.Checked;
        }

        #endregion

        private void DarkKnightBloodWeapon_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightBloodWeapon = DarkKnightBloodWeapon.Checked;
        }

        private void DarkKnightDarkArts_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightDarkArts = DarkKnightDarkArts.Checked;
        }

        private void DarkKnightReprisal_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightReprisal = DarkKnightReprisal.Checked;
        }

        private void DarkKnightDelirium_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightDelirium = DarkKnightDelirium.Checked;
        }

        private void DarkKnightPlunge_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightPlunge = DarkKnightPlunge.Checked;
        }

        private void DarkKnightLowBlow_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightLowBlow = DarkKnightLowBlow.Checked;
        }

        private void DarkKnightSaltedEarth_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DarkKnightSaltedEarth = DarkKnightSaltedEarth.Checked;
        }

        #endregion

        #region Dragoon Settings

        #region Marauder Cross-Class

        private void DragoonForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonForesight = DragoonForesight.Checked;
        }

        private void DragoonSkullSunder_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonSkullSunder = DragoonSkullSunder.Checked;
        }

        private void DragoonFracture_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonFracture = DragoonFracture.Checked;
        }

        private void DragoonBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonBloodbath = DragoonBloodbath.Checked;
        }

        private void DragoonMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonMercyStroke = DragoonMercyStroke.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void DragoonFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonFeatherfoot = DragoonFeatherfoot.Checked;
        }

        private void DragoonSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonSecondWind = DragoonSecondWind.Checked;
        }

        private void DragoonHaymaker_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonHaymaker = DragoonHaymaker.Checked;
        }

        private void DragoonInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonInternalRelease = DragoonInternalRelease.Checked;
        }

        private void DragoonMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonMantra = DragoonMantra.Checked;
        }

        #endregion

        private void DragoonLegSweep_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonLegSweep = DragoonLegSweep.Checked;
        }

        private void DragoonJump_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonJump = DragoonJump.Checked;
        }

        private void DragoonSpineshatterDive_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonSpineshatterDive = DragoonSpineshatterDive.Checked;
        }

        private void DragoonPowerSurge_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonPowerSurge = DragoonPowerSurge.Checked;
        }

        private void DragoonDragonfireDive_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonDragonfireDive = DragoonDragonfireDive.Checked;
        }
        private void DragoonBattleLitany_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.DragoonBattleLitany = DragoonBattleLitany.Checked;
        }

        #endregion

        #region Machinist Settings

        #region Archer Cross-Class

        private void MachinistRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistRagingStrikes = MachinistRagingStrikes.Checked;
        }

        private void MachinistHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistHawksEye = MachinistHawksEye.Checked;
        }

        private void MachinistQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistQuellingStrikes = MachinistQuellingStrikes.Checked;
        }

        #endregion

        #region Lancer Cross-Class

        private void MachinistFeint_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistFeint = MachinistFeint.Checked;
        }

        private void MachinistKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistKeenFlurry = MachinistKeenFlurry.Checked;
        }

        private void MachinistInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistInvigorate = MachinistInvigorate.Checked;
        }

        private void MachinistBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistBloodForBlood = MachinistBloodForBlood.Checked;
        }

        #endregion

        private void MachinistSummonTurret_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistSummonTurret = MachinistSummonTurret.Checked;
        }

        private void MachinistSummonTurretCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MachinistSummonTurretCombo.Text == @"Rook Autoturret")
            {
                Ultima.UltSettings.MachinistRook = true;
                Ultima.UltSettings.MachinistBishop = false;
            }

            if (MachinistSummonTurretCombo.Text == @"Bishop Autoturret")
            {
                Ultima.UltSettings.MachinistRook = false;
                Ultima.UltSettings.MachinistBishop = true;
            }
        }

        private void MachinistHeadGraze_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistHeadGraze = MachinistHeadGraze.Checked;
        }

        private void MachinistHypercharge_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistHypercharge = MachinistHypercharge.Checked;
        }

        private void MachinistBlank_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistBlank = MachinistBlank.Checked;
        }

        private void MachinistHeartbreak_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistHeartbreak = MachinistHeartbreak.Checked;
        }

        private void MachinistGaussBarrel_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MachinistGaussBarrel = MachinistGaussBarrel.Checked;
        }

        #endregion

        #region Monk Settings

        #region Lancer Cross-Class

        private void MonkFeint_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkFeint = MonkFeint.Checked;
        }

        private void MonkKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkKeenFlurry = MonkKeenFlurry.Checked;
        }

        private void MonkInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkInvigorate = MonkInvigorate.Checked;
        }

        private void MonkBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkBloodForBlood = MonkBloodForBlood.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void MonkForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkForesight = MonkForesight.Checked;
        }

        private void MonkSkullSunder_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkSkullSunder = MonkSkullSunder.Checked;
        }

        private void MonkFracture_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkFracture = MonkFracture.Checked;
        }

        private void MonkBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkBloodbath = MonkBloodbath.Checked;
        }

        private void MonkMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkMercyStroke = MonkMercyStroke.Checked;
        }

        #endregion

        private void MonkShoulderTackle_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkShoulderTackle = MonkShoulderTackle.Checked;
        }

        private void MonkPerfectBalance_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkPerfectBalance = MonkPerfectBalance.Checked;
        }
        private void MonkFistsOfEarth_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkFistsOfEarth = MonkFistsOfEarth.Checked;
        }

        private void MonkFistsOfWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkFistsOfWind = MonkFistsOfWind.Checked;
        }

        private void MonkFistsOfFire_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkFistsOfFire = MonkFistsOfFire.Checked;
        }

        private void MonkMeditation_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkMeditation = MonkMeditation.Checked;
        }

        private void MonkTheForbiddenChakra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkTheForbiddenChakra = MonkTheForbiddenChakra.Checked;
        }

        private void MonkElixirField_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.MonkElixirField = MonkElixirField.Checked;
        }

        #endregion

        #region Ninja Settings

        #region Lancer Cross-Class

        private void NinjaFeint_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaFeint = NinjaFeint.Checked;
        }

        private void NinjaKeenFlurry_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaKeenFlurry = NinjaKeenFlurry.Checked;
        }

        private void NinjaInvigorate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaInvigorate = NinjaInvigorate.Checked;
        }

        private void NinjaBloodForBlood_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaBloodForBlood = NinjaBloodForBlood.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void NinjaFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaFeatherfoot = NinjaFeatherfoot.Checked;
        }

        private void NinjaSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaSecondWind = NinjaSecondWind.Checked;
        }

        private void NinjaHaymaker_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaHaymaker = NinjaHaymaker.Checked;
        }

        private void NinjaInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaInternalRelease = NinjaInternalRelease.Checked;
        }

        private void NinjaMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaMantra = NinjaMantra.Checked;
        }

        #endregion

        private void NinjaShukuchi_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaShukuchi = NinjaShukuchi.Checked;
        }

        private void NinjaJugulate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaJugulate = NinjaJugulate.Checked;
        }

        private void NinjaAssassinate_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaAssassinate = NinjaAssassinate.Checked;
        }

        private void NinjaRaiton_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaRaiton = NinjaRaiton.Checked;
        }

        private void NinjaFumaShuriken_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaFumaShuriken = NinjaFumaShuriken.Checked;
        }

        private void NinjaDancingEdge_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaDancingEdge = NinjaDancingEdge.Checked;
        }

        private void NinjaKissOfTheWasp_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaKissOfTheWasp = NinjaKissOfTheWasp.Checked;
        }

        private void NinjaKissOfTheViper_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaKissOfTheViper = NinjaKissOfTheViper.Checked;
        }

        private void NinjaGoad_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaGoad = NinjaGoad.Checked;
        }

        private void NinjaDreamWithinADream_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.NinjaDreamWithinADream = NinjaDreamWithinADream.Checked;
        }

        #endregion

        #region Paladin Settings

        #region Conjurer Cross-Class

        private void PaladinCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinCure = PaladinCure.Checked;
        }

        private void PaladinProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinProtect = PaladinProtect.Checked;
        }

        private void PaladinRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinRaise = PaladinRaise.Checked;
        }

        private void PaladinStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinStoneskin = PaladinStoneskin.Checked;
        }

        #endregion

        #region Marauder Cross-Class

        private void PaladinForesight_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinForesight = PaladinForesight.Checked;
        }

        private void PaladinSkullSunder_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinSkullSunder = PaladinSkullSunder.Checked;
        }

        private void PaladinFracture_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinFracture = PaladinFracture.Checked;
        }

        private void PaladinBloodbath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinBloodbath = PaladinBloodbath.Checked;
        }

        private void PaladinMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinMercyStroke = PaladinMercyStroke.Checked;
        }

        #endregion

        private void PaladinShieldSwipe_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinShieldSwipe = PaladinShieldSwipe.Checked;
        }

        private void PaladinSpiritsWithin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinSpiritsWithin = PaladinSpiritsWithin.Checked;
        }

        private void PaladinSwordOath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinSwordOath = PaladinSwordOath.Checked;
        }

        private void PaladinShieldOath_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.PaladinShieldOath = PaladinShieldOath.Checked;
        }

        #endregion

        #region Scholar Settings

        #region Conjurer Cross-Class

        private void ScholarCure_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarCure = ScholarCure.Checked;
        }

        private void ScholarAero_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarAero = ScholarAero.Checked;
        }

        private void ScholarClericStance_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarClericStance = ScholarClericStance.Checked;
        }

        private void ScholarProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarProtect = ScholarProtect.Checked;
        }

        private void ScholarRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarRaise = ScholarRaise.Checked;
        }

        private void ScholarStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarStoneskin = ScholarStoneskin.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void ScholarSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarSurecast = ScholarSurecast.Checked;
        }

        private void ScholarBlizzardII_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarBlizzardII = ScholarBlizzardII.Checked;
        }

        private void ScholarSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarSwiftcast = ScholarSwiftcast.Checked;
        }

        #endregion

        private void ScholarSummonPet_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarSummonPet = ScholarSummonPet.Checked;
        }

        private void ScholarSummonPetCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScholarSummonPetCombo.Text == @"Eos")
            {
                Ultima.UltSettings.ScholarEos = true;
                Ultima.UltSettings.ScholarSelene = false;
            }

            if (ScholarSummonPetCombo.Text == @"Selene")
            {
                Ultima.UltSettings.ScholarEos = false;
                Ultima.UltSettings.ScholarSelene = true;
            }
        }
        private void ScholarPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarPhysick = ScholarPhysick.Checked;
        }


        private void ScholarAdloquium_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.ScholarAdloquium = ScholarAdloquium.Checked;
        }

        #endregion

        #region Summoner Settings

        #region Archer Cross-Class

        private void SummonerRagingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.SummonerRagingStrikes = SummonerRagingStrikes.Checked;
        }

        private void SummonerHawksEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.SummonerHawksEye = SummonerHawksEye.Checked;
        }

        private void SummonerQuellingStrikes_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.SummonerQuellingStrikes = SummonerQuellingStrikes.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void SummonerSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.SummonerSurecast = SummonerSurecast.Checked;
        }

        private void SummonerBlizzardII_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.SummonerBlizzardII = SummonerBlizzardII.Checked;
        }

        private void SummonerSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.SummonerSwiftcast = SummonerSwiftcast.Checked;
        }

        #endregion

        private void SummonerSummonPet_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.SummonerSummonPet = SummonerSummonPet.Checked;
        }

        private void SummonerSummonPetCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SummonerSummonPetCombo.Text == @"Garuda-Egi")
            {
                Ultima.UltSettings.SummonerGaruda = true;
                Ultima.UltSettings.SummonerTitan = false;
                Ultima.UltSettings.SummonerIfrit = false;
            }

            if (SummonerSummonPetCombo.Text == @"Titan-Egi")
            {
                Ultima.UltSettings.SummonerGaruda = false;
                Ultima.UltSettings.SummonerTitan = true;
                Ultima.UltSettings.SummonerIfrit = false;
            }

            if (SummonerSummonPetCombo.Text == @"Ifrit-Egi")
            {
                Ultima.UltSettings.SummonerGaruda = false;
                Ultima.UltSettings.SummonerTitan = false;
                Ultima.UltSettings.SummonerIfrit = true;
            }
        }

        private void SummonerPhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.SummonerPhysick = SummonerPhysick.Checked;
        }

        #endregion

        #region Warrior Settings

        #region Gladiator Cross-Class

        private void WarriorSavageBlade_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorSavageBlade = WarriorSavageBlade.Checked;
        }

        private void WarriorFlash_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorFlash = WarriorFlash.Checked;
        }

        private void WarriorConvalescence_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorConvalescence = WarriorConvalescence.Checked;
        }

        private void WarriorProvoke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorProvoke = WarriorProvoke.Checked;
        }

        private void WarriorAwareness_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorAwareness = WarriorAwareness.Checked;
        }

        #endregion

        #region Pugilist Cross-Class

        private void WarriorFeatherfoot_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorFeatherfoot = WarriorFeatherfoot.Checked;
        }

        private void WarriorSecondWind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorSecondWind = WarriorSecondWind.Checked;
        }

        private void WarriorHaymaker_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorHaymaker = WarriorHaymaker.Checked;
        }

        private void WarriorInternalRelease_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorInternalRelease = WarriorInternalRelease.Checked;
        }

        private void WarriorMantra_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorMantra = WarriorMantra.Checked;
        }

        #endregion

        private void WarriorBrutalSwing_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorBrutalSwing = WarriorBrutalSwing.Checked;
        }

        private void WarriorMercyStroke_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WarriorMercyStroke = WarriorMercyStroke.Checked;
        }

        #endregion

        #region White Mage Settings

        #region Arcanist Cross-Class

        private void WhiteMageRuin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageRuin = WhiteMageRuin.Checked;
        }

        private void WhiteMagePhysick_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMagePhysick = WhiteMagePhysick.Checked;
        }

        private void WhiteMageVirus_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageVirus = WhiteMageVirus.Checked;
        }

        private void WhiteMageEyeForAnEye_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageEyeForAnEye = WhiteMageEyeForAnEye.Checked;
        }

        #endregion

        #region Thaumaturge Cross-Class

        private void WhiteMageSurecast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageSurecast = WhiteMageSurecast.Checked;
        }

        private void WhiteMageBlizzardII_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageBlizzardII = WhiteMageBlizzardII.Checked;
        }

        private void WhiteMageSwiftcast_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageSwiftcast = WhiteMageSwiftcast.Checked;
        }

        #endregion

        private void WhiteMageRaise_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageRaise = WhiteMageRaise.Checked;
        }

        private void WhiteMageBenediction_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageBenediction = WhiteMageBenediction.Checked;
        }

        private void WhiteMageTetragrammaton_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageTetragrammaton = WhiteMageTetragrammaton.Checked;
        }

        private void WhiteMageShroudOfSaints_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageShroudOfSaints = WhiteMageShroudOfSaints.Checked;
        }

        private void WhiteMagePresenceOfMind_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMagePresenceOfMind = WhiteMagePresenceOfMind.Checked;
        }

        private void WhiteMageDivineSeal_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageDivineSeal = WhiteMageDivineSeal.Checked;
        }

        private void WhiteMageProtect_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageProtect = WhiteMageProtect.Checked;
        }

        private void WhiteMageStoneskin_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageStoneskin = WhiteMageStoneskin.Checked;
        }

        private void WhiteMageStoneskinII_CheckedChanged(object sender, EventArgs e)
        {
            Ultima.UltSettings.WhiteMageStoneskinII = WhiteMageStoneskinII.Checked;
        }

        #endregion

        #endregion
    }
}