﻿namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LOGIN = new System.Windows.Forms.Button();
            this.SIGNIN = new System.Windows.Forms.Button();
            this.QUERY1 = new System.Windows.Forms.Button();
            this.QUERY2 = new System.Windows.Forms.Button();
            this.QUERY3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.USERNAME = new System.Windows.Forms.TextBox();
            this.PASSWORD = new System.Windows.Forms.TextBox();
            this.NAME = new System.Windows.Forms.TextBox();
            this.DATE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DESCONECTAR = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lConectados = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Invitar = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.eliminarBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LOGIN
            // 
            this.LOGIN.Location = new System.Drawing.Point(391, 36);
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.Size = new System.Drawing.Size(75, 23);
            this.LOGIN.TabIndex = 0;
            this.LOGIN.Text = "LOG IN";
            this.LOGIN.UseVisualStyleBackColor = true;
            this.LOGIN.Click += new System.EventHandler(this.LOGIN_Click);
            // 
            // SIGNIN
            // 
            this.SIGNIN.Location = new System.Drawing.Point(391, 87);
            this.SIGNIN.Name = "SIGNIN";
            this.SIGNIN.Size = new System.Drawing.Size(75, 23);
            this.SIGNIN.TabIndex = 1;
            this.SIGNIN.Text = "SIGN IN";
            this.SIGNIN.UseVisualStyleBackColor = true;
            this.SIGNIN.Click += new System.EventHandler(this.SIGNIN_Click);
            // 
            // QUERY1
            // 
            this.QUERY1.Location = new System.Drawing.Point(391, 156);
            this.QUERY1.Name = "QUERY1";
            this.QUERY1.Size = new System.Drawing.Size(321, 40);
            this.QUERY1.TabIndex = 2;
            this.QUERY1.Text = "PARTIDA MAS LARGA EN UNA FECHA DETERMINADA";
            this.QUERY1.UseVisualStyleBackColor = true;
            this.QUERY1.Visible = false;
            this.QUERY1.Click += new System.EventHandler(this.QUERY1_Click);
            // 
            // QUERY2
            // 
            this.QUERY2.Location = new System.Drawing.Point(391, 202);
            this.QUERY2.Name = "QUERY2";
            this.QUERY2.Size = new System.Drawing.Size(321, 47);
            this.QUERY2.TabIndex = 3;
            this.QUERY2.Text = "JUGADOR CON MAS PARTIDAS EN UNA FECHA DETERMINADA";
            this.QUERY2.UseVisualStyleBackColor = true;
            this.QUERY2.Visible = false;
            this.QUERY2.Click += new System.EventHandler(this.QUERY2_Click);
            // 
            // QUERY3
            // 
            this.QUERY3.Location = new System.Drawing.Point(391, 255);
            this.QUERY3.Name = "QUERY3";
            this.QUERY3.Size = new System.Drawing.Size(321, 41);
            this.QUERY3.TabIndex = 4;
            this.QUERY3.Text = "WINRATIO DE JUGADOR DETERMINADO EN UNA FECHA DETERMINADA";
            this.QUERY3.UseVisualStyleBackColor = true;
            this.QUERY3.Visible = false;
            this.QUERY3.Click += new System.EventHandler(this.QUERY3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(152, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "USUARIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(152, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "CONTRASEÑA";
            // 
            // USERNAME
            // 
            this.USERNAME.Location = new System.Drawing.Point(24, 38);
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.Size = new System.Drawing.Size(100, 20);
            this.USERNAME.TabIndex = 7;
            // 
            // PASSWORD
            // 
            this.PASSWORD.Location = new System.Drawing.Point(24, 85);
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.Size = new System.Drawing.Size(100, 20);
            this.PASSWORD.TabIndex = 8;
            this.PASSWORD.UseSystemPasswordChar = true;
            // 
            // NAME
            // 
            this.NAME.Location = new System.Drawing.Point(24, 158);
            this.NAME.Name = "NAME";
            this.NAME.Size = new System.Drawing.Size(100, 20);
            this.NAME.TabIndex = 9;
            this.NAME.Visible = false;
            // 
            // DATE
            // 
            this.DATE.Location = new System.Drawing.Point(24, 214);
            this.DATE.Name = "DATE";
            this.DATE.Size = new System.Drawing.Size(100, 20);
            this.DATE.TabIndex = 10;
            this.DATE.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(33, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "CONSULTAS";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(152, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "NOMBRE";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(152, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "FECHA (DD/MM/YYYY)";
            this.label5.Visible = false;
            // 
            // DESCONECTAR
            // 
            this.DESCONECTAR.Enabled = false;
            this.DESCONECTAR.Location = new System.Drawing.Point(598, 36);
            this.DESCONECTAR.Name = "DESCONECTAR";
            this.DESCONECTAR.Size = new System.Drawing.Size(113, 23);
            this.DESCONECTAR.TabIndex = 14;
            this.DESCONECTAR.Text = "DESCONECTAR";
            this.DESCONECTAR.UseVisualStyleBackColor = true;
            this.DESCONECTAR.Click += new System.EventHandler(this.DESCONECTAR_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lConectados});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 34);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // lConectados
            // 
            this.lConectados.AutoSize = false;
            this.lConectados.AutoToolTip = true;
            this.lConectados.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.lConectados.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lConectados.Name = "lConectados";
            this.lConectados.Size = new System.Drawing.Size(122, 30);
            this.lConectados.Text = "Conectados";
            this.lConectados.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(69, 22);
            // 
            // Invitar
            // 
            this.Invitar.Enabled = false;
            this.Invitar.Location = new System.Drawing.Point(136, 9);
            this.Invitar.Name = "Invitar";
            this.Invitar.Size = new System.Drawing.Size(86, 22);
            this.Invitar.TabIndex = 16;
            this.Invitar.Text = "Invitar";
            this.Invitar.UseVisualStyleBackColor = true;
            this.Invitar.Visible = false;
            this.Invitar.Click += new System.EventHandler(this.Invitar_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Enabled = false;
            this.Cancelar.Location = new System.Drawing.Point(228, 9);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(86, 22);
            this.Cancelar.TabIndex = 17;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Visible = false;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Invitando:";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(402, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(484, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(564, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // eliminarBtn
            // 
            this.eliminarBtn.Location = new System.Drawing.Point(598, 82);
            this.eliminarBtn.Name = "eliminarBtn";
            this.eliminarBtn.Size = new System.Drawing.Size(113, 23);
            this.eliminarBtn.TabIndex = 22;
            this.eliminarBtn.Text = "ELIMINAR CUENTA";
            this.eliminarBtn.UseVisualStyleBackColor = true;
            this.eliminarBtn.Visible = false;
            this.eliminarBtn.Click += new System.EventHandler(this.eliminarBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.eliminarBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Invitar);
            this.Controls.Add(this.DESCONECTAR);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DATE);
            this.Controls.Add(this.NAME);
            this.Controls.Add(this.PASSWORD);
            this.Controls.Add(this.USERNAME);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.QUERY3);
            this.Controls.Add(this.QUERY2);
            this.Controls.Add(this.QUERY1);
            this.Controls.Add(this.SIGNIN);
            this.Controls.Add(this.LOGIN);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LOGIN;
        private System.Windows.Forms.Button SIGNIN;
        private System.Windows.Forms.Button QUERY1;
        private System.Windows.Forms.Button QUERY2;
        private System.Windows.Forms.Button QUERY3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox USERNAME;
        private System.Windows.Forms.TextBox PASSWORD;
        private System.Windows.Forms.TextBox NAME;
        private System.Windows.Forms.TextBox DATE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button DESCONECTAR;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lConectados;
        private System.Windows.Forms.Button Invitar;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button eliminarBtn;
    }
}

