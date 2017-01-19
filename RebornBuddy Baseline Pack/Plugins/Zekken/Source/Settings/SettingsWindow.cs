using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ff14bot.Helpers;
using ProtoBuf;

namespace Zekken
{
    public partial class SettingsWindow : Form
    {
        private Dictionary<string, Image> images = new Dictionary<string, Image>();

        public SettingsWindow()
        {
            InitializeComponent();
        }

        #region Form Dragging

        private const int WmNclbuttondown = 0xA1;
        private const int HtCaption = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void WindowDrag(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
        }

        #endregion

        #region Compile Button
        private void CompileButtonHoverEnter(object sender, EventArgs e)
        {
            CompileButton.Image = images["CompileButtonHover"];
        }

        private void CompileButtonHoverExit(object sender, EventArgs e)
        {
            CompileButton.Image = images["CompileButtonNormal"];
        }

        private void CompileButtonReleased(object sender, MouseEventArgs e)
        {
            CompileButton.Image = images["CompileButtonHover"];
        }

        private void CompileButtonPressed(object sender, MouseEventArgs e)
        {
            CompileButton.Image = images["CompileButtonPressed"];
        }

        private void CompileButtonClick(object sender, EventArgs e)
        {
            if (Plugin.Enabled) { Plugin.UnhookAvoidance(); }

            ShapeCompiler.CompileShapes();

			Plugin.Database = new ShapeDatabase();
			
			if (!Plugin.Database.Load())
			{
				return;
			}
			
            if (Plugin.Enabled) { Plugin.HookAvoidance(); }
        }
        #endregion

        #region Exit Button
        private void ExitButtonHoverEnter(object sender, EventArgs e)
        {
            ExitButton.Image = images["ExitButtonHover"];
        }

        private void ExitButtonHoverExit(object sender, EventArgs e)
        {
            ExitButton.Image = images["ExitButtonNormal"];
        }

        private void ExitButtonClicked(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        public ZekkenPlugin Plugin { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FormBorderStyle = FormBorderStyle.None;

            foreach (var path in Directory.EnumerateFiles(Directories.DEFAULT_IMAGES_DIR, "*.png"))
            {
                var name = Path.GetFileNameWithoutExtension(path);
                if (name == null) { continue; }
                images[name] = Image.FromFile(path);
            }

            CompileButton.Image = images["CompileButtonNormal"];
            ExitButton.Image = images["ExitButtonNormal"];
            LogoImage.Image = images["Logo"];
            ZekkenImage.Image = images["ZekkenImageSmall"];
        }

        private void MultiAvoidanceCheckboxChanged(object sender, EventArgs e)
        {
            ZekkenPlugin.Settings.MultiAvoidanceEnabled = MultiAvoidanceCheckbox.Checked;
            Save(Directories.SETTINGS_PATH, ZekkenPlugin.Settings);
        }

        private void TargetedCheckboxChanged(object sender, EventArgs e)
        {
            ZekkenPlugin.Settings.TargetedOnTargetEnabled = TargetedCheckbox.Checked;
            Save(Directories.SETTINGS_PATH, ZekkenPlugin.Settings);
        }

        public static bool Save(string path, ZekkenSettings settings)
        {
			return FileTools.Save(path,settings,(stream,data)=>{Serializer.Serialize(stream, data);});
        }

        private void CircleFromMobCheckboxChanged(object sender, EventArgs e)
        {
            ZekkenPlugin.Settings.CircleFromCasterEnabled = CircleFromMobCheckbox.Checked;
            Save(Directories.SETTINGS_PATH, ZekkenPlugin.Settings);
        }
    }
}
