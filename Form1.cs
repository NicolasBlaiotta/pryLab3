using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryLab3
{
    public partial class Form1 : Form
    {
        private Point previousPoint;
        private Pen pen;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 2); // Color y grosor del trazo
            pictureBox1.BackColor = Color.White; // Color de fondo del PictureBox
            pictureBox1.Paint += PictureBox1_Paint;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            using (var g = e.Graphics)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            previousPoint = e.Location;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (previousPoint != null && e.Button == MouseButtons.Left)
            {
                using (Graphics g = pictureBox1.CreateGraphics())
                {
                    g.DrawLine(pen, previousPoint.Value, e.Location);
                }
                previousPoint = e.Location;
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            previousPoint = null;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh(); // Limpia la firma
        }
    }
}

