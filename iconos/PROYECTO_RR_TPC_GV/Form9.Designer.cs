namespace PROYECTO_RR_TPC_GV
{
    partial class Form9
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
            this.Empleados = new System.Windows.Forms.GroupBox();
            this.btnSalirFormulario = new System.Windows.Forms.Button();
            this.btnBuscarCodigo = new System.Windows.Forms.Button();
            this.btnGuardarMascota_Imagen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.pbImgen = new System.Windows.Forms.PictureBox();
            this.txtNombreMascota = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Empleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgen)).BeginInit();
            this.SuspendLayout();
            // 
            // Empleados
            // 
            this.Empleados.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.Empleados.Controls.Add(this.btnSalirFormulario);
            this.Empleados.Controls.Add(this.btnBuscarCodigo);
            this.Empleados.Controls.Add(this.btnGuardarMascota_Imagen);
            this.Empleados.Controls.Add(this.label3);
            this.Empleados.Controls.Add(this.btnCargarImagen);
            this.Empleados.Controls.Add(this.pbImgen);
            this.Empleados.Controls.Add(this.txtNombreMascota);
            this.Empleados.Controls.Add(this.txtCodigo);
            this.Empleados.Controls.Add(this.label2);
            this.Empleados.Controls.Add(this.label1);
            this.Empleados.Location = new System.Drawing.Point(11, 11);
            this.Empleados.Margin = new System.Windows.Forms.Padding(2);
            this.Empleados.Name = "Empleados";
            this.Empleados.Padding = new System.Windows.Forms.Padding(2);
            this.Empleados.Size = new System.Drawing.Size(429, 181);
            this.Empleados.TabIndex = 14;
            this.Empleados.TabStop = false;
            this.Empleados.Text = "CRUD de Mascota_Imagen";
            // 
            // btnSalirFormulario
            // 
            this.btnSalirFormulario.Location = new System.Drawing.Point(159, 119);
            this.btnSalirFormulario.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalirFormulario.Name = "btnSalirFormulario";
            this.btnSalirFormulario.Size = new System.Drawing.Size(97, 40);
            this.btnSalirFormulario.TabIndex = 22;
            this.btnSalirFormulario.Text = "Salir del Formulario";
            this.btnSalirFormulario.UseVisualStyleBackColor = true;
            this.btnSalirFormulario.Click += new System.EventHandler(this.btnSalirFormulario_Click);
            // 
            // btnBuscarCodigo
            // 
            this.btnBuscarCodigo.Location = new System.Drawing.Point(159, 35);
            this.btnBuscarCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCodigo.Name = "btnBuscarCodigo";
            this.btnBuscarCodigo.Size = new System.Drawing.Size(89, 23);
            this.btnBuscarCodigo.TabIndex = 21;
            this.btnBuscarCodigo.Text = "Buscar Codigo";
            this.btnBuscarCodigo.UseVisualStyleBackColor = true;
            this.btnBuscarCodigo.Click += new System.EventHandler(this.btnBuscarCodigo_Click);
            // 
            // btnGuardarMascota_Imagen
            // 
            this.btnGuardarMascota_Imagen.Location = new System.Drawing.Point(42, 119);
            this.btnGuardarMascota_Imagen.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarMascota_Imagen.Name = "btnGuardarMascota_Imagen";
            this.btnGuardarMascota_Imagen.Size = new System.Drawing.Size(97, 40);
            this.btnGuardarMascota_Imagen.TabIndex = 20;
            this.btnGuardarMascota_Imagen.Text = "Guardar Mascota_Imagen";
            this.btnGuardarMascota_Imagen.UseVisualStyleBackColor = true;
            this.btnGuardarMascota_Imagen.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Foto";
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Location = new System.Drawing.Point(302, 143);
            this.btnCargarImagen.Margin = new System.Windows.Forms.Padding(2);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(115, 27);
            this.btnCargarImagen.TabIndex = 18;
            this.btnCargarImagen.Text = "Cargar Imagen";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // pbImgen
            // 
            this.pbImgen.Location = new System.Drawing.Point(302, 24);
            this.pbImgen.Margin = new System.Windows.Forms.Padding(2);
            this.pbImgen.Name = "pbImgen";
            this.pbImgen.Size = new System.Drawing.Size(115, 115);
            this.pbImgen.TabIndex = 17;
            this.pbImgen.TabStop = false;
            // 
            // txtNombreMascota
            // 
            this.txtNombreMascota.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreMascota.Location = new System.Drawing.Point(159, 75);
            this.txtNombreMascota.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreMascota.Name = "txtNombreMascota";
            this.txtNombreMascota.Size = new System.Drawing.Size(135, 23);
            this.txtNombreMascota.TabIndex = 3;
            this.txtNombreMascota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApeNom_KeyPress);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(63, 35);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(76, 23);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.Click += new System.EventHandler(this.txtCodigo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre de la Mascota";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(452, 202);
            this.Controls.Add(this.Empleados);
            this.Name = "Form9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRUD de Mascota_Imagen";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.Empleados.ResumeLayout(false);
            this.Empleados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Empleados;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.PictureBox pbImgen;
        private System.Windows.Forms.Button btnGuardarMascota_Imagen;
        private System.Windows.Forms.TextBox txtNombreMascota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarCodigo;
        private System.Windows.Forms.Button btnSalirFormulario;
    }
}