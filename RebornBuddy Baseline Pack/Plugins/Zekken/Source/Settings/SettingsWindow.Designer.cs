namespace Zekken
{
    partial class SettingsWindow
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
            this.MultiAvoidanceCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackgroundPanel = new System.Windows.Forms.Panel();
            this.LogoImage = new System.Windows.Forms.PictureBox();
            this.ZekkenImage = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.CompileButton = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CircleFromMobCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TargetedCheckbox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.BackgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZekkenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompileButton)).BeginInit();
            this.SuspendLayout();
            // 
            // MultiAvoidanceCheckbox
            // 
            this.MultiAvoidanceCheckbox.AutoSize = true;
            this.MultiAvoidanceCheckbox.Checked = true;
            this.MultiAvoidanceCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MultiAvoidanceCheckbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiAvoidanceCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MultiAvoidanceCheckbox.Location = new System.Drawing.Point(61, 195);
            this.MultiAvoidanceCheckbox.Name = "MultiAvoidanceCheckbox";
            this.MultiAvoidanceCheckbox.Size = new System.Drawing.Size(169, 28);
            this.MultiAvoidanceCheckbox.TabIndex = 0;
            this.MultiAvoidanceCheckbox.Text = "Multi-Avoidance";
            this.MultiAvoidanceCheckbox.UseVisualStyleBackColor = true;
            this.MultiAvoidanceCheckbox.CheckedChanged += new System.EventHandler(this.MultiAvoidanceCheckboxChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Sitka Subheading", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(81, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 79);
            this.label1.TabIndex = 1;
            this.label1.Text = "Avoid spells from all nearby mobs and not just your target.";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDrag);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.BackgroundPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 647);
            this.panel1.TabIndex = 2;
            // 
            // BackgroundPanel
            // 
            this.BackgroundPanel.Controls.Add(this.ZekkenImage);
            this.BackgroundPanel.Controls.Add(this.LogoImage);
            this.BackgroundPanel.Controls.Add(this.ExitButton);
            this.BackgroundPanel.Controls.Add(this.CompileButton);
            this.BackgroundPanel.Controls.Add(this.label3);
            this.BackgroundPanel.Controls.Add(this.label1);
            this.BackgroundPanel.Controls.Add(this.CircleFromMobCheckbox);
            this.BackgroundPanel.Controls.Add(this.MultiAvoidanceCheckbox);
            this.BackgroundPanel.Controls.Add(this.label2);
            this.BackgroundPanel.Controls.Add(this.TargetedCheckbox);
            this.BackgroundPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundPanel.Location = new System.Drawing.Point(0, 0);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(515, 647);
            this.BackgroundPanel.TabIndex = 7;
            this.BackgroundPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDrag);
            // 
            // LogoImage
            // 
            this.LogoImage.Location = new System.Drawing.Point(136, 21);
            this.LogoImage.Name = "LogoImage";
            this.LogoImage.Size = new System.Drawing.Size(280, 130);
            this.LogoImage.TabIndex = 10;
            this.LogoImage.TabStop = false;
            this.LogoImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDrag);
            // 
            // ZekkenImage
            // 
            this.ZekkenImage.Location = new System.Drawing.Point(46, 12);
            this.ZekkenImage.Name = "ZekkenImage";
            this.ZekkenImage.Size = new System.Drawing.Size(100, 139);
            this.ZekkenImage.TabIndex = 9;
            this.ZekkenImage.TabStop = false;
            this.ZekkenImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDrag);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(465, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(50, 50);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButtonClicked);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButtonHoverEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButtonHoverExit);
            // 
            // CompileButton
            // 
            this.CompileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompileButton.Location = new System.Drawing.Point(121, 520);
            this.CompileButton.Name = "CompileButton";
            this.CompileButton.Size = new System.Drawing.Size(250, 100);
            this.CompileButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CompileButton.TabIndex = 7;
            this.CompileButton.TabStop = false;
            this.CompileButton.Click += new System.EventHandler(this.CompileButtonClick);
            this.CompileButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CompileButtonPressed);
            this.CompileButton.MouseEnter += new System.EventHandler(this.CompileButtonHoverEnter);
            this.CompileButton.MouseLeave += new System.EventHandler(this.CompileButtonHoverExit);
            this.CompileButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CompileButtonReleased);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Sitka Subheading", 10.2F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(81, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 79);
            this.label3.TabIndex = 6;
            this.label3.Text = "Avoid circle spells that originate from the caster.";
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDrag);
            // 
            // CircleFromMobCheckbox
            // 
            this.CircleFromMobCheckbox.AutoSize = true;
            this.CircleFromMobCheckbox.Checked = true;
            this.CircleFromMobCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CircleFromMobCheckbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CircleFromMobCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CircleFromMobCheckbox.Location = new System.Drawing.Point(61, 421);
            this.CircleFromMobCheckbox.Name = "CircleFromMobCheckbox";
            this.CircleFromMobCheckbox.Size = new System.Drawing.Size(276, 28);
            this.CircleFromMobCheckbox.TabIndex = 5;
            this.CircleFromMobCheckbox.Text = "Circle From Caster Avoidance";
            this.CircleFromMobCheckbox.UseVisualStyleBackColor = true;
            this.CircleFromMobCheckbox.CheckedChanged += new System.EventHandler(this.CircleFromMobCheckboxChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Sitka Subheading", 10.2F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(81, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 79);
            this.label2.TabIndex = 3;
            this.label2.Text = "Avoid spells that originate from the caster\'s target.";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowDrag);
            // 
            // TargetedCheckbox
            // 
            this.TargetedCheckbox.AutoSize = true;
            this.TargetedCheckbox.Checked = true;
            this.TargetedCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TargetedCheckbox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetedCheckbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TargetedCheckbox.Location = new System.Drawing.Point(61, 308);
            this.TargetedCheckbox.Name = "TargetedCheckbox";
            this.TargetedCheckbox.Size = new System.Drawing.Size(281, 28);
            this.TargetedCheckbox.TabIndex = 2;
            this.TargetedCheckbox.Text = "Targeted On Target Avoidance";
            this.TargetedCheckbox.UseVisualStyleBackColor = true;
            this.TargetedCheckbox.CheckedChanged += new System.EventHandler(this.TargetedCheckboxChanged);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 647);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingsWindow";
            this.Text = "Zekken Settings";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.panel1.ResumeLayout(false);
            this.BackgroundPanel.ResumeLayout(false);
            this.BackgroundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZekkenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompileButton)).EndInit();
            this.ResumeLayout(false);

        }

        private void SettingsWindow_Load(object sender, System.EventArgs e)
        {

        }

        #endregion

        private System.Windows.Forms.CheckBox MultiAvoidanceCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox TargetedCheckbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CircleFromMobCheckbox;
        private System.Windows.Forms.Panel BackgroundPanel;
        private System.Windows.Forms.PictureBox CompileButton;
        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.PictureBox ZekkenImage;
        private System.Windows.Forms.PictureBox LogoImage;
    }
}