namespace PROYECTO_RR_TPC_GV
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBuscarMascota = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtregistrosNoEnco = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtregistrosencontrados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBorrarMascota = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.btnBorrarMascota);
            this.groupBox1.Controls.Add(this.txtBuscarMascota);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtregistrosNoEnco);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.txtregistrosencontrados);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 343);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar Mascota";
            // 
            // txtBuscarMascota
            // 
            this.txtBuscarMascota.Location = new System.Drawing.Point(361, 74);
            this.txtBuscarMascota.Name = "txtBuscarMascota";
            this.txtBuscarMascota.Size = new System.Drawing.Size(150, 20);
            this.txtBuscarMascota.TabIndex = 33;
            this.txtBuscarMascota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarMascota_KeyPress);
            this.txtBuscarMascota.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarMascota_KeyUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // txtregistrosNoEnco
            // 
            this.txtregistrosNoEnco.BackColor = System.Drawing.Color.White;
            this.txtregistrosNoEnco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtregistrosNoEnco.Location = new System.Drawing.Point(402, 305);
            this.txtregistrosNoEnco.Name = "txtregistrosNoEnco";
            this.txtregistrosNoEnco.Size = new System.Drawing.Size(100, 23);
            this.txtregistrosNoEnco.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(525, 197);
            this.dataGridView1.TabIndex = 5;
            // 
            // txtregistrosencontrados
            // 
            this.txtregistrosencontrados.BackColor = System.Drawing.Color.White;
            this.txtregistrosencontrados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtregistrosencontrados.Location = new System.Drawing.Point(131, 305);
            this.txtregistrosencontrados.Name = "txtregistrosencontrados";
            this.txtregistrosencontrados.Size = new System.Drawing.Size(100, 23);
            this.txtregistrosencontrados.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Registros no encontrados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Registros encontrados:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Buscar Mascotas por Nombre:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(246, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 39);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultar Mascota";
            // 
            // btnBorrarMascota
            // 
            this.btnBorrarMascota.Location = new System.Drawing.Point(156, 22);
            this.btnBorrarMascota.Name = "btnBorrarMascota";
            this.btnBorrarMascota.Size = new System.Drawing.Size(75, 38);
            this.btnBorrarMascota.TabIndex = 36;
            this.btnBorrarMascota.Text = "Borrar Registro";
            this.btnBorrarMascota.UseVisualStyleBackColor = true;
            this.btnBorrarMascota.Click += new System.EventHandler(this.btnBorrarMascota_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(560, 365);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Mascota Por Nombre";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBuscarMascota;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtregistrosNoEnco;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label txtregistrosencontrados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBorrarMascota;
    }
}