using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab5.LSystem;

namespace Lab5
{
    public partial class Task1 : Form
    {
        Bitmap _bm;
        Graphics _g;
        Pen _pen = new Pen(Color.Black);
        Size _size;
        Random _rand = new Random();
        LS _ls;

        public Task1()
        {
            InitializeComponent();
            _size = pictureBox1.Size;
            _bm = new Bitmap(_size.Width, _size.Height);
            pictureBox1.Image = _bm;
            _g = Graphics.FromImage(_bm);
        }

        void DrawFractal(List<FractalPoint> points, float targetWidth, float targetHeight, float padding)
        {
            float minX = points.Min(p => p.X);
            float maxX = points.Max(p => p.X);
            float minY = points.Min(p => p.Y);
            float maxY = points.Max(p => p.Y);

            float width = maxX - minX;
            float height = maxY - minY;
            float centerX = (maxX + minX) / 2;
            float centerY = (maxY + minY) / 2;

            float k = Math.Min((targetWidth - padding) / width, (targetHeight - padding) / height); //коэф. масштабирования

            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new FractalPoint((points[i].X * k) + (targetWidth / 2 - (centerX * k)), (points[i].Y * k) + (targetHeight / 2 - (centerY * k)), points[i].Flag);
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                if (!points[i + 1].Flag) _g.DrawLine(_pen, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
                //_pen = new Pen(Color.FromArgb(i % 255, 0, 0), 1);
                //pictureBox1.Refresh();
            }
            pictureBox1.Refresh();
        }

        List<FractalPoint> GetFractal(LS l, int maxDepth, float deviationProportion)
        {
            List<FractalPoint> res = new List<FractalPoint>() { new FractalPoint(0, 0, false) };

            PointF curPoint = new PointF(0, 0);
            float curAngle = l.initAngle;
            Stack<(PointF p, float angle)> stateStack = new Stack<(PointF p, float angle)>();

            string s = GetFractalString(l.initAxiom, maxDepth, l.rules);
            int deviation = (int)(deviationProportion * l.angle);

            foreach (char c in s)
            {
                if (c == '+') curAngle += l.angle - _rand.Next(0, deviation);
                else if (c == '-') curAngle -= l.angle - _rand.Next(0, deviation);
                else if (c == '[') stateStack.Push((curPoint, curAngle));
                else if (c == ']')
                {
                    (PointF p, float angle) temp = stateStack.Pop();
                    curPoint = temp.p;
                    curAngle = temp.angle;
                    res.Add(new FractalPoint(temp.p.X, temp.p.Y, true));
                }

                if (char.IsUpper(c))
                {
                        float x = (float)(curPoint.X + Math.Cos(curAngle * Math.PI / 180));
                        float y = (float)(curPoint.Y + Math.Sin(curAngle * Math.PI / 180));
                        res.Add(new FractalPoint(x, y, false));
                        curPoint = new PointF(x, y);
                }
            }

            return res;
        }

        string GetFractalString(string s, int depth, Dictionary<char, string> rules)
        {
            if (depth == 0) return s;

            string res = "";
            foreach (char c in s)
            {
                if (char.IsUpper(c)) res += GetFractalString(rules[c], depth - 1, rules);
                else res += c;
            }
            return res;
        }

        float Interpolation(float x, float min1, float max1, float min2, float max2) => (x - min1) / (max1 - min1) * (max2 - min2) + min2;

        void DrawTreeFractal(List<TreeFractalPoint> points, float targetWidth, float targetHeight, float padding, float minWidth, float maxWidth, Color rootColor, Color leafColor)
        {
            float minx = points[0].X, maxx = points[0].X, miny = points[0].Y, maxy = points[0].Y;
            int maxDepth = 0;

            foreach (TreeFractalPoint p in points)
            {
                if (p.X < minx) minx = p.X;
                if (p.Y < miny) miny = p.Y;
                if (p.X > maxx) maxx = p.X;
                if (p.Y > maxy) maxy = p.Y;
                if (p.Depth > maxDepth) maxDepth = p.Depth;
            }

            float width = maxx - minx;
            float height = maxy - miny;
            float centerX = (maxx + minx) / 2;
            float centerY = (maxy + miny) / 2;

            float k = Math.Min((targetWidth - padding) / width, (targetHeight - padding) / height);

            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new TreeFractalPoint((points[i].X * k) + (targetWidth / 2 - (centerX * k)), (points[i].Y * k) + (targetHeight / 2 - (centerY * k)), points[i].Flag, points[i].Depth);
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                if (!points[i + 1].Flag)
                {
                    float w = Interpolation(points[i + 1].Depth, 0, maxDepth, maxWidth, minWidth);

                    Byte R = (Byte)Interpolation(points[i + 1].Depth, 0, maxDepth, rootColor.R, leafColor.R);
                    Byte G = (Byte)Interpolation(points[i + 1].Depth, 0, maxDepth, rootColor.G, leafColor.G);
                    Byte B = (Byte)Interpolation(points[i + 1].Depth, 0, maxDepth, rootColor.B, leafColor.B);

                    Pen treePen = new Pen(Color.FromArgb(R, G, B), w);

                    _g.DrawLine(treePen, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
                }
            }
            pictureBox1.Refresh();


        }

        List<TreeFractalPoint> GetTreeFractal(LS l, int maxDepth, float deviationProportion, float minLength, float maxLength)
        {
            float length = maxLength;
            List<TreeFractalPoint> res = new List<TreeFractalPoint>();
            res.Add(new TreeFractalPoint(0, 0, false,0));

            (float X, float Y) curPoint = (0, 0);
            float curAngle = l.initAngle;
            Stack<((float X, float Y) p, float angle, int depth)> stateStack = new Stack<((float X, float Y) p, float angle, int depth)>();

            string s = GetFractalString(l.initAxiom, maxDepth, l.rules);
            int depth = 0;

            int deviation = (int)(deviationProportion * l.angle);

            foreach (char c in s)
            {
                if (c == '+') curAngle += l.angle - _rand.Next(0, deviation);
                else if (c == '-') curAngle -= l.angle - _rand.Next(0, deviation);
                else if (c == '[') stateStack.Push((curPoint, curAngle, depth));
                else if (c == ']')
                {
                    ((float X, float Y) p, float angle, int depth) temp = stateStack.Pop();
                    curPoint = temp.p;
                    curAngle = temp.angle;
                    depth = temp.depth;
                    length = Interpolation(depth, 0, maxDepth, maxLength, minLength);
                    res.Add(new TreeFractalPoint(temp.p.X, temp.p.Y, true, depth));
                }
                else if (c == '@')
                {
                    depth++;
                    length = Interpolation(depth, 0, maxDepth, maxLength, minLength);
                }

                if (char.IsUpper(c))
                {
                    float x = (float)(curPoint.X + length * Math.Cos(curAngle * Math.PI / 180));
                    float y = (float)(curPoint.Y + length * Math.Sin(curAngle * Math.PI / 180));
                    res.Add(new TreeFractalPoint(x, y, false, depth));
                    curPoint = (x, y);
                }
            }

            return res;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int depth = 0;
            int.TryParse(textBox1.Text, out depth);
            float deviationProportion = 0f;
            float.TryParse(textBox2.Text, out deviationProportion);

            if (radioButton11.Checked)
            {
                _ls = new LS("tree.txt");
                List<TreeFractalPoint> tree_fractal = GetTreeFractal(_ls, depth, deviationProportion, 1, 20);
                DrawTreeFractal(tree_fractal, this.Width, this.Height, 200, 1, 10, Color.Brown, Color.LimeGreen);

                return;
            }

            if (radioButton1.Checked)
                _ls = new LS("serpinski_tip.txt");
            if (radioButton2.Checked)
                _ls = new LS("snowflake.txt");
            if (radioButton3.Checked)
                _ls = new LS("gilbert.txt");
            if (radioButton4.Checked)
                _ls = new LS("gosper.txt");
            if (radioButton5.Checked)
                _ls = new LS("dragon.txt");
            if (radioButton6.Checked)
                _ls = new LS("island.txt");
            if (radioButton7.Checked)
                _ls = new LS("bush1.txt");
            if (radioButton8.Checked)
                _ls = new LS("bush2.txt");
            if (radioButton9.Checked)
                _ls = new LS("bush3.txt");
            if (radioButton10.Checked)
                _ls = new LS("mosaic.txt");


            List<FractalPoint> fractal = GetFractal(_ls, depth, deviationProportion);
            DrawFractal(fractal, _size.Width, _size.Height, 50);
        }

        private void BClear_Click(object sender, EventArgs e)
        {
            _g.Clear(pictureBox1.BackColor);
            _bm = new Bitmap(_size.Width, _size.Height);
            pictureBox1.Image = _bm;
            _g = Graphics.FromImage(pictureBox1.Image);
        }
    }
}
