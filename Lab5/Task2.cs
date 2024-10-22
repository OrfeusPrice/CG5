using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Task2 : Form
    {
        PointF startPoint = new PointF(0, 0);
        PointF endPoint = new PointF(0, 0);
        private Bitmap bitmap;
        private Graphics g;
        private Random random = new Random();

        public Task2()
        {
            InitializeComponent();

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            g = Graphics.FromImage(bitmap);
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(roughnessTextBox.Text, out float roughness))
            {
                MessageBox.Show("Некорректное значение шероховатости!");
                return;
            }

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);


            MidpointDisplacement(g, startPoint, endPoint, roughness, detailLevelBar.Value);

            pictureBox1.Image = bitmap;
            pictureBox1.Invalidate();
        }
        private void MidpointDisplacement(Graphics g, PointF start, PointF end, float roughness, int detailLevel)
        {
            if (detailLevel <= 0)
            {
                g.DrawLine(Pens.Black, start, end);

                using (Brush blackBrush = new SolidBrush(Color.Black))
                {
                    PointF[] fillPoints = new PointF[]
                    {
                start,
                end,
                new PointF(end.X, pictureBox1.Height),
                new PointF(start.X, pictureBox1.Height)
                    };

                }
            }
            else
            {
                float midX = (start.X + end.X) / 2;
                float midY = (start.Y + end.Y) / 2;
                float length = (end.X - start.X) / pictureBox1.Width;
                float randomOffset = (float)(random.NextDouble() * (roughness * length * 2)) - (roughness * length); //TODO
                midY += randomOffset;

                PointF midPoint = new PointF(midX, midY);

                MidpointDisplacement(g, start, midPoint, roughness, detailLevel - 1);
                MidpointDisplacement(g, midPoint, end, roughness, detailLevel - 1);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (bitmap != null && pictureBox1.ClientSize.Width > 0 && pictureBox1.ClientSize.Height > 0)
            {
                Bitmap newBitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                using (Graphics g = Graphics.FromImage(newBitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                    g.DrawImage(bitmap, 0, 0, newBitmap.Width, newBitmap.Height);
                }

                bitmap = newBitmap;
                pictureBox1.Image = bitmap;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = new PointF(e.Location.X, e.Location.Y);
                g.DrawRectangle(new Pen(Color.Blue,2),new Rectangle(e.Location.X,e.Location.Y,1,1));
                pictureBox1.Image = bitmap;
            }
            if (e.Button == MouseButtons.Right)
            {
                endPoint = new PointF(e.Location.X, e.Location.Y);
                g.DrawRectangle(new Pen(Color.Orange,2), new Rectangle(e.Location.X, e.Location.Y, 1, 1));
                pictureBox1.Image = bitmap;
            }
        }
    }
}
