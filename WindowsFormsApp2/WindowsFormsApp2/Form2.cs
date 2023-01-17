using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Label l1;
        public Label l2;
        public Label l3;
        public Label l4;
        public Label l5;
        public Label l6;
        public Label l7;
        public TextBox tB;
        public PictureBox nJ1;
        public PictureBox nJ2;
        public PictureBox nJ3;
        public PictureBox nJ4;
        public int Jn = 1;
        Random aleatorio = new Random();

        public Form2()
        {
            InitializeComponent();
            instance = this;
            l1 = jugador1;
            l2 = jugador2;
            l3 = jugador3;
            l4 = jugador4;
            tB = textBox1;
            nJ1 = J1;
            nJ2 = J2;
            nJ3 = J3;
            nJ4 = J4;

            nJ1.Parent = fondo;
            nJ2.Parent = fondo;
            nJ3.Parent = fondo;
            nJ4.Parent = fondo;
            pilota.Parent = fondo;
            jugador1.Parent = fondo;
            jugador2.Parent = fondo;
            jugador3.Parent = fondo;
            jugador4.Parent = fondo;
        }

        public int velocidad = 7;
        int puntuacio1 = 0;
        int puntuacio2 = 0;
        public int nVely;
        public int vely;
        bool anfitrion;
        PictureBox jugador = new PictureBox();
        private void Form2_Load(object sender, EventArgs e)
        {
            Jn = Form1.instance.J;
            switch (Jn)
            {
                case 0:
                    jugador = nJ1;
                    anfitrion = true;
                    START.Enabled = true;
                    break;
                case 1:
                    jugador = nJ2;
                    break;
                case 2:
                    jugador = nJ3;
                    break;
                case 3:
                    jugador = nJ4;
                    break;
            }
            pilota.Location = new Point(384, 209); //la pilota surt a una posicio aleatoria de Y
            velocidad = -7;
            this.KeyPreview = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.instance.enviarMensaje();
            textBox3.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pilota.Left += velocidad;
            pilota.Top += vely;
            if (pilota.Top >= 360 || pilota.Top <= 50) //si pega a la paret de baix
            {
                vely = -(vely);
            }
            if (J1.Location.X + 51 >= pilota.Location.X && J1.Location.X <= pilota.Location.X && J1.Location.Y + 67 >= pilota.Location.Y && J1.Location.Y <= pilota.Location.Y) //verifica que no es passi de la part de baix del jugador 1
            {
                if (anfitrion)
                {
                    Random rnd = new Random();
                    nVely = rnd.Next(0, 14);
                    Form1.instance.golpePelota();
                }
                velocidad = -(velocidad + 1 / 2);
            }
            if (J2.Location.X + 51 >= pilota.Location.X && J2.Location.X <= pilota.Location.X && J2.Location.Y + 67 >= pilota.Location.Y && J2.Location.Y <= pilota.Location.Y) //verifica que no es passi de la part de baix del jugador 1
            {
                if (anfitrion)
                {
                    Random rnd = new Random();
                    nVely = rnd.Next(0, 14);
                    Form1.instance.golpePelota();
                }
                velocidad = -(velocidad + 1 / 2);
            }
            if (J3.Location.X + 51 >= pilota.Location.X && J3.Location.X <= pilota.Location.X && J3.Location.Y + 67 >= pilota.Location.Y && J3.Location.Y <= pilota.Location.Y) //verifica que no es passi de la part de baix del jugador 1
            {
                if (anfitrion)
                {
                    Random rnd = new Random();
                    nVely = rnd.Next(0, 14);
                    Form1.instance.golpePelota();
                }
                velocidad = -(velocidad + 1 / 2);
            }
            if (J4.Location.X + 51 >= pilota.Location.X && J4.Location.X <= pilota.Location.X && J4.Location.Y + 67 >= pilota.Location.Y && J4.Location.Y <= pilota.Location.Y) //verifica que no es passi de la part de baix del jugador 1
            {
                if (anfitrion)
                {
                    Random rnd = new Random();
                    nVely = rnd.Next(0, 14);
                    Form1.instance.golpePelota();
                }
                velocidad = -(velocidad + 1 / 2);
            }
            if (pilota.Left > 740) //para cuando marca el equipo 1
            {
                timer1.Stop();
                puntuacio1 = puntuacio1 + 1;
                int count = int.Parse(textBox1.Text);
                count++;
                textBox1.Text = count.ToString();
                pilota.Location = new Point(385, 209); //la pilota surt a una posicio aleatoria de Y
                velocidad = 7;
                System.Threading.Thread.Sleep(2000); //per què s'esperi 2 segons
                if (puntuacio1 == 7 || puntuacio2 == 7) //un dels dos equips marca 7 punts, s'acaba la partida
                {
                    timer1.Stop();
                    MessageBox.Show("Game Over! " + puntuacio1.ToString() + " - " + puntuacio2.ToString());
                    puntuacio1 = 0;
                    puntuacio2 = 0;
                    velocidad = 7;
                    textBox1.Text = "0";
                    textBox2.Text = "0";
                    panel1.Show();
                }
                timer1.Start();
            }
            if (pilota.Right < 13) //para cuando marca el equipo 2
            {
                timer1.Stop();
                puntuacio2 = puntuacio2 + 1;
                int count = int.Parse(textBox2.Text);
                count++;
                textBox2.Text = count.ToString();
                pilota.Location = new Point(385, 209); //la pilota surt a una posicio aleatoria de Y
                velocidad = -7;
                System.Threading.Thread.Sleep(2000); //per què s'esperi 2 segons
                if (puntuacio1 == 7 || puntuacio2 == 7) //un dels dos equips marca 7 punts, s'acaba la partida
                {
                    timer1.Stop();
                    MessageBox.Show("Game Over! " + puntuacio1.ToString() + " - " + puntuacio2.ToString());
                    puntuacio1 = 0;
                    puntuacio2 = 0;
                    velocidad = 7;
                    textBox1.Text = "0";
                    textBox2.Text = "0";
                    panel1.Show();
                }
                timer1.Start();
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            string mov;
            switch (e.KeyData)
            {
                case Keys.W:
                    mov = "w";
                    Form1.instance.movimiento(mov, Jn);
                    break;
                case Keys.S:
                    mov = "s";
                    Form1.instance.movimiento(mov, Jn);
                    break;
            }

        }

        private void START_Click(object sender, EventArgs e)
        {
            Form1.instance.START();
        }

        public void startAction()
        {
            J1.Show();
            J2.Show();
            J3.Show();
            J4.Show();
            jugador1.Hide();
            jugador2.Hide();
            jugador3.Hide();
            jugador4.Hide();
            textBox3.Hide();
            START.Hide();
            CLOSE.Hide();
            button1.Hide();
            timer1.Start();
        }

        private void CLOSE_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
