using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalHunter.Settings
{
    public partial class CrystalHunterSettingsForm : Form
    {
        public CrystalHunterSettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = CrystalHunter.settings;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CrystalHunter.settings.Save();
			CrystalHunter.LoadSettings();
        }
    }
}