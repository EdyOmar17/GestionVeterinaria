namespace PROYECTO_RR_TPC_GV
{
    partial class Form8
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
            this.gbDueño = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.txtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.dgvCRUDMascotas = new System.Windows.Forms.DataGridView();
            this.Txt_ID_dueño = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtEspecie = new System.Windows.Forms.TextBox();
            this.TxtRaza = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.gbDueño.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCRUDMascotas)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDueño
            // 
            this.gbDueño.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gbDueño.Controls.Add(this.btnEliminar);
            this.gbDueño.Controls.Add(this.txtFechaNacimiento);
            this.gbDueño.Controls.Add(this.dgvCRUDMascotas);
            this.gbDueño.Controls.Add(this.Txt_ID_dueño);
            this.gbDueño.Controls.Add(this.label6);
            this.gbDueño.Controls.Add(this.TxtEspecie);
            this.gbDueño.Controls.Add(this.TxtRaza);
            this.gbDueño.Controls.Add(this.TxtNombre);
            this.gbDueño.Controls.Add(this.TxtCodigo);
            this.gbDueño.Controls.Add(this.label5);
            this.gbDueño.Controls.Add(this.label4);
            this.gbDueño.Controls.Add(this.label3);
            this.gbDueño.Controls.Add(this.label2);
            this.gbDueño.Controls.Add(this.label1);
            this.gbDueño.Controls.Add(this.btn_limpiar);
            this.gbDueño.Controls.Add(this.BtnActualizar);
            this.gbDueño.Controls.Add(this.BtnCancelar);
            this.gbDueño.Location = new System.Drawing.Point(12, 12);
            this.gbDueño.Name = "gbDueño";
            this.gbDueño.Size = new System.Drawing.Size(711, 208);
            this.gbDueño.TabIndex = 3;
            this.gbDueño.TabStop = false;
            this.gbDueño.Text = "CRUD De Mascotas";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(6, 146);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(72, 23);
            this.btnEliminar.TabIndex = 35;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtFechaNacimiento
            // 
            this.txtFechaNacimiento.Location = new System.Drawing.Point(181, 138);
            this.txtFechaNacimiento.Name = "txtFechaNacimiento";
            this.txtFechaNacimiento.Size = new System.Drawing.Size(100, 20);
            this.txtFechaNacimiento.TabIndex = 34;
            // 
            // dgvCRUDMascotas
            // 
            this.dgvCRUDMascotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCRUDMascotas.Location = new System.Drawing.Point(293, 18);
            this.dgvCRUDMascotas.Name = "dgvCRUDMascotas";
            this.dgvCRUDMascotas.Size = new System.Drawing.Size(410, 177);
            this.dgvCRUDMascotas.TabIndex = 33;
            this.dgvCRUDMascotas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Txt_ID_dueño
            // 
            this.Txt_ID_dueño.Location = new System.Drawing.Point(181, 163);
            this.Txt_ID_dueño.Name = "Txt_ID_dueño";
            this.Txt_ID_dueño.Size = new System.Drawing.Size(100, 20);
            this.Txt_ID_dueño.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "Id_Dueño";
            // 
            // TxtEspecie
            // 
            this.TxtEspecie.Location = new System.Drawing.Point(181, 111);
            this.TxtEspecie.Name = "TxtEspecie";
            this.TxtEspecie.Size = new System.Drawing.Size(100, 20);
            this.TxtEspecie.TabIndex = 29;
            this.TxtEspecie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtEspecie_KeyPress);
            // 
            // TxtRaza
            // 
            this.TxtRaza.Location = new System.Drawing.Point(181, 85);
            this.TxtRaza.Name = "TxtRaza";
            this.TxtRaza.Size = new System.Drawing.Size(100, 20);
            this.TxtRaza.TabIndex = 28;
            this.TxtRaza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtRaza_KeyPress);
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(181, 59);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(100, 20);
            this.TxtNombre.TabIndex = 27;
            this.TxtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNombre_KeyPress);
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(181, 32);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.Size = new System.Drawing.Size(100, 20);
            this.TxtCodigo.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Fecha Nac";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "Especie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Raza";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Codigo";
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(6, 112);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(72, 23);
            this.btn_limpiar.TabIndex = 20;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Location = new System.Drawing.Point(6, 77);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(72, 23);
            this.BtnActualizar.TabIndex = 18;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(7, 43);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(72, 23);
            this.BtnCancelar.TabIndex = 16;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(732, 231);
            this.Controls.Add(this.gbDueño);
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRUD de Mascotas";
            this.Load += new System.EventHandler(this.Form8_Load_1);
            this.gbDueño.ResumeLayout(false);
            this.gbDueño.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCRUDMascotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDueño;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.DataGridView dgvCRUDMascotas;
        private System.Windows.Forms.TextBox Txt_ID_dueño;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtEspecie;
        private System.Windows.Forms.TextBox TxtRaza;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFechaNacimiento;
        private System.Windows.Forms.Button btnEliminar;
    }
}