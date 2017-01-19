using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ff14bot.Managers;

namespace CompanyManualGuyPlugin
{
    public partial class Gui : Form
    {

        private static IEnumerable<string> companyManualList()
        {
            return InventoryManager.FilledSlots.InventoryItems()
            .CompanyManualItems()
            .Select(x => x.Item.EnglishName + "(HQ: " + x.Item.IsHighQuality.ToString() + ")");
        }

        public Gui()
        {
            InitializeComponent();

            var CompanyManualItems = companyManualList().ToList();
            CompanyManualItems.Insert(0, "None");
            comboBox1.DataSource = CompanyManualItems;

            /*
            comboBox1.DataSource =
                InventoryManager.FilledSlots.InventoryItems()
                    .CompanyManualItems()
                    .Select(x => x.Item.EnglishName + "(HQ: " + x.Item.IsHighQuality.ToString() + ")").ToList();*/

            if (Settings.Instance.CompanyManualName != null && comboBox1.Items.Contains(Settings.Instance.CompanyManualName))
            {
                comboBox1.SelectedItem = Settings.Instance.CompanyManualName;
            }
            else
            {
                comboBox1.SelectedItem = "None";
                Settings.Instance.CompanyManualName = null;
                Settings.Instance.Save();
            }
            /*
            if (
                InventoryManager.FilledSlots.InventoryItems()
                    .CompanyManualItems()
                    .Select(x => x.Item.EnglishName)
                    .Contains(Settings.Instance.CompanyManualName))
            {
                comboBox1.SelectedText = Settings.Instance.CompanyManualName;
            }*/
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Settings.Instance.CompanyManualName = comboBox1.SelectedValue.ToString();
            if (Settings.Instance.CompanyManualName == "None") { Settings.Instance.CompanyManualName = null; }
            Settings.Instance.Save();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            var CompanyManualItems = companyManualList().ToList();
            CompanyManualItems.Insert(0, "None");
            comboBox1.DataSource = CompanyManualItems;
        }
    }
}