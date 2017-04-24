using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoGebra_v1._0
{
    public class Tool
    {
        public virtual void MouseDown(float x, float y, PictureBox temp)
        {

        }

        public virtual void MouseUp(float x, float y)
        {

        }

        public virtual void MouseMove(float x, float y)
        {
        }

        static Tool currentTool;

        public static Tool CurrentTool
        {
            get
            {
                return currentTool;
            }

            set
            {
                currentTool = value;
            }
        }
    }

    public class ToolPoint : Tool
    {
        public override void MouseUp(float x, float y)
        {
            Point t = new Point(x, y);
            Construction.getConstruction().AddShape(t);
        }

        private ToolPoint()
        {
        }

        public static ToolPoint getToolPoint()
        {
            if (toolPoint == null)
                toolPoint = new ToolPoint();
            return toolPoint;
        }

        static ToolPoint toolPoint;

    }

    public class ToolEllipse : Tool
    {
        float xc, yc;
        private ToolEllipse()
        {
        }
        public static ToolEllipse getToolEllipse()
        {
            if (toolEllipse == null)
                toolEllipse = new ToolEllipse();
            return toolEllipse;
        }
        static ToolEllipse toolEllipse;

        public override void MouseDown(float x, float y, PictureBox temp)
        {
            this.xc = x;
            this.yc = y;
        }
        public override void MouseUp(float x, float y)
        {
            Ellipse e = new Ellipse(xc, yc, Math.Abs(x - xc), Math.Abs(y - yc));
            Construction.getConstruction().AddShape(e);
        }
    }
    public class ToolLine : Tool
    {
        float x1, y1;
        private ToolLine()
        { }
        public static ToolLine getToolLine()
        {
            if (toolLine == null)
                toolLine = new ToolLine();
            return toolLine;
        }
        static ToolLine toolLine;
        public override void MouseDown(float x, float y, PictureBox temp)
        {
            this.x1 = x;
            this.y1 = y;
            Construction.getConstruction().RegisterTempRepresentation(new RepresentationPictureBox(temp));
        }
        public override void MouseMove(float x, float y)
        {
            Construction.getConstruction().ClearTempShapes();
            Construction.getConstruction().AddTempShape(new Line(x1, y1, x, y));
        }

        public override void MouseUp(float x, float y)
        {
            Construction.getConstruction().ClearTempRepresentations();
            Line l = new Line(x1, y1, x, y);
            Construction.getConstruction().AddShape(l);
        }
    }

    public class ToolCircle : Tool
    {
        float xc, yc;
        private ToolCircle()
        {
        }
        public static ToolCircle getToolCircle()
        {
            if (toolCircle == null)
                toolCircle = new ToolCircle();
            return toolCircle;
        }
        static ToolCircle toolCircle;

        public override void MouseDown(float x, float y, PictureBox temp)
        {
            this.xc = x;
            this.yc = y;
        }

        public override void MouseUp(float x, float y)
        {
            Circle c = new Circle(xc, yc, (float)Math.Sqrt((x - xc) * (x - xc) + (y - yc) * (y - yc)));
            Construction.getConstruction().AddShape(c);
        }

    }

    public class Coordinates : Tool
    {
        Form form;
        public Coordinates(Form form)
        {
            this.form = form;
        }

        public override void MouseMove(float x, float y)
        {
            form.Text = x + ":" + y;
        }
    }
}