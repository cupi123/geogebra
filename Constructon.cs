using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GeoGebra_v1._0
{

    public class Construction
    {
        List<Shape> shapes;
        private Construction()
        {
            this.shapes = new List<Shape>();
            this.representations = new List<Representation>();
        }

        public static Construction getConstruction()
        {
            if (Construction.construction == null)
            {
                Construction.construction = new Construction();
            }
            return Construction.construction;
        }

        static Construction construction;

        public void AddShape(Shape o)    
        {
            shapes.Add(o);
            foreach (var representation in representations)
                representation.ShowShape(o, g);
        }

        Grid g;
        public void RegisterGrid(Grid g)
        {
            this.g = g;
            foreach (var representation in representations)
                representation.ShowGrid(g);
        }

        public void RegisterRepresentation(Representation representation)
        {
            representations.Add(representation);
        }

        List<Representation> representations;

        //Temporary Shapes And Representations
        List<Shape> tempshapes = new List<Shape>();
        public void AddTempShape(Shape s)
        {
            tempshapes.Add(s);
            foreach (var temprepresentation in temprepresentations)
            {
                temprepresentation.Start();
                temprepresentation.ShowShape(s, g);
            }
        }
        public void ClearTempShapes()
        {
            tempshapes.Clear();
        }
        List<Representation> temprepresentations = new List<Representation>();
        public void RegisterTempRepresentation(Representation temprepresentation)
        {
            temprepresentations.Add(temprepresentation);
        }
        public void ClearTempRepresentations()
        {
            temprepresentations.Clear();
        }
    }

    public abstract class Representation
    {
        public abstract void Start();
        public abstract void ShowShape(Shape o, Grid g);
        public abstract void ShowGrid(Grid g);
    }

    public class RepresentationListBox : Representation
    {
        ListBox lb;
        public RepresentationListBox(ListBox lb)
        {
            this.lb = lb;
        }
        public override void Start()
        {
            lb.Items.Clear();
        }

        public override void ShowShape(Shape o, Grid g)
        {
            lb.Items.Add(o.ToString(g));
        }
        public override void ShowGrid(Grid g)
        {
            lb.Items.Add(g.ToString());
        }
    }

    public class RepresentationPictureBox : Representation
    {
        PictureBox pb;
        public RepresentationPictureBox(PictureBox pb)
        {
            this.pb = pb;
        }
        public override void Start()
        {
            pb.Refresh();
        }
        public override void ShowShape(Shape o, Grid g)
        {
            o.Draw(this.pb);
        }
        public override void ShowGrid(Grid g)
        {
            g.Draw(this.pb);
        }
    }

}


