using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryLab3
{
    public partial class frmNave : Form
    {
        private const int velocidadNave = 5;
        private const int velocidadEnemigo = 3;
        private const int velocidadBala = 10;
        private const int intervaloOleada = 4000;
        private Random rnd = new Random();
        private PictureBox naveJugador;
        private Timer temporizadorJuego = new Timer();
        private PictureBox[] enemigos;
        private PictureBox bala;
        public frmNave()
        {
            InitializeComponent();
            InicializarJuego();
        }
        private void InicializarJuego()
        {
            naveJugador = new PictureBox
            {
                Image = Properties.Resources.nave,
                Size = new Size(50, 50),
                Location = new Point(ClientSize.Width / 2 - 25, ClientSize.Height - 70),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Controls.Add(naveJugador);

            temporizadorJuego.Interval = 20;
            temporizadorJuego.Tick += BucleJuego;
            temporizadorJuego.Start();

            enemigos = new PictureBox[10];

            for (int i = 0; i < 10; i++)
            {
                enemigos[i] = new PictureBox
                {
                    Image = Properties.Resources.enemigo,
                    Size = new Size(40, 40),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = "enemigo",
                    Location = new Point(i * 50, 10)
                };
                Controls.Add(enemigos[i]);
            }

            KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (naveJugador.Left > 0)
                    naveJugador.Left -= velocidadNave;
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (naveJugador.Right < ClientSize.Width)
                    naveJugador.Left += velocidadNave;
            }
            else if (e.KeyCode == Keys.Space)
            {
                DispararBala();
            }
        }
        private void DispararBala()
        {
            bala = new PictureBox
            {
                Image = Properties.Resources.bala,
                Size = new Size(5, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Tag = "bala",
                Location = new Point(naveJugador.Left + naveJugador.Width / 2 - 2, naveJugador.Top - 20)
            };
            Controls.Add(bala);
        }
        private void BucleJuego(object sender, EventArgs e)
        {
            MoverEnemigos();
            MoverBala();
            ComprobarColisiones();
        }

        private void MoverEnemigos()
        {
            foreach (PictureBox enemigo in enemigos)
            {
                enemigo.Top += velocidadEnemigo;
            }
        }

        private void MoverBala()
        {
            if (bala != null)
            {
                bala.Top -= velocidadBala;

                if (bala.Top < 0)
                {
                    Controls.Remove(bala);
                    bala.Dispose();
                    bala = null;
                }
            }
        }
        private void ComprobarColisiones()
        {
            foreach (Control control in Controls)
            {
                if (control is PictureBox && (string)control.Tag == "enemigo")
                {
                    if (bala != null && control.Bounds.IntersectsWith(bala.Bounds))
                    {
                        Controls.Remove(control);
                        control.Dispose();
                        Controls.Remove(bala);
                        bala.Dispose();
                        bala = null;
                        return;
                    }
                }
            }
        }
        private void GenerarOleada(object sender, EventArgs e)
        {
            // Crear un array para almacenar los enemigos generados en esta oleada
            PictureBox[] nuevasOleada = new PictureBox[5]; // Generar 5 nuevos enemigos en cada oleada

            for (int i = 0; i < 5; i++)
            {
                PictureBox enemigo = new PictureBox
                {
                    Image = Properties.Resources.enemigo,
                    Size = new Size(40, 40),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = "enemigo",
                    Location = new Point(rnd.Next(ClientSize.Width - 40), 10) // Posición aleatoria en la parte superior del formulario
                };

                nuevasOleada[i] = enemigo; // Almacenar el enemigo generado en el array
                Controls.Add(enemigo); // Agregar el enemigo al formulario
            }

            // Almacenar la oleada recién generada en el array principal de enemigos
            enemigos = nuevasOleada;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
