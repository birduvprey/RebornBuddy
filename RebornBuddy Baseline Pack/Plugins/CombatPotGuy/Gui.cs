using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ff14bot.Managers;

namespace CombatPotGuyPlugin
{
    public partial class Gui : Form
    {

        private static IEnumerable<string> HealthPotList()
        {
            return InventoryManager.FilledSlots.InventoryItems()
            .HealthMedicineItems()
            .Select(x => x.Item.EnglishName + "(HQ: " + x.Item.IsHighQuality.ToString() + ")");
        }

        private static IEnumerable<string> ManaPotList()
        {
            return InventoryManager.FilledSlots.InventoryItems()
            .ManaMedicineItems()
            .Select(x => x.Item.EnglishName + "(HQ: " + x.Item.IsHighQuality.ToString() + ")");
        }

        private static IEnumerable<string> TPPotList()
        {
            return InventoryManager.FilledSlots.InventoryItems()
            .TPMedicineItems()
            .Select(x => x.Item.EnglishName + "(HQ: " + x.Item.IsHighQuality.ToString() + ")");
        }

        public Gui()
        {
            InitializeComponent();

            var healthPots = HealthPotList().ToList();
            healthPots.Insert(0,"None");
            comboBoxHealth.DataSource = healthPots;

            /*
            comboBoxHealth.DataSource =
                InventoryManager.FilledSlots.InventoryItems()
                    .HealthMedicineItems()
                    .Select(x => x.Item.EnglishName + "(HQ: " + x.Item.IsHighQuality.ToString() + ")").ToList();
            comboBoxHealth.Items.Add("None");*/

            if (Settings.Instance.HealthMedicineName != null && comboBoxHealth.Items.Contains(Settings.Instance.HealthMedicineName))
            {
                comboBoxHealth.SelectedItem = Settings.Instance.HealthMedicineName;
            }
            else
            {
                comboBoxHealth.SelectedItem = "None";
                Settings.Instance.HealthMedicineName = null;
                Settings.Instance.Save();
            }
            /*
            if (
                InventoryManager.FilledSlots.InventoryItems()
                    .HealthMedicineItems()
                    .Select(x => x.Item.EnglishName)
                    .Contains(Settings.Instance.HealthMedicineName))
            {
                comboBoxHealth.SelectedItem = Settings.Instance.HealthMedicineName;
            }
            else
            {
                Settings.Instance.HealthMedicineName = null;
                Settings.Instance.Save();
            }*/

            var manaPots = ManaPotList().ToList();
            manaPots.Insert(0, "None");
            comboBoxMana.DataSource = manaPots;
            /*
            comboBoxMana.DataSource =
                InventoryManager.FilledSlots.InventoryItems()
                    .ManaMedicineItems()
                    .Select(x => x.Item.EnglishName + "(HQ: " + x.Item.IsHighQuality.ToString() + ")").ToList();
            comboBoxMana.Items.Add("None");*/

            if (Settings.Instance.ManaMedicineName != null && comboBoxMana.Items.Contains(Settings.Instance.ManaMedicineName))
            {
                comboBoxMana.SelectedItem = Settings.Instance.ManaMedicineName;
            }
            else
            {
                comboBoxMana.SelectedItem = "None";
                Settings.Instance.ManaMedicineName = null;
                Settings.Instance.Save();
            }
            /*
            var ManaMedicineName = InventoryManager.FilledSlots.InventoryItems()
                    .ManaMedicineItems()
                    .FirstOrDefault(x => x.Item.EnglishName == (Settings.Instance.ManaMedicineName));

            if (
                InventoryManager.FilledSlots.InventoryItems()
                    .ManaMedicineItems()
                    .Select(x => x.Item.EnglishName)
                    .Contains(Settings.Instance.ManaMedicineName))
            {
                comboBoxMana.SelectedValue = Settings.Instance.ManaMedicineName;//ManaMedicineName;
            }
            else
            {
                //comboBoxMana.SelectedValue = null;
                Settings.Instance.ManaMedicineName = null;
                Settings.Instance.Save();
            }*/

            var tpPots = TPPotList().ToList();
            tpPots.Insert(0, "None");
            comboBoxTP.DataSource = tpPots;
            /*
            comboBoxTP.DataSource =
                InventoryManager.FilledSlots.InventoryItems()
                    .TPMedicineItems()
                    .Select(x => x.Item.EnglishName + "(HQ: " + x.Item.IsHighQuality.ToString() + ")").ToList();
            comboBoxTP.Items.Add("None");*/

            if (Settings.Instance.TPMedicineName != null && comboBoxTP.Items.Contains(Settings.Instance.TPMedicineName))
            {
                comboBoxTP.SelectedItem = Settings.Instance.TPMedicineName;
            }
            else
            {
                comboBoxTP.SelectedItem = "None";
                Settings.Instance.TPMedicineName = null;
                Settings.Instance.Save();
            }

            checkBoxHealth.Checked = Settings.Instance.UseHealthMedicine;
            checkBoxMana.Checked = Settings.Instance.UseManaMedicine;
            checkBoxTP.Checked = Settings.Instance.UseTPMedicine;
            HealthThresholdUpDown.Value = (decimal)Settings.Instance.HealthThreshold;
            ManaThresholdUpDown.Value = (decimal)Settings.Instance.ManaThreshold;
            TPThresholdUpDown.Value = (decimal)Settings.Instance.TPThreshold;
        }

        private void comboBoxHealth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Settings.Instance.HealthMedicineName = comboBoxHealth.SelectedValue.ToString();
            if (Settings.Instance.HealthMedicineName == "None") { Settings.Instance.HealthMedicineName = null; }
            Settings.Instance.Save();
        }

        private void comboBoxMana_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Settings.Instance.ManaMedicineName = comboBoxMana.SelectedValue.ToString();
            if (Settings.Instance.ManaMedicineName == "None") { Settings.Instance.ManaMedicineName = null; }
            Settings.Instance.Save();
        }

        private void comboBoxTP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Settings.Instance.TPMedicineName = comboBoxTP.SelectedValue.ToString();
            if (Settings.Instance.TPMedicineName == "None") { Settings.Instance.TPMedicineName = null; }
            Settings.Instance.Save();
        }

        private void checkBoxHealth_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.UseHealthMedicine = checkBoxHealth.Checked;
            Settings.Instance.Save();
        }

        private void checkBoxMana_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.UseManaMedicine = checkBoxMana.Checked;
            Settings.Instance.Save();
        }

        private void checkBoxTP_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.UseTPMedicine = checkBoxTP.Checked;
            Settings.Instance.Save();
        }

        private void HealthThresholdUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Instance.HealthThreshold = (float)HealthThresholdUpDown.Value;
            Settings.Instance.Save();
        }

        private void ManaThresholdUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Instance.ManaThreshold = (float)ManaThresholdUpDown.Value;
            Settings.Instance.Save();
        }

        private void TPThresholdUpDown_ValueChanged(object sender, EventArgs e)
        {
            Settings.Instance.TPThreshold = (float)TPThresholdUpDown.Value;
            Settings.Instance.Save();
        }

        private void comboBoxHealth_DropDown(object sender, EventArgs e)
        {
            comboBoxHealth.DataSource = null;
            var healthPots = HealthPotList().ToList();
            healthPots.Insert(0, "None");
            comboBoxHealth.DataSource = healthPots;
        }

        private void comboBoxMana_DropDown(object sender, EventArgs e)
        {
            comboBoxMana.DataSource = null;
            var manaPots = ManaPotList().ToList();
            manaPots.Insert(0, "None");
            comboBoxMana.DataSource = manaPots;
        }

        private void comboBoxTP_DragDrop(object sender, DragEventArgs e)
        {
            comboBoxTP.DataSource = null;
            var tpPots = TPPotList().ToList();
            tpPots.Insert(0, "None");
            comboBoxTP.DataSource = tpPots;
        }
    }
}