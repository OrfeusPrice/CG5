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
            if (detailLevel == 0)
            {
                g.DrawLine(Pens.Black, start, end);
            }
            else
            {
                float midX = (start.X + end.X) / 2;
                float midY = (start.Y + end.Y) / 2; // (hL + hR) / 2 
                float length = (end.X - start.X) / pictureBox1.Width;
                float randomOffset = (float)(random.NextDouble() * (roughness * length * 2)) - (roughness * length); // Задание диапазона random(- R * l, R * l)
                midY += randomOffset; // (hL + hR) / 2 + random(- R * l, R * l)

                PointF midPoint = new PointF(midX, midY);

                MidpointDisplacement(g, start, midPoint, roughness, detailLevel - 1);
                MidpointDisplacement(g, midPoint, end, roughness, detailLevel - 1);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g = Graphics.FromImage(bitmap);
                g.Clear(Color.White);
                startPoint = new PointF(e.Location.X, e.Location.Y);
                g.DrawRectangle(new Pen(Color.Blue,2),new Rectangle(e.Location.X,e.Location.Y,1,1));
                g.DrawRectangle(new Pen(Color.Orange, 2), new Rectangle((int)endPoint.X, (int)endPoint.Y, 1, 1));
                pictureBox1.Image = bitmap;
            }
            if (e.Button == MouseButtons.Right)
            {
                g = Graphics.FromImage(bitmap);
                g.Clear(Color.White);
                endPoint = new PointF(e.Location.X, e.Location.Y);
                g.DrawRectangle(new Pen(Color.Orange,2), new Rectangle(e.Location.X, e.Location.Y, 1, 1));
                g.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle((int)startPoint.X, (int)startPoint.Y, 1, 1));
                pictureBox1.Image = bitmap;
            }
        }
    }
}
