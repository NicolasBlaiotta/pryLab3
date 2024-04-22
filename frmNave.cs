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
        private const int intervaloOleada = 5000; // Intervalo de tiempo entre oleadas (en milisegundos)
        private const int velocidadNave = 17;
        private const int velocidadEnemigo = 5;
        private const int velocidadBala = 10;
        private Random rnd = new Random();
        private PictureBox naveJugador;
        private Timer temporizadorJuego = new Timer();
        private PictureBox[] enemigos;
        private PictureBox bala;
        public List<PictureBox> listadisparos = new List<PictureBox> ();
        public frmNave()
        {
            InitializeComponent();
            InicializarJuego();
            // Configurar el Timer
            timer1.Interval = intervaloOleada;
            timer1.Tick += GenerarOleada; // Suscribirse al evento Tick
            timer1.Start(); // Iniciar el temporizador para que comience a generar oleadas automáticamente
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

            enemigos = new PictureBox[1];

            for (int i = 0; i < 1; i++)
            {
                enemigos[i] = new PictureBox
                {
                    Image = Properties.Resources.enemigo,
                    Size = new Size(40, 20),
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
            listadisparos.Add(bala);
        }
        private void BucleJuego(object sender, EventArgs e)
        {
            MoverEnemigos();
            Movimiento();
            ComprobarColisiones();
        }

        private void MoverEnemigos()
        {
            foreach (PictureBox enemigo in enemigos)
            {
                enemigo.Top += velocidadEnemigo;
                // Verificar si el enemigo llega al borde inferior
                if (enemigo.Bottom >= this.ClientSize.Height)
                {
                    // Eliminar el enemigo si llega al borde inferior
                    this.Controls.Remove(enemigo);
                    enemigo.Dispose();
                }
            }
        }

        //private void MoverBala()
        //{
        //    if (bala != null)
        //    {
        //        bala.Top -= velocidadBala;

        //        if (bala.Top < 0)
        //        {
        //            Controls.Remove(bala);
        //            bala.Dispose();
        //            bala = null;
        //        }
        //    }
        //}
        private void Movimiento()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag =="bala")
                {
                    x.Top -= 10;
                    if (x.Top<50)
                    {
                        this.Controls.Remove(x);
                    }
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
                        //return;
                    }
                }
            }
        }
        private void GenerarOleada(object sender, EventArgs e)
        {
            // Crear un array para almacenar los enemigos generados en esta oleada
            PictureBox[] nuevasOleada = new PictureBox[2]; // Generar 5 nuevos enemigos en cada oleada

            for (int i = 0; i < 2; i++)
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
