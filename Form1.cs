using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace GeoGebra_v1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
            pictureBox1.BringToFront();
            if (Tool.CurrentTool != null)
                Tool.CurrentTool.MouseUp(e.X, e.Y);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox temp = new PictureBox
            {
                Name = "TemporaryPB",
                Size = new Size(1500, 1000),
                Location = new System.Drawing.Point(0, 0),
                BackColor = Color.Transparent
            };
            pictureBox1.Controls.Add(temp);
            if (Tool.CurrentTool != null)
                Tool.CurrentTool.MouseDown(e.X, e.Y, temp);
        }

        PictureBox temp = null;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Tool.CurrentTool != null)
                Tool.CurrentTool.MouseMove(e.X, e.Y);
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            Tool.CurrentTool = ToolEllipse.getToolEllipse();
            pictureBox1.BringToFront();
        }

        private void Circle_Click(object sender, EventArgs e)
        {
            Tool.CurrentTool = ToolCircle.getToolCircle();
            pictureBox1.BringToFront();
        }

        private void Lines_ButtonClick(object sender, EventArgs e)
        {
            Tool.CurrentTool = ToolLine.getToolLine();
            pictureBox1.BringToFront();
        }

        private void Points_ButtonClick(object sender, EventArgs e)
        {
            Tool.CurrentTool = ToolPoint.getToolPoint();
            pictureBox1.BringToFront();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Construction.getConstruction().RegisterRepresentation(new RepresentationListBox(listBox1));
            Construction.getConstruction().RegisterRepresentation(new RepresentationPictureBox(pictureBox1));
            Tool.CurrentTool = new Coordinates(this);
            Construction.getConstruction().RegisterGrid(new Grid(10, pictureBox1.Width / 2, pictureBox1.Height / 2));
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
        }



        /*private void Point_Click(object sender, EventArgs e)
        {
            Tool.CurrentTool = ToolPoint.getToolPoint();
            pictureBox1.BringToFront();
        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            Tool.CurrentTool = ToolEllipse.getToolEllipse();
            pictureBox1.BringToFront();
        }

        private void Line_Click(object sender, EventArgs e)
        {
            Tool.CurrentTool = ToolLine.getToolLine();
            pictureBox1.BringToFront();
        }*/
    }
}
