using System.ComponentModel;
using System.Windows.Forms;

namespace UltimaCR.Settings.Forms
{
    partial class RotationOverlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.CurrentRotationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CurrentRotationLabel
            // 
            this.CurrentRotationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentRotationLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CurrentRotationLabel.Location = new System.Drawing.Point(12, 9);
            this.CurrentRotationLabel.Name = "CurrentRotationLabel";
            this.CurrentRotationLabel.Size = new System.Drawing.Size(111, 27);
            this.CurrentRotationLabel.TabIndex = 1;
            this.CurrentRotationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CurrentRotationLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RotationOverlay_MouseDown);
            // 
            // RotationOverlay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(135, 45);
            this.Controls.Add(this.CurrentRotationLabel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RotationOverlay";
            this.Opacity = 0.85D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RotationOverlay";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RotationOverlay_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RotationOverlay_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Label CurrentRotationLabel;
    }
}