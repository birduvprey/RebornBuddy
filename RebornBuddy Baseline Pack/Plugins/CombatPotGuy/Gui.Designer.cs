namespace CombatPotGuyPlugin
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TPThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxTP = new System.Windows.Forms.CheckBox();
            this.comboBoxTP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ManaThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.HealthThresholdUpDown = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.checkBoxMana = new System.Windows.Forms.CheckBox();
            this.checkBoxHealth = new System.Windows.Forms.CheckBox();
            this.comboBoxMana = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxHealth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TPThresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManaThresholdUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthThresholdUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TPThresholdUpDown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkBoxTP);
            this.groupBox1.Controls.Add(this.comboBoxTP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ManaThresholdUpDown);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.HealthThresholdUpDown);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.checkBoxMana);
            this.groupBox1.Controls.Add(this.checkBoxHealth);
            this.groupBox1.Controls.Add(this.comboBoxMana);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxHealth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // TPThresholdUpDown
            // 
            this.TPThresholdUpDown.Location = new System.Drawing.Point(257, 166);
            this.TPThresholdUpDown.Name = "TPThresholdUpDown";
            this.TPThresholdUpDown.Size = new System.Drawing.Size(45, 20);
            this.TPThresholdUpDown.TabIndex = 36;
            this.TPThresholdUpDown.Visible = false;
            this.TPThresholdUpDown.ValueChanged += new System.EventHandler(this.TPThresholdUpDown_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "TP Percent to use Pot";
            this.label4.Visible = false;
            // 
            // checkBoxTP
            // 
            this.checkBoxTP.AutoSize = true;
            this.checkBoxTP.Location = new System.Drawing.Point(257, 147);
            this.checkBoxTP.Name = "checkBoxTP";
            this.checkBoxTP.Size = new System.Drawing.Size(87, 17);
            this.checkBoxTP.TabIndex = 34;
            this.checkBoxTP.Text = "Use TP Pot?";
            this.checkBoxTP.UseVisualStyleBackColor = true;
            this.checkBoxTP.Visible = false;
            this.checkBoxTP.CheckedChanged += new System.EventHandler(this.checkBoxTP_CheckedChanged);
            // 
            // comboBoxTP
            // 
            this.comboBoxTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTP.FormattingEnabled = true;
            this.comboBoxTP.ItemHeight = 13;
            this.comboBoxTP.Location = new System.Drawing.Point(7, 165);
            this.comboBoxTP.Name = "comboBoxTP";
            this.comboBoxTP.Size = new System.Drawing.Size(244, 21);
            this.comboBoxTP.TabIndex = 33;
            this.comboBoxTP.Visible = false;
            this.comboBoxTP.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTP_SelectionChangeCommitted);
            this.comboBoxTP.DragDrop += new System.Windows.Forms.DragEventHandler(this.comboBoxTP_DragDrop);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "TP Pot Name";
            this.label5.Visible = false;
            // 
            // ManaThresholdUpDown
            // 
            this.ManaThresholdUpDown.Location = new System.Drawing.Point(257, 101);
            this.ManaThresholdUpDown.Name = "ManaThresholdUpDown";
            this.ManaThresholdUpDown.Size = new System.Drawing.Size(45, 20);
            this.ManaThresholdUpDown.TabIndex = 31;
            this.ManaThresholdUpDown.ValueChanged += new System.EventHandler(this.ManaThresholdUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Mana Percent to use Pot";
            // 
            // HealthThresholdUpDown
            // 
            this.HealthThresholdUpDown.Location = new System.Drawing.Point(257, 38);
            this.HealthThresholdUpDown.Name = "HealthThresholdUpDown";
            this.HealthThresholdUpDown.Size = new System.Drawing.Size(45, 20);
            this.HealthThresholdUpDown.TabIndex = 29;
            this.HealthThresholdUpDown.ValueChanged += new System.EventHandler(this.HealthThresholdUpDown_ValueChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(308, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(129, 13);
            this.label22.TabIndex = 28;
            this.label22.Text = "Health Percent to use Pot";
            // 
            // checkBoxMana
            // 
            this.checkBoxMana.AutoSize = true;
            this.checkBoxMana.Location = new System.Drawing.Point(257, 82);
            this.checkBoxMana.Name = "checkBoxMana";
            this.checkBoxMana.Size = new System.Drawing.Size(100, 17);
            this.checkBoxMana.TabIndex = 5;
            this.checkBoxMana.Text = "Use Mana Pot?";
            this.checkBoxMana.UseVisualStyleBackColor = true;
            this.checkBoxMana.CheckedChanged += new System.EventHandler(this.checkBoxMana_CheckedChanged);
            // 
            // checkBoxHealth
            // 
            this.checkBoxHealth.AutoSize = true;
            this.checkBoxHealth.Location = new System.Drawing.Point(258, 20);
            this.checkBoxHealth.Name = "checkBoxHealth";
            this.checkBoxHealth.Size = new System.Drawing.Size(104, 17);
            this.checkBoxHealth.TabIndex = 4;
            this.checkBoxHealth.Text = "Use Health Pot?";
            this.checkBoxHealth.UseVisualStyleBackColor = true;
            this.checkBoxHealth.CheckedChanged += new System.EventHandler(this.checkBoxHealth_CheckedChanged);
            // 
            // comboBoxMana
            // 
            this.comboBoxMana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMana.FormattingEnabled = true;
            this.comboBoxMana.ItemHeight = 13;
            this.comboBoxMana.Location = new System.Drawing.Point(7, 100);
            this.comboBoxMana.Name = "comboBoxMana";
            this.comboBoxMana.Size = new System.Drawing.Size(244, 21);
            this.comboBoxMana.TabIndex = 3;
            this.comboBoxMana.DropDown += new System.EventHandler(this.comboBoxMana_DropDown);
            this.comboBoxMana.SelectionChangeCommitted += new System.EventHandler(this.comboBoxMana_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mana Pot Name";
            // 
            // comboBoxHealth
            // 
            this.comboBoxHealth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHealth.FormattingEnabled = true;
            this.comboBoxHealth.ItemHeight = 13;
            this.comboBoxHealth.Location = new System.Drawing.Point(7, 37);
            this.comboBoxHealth.Name = "comboBoxHealth";
            this.comboBoxHealth.Size = new System.Drawing.Size(244, 21);
            this.comboBoxHealth.TabIndex = 1;
            this.comboBoxHealth.DropDown += new System.EventHandler(this.comboBoxHealth_DropDown);
            this.comboBoxHealth.SelectionChangeCommitted += new System.EventHandler(this.comboBoxHealth_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Health Pot Name";
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 157);
            this.Controls.Add(this.groupBox1);
            this.Name = "Gui";
            this.Text = "CombatPotGuy";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TPThresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManaThresholdUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HealthThresholdUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxHealth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxMana;
        private System.Windows.Forms.CheckBox checkBoxHealth;
        private System.Windows.Forms.ComboBox comboBoxMana;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ManaThresholdUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown HealthThresholdUpDown;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown TPThresholdUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxTP;
        private System.Windows.Forms.ComboBox comboBoxTP;
        private System.Windows.Forms.Label label5;
    }
}