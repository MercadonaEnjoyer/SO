using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Socket server;
        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void LOGIN_Click(object sender, EventArgs e)//iniciar sesion 
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9090);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                

                string login = "0" + "-" + USERNAME.Text + "-" + PASSWORD.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(login);

                server.Send(mensaje);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                login = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (login == "0-0")
                {
                    MessageBox.Show("Has accedido a la cuenta");
                    this.BackColor = Color.Green;
                    lConectados.BackColor = Color.Green;
                    menuStrip1.BackColor = Color.Green;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    NAME.Visible = true;
                    DATE.Visible = true;
                    QUERY1.Visible = true;
                    QUERY2.Visible = true;
                    QUERY3.Visible = true;
                    lConectados.Visible = true;
                    recargar.Visible = true;
                    USERNAME.Enabled = false;
                    PASSWORD.Enabled = false;
                }
                if (login == "Error")
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }

            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return; 
            }
        }

        private void SIGNIN_Click(object sender, EventArgs e)//registrarse
        {

            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9090);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green;

                string SIGNIN = "4" + "-" + USERNAME.Text + "-" + PASSWORD.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(SIGNIN);

                server.Send(mensaje);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                SIGNIN = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (SIGNIN == "4-0")
                {
                    MessageBox.Show("Registrado correctamente");
                    USERNAME.Enabled = false;
                    PASSWORD.Enabled = false;
                }
                if (SIGNIN == "ERROR")
                {
                    MessageBox.Show("Ha habido un problema con la creación de cuenta");
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return;
            }
        }

        private void QUERY1_Click(object sender, EventArgs e)//jugadores de la partida mas larga
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9090);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green;

                string QUERY1 = "1" + "-" + DATE.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(QUERY1);

                server.Send(mensaje);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                QUERY1 = Encoding.ASCII.GetString(msg2).Split('\0')[0];//2 o 4 nombres separados por -
                if (QUERY1 != "Error") 
                {
                    int i = 1;
                    string jugadores = "Los jugadores que jugaron la partida mas larga son : " + QUERY1.Split('-')[i];
                    i++;
                    while (i < QUERY1.Split('-').Length)
                    {
                        jugadores = jugadores + " ," + QUERY1.Split('-')[i];
                        i++;
                    }
                    MessageBox.Show(jugadores);
                }
                if (QUERY1 == "Error")
                {
                    MessageBox.Show("No hay datos coincidentes");
                }


            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return;
            }
        }

        private void QUERY2_Click(object sender, EventArgs e)// nombre del jugador con mas partidas 
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9090);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green;

                string QUERY2 = "2" + "-" + DATE.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(QUERY2);

                server.Send(mensaje);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                QUERY2 = Encoding.ASCII.GetString(msg2).Split('\0')[0];           
                if (QUERY2 != "Error")
                {
                    string mensaje2 = QUERY2.Split('-')[1];
                    MessageBox.Show("El jugador " + mensaje2 + " fue el jugador con mas partidas el dia " + DATE.Text);
                }
                if (QUERY2 == "Error")
                {
                    MessageBox.Show("No hay datos coincidentes");
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return;
            }
        }

        private void QUERY3_Click(object sender, EventArgs e)//winratio de un jugador un dia
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9090);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green;

                string QUERY3 = "3" + "-" + NAME.Text + "-" + DATE.Text;//probar con 03/10/2022
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(QUERY3);

                server.Send(mensaje);

                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                QUERY3 = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                if (QUERY3 != "Error")
                {
                    double Wins = Convert.ToDouble(QUERY3.Split('-')[1]);
                    double Played = Convert.ToDouble(QUERY3.Split('-')[2]);
                    double wr; 
                    wr = (Wins/Played) * 100; 
                    MessageBox.Show("El jugador " + NAME.Text + " tuvo un winratio de " + wr + "% el dia " + DATE.Text);
                }
                if (QUERY3 == "Error")
                {
                    MessageBox.Show("No hay datos coincidentes");
                }
            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return;
            }
        }

        private void DESCONECTAR_Click(object sender, EventArgs e)//desconectar
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9090);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green;

                string CERRAR = "5" + "-" + USERNAME.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(CERRAR);

                server.Send(mensaje);
                server.Shutdown(SocketShutdown.Both);
                this.BackColor = Color.Gray;
                server.Close();
                MessageBox.Show("DESCONECTADO DEL SERVIDOR");
            }
            catch (SocketException)
            {
                MessageBox.Show("DESCONECTADO DEL SERVIDOR");
                return;
            }
        }
        private List<String> dameListaConectados()
        {
            IPAddress direc = IPAddress.Parse("192.168.56.101");
            IPEndPoint ipep = new IPEndPoint(direc, 9090);

            List<String> conectados = new List<String>();

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Connect(ipep);

            string lconectados = "6" + "-";
            byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(lconectados);

            server.Send(mensaje);
            byte[] msg2 = new byte[80];
            server.Receive(msg2);
            lconectados = Encoding.ASCII.GetString(msg2).Split('\0')[0];
            int numeroConectados = Convert.ToInt32(lconectados.Split('/')[0]);
            int i = 1;
            while (i < lconectados.Split('/').Length)
            {
                string nombre = lconectados.Split('/')[i];
                conectados.Add(nombre);
                i++;
            }
            return conectados;
        }

        private void recargar_Click(object sender, EventArgs e)
        {
            int id = 0;
            lConectados.DropDownItems.Clear();
            foreach (String items in dameListaConectados())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(items);
                item.Tag = id;
                id++;
                lConectados.DropDownItems.Add(item);
            }
        }
    }    
}
