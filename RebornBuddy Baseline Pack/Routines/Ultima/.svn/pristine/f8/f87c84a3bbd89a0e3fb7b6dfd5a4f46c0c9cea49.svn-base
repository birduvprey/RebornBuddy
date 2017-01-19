using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UltimaCR.Settings.Forms.Design
{
    public class TabDesign : TabControl
    {
        public TabDesign()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;

            // Changes tab size, the selection triangle needs to be readjusted if this changes
            ItemSize = new Size(35, 110);
        }

        protected override sealed bool DoubleBuffered
        {
            get { return base.DoubleBuffered; }
            set { base.DoubleBuffered = value; }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Left;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            var b = new Bitmap(Width, Height);
            var g = Graphics.FromImage(b);
            try
            {
                SelectedTab.Padding = new Padding(0, 0, 0, 0);
                SelectedTab.Margin = new Padding(0, 0, 0, 0);
                SelectedTab.BackColor = Color.FromArgb(64, 64, 64);
            }
            catch (Exception)
            {
            }

            // BACKGROUND COLOR
            g.Clear(Color.FromArgb(64, 64, 64));

            // Background BEHIND tabs
            g.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), new Rectangle(0, 0, ItemSize.Height + 4, Height));

            //G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(Width - 1, 0), New Point(Width - 1, Height - 1))    
            //G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(ItemSize.Height + 1, 0), New Point(Width - 1, 0))                   
            //G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(ItemSize.Height + 3, Height - 1), New Point(Width - 1, Height - 1))


            // Line on the right side of the tabs that goes all the way down
            g.DrawLine(new Pen(Color.FromArgb(40, 40, 40)), new Point(ItemSize.Height + 3, 0),
                new Point(ItemSize.Height + 3, 999));
            for (var i = 0; i <= TabCount - 1; i++)
            {
                if (i == SelectedIndex)
                {
                    // This changes the actual tab rectangle
                    var x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2),
                        new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1));
                    var myBlend = new ColorBlend
                    {
                        // SELECTED tab color
                        Colors =
                            new[]
                            {Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40)},
                        Positions = new[] {0f, 0.5f, 1f}
                    };

                    var lgBrush = new LinearGradientBrush(x2, Color.Black, Color.Black, 90f)
                    {
                        InterpolationColors = myBlend
                    };
                    g.FillRectangle(lgBrush, x2);

                    // Tab border color
                    g.DrawRectangle(new Pen(Color.FromArgb(64, 64, 64)), x2);

                    g.SmoothingMode = SmoothingMode.HighQuality;
                    Point[] p =
                    {
                        // This is the triangle location, have to add or substract from the location.Y equally
                        new Point(ItemSize.Height - 3, GetTabRect(i).Location.Y + 15),
                        new Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 9),
                        new Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 22)
                    };

                    // Triangle color and OUTLINE color
                    var brush = new SolidBrush(Color.Red);

                    g.FillPolygon(brush, p);
                    g.DrawPolygon(new Pen(Color.Red), p);

                    if (ImageList != null)
                    {
                        try
                        {
                            g.DrawImage(ImageList.Images[TabPages[i].ImageIndex],
                                new Point(x2.Location.X + 8, x2.Location.Y + 6));
                            g.DrawString("      " + TabPages[i].Text, Font, Brushes.White, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                        catch (Exception)
                        {
                            // Font color
                            g.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                                Brushes.White, x2, new StringFormat
                                {
                                    LineAlignment = StringAlignment.Center,
                                    Alignment = StringAlignment.Center
                                });
                        }
                    }
                    else
                    {
                        // Font color
                        g.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                            Brushes.White, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                    }

                    g.DrawLine(new Pen(Color.FromArgb(40, 40, 40)), new Point(x2.Location.X - 1, x2.Location.Y - 1),
                        new Point(x2.Location.X, x2.Location.Y));
                    g.DrawLine(new Pen(Color.FromArgb(40, 40, 40)), new Point(x2.Location.X - 1, x2.Bottom - 1),
                        new Point(x2.Location.X, x2.Bottom));
                }
                else
                {
                    var x2 = new Rectangle(new Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2),
                        new Size(GetTabRect(i).Width + 3, GetTabRect(i).Height + 1));
                    g.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), x2);

                    // Line to the right of the tabs, needs to be changed with the other
                    g.DrawLine(new Pen(Color.FromArgb(40, 40, 40)), new Point(x2.Right, x2.Top),
                        new Point(x2.Right, x2.Bottom));

                    if (ImageList != null)
                    {
                        try
                        {
                            g.DrawImage(ImageList.Images[TabPages[i].ImageIndex],
                                new Point(x2.Location.X + 8, x2.Location.Y + 6));
                            g.DrawString("      " + TabPages[i].Text, Font, Brushes.LightGray, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                        catch (Exception)
                        {
                            // Unselected font color
                            g.DrawString(TabPages[i].Text, Font, Brushes.LightGray, x2, new StringFormat
                            {
                                LineAlignment = StringAlignment.Center,
                                Alignment = StringAlignment.Center
                            });
                        }
                    }
                    else
                    {
                        // Unselected font color
                        g.DrawString(TabPages[i].Text, Font, Brushes.LightGray, x2, new StringFormat
                        {
                            LineAlignment = StringAlignment.Center,
                            Alignment = StringAlignment.Center
                        });
                    }
                }
            }

            g.DrawLine(new Pen(Color.FromArgb(64, 64, 64)), new Point(0, Height - 1), new Point(800, Height - 1));

            // Topmost gray line
            g.DrawLine(new Pen(Color.FromArgb(64, 64, 64)), new Point(0, 0), new Point(800, 0));

            e.Graphics.DrawImage((Image) b.Clone(), 0, 0);
            g.Dispose();
            b.Dispose();
        }
    }
}