using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab5
{
    internal class LSystem
    {
        public class LS
        {
            public string initAxiom;
            public float initAngle;
            public float angle;
            public Dictionary<char, string> rules = new Dictionary<char, string>();
            public int depth;
            public float deviationProportion;
            public LS(string ia, float iangle, float angle, Dictionary<char, string> r)
            {
                initAxiom = ia;
                initAngle = iangle;
                this.angle = angle;
                rules = r;

            }

            public LS(string filename)
            {
                string[] file = File.ReadAllLines(filename);
                string[] s = file[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                initAxiom = s[0];
                initAngle = float.Parse(s[1]);
                angle = float.Parse(s[2]);
                for (int i = 1; i < file.Length; i++)
                {
                    rules.Add(file[i][0], file[i].Substring(3));
                }
                //if (s.Length > 3)
                //    depth = int.Parse(s[3]);
                //if (s.Length > 4)
                //    deviationProportion = float.Parse(s[4]);
            }
        }

        public class FractalPoint
        {
            public float X;
            public float Y;
            public bool Flag;

            public FractalPoint(float x, float y, bool flag)
            {
                this.X = x;
                this.Y = y;
                this.Flag = flag;
            }
        }

        public class TreeFractalPoint : FractalPoint
        {
            public int Depth;

            public TreeFractalPoint(float x, float y, bool flag, int depth) : base(x, y, flag)
            {
                Depth = depth;
            }
        }
    }
}
