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
        int partida;
        public int J;
        bool atendiendo = false;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            instance = this;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void atenderServidor()      //atiende las respuestas del servidor
        {
            string[] jugadores = new string[3];
            while (true)
            {
                int i;
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string mensaje;
                string[] trozos;
                int codigo = 13;
                try
                {
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    trozos = Encoding.ASCII.GetString(msg2).Split('-');
                    codigo = Convert.ToInt32(trozos[0]);
                }
                catch
                {
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    trozos = Encoding.ASCII.GetString(msg2).Split('-');
                }
                switch (codigo)     //dependiendo del codigo hace la accion pedida por el servidor 
                {
                    case 0:
                        if (mensaje == "0-0")       //el usuario se conecta y se ha logeado satisfactoriamente o le informa de que ha introducido mal el nombre o contraseña
                        {
                            Invoke(new Action(() =>
                            {
                                DESCONECTAR.Enabled = true;
                                menuStrip1.BackColor = Color.Transparent;
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
                                eliminarBtn.Visible = true;
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
                        if (mensaje != "1-Error")       //respuesta del servidor de cual es el jugador con mas partidas
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

                        if (mensaje != "2-Error")       //respuesta del servidor de cual fue el jugador con mas partidas
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
                        if (mensaje != "3-Error")       // respuesta del servidor a cual es el winratio del jugador
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
                        if (mensaje == "4-0")       //informa de si el cliente se ha registrado correctamente y le permite el acceso
                        {
                            Invoke(new Action(() =>
                            {
                                MessageBox.Show("Registrado correctamente, has accedido a la cuenta");
                                DESCONECTAR.Enabled = true;
                                menuStrip1.BackColor = Color.Transparent;
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
                                eliminarBtn.Visible = true;
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
                        int id = 0;     //añade a la lista de jugadores conectados el listado que le entrega el servidor 
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
                        if (mensaje != "7-ERROR")       //avisa al cliente de que ha sido invitado a jugar y le da la opcion de aceptar o rechazar
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
                        J = Convert.ToInt32(trozos[1]);     //cuando la gente se va uniendo a la partida va añadiendo su nombre a los jugadores y los pone en verde
                        Invoke(new Action(() =>
                        {
                            form.Show();
                        }));
                        Form2.instance.l1.Text = trozos[2];
                        Form2.instance.l1.ForeColor = Color.Green;
                        if (trozos.Length > 3)
                        {
                            Form2.instance.l3.Text = trozos[3];
                            Form2.instance.l3.ForeColor = Color.Green;
                        }
                        if (trozos.Length > 4)
                        {
                            Form2.instance.l2.Text = trozos[4];
                            Form2.instance.l2.ForeColor = Color.Green;
                        }
                        if (trozos.Length > 5)
                        {
                            Form2.instance.l4.Text = trozos[5];
                            Form2.instance.l4.ForeColor = Color.Green;
                        }
                        break;
                    case 9:
                        Form2.instance.l8.Text = Form2.instance.l7.Text;        //actualiza los mensajes enviados 
                        Form2.instance.l7.Text = Form2.instance.l6.Text;
                        Form2.instance.l6.Text = Form2.instance.l5.Text;
                        Form2.instance.l5.Text = trozos[1];
                        break;
                    case 10:
                        Invoke(new Action(() =>
                        {
                            Form2.instance.startAction();       //inicia la partida
                        }));
                        break;
                    case 11:
                        Form2.instance.vely = Convert.ToInt32(trozos[1]) - 7;       //cambia la direccion de la velocidad vertical de la pelota
                        break;
                    case 12:
                        int nJ = Convert.ToInt32(trozos[2]);
                        Point p;
                        switch (nJ)
                        {
                            case 0:
                                if (trozos[1] == "w")       //mueve a los personajes
                                {
                                    p = Form2.instance.nJ1.Location;
                                    Form2.instance.nJ1.Location = new Point(p.X, p.Y - 4);
                                }
                                else
                                {
                                    p = Form2.instance.nJ1.Location;
                                    Form2.instance.nJ1.Location = new Point(p.X, p.Y + 4);
                                }
                                break;
                            case 1:
                                if(trozos[1] == "w")
                                {
                                    p = Form2.instance.nJ2.Location;
                                    Form2.instance.nJ2.Location = new Point(p.X, p.Y - 4);
                                }
                                else
                                {
                                    p = Form2.instance.nJ2.Location;
                                    Form2.instance.nJ2.Location = new Point(p.X, p.Y + 4);
                                }
                                break;
                            case 2:
                                if (trozos[1] == "w")
                                {
                                    p = Form2.instance.nJ3.Location;
                                    Form2.instance.nJ3.Location = new Point(p.X, p.Y - 4);
                                }
                                else
                                {
                                    p = Form2.instance.nJ3.Location;
                                    Form2.instance.nJ3.Location = new Point(p.X, p.Y + 4);
                                }
                                break;
                            case 3:
                                if (trozos[1] == "w")
                                {
                                    p = Form2.instance.nJ4.Location;
                                    Form2.instance.nJ4.Location = new Point(p.X, p.Y - 4);
                                }
                                else
                                {
                                    p = Form2.instance.nJ4.Location;
                                    Form2.instance.nJ4.Location = new Point(p.X, p.Y + 4);
                                }
                                break;
                        }
                        break;
                    case 13:
                        break;
                }
            }
        }
        private void LOGIN_Click(object sender, EventArgs e)        //envia la peticion de login con la informacion necesaria
        {
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 5060);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);


                if (USERNAME.Text != "" && PASSWORD.Text != "")
                {
                    string login = "0" + "-" + USERNAME.Text + "-" + PASSWORD.Text;
                    byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(login);

                    server.Send(mensaje);

                    if (!atendiendo)
                    {
                        ThreadStart ts = delegate { atenderServidor(); };
                        atender = new Thread(ts);
                        atender.Start();
                        atendiendo = true;
                    }
                }
                else
                    MessageBox.Show("Introduzca su nombre y contraseña");
            }
            catch (SocketException)
            {
                MessageBox.Show("NO HA SIDO POSIBLE CONECTARSE AL SERVIDOR");
                return; 
            }
        }

        private void SIGNIN_Click(object sender, EventArgs e)       //envia la peticion de añadir un nuevo cliente junto con la informacion necesaria 
        {

            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 5060);

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);

                string SIGNIN1 = "4" + "-" + USERNAME.Text + "-" + PASSWORD.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(SIGNIN1);

                server.Send(mensaje);

                if (!atendiendo)
                {
                    ThreadStart ts = delegate { atenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
                    atendiendo = true;
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
            try
            {
                if(NAME.Text != "" && DATE.Text != "")
                {
                    string QUERY1 = "1" + "-" + DATE.Text;
                    byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(QUERY1);
                    server.Send(mensaje);
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
            try
            {
                if (NAME.Text != "" && DATE.Text != "")
                {
                    string QUERY2 = "2" + "-" + DATE.Text;
                    byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(QUERY2);
                    server.Send(mensaje);
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
            try
            {
                if (NAME.Text != "" && DATE.Text != "")
                {
                    string QUERY3 = "3" + "-" + NAME.Text + "-" + DATE.Text;//probar con 03/10/2022
                    byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(QUERY3);
                    server.Send(mensaje);
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
            try
            {
                string CERRAR = "5" + "-" + USERNAME.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(CERRAR);

                server.Send(mensaje);

                atender.Abort();

                server.Shutdown(SocketShutdown.Both);
                DESCONECTAR.Enabled = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                NAME.Visible = false;
                DATE.Visible = false;
                QUERY1.Visible = false;
                QUERY2.Visible = false;
                QUERY3.Visible = false;
                Invitar.Visible = false;
                Cancelar.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                lConectados.Visible = false;
                eliminarBtn.Visible = false;
                USERNAME.Enabled = true;
                PASSWORD.Enabled = true;
                SIGNIN.Enabled = true;
                LOGIN.Enabled = true;
                server.Close();
                atendiendo = false;
            }
            catch (SocketException)
            {
                MessageBox.Show("DESCONECTADO DEL SERVIDOR");
                return;
            }
 
        }
        private List<String> dameListaConectados(string lista, int nConectados)         //funcion para generar la lista de conectados
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
        public void item_Click(object sender, EventArgs e)      //añadir a usuarios para invitarlos a jugar
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            listaInvitacion(item.Text);
        }
        private void listaInvitacion (string nombre)        //guarda la informacion de la gente que vas a invitar a jugar
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
        private void Invitar_Click(object sender, EventArgs e)      //envia las invitaciones
        {
            label6.Visible = true;
            if(invitados != null)
            {
                string invite = "6-" + nInvitados + invitados;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(invite);
                server.Send(mensaje);
            }
        }
        public void enviarMensaje()     //envia los mensajes de chat al servidor
        {
            string peticion = "12-" + partida + "-" + USERNAME.Text + ": " + Form2.instance.tB.Text;
            byte[] enviar = System.Text.Encoding.ASCII.GetBytes(peticion);
            server.Send(enviar);
        }

        private void Cancelar_Click(object sender, EventArgs e)     //elimina a la gente de la lista de invitacion
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
        public void START()     //avisa al servidor de que inicie la partida
        {   
            string peticion = "8-";
            byte[] enviar = System.Text.Encoding.ASCII.GetBytes(peticion);
            server.Send(enviar);
        }
        public void golpePelota()       //avisa al servidor de que se ha golpeado la pelota
        {
            string peticion = "9-" + Convert.ToString(Form2.instance.nVely);
            byte[] enviar = System.Text.Encoding.ASCII.GetBytes(peticion);
            server.Send(enviar);
        }
        public void movimiento(string direccion, int jugador)       //actualiza la posicion de un personaje cuandos e mueve
        {
            string peticion = "10-" + direccion + "-" + Convert.ToString(jugador);
            byte[] enviar = System.Text.Encoding.ASCII.GetBytes(peticion);
            server.Send(enviar);
        }

        private void eliminarBtn_Click(object sender, EventArgs e)      //boton para eliminar la cuenta del cliente
        {
            if (MessageBox.Show("Esta seguro/a de que desea eliminar esta cuenta?", "Eliminar cuenta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string peticion = "11-" + USERNAME.Text;
                byte[] enviar = System.Text.Encoding.ASCII.GetBytes(peticion);
                server.Send(enviar);
                string CERRAR = "5" + "-" + USERNAME.Text;
                byte[] mensaje = System.Text.Encoding.ASCII.GetBytes(CERRAR);
                server.Send(mensaje);
                atender.Abort();
                server.Shutdown(SocketShutdown.Both);
                DESCONECTAR.Enabled = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                NAME.Visible = false;
                DATE.Visible = false;
                QUERY1.Visible = false;
                QUERY2.Visible = false;
                QUERY3.Visible = false;
                Invitar.Visible = false;
                Cancelar.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                lConectados.Visible = false;
                eliminarBtn.Visible = false;
                USERNAME.Enabled = true;
                PASSWORD.Enabled = true;
                SIGNIN.Enabled = true;
                LOGIN.Enabled = true;
                server.Close();
                atendiendo = false;
            }
        }
        public void finalPartida(int t, int puntos, int puntos2, int ganador, string fecha)     //envia la informacion de la partida una vez terminada al servidor
        {
            string peticion = "13-" + ganador + "-" + puntos + "-"  + puntos2 + "-" + t + "-" + fecha;
            byte[] enviar = System.Text.Encoding.ASCII.GetBytes(peticion);
            server.Send(enviar);
        }
    }    
}
