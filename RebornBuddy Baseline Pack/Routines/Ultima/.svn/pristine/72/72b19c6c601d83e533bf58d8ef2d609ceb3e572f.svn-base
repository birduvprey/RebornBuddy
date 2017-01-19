using System.Drawing;
using System.Windows.Forms;

namespace UltimaCR.Settings.Forms.Design
{
    public class GroupBoxDesign : GroupBox
    {
        private readonly Color _borderColor;

        public GroupBoxDesign()
        {
            _borderColor = Color.FromArgb(40, 40, 40);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var tSize = TextRenderer.MeasureText(Text, Font);
            var borderRect = e.ClipRectangle;
            borderRect.Y += tSize.Height/2;
            borderRect.Height -= tSize.Height/2;
            ControlPaint.DrawBorder(e.Graphics, borderRect, _borderColor, ButtonBorderStyle.Solid);
            var textRect = e.ClipRectangle;
            textRect.X += 6;
            textRect.Width = tSize.Width;
            textRect.Height = tSize.Height;
            e.Graphics.FillRectangle(new SolidBrush(BackColor), textRect);
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), textRect);
        }
    }
}