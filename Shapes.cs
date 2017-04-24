using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GeoGebra_v1._0
{
    public abstract class Shape
    {
        public abstract string ToString(Grid g);
        public abstract void Draw(PictureBox pb);
    }

    public class Point : Shape
    {
        float x, y;
        public Point(float x, float y)
        {
            this.x = x; this.y = y;
        }

        public override string ToString(Grid g)
        {
            return "Point: " + (x - g.X)/g.D + " ; " + (y-g.Y)/g.D;
        }

        public override void Draw(PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Brush b = new SolidBrush(Color.Black);
            g.FillEllipse(b, x - 2.5f, y - 2.5f, 5, 5);
        }
    }
    public class Line : Shape
    {
        float x1, x2, y1, y2;
        public Line(float x1, float y1, float x2, float y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }
        public override string ToString(Grid g)
        {
            return "Line: (" + (x1-g.X)/g.D + ";" + (y1-g.Y)/g.D + ")" + " ; (" + (x2 - g.X)/g.D + ";" + (y2 - g.Y)/g.D + ")";
        }
        public override void Draw(PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Pen p = new Pen(Color.Black);
            g.DrawLine(p, x1, y1, x2, y2);
        }
    }

    public class Ellipse : Shape
    {
        protected float x, y, a, b;
        public Ellipse(float x, float y, float a, float b)
        {
            this.x = x;
            this.y = y;
            this.a = a;
            this.b = b;
        }
        public float F1
        {
            get
            {
                return (x + (float)Math.Sqrt(a * a - b * b));
            }
        }
        public float F2
        {
            get
            {
                return (x - (float)Math.Sqrt(a * a - b * b));
            }
        }
        public override string ToString(Grid g)
        {
            return "Ellipse: " + (x - g.X)/g.D  + " ; " + (y - g.Y)/g.D;
        }
        public override void Draw(PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Pen p = new Pen(Color.Black);
            g.DrawEllipse(p, x - a, y - b, 2*a, 2*b);
            //g.DrawRectangle(p, x - a, y -b, 2*a, 2*b);
        }
    }

    public class Circle : Ellipse
    {
        public Circle(float x, float y, float r) : base(x,y,r,r)
        {

        }
        public override string ToString(Grid g)
        {
            return "Circle: " + (x - g.X)/g.D + " ; " + (y - g.Y)/g.D + "   |   radius" + a/g.D; 
        }
        public override void Draw(PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Pen p = new Pen(Color.Black);
            g.DrawEllipse(p, x - a, y - b, 2 * a, 2 * b);
        }
    }

    public class Grid
    {
        public float D { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public Grid(float d, float x, float y)
        {
            this.D = d;
            this.X = x;
            this.Y = y;
        }
        
        public void Draw(PictureBox pb)
        {
            Graphics g = pb.CreateGraphics();
            Pen p = new Pen(Color.LightGray);
            g.DrawLine(p, X, 0, X, pb.Height);
            g.DrawLine(p, 0, Y, pb.Width, Y);
            int i = 0;
            while(i*D + X < pb.Width)
            {
                g.DrawLine(p, X + i * D, Y - 3, X + i * D, Y + 3);
                i++;
            }
            i = 0;
            while ( X - i*D > 0)
            {
                g.DrawLine(p, X - i * D, Y - 3, X - i * D, Y + 3);
                i++;
            }
            i = 0;
            while (Y - i * D > 0)
            {
                g.DrawLine(p, X - 3, Y - i * D, X + 3, Y - i * D);
                i++;
            }
            i = 0;
            while (Y + i * D < pb.Height)
            {
                g.DrawLine(p, X - 3, Y + i * D, X + 3, Y + i * D);
                i++;
            }
            i = 0;
        }
    }


}
