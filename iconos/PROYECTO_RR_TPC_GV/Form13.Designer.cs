namespace PROYECTO_RR_TPC_GV
{
    partial class Form13
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form13));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBorrarRegistro = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtregistrosNoEnco = new System.Windows.Forms.Label();
            this.DgvCitas = new System.Windows.Forms.DataGridView();
            this.txtregistrosencontrados = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCitas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBorrarRegistro);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtregistrosNoEnco);
            this.groupBox1.Controls.Add(this.DgvCitas);
            this.groupBox1.Controls.Add(this.txtregistrosencontrados);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 318);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar Citas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Consulta de las Citas Creadas";
            // 
            // btnBorrarRegistro
            // 
            this.btnBorrarRegistro.Location = new System.Drawing.Point(607, 258);
            this.btnBorrarRegistro.Name = "btnBorrarRegistro";
            this.btnBorrarRegistro.Size = new System.Drawing.Size(75, 38);
            this.btnBorrarRegistro.TabIndex = 35;
            this.btnBorrarRegistro.Text = "Borrar Registro";
            this.btnBorrarRegistro.UseVisualStyleBackColor = true;
            this.btnBorrarRegistro.Click += new System.EventHandler(this.btnBorrarRegistro_Click);
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
            this.txtregistrosNoEnco.Location = new System.Drawing.Point(490, 270);
            this.txtregistrosNoEnco.Name = "txtregistrosNoEnco";
            this.txtregistrosNoEnco.Size = new System.Drawing.Size(100, 23);
            this.txtregistrosNoEnco.TabIndex = 11;
            // 
            // DgvCitas
            // 
            this.DgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCitas.Location = new System.Drawing.Point(6, 103);
            this.DgvCitas.Name = "DgvCitas";
            this.DgvCitas.Size = new System.Drawing.Size(687, 137);
            this.DgvCitas.TabIndex = 5;
            // 
            // txtregistrosencontrados
            // 
            this.txtregistrosencontrados.BackColor = System.Drawing.Color.White;
            this.txtregistrosencontrados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtregistrosencontrados.Location = new System.Drawing.Point(175, 269);
            this.txtregistrosencontrados.Name = "txtregistrosencontrados";
            this.txtregistrosencontrados.Size = new System.Drawing.Size(100, 23);
            this.txtregistrosencontrados.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Registros no encontrados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Registros encontrados:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(473, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 39);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Citas";
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(723, 337);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form13";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Citas Creadas";
            this.Load += new System.EventHandler(this.Form13_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCitas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBorrarRegistro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtregistrosNoEnco;
        private System.Windows.Forms.DataGridView DgvCitas;
        private System.Windows.Forms.Label txtregistrosencontrados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}