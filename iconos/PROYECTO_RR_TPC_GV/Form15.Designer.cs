namespace PROYECTO_RR_TPC_GV
{
    partial class Form15
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form15));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtregistrosNoEnco = new System.Windows.Forms.Label();
            this.DgvImagenMascota = new System.Windows.Forms.DataGridView();
            this.txtregistrosencontrados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBorrarRegistro = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvImagenMascota)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBorrarRegistro);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtregistrosNoEnco);
            this.groupBox1.Controls.Add(this.DgvImagenMascota);
            this.groupBox1.Controls.Add(this.txtregistrosencontrados);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 360);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar Citas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(261, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Consulta Mascotas con Imagen";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 19);
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
            this.txtregistrosNoEnco.Location = new System.Drawing.Point(502, 318);
            this.txtregistrosNoEnco.Name = "txtregistrosNoEnco";
            this.txtregistrosNoEnco.Size = new System.Drawing.Size(100, 23);
            this.txtregistrosNoEnco.TabIndex = 11;
            // 
            // DgvImagenMascota
            // 
            this.DgvImagenMascota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvImagenMascota.Location = new System.Drawing.Point(6, 103);
            this.DgvImagenMascota.Name = "DgvImagenMascota";
            this.DgvImagenMascota.Size = new System.Drawing.Size(744, 198);
            this.DgvImagenMascota.TabIndex = 5;
            // 
            // txtregistrosencontrados
            // 
            this.txtregistrosencontrados.BackColor = System.Drawing.Color.White;
            this.txtregistrosencontrados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtregistrosencontrados.Location = new System.Drawing.Point(187, 317);
            this.txtregistrosencontrados.Name = "txtregistrosencontrados";
            this.txtregistrosencontrados.Size = new System.Drawing.Size(100, 23);
            this.txtregistrosencontrados.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Registros no encontrados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Registros encontrados:";
            // 
            // btnBorrarRegistro
            // 
            this.btnBorrarRegistro.Location = new System.Drawing.Point(642, 308);
            this.btnBorrarRegistro.Name = "btnBorrarRegistro";
            this.btnBorrarRegistro.Size = new System.Drawing.Size(75, 38);
            this.btnBorrarRegistro.TabIndex = 35;
            this.btnBorrarRegistro.Text = "Salir de Formulario";
            this.btnBorrarRegistro.UseVisualStyleBackColor = true;
            this.btnBorrarRegistro.Click += new System.EventHandler(this.btnBorrarRegistro_Click);
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(780, 382);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form15";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Mascota con Imagen";
            this.Load += new System.EventHandler(this.Form15_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvImagenMascota)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtregistrosNoEnco;
        private System.Windows.Forms.DataGridView DgvImagenMascota;
        private System.Windows.Forms.Label txtregistrosencontrados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBorrarRegistro;
    }
}