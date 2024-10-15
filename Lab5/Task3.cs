using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Task3 : Form
    {

        private Graphics _graphics;
        private Bitmap _bitmap;
        private List<Point> _points = new List<Point>();
        private int _selectedPointIndex = -1;
        private int _movingPointIndex = -1;
        private bool _isDragging = false;
        private const float _pointRadius = 4f;
        private bool _isShowing = true;
        public Task3()
        {
            InitializeComponent();
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = _bitmap;
            _graphics = Graphics.FromImage(pictureBox1.Image);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _points.Clear();
            _graphics.Clear(pictureBox1.BackColor);
            _bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = _bitmap;
            _graphics = Graphics.FromImage(pictureBox1.Image);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedPointIndex = FindPoint(e.Location);
            if (_selectedPointIndex != -1)
            {
                if (e.Button == MouseButtons.Left && !_isDragging)
                {
                    _isDragging = true;
                    _movingPointIndex = _selectedPointIndex;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    RemovePoint(e.Location);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                _points.Add(e.Location);
                Redraw();
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && _movingPointIndex != -1)
            {
                _points[_selectedPointIndex] = e.Location;
                Redraw();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
            _selectedPointIndex = -1;
            _movingPointIndex = -1;
        }
        
        private void RemovePoint(Point location)
        {
            _selectedPointIndex = FindPoint(location);
            if (_selectedPointIndex != -1)
            {
                _points.RemoveAt(_selectedPointIndex);
                Redraw();
            }
        }

        private int FindPoint(Point location)
        {
            for (int i = 0; i < _points.Count; i++)
            {
                if (Math.Abs(_points[i].X - location.X) < _pointRadius && Math.Abs(_points[i].Y - location.Y) < _pointRadius)
                {
                    return i;
                }
            }
            return -1;
        }

        private void Redraw()
        {
            _graphics.Clear(Color.White);
            DrawBezierCurve();
            DrawPoints();
            pictureBox1.Image = _bitmap;
        }

        private void DrawPoints()
        {
            //_graphics.FillRectangle(Brushes.Red, _points[0].X - _pointRadius, _points[0].Y - _pointRadius, _pointRadius * 2, _pointRadius * 2);
            for (int i = 0; i < _points.Count; i++)
            {
                if(i % 2 == 0 && i != _points.Count - 1)
                {
                    _graphics.DrawLine(new Pen(Color.Red), _points[i].X, _points[i].Y, _points[i+1].X, _points[i+1].Y);
                }
                _graphics.FillRectangle(Brushes.Red, _points[i].X - _pointRadius, _points[i].Y - _pointRadius, _pointRadius * 2, _pointRadius * 2);
            }
        }

        private void DrawBezierCurve()
        {
            if (_points.Count < 4) return;
            List<Point> result = new List<Point>();
            float step = 0.01f;
            
                for (int i = 1; i <= _points.Count - 3; i += 2)
                {
                    Point temp = new Point((_points[i - 1].X + _points[i].X) / 2, (_points[i - 1].Y + _points[i].Y) / 2);
                    Point temp2 = new Point((_points[i + 1].X + _points[i + 2].X) / 2, (_points[i + 1].Y + _points[i + 2].Y) / 2);
                    for (float t = 0; t <= 1; t += step)
                    {
                        float x = (float)(Math.Pow(1 - t, 3) * temp.X +
                                           3 * Math.Pow(1 - t, 2) * t * _points[i].X +
                                           3 * (1 - t) * Math.Pow(t, 2) * _points[i + 1].X +
                                           Math.Pow(t, 3) * temp2.X);

                        float y = (float)(Math.Pow(1 - t, 3) * temp.Y +
                                           3 * Math.Pow(1 - t, 2) * t * _points[i].Y +
                                           3 * (1 - t) * Math.Pow(t, 2) * _points[i + 1].Y +
                                           Math.Pow(t, 3) * temp2.Y);

                        result.Add(new Point((int)x, (int)y));
                    }
                }


            if (result.Count > 1)
            {
                _graphics.DrawLines(new Pen(Color.Blue), result.ToArray());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_isShowing)
            {
                DrawWithoutPoints();
            }
            else
            {
                Redraw();
            }
            _isShowing = !_isShowing;
        }

        private void DrawWithoutPoints()
        {
            _graphics.Clear(Color.White);
            DrawBezierCurve();
            pictureBox1.Image = _bitmap;
        }

    }
}
