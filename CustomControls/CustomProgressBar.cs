using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControls
{
    public class CustomProgressBar : ProgressBar
    {

        public CustomProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            Graphics g = e.Graphics;

            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            rect.Inflate(-3, -3);
            if (this.Value > 0)
            {
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)this.Value / this.Maximum) * rect.Width), rect.Height);
                ProgressBarRenderer.DrawHorizontalChunks(g, clip);
            }

            string text = this.Value.ToString() + " / " + this.Maximum.ToString();

            using (Font f = new Font(FontFamily.GenericMonospace, 10))
            {
                SizeF strLen = g.MeasureString(text, f);
                Point location = new Point((int)((rect.Width / 2) - (strLen.Width / 2)), (int)((rect.Height / 2) - (strLen.Height / 2)));
                g.DrawString(text, f, Brushes.Black, location);
            }
        }
    }
}
