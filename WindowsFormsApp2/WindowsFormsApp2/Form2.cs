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
        public static Form2 instance;       //labels y otros objetos que se han de poder acceder desde el formulario principal
        public Label l1;
        public Label l2;
        public Label l3;
        public Label l4;
        public Label l5;
        public Label l6;
        public Label l7;
        public Label l8;
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
            l5 = label1;
            l6 = label2;
            l7 = label3; 
            l8 = label4;
            tB = textBox3;
            nJ1 = J1;
            nJ2 = J3;
            nJ3 = J2;
            nJ4 = J4;

            nJ1.Parent = fondo;     //indica el parent de los objetos para que puedan tener transparencia 
            nJ2.Parent = fondo;
            nJ3.Parent = fondo;
            nJ4.Parent = fondo;
            pilota.Parent = fondo;
            jugador1.Parent = fondo;
            jugador2.Parent = fondo;
            jugador3.Parent = fondo;
            jugador4.Parent = fondo;

            timer1.Interval = 2;
        }

        public int velocidad = 4;       //valores iniciales 
        int puntuacio1 = 0;
        int puntuacio2 = 0;
        public int nVely;
        public int vely;
        bool anfitrion;
        public int tiempo = 0;
        PictureBox jugador = new PictureBox();
        private void Form2_Load(object sender, EventArgs e)
        {
            Jn = Form1.instance.J;      //recibe la informacion de que personaje es cada jugador para que lo pueda mover
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
            pilota.Location = new Point(384, 209); //posicion inicial de la pelota
            velocidad = -4;
            this.KeyPreview = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo++;
            pilota.Left += velocidad;
            pilota.Top += vely;
            if (pilota.Top >= 360 || pilota.Top <= 50) //la pelota rebota si pega en la pared
            {
                vely = -(vely);
            }
            if (J1.Location.X + 51 >= pilota.Location.X && J1.Location.X <= pilota.Location.X && J1.Location.Y + 67 >= pilota.Location.Y && J1.Location.Y <= pilota.Location.Y) //verifica que no es passi de la part de baix del jugador 1
            {
                if (anfitrion)      //la pelota rebota si toca a un jugador y el anfitrion envia el aviso de que la pelota cambie de velocidad vertical
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
                textBox1.Text = Convert.ToString(puntuacio1);
                pilota.Location = new Point(385, 209); //reinicializa la posicion de la pelota
                velocidad = 7;
                System.Threading.Thread.Sleep(2000); //espera un tiempo antes de volver a sacar
                if (puntuacio1 == 7) //el equipo 1 llega a 7 puntos y envia la informacion del final de partida
                {
                    timer1.Stop();
                    string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                    MessageBox.Show("Game Over! " + puntuacio1.ToString() + " - " + puntuacio2.ToString());
                    Form1.instance.finalPartida(tiempo / 100, puntuacio1, puntuacio2, 1, fecha);
                    this.Close();
                }
                timer1.Start();
            }
            if (pilota.Right < 13) //para cuando marca el equipo 2
            {
                timer1.Stop();
                puntuacio2 = puntuacio2 + 1;
                textBox2.Text = Convert.ToString(puntuacio2);
                pilota.Location = new Point(385, 209); //inicializa la pelota
                velocidad = -7;
                System.Threading.Thread.Sleep(2000); //espera
                if (puntuacio2 == 7) //victoria equipo 2 envia informacion
                {
                    timer1.Stop();
                    string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                    MessageBox.Show("Game Over! " + puntuacio1.ToString() + " - " + puntuacio2.ToString());
                    Form1.instance.finalPartida(tiempo / 100, puntuacio1, puntuacio2, 0, fecha);
                    this.Close();
                }
                timer1.Start();
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)       //envia moviemiento
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

        private void START_Click(object sender, EventArgs e)        //aviso inicio partida
        {
            Form1.instance.START();
        }

        public void startAction()       //aparecen los jugadores al iniciar la partida y pueden comenzar a moverse
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
        private void CLOSE_Click(object sender, EventArgs e)        //cierra el form
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)      //boton para enviar mensaje
        {
            Form1.instance.enviarMensaje();
            textBox3.Clear();
        }
    }
}
