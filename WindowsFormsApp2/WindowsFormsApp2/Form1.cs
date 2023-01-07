﻿using System;
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
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Socket server;
        Thread atender;
        string invitados;
        int nInvitados = 0;
        public static Form1 instance;
        Form2 form = new Form2();
        bool anfitrion;
        int partida;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            instance = this;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            
        }
        private void atenderServidor()
        {
            int nAceptada = 0;
            string[] jugadores = new string[3];
            while (true)
            {
                int i;
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                string [] trozos = Encoding.ASCII.GetString(msg2).Split('-');
                int codigo = Convert.ToInt32(trozos[0]);
                switch (codigo)
                {
                    case 0:
                        if (mensaje == "0-0")
                        {
                            Invoke(new Action(() =>
                            {
                                this.BackColor = Color.Green;
                                menuStrip1.BackColor = Color.Green;
                                label3.Visible = true;
                                label4.Visible = true;
                                label5.Visible = true;
                                NAME.Visible = true;
                                DATE.Visible = true;
                                QUERY1.Visible = true;
                                QUERY2.Visible = true;
                                QUERY3.Visible = true;
                                menuStrip1.Visible = true;
                                lConectados.Visible = true;
                                Invitar.Visible = true;
                                Cancelar.Visible = true;
                                USERNAME.Enabled = false;
                                PASSWORD.Enabled = false;
                                SIGNIN.Enabled = false;
                                LOGIN.Enabled = false;
                            }));
                        }
                        if (mensaje == "0-Error")
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos");
                        }
                        break;
                    case 1:
                        if (mensaje != "1-Error")
                        {
                            i = 1;
                            string jugadoresP = "Los jugadores que jugaron la partida mas larga son : " + mensaje.Split('-')[i];
                            i++;
                            while (i < mensaje.Split('-').Length)
                            {
                                jugadoresP = jugadoresP + " ," + mensaje.Split('-')[i];
                                i++;
                            }
                            MessageBox.Show(jugadoresP);
                        }
                        if (mensaje == "1-Error")
                        {
                            MessageBox.Show("No hay datos coincidentes");
                        }
                        break;
                    case 2:

                        if (mensaje != "2-Error")
                        {
                            string mensaje2 = mensaje.Split('-')[1];
                            MessageBox.Show("El jugador " + mensaje2 + " fue el jugador con mas partidas el dia " + DATE.Text);
                        }
                        if (mensaje == "2-Error")
                        {
                            MessageBox.Show("No hay datos coincidentes");
                        }
                        break;
                    case 3:
                        if (mensaje != "3-Error")
                        {
                            double Wins = Convert.ToDouble(mensaje.Split('-')[1]);
                            double Played = Convert.ToDouble(mensaje.Split('-')[2]);
                            double wr;
                            wr = (Wins / Played) * 100;
                            MessageBox.Show("El jugador " + NAME.Text + " tuvo un winratio de " + wr + "% el dia " + DATE.Text);
                        }
                        if (mensaje == "3-Error")
                        {
                            MessageBox.Show("No hay datos coincidentes");
                        }
                        break;
                    case 4:
                        if (mensaje == "4-0")
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show("Registrado correctamente, has accedido a la cuenta");
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
                                USERNAME.Enabled = false;
                                PASSWORD.Enabled = false;
                                SIGNIN.Enabled = false;
                                LOGIN.Enabled = false;
                            }));
                        }
                        if (mensaje == "4-ERROR")
                        {
                            MessageBox.Show("Ha habido un problema con la creación de cuenta");
                        }
                        break;
                    case 5:
                        break;
                    case 6:
                        int id = 0;
                        int nConectados = Convert.ToInt32(trozos[1]);
                        lConectados.DropDownItems.Clear();
                        foreach (String items in dameListaConectados(mensaje, nConectados))
                        {
                            ToolStripMenuItem item = new ToolStripMenuItem(items);
                            item.Tag = id;
                            id++;
                            lConectados.DropDownItems.Add(item);
                            item.Click += new EventHandler(item_Click);
                        }
                        break;
                    case 7:
                        if (mensaje != "7-ERROR")
                        {
                            string peticion;
                            Convert.ToString(mensaje);
                            partida = Convert.ToInt32(trozos[1]);
                            string invitador = trozos[2];
                            if (MessageBox.Show("Has sido invitado a jugar por: " + invitador, "Invitacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                peticion = "7-" + partida + "-Yes";
                                byte[] enviar = System.Text.Encoding.ASCII.GetBytes(peticion);
                                server.Send(enviar);
                                Invoke(new Action(() =>
                                {
                                    form.Show();
                                }));
                            }
                            else
                            {
                                peticion = "7-No";
                                byte[] enviar = System.Text.Encoding.ASCII.GetBytes(peticion);
                                server.Send(enviar);
                            }
                        }
                        break;
                    case 8:
                        partida = Convert.ToInt32(trozos[1]);
                        if (trozos[2] == "Yes")
                        {
                            i = 0;
                            string peticion;
                            jugadores[nAceptada] = trozos[3];
                            switch (nAceptada)
                            {
                                case 0:
                                    Form2.instance.l1.Text = jugadores[nAceptada];
                                    Form2.instance.l1.ForeColor = Color.Green;
                                    nAceptada++;
                                    break;
                                case 1:
                                    Form2.instance.l2.Text = jugadores[nAceptada];
                                    Form2.instance.l2.ForeColor = Color.Green;
                                    nAceptada++;
                                    break;
                                case 2:
                                    Form2.instance.l3.Text = jugadores[nAceptada];
                                    Form2.instance.l3.ForeColor = Color.Green;
                                    break;
                            }
                            string peticion2 = "-" + USERNAME.Text;
                            while (jugadores[i] != null)
                            {
                                peticion2 = peticion2 + "-" + jugadores[i];
                                i++;
                            }
                            peticion = "9-" + i;
                            peticion = peticion + peticion2;
                            byte[] enviar = System.Text.Encoding.ASCII.GetBytes(peticion);
                            server.Send(enviar);
                        }
                        break;
                    case 9:
                        Form2.instance.l7.Text = Form2.instance.l6.Text;
                        Form2.instance.l6.Text = Form2.instance.l5.Text;
                        Form2.instance.l5.Text = Form2.instance.l4.Text;
                        Form2.instance.l4.Text = trozos[1];
                        break;
                    case 10:
                        i = 1;
                        Form2.instance.l1.Text = trozos[i];
                        Form2.instance.l1.ForeColor = Color.Green;
                        i++;
                        if (trozos.Length > 2)
                        { 
                            if (trozos[i] != null && trozos[i] != USERNAME.Text)
                            {
                                
                                Form2.instance.l2.Text = trozos[i];
                                Form2.instance.l2.ForeColor = Color.Green;
                                i++;
                                
                            }
                            else if (trozos.Length > 3)
                            {
                                i++;
                                Form2.instance.l2.Text = trozos[i];
                                Form2.instance.l2.ForeColor = Color.Green;
                                i++;
                            }
                        }
                        if (trozos.Length > 3)
                        {
                            if (trozos[i] != null && trozos[i] != USERNAME.Text)
                            {
                                Form2.instance.l3.Text = trozos[i];
                                Form2.instance.l3.ForeColor = Color.Green;
                            }
                            break;
                        }
                        break;
                }
            }
        }
        private void LOGIN_Click(object sender, EventArgs e)
        {
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 5060);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                

                string login = "0" + "-" + USERNAME.Text + "-" + PASSWORD.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(login);

                server.Send(mensaje);

                ThreadStart ts = delegate { atenderServidor(); };
                atender = new Thread(ts);
                atender.Start();
            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return; 
            }
        }

        private void SIGNIN_Click(object sender, EventArgs e)
        {

            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 5060);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
                this.BackColor = Color.Green;

                string SIGNIN1 = "4" + "-" + USERNAME.Text + "-" + PASSWORD.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(SIGNIN1);

                server.Send(mensaje);

                ThreadStart ts = delegate { atenderServidor(); };
                atender = new Thread(ts);
                atender.Start();

            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return;
            }
        }

        private void QUERY1_Click(object sender, EventArgs e)//jugadores de la partida mas larga
        {
            try
            {
                this.BackColor = Color.Green;

                string QUERY1 = "1" + "-" + DATE.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(QUERY1);

                server.Send(mensaje);
            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return;
            }
        }

        private void QUERY2_Click(object sender, EventArgs e)// nombre del jugador con mas partidas 
        {
            try
            {
                this.BackColor = Color.Green;

                string QUERY2 = "2" + "-" + DATE.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(QUERY2);

                server.Send(mensaje);  
            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return;
            }
        }

        private void QUERY3_Click(object sender, EventArgs e)//winratio de un jugador un dia
        {
            try
            {
                this.BackColor = Color.Green;

                string QUERY3 = "3" + "-" + NAME.Text + "-" + DATE.Text;//probar con 03/10/2022
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(QUERY3);

                server.Send(mensaje);
            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return;
            }
        }

        private void DESCONECTAR_Click(object sender, EventArgs e)//desconectar
        {
            try
            {
                this.BackColor = Color.Green;

                string CERRAR = "5" + "-" + USERNAME.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(CERRAR);

                server.Send(mensaje);

                atender.Abort();

                server.Shutdown(SocketShutdown.Both);
                this.BackColor = Color.Gray;
                lConectados.BackColor = Color.Gray;
                menuStrip1.BackColor = Color.Gray;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                NAME.Visible = false;
                DATE.Visible = false;
                QUERY1.Visible = false;
                QUERY2.Visible = false;
                QUERY3.Visible = false;
                lConectados.Visible = false;
                USERNAME.Enabled = true;
                PASSWORD.Enabled = true;
                SIGNIN.Enabled = true;
                LOGIN.Enabled = true;
                server.Close();
            }
            catch (SocketException)
            {
                MessageBox.Show("DESCONECTADO DEL SERVIDOR");
                return;
            }
 
        }
        private List<String> dameListaConectados(string lista, int nConectados)
        {
            List<String> conectados = new List<String>();
            string [] lconectados = lista.Split('-');

            int numeroConectados = Convert.ToInt32(lconectados[1]);
            int i = 0;
            while (i < nConectados)
            {

                string nombre = lconectados[i+2];
                string[] Nnombre;
                Nnombre = nombre.Split('6');
                conectados.Add(Nnombre[0]);
                i++;
            }
            return conectados;
        }
        public void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            MessageBox.Show("Se enviara una invitacion a " + item.Text);
            listaInvitacion(item.Text);
        }
        private void listaInvitacion (string nombre)
        {
            label6.Visible = true;
            Invitar.Enabled = true;
            Cancelar.Enabled = true;
            if (nInvitados < 3)
            {
                invitados = invitados + "-" + nombre;
                nInvitados++;
            }
            else
            {
                MessageBox.Show("Solo se puede invitar un maximo de 4 jugadores");
            }
            switch (nInvitados)
            {
                case 1:
                    label7.Text = nombre;
                    label7.Visible = true;
                    break;
                case 2:
                    label8.Text = nombre;
                    label8.Visible = true;
                    break;
                case 3:
                    label9.Text = nombre;
                    label9.Visible = true;
                    break;
            }
        }
        private void Invitar_Click(object sender, EventArgs e)
        {
            anfitrion = true;
            label6.Visible = true;
            if(invitados != null)
            {
                string invite = "6-" + nInvitados + invitados;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(invite);
                server.Send(mensaje);
                form.Show();
            }
        }
        public void enviarMensaje()
        {
            string peticion = "8-" + partida + "-" + USERNAME.Text + ": " + Form2.instance.tB.Text;
            byte[] enviar = System.Text.Encoding.ASCII.GetBytes(peticion);
            server.Send(enviar);
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            Invitar.Enabled = false;
            Cancelar.Enabled = false;
            nInvitados = 0;
            label7.Text = "";
            label7.Visible = false;
            label8.Text = "";
            label7.Visible = false;
            label9.Text = "";
            label9.Visible = false;
            invitados = null;
        }
    }    
}
