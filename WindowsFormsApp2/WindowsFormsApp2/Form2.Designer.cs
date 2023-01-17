namespace WindowsFormsApp2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.CLOSE = new System.Windows.Forms.Button();
            this.START = new System.Windows.Forms.Button();
            this.jugador4 = new System.Windows.Forms.Label();
            this.jugador3 = new System.Windows.Forms.Label();
            this.jugador2 = new System.Windows.Forms.Label();
            this.jugador1 = new System.Windows.Forms.Label();
            this.pilota = new System.Windows.Forms.PictureBox();
            this.J2 = new System.Windows.Forms.PictureBox();
            this.J4 = new System.Windows.Forms.PictureBox();
            this.J1 = new System.Windows.Forms.PictureBox();
            this.J3 = new System.Windows.Forms.PictureBox();
            this.fondo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pilota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.J2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.J4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.J1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.J3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fondo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Azure;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(15, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(18, 31);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Azure;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(770, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(18, 31);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pilota);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.CLOSE);
            this.panel1.Controls.Add(this.J2);
            this.panel1.Controls.Add(this.START);
            this.panel1.Controls.Add(this.J4);
            this.panel1.Controls.Add(this.J1);
            this.panel1.Controls.Add(this.jugador4);
            this.panel1.Controls.Add(this.J3);
            this.panel1.Controls.Add(this.jugador3);
            this.panel1.Controls.Add(this.jugador2);
            this.panel1.Controls.Add(this.jugador1);
            this.panel1.Controls.Add(this.fondo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(214, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(13, 419);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(196, 20);
            this.textBox3.TabIndex = 28;
            // 
            // CLOSE
            // 
            this.CLOSE.Location = new System.Drawing.Point(363, 368);
            this.CLOSE.Name = "CLOSE";
            this.CLOSE.Size = new System.Drawing.Size(75, 23);
            this.CLOSE.TabIndex = 27;
            this.CLOSE.Text = "CLOSE";
            this.CLOSE.UseVisualStyleBackColor = true;
            this.CLOSE.Click += new System.EventHandler(this.CLOSE_Click);
            // 
            // START
            // 
            this.START.BackColor = System.Drawing.Color.Coral;
            this.START.Enabled = false;
            this.START.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.START.Location = new System.Drawing.Point(354, 311);
            this.START.Name = "START";
            this.START.Size = new System.Drawing.Size(93, 39);
            this.START.TabIndex = 26;
            this.START.Text = "START";
            this.START.UseVisualStyleBackColor = false;
            this.START.Click += new System.EventHandler(this.START_Click);
            // 
            // jugador4
            // 
            this.jugador4.AutoSize = true;
            this.jugador4.BackColor = System.Drawing.Color.LightSalmon;
            this.jugador4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.jugador4.ForeColor = System.Drawing.Color.Red;
            this.jugador4.Location = new System.Drawing.Point(662, 151);
            this.jugador4.Name = "jugador4";
            this.jugador4.Size = new System.Drawing.Size(43, 31);
            this.jugador4.TabIndex = 25;
            this.jugador4.Text = "J4";
            // 
            // jugador3
            // 
            this.jugador3.AutoSize = true;
            this.jugador3.BackColor = System.Drawing.Color.LightSalmon;
            this.jugador3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.jugador3.ForeColor = System.Drawing.Color.Red;
            this.jugador3.Location = new System.Drawing.Point(482, 270);
            this.jugador3.Name = "jugador3";
            this.jugador3.Size = new System.Drawing.Size(43, 31);
            this.jugador3.TabIndex = 24;
            this.jugador3.Text = "J3";
            // 
            // jugador2
            // 
            this.jugador2.AutoSize = true;
            this.jugador2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.jugador2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.jugador2.ForeColor = System.Drawing.Color.Red;
            this.jugador2.Location = new System.Drawing.Point(90, 270);
            this.jugador2.Name = "jugador2";
            this.jugador2.Size = new System.Drawing.Size(43, 31);
            this.jugador2.TabIndex = 22;
            this.jugador2.Text = "J2";
            // 
            // jugador1
            // 
            this.jugador1.AutoSize = true;
            this.jugador1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.jugador1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.jugador1.ForeColor = System.Drawing.Color.Green;
            this.jugador1.Location = new System.Drawing.Point(270, 151);
            this.jugador1.Name = "jugador1";
            this.jugador1.Size = new System.Drawing.Size(46, 31);
            this.jugador1.TabIndex = 21;
            this.jugador1.Text = "Tu";
            // 
            // pilota
            // 
            this.pilota.BackColor = System.Drawing.Color.Transparent;
            this.pilota.Image = global::WindowsFormsApp2.Properties.Resources.png_clipart_tennis_balls_green_tennis_glass_white;
            this.pilota.Location = new System.Drawing.Point(387, 213);
            this.pilota.Name = "pilota";
            this.pilota.Size = new System.Drawing.Size(37, 37);
            this.pilota.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pilota.TabIndex = 31;
            this.pilota.TabStop = false;
            // 
            // J2
            // 
            this.J2.BackColor = System.Drawing.Color.Transparent;
            this.J2.Image = global::WindowsFormsApp2.Properties.Resources.jugador;
            this.J2.Location = new System.Drawing.Point(139, 283);
            this.J2.Name = "J2";
            this.J2.Size = new System.Drawing.Size(51, 67);
            this.J2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.J2.TabIndex = 6;
            this.J2.TabStop = false;
            this.J2.Visible = false;
            // 
            // J4
            // 
            this.J4.BackColor = System.Drawing.Color.Transparent;
            this.J4.Image = global::WindowsFormsApp2.Properties.Resources.jugador;
            this.J4.Location = new System.Drawing.Point(654, 213);
            this.J4.Name = "J4";
            this.J4.Size = new System.Drawing.Size(51, 67);
            this.J4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.J4.TabIndex = 8;
            this.J4.TabStop = false;
            this.J4.Visible = false;
            // 
            // J1
            // 
            this.J1.BackColor = System.Drawing.Color.Transparent;
            this.J1.Image = global::WindowsFormsApp2.Properties.Resources.jugador;
            this.J1.Location = new System.Drawing.Point(197, 115);
            this.J1.Name = "J1";
            this.J1.Size = new System.Drawing.Size(51, 67);
            this.J1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.J1.TabIndex = 5;
            this.J1.TabStop = false;
            this.J1.Visible = false;
            // 
            // J3
            // 
            this.J3.BackColor = System.Drawing.Color.Transparent;
            this.J3.Image = global::WindowsFormsApp2.Properties.Resources.jugador;
            this.J3.Location = new System.Drawing.Point(531, 283);
            this.J3.Name = "J3";
            this.J3.Size = new System.Drawing.Size(51, 67);
            this.J3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.J3.TabIndex = 7;
            this.J3.TabStop = false;
            this.J3.Visible = false;
            // 
            // fondo
            // 
            this.fondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fondo.Image = global::WindowsFormsApp2.Properties.Resources.fondo;
            this.fondo.Location = new System.Drawing.Point(0, 0);
            this.fondo.Name = "fondo";
            this.fondo.Size = new System.Drawing.Size(800, 450);
            this.fondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fondo.TabIndex = 30;
            this.fondo.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pilota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.J2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.J4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.J1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.J3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fondo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox J1;
        private System.Windows.Forms.PictureBox J2;
        private System.Windows.Forms.PictureBox J3;
        private System.Windows.Forms.PictureBox J4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label jugador1;
        private System.Windows.Forms.Label jugador2;
        private System.Windows.Forms.Label jugador3;
        private System.Windows.Forms.Label jugador4;
        private System.Windows.Forms.Button START;
        private System.Windows.Forms.Button CLOSE;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox fondo;
        private System.Windows.Forms.PictureBox pilota;
    }
}