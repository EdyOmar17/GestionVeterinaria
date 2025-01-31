namespace PROYECTO_RR_TPC_GV
{
    partial class Form16
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
            this.dgvResgistrosBorrados = new System.Windows.Forms.DataGridView();
            this.label29 = new System.Windows.Forms.Label();
            this.gbDueño.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResgistrosBorrados)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDueño
            // 
            this.gbDueño.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.gbDueño.Controls.Add(this.dgvResgistrosBorrados);
            this.gbDueño.Controls.Add(this.label29);
            this.gbDueño.Location = new System.Drawing.Point(13, 12);
            this.gbDueño.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDueño.Name = "gbDueño";
            this.gbDueño.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gbDueño.Size = new System.Drawing.Size(853, 288);
            this.gbDueño.TabIndex = 3;
            this.gbDueño.TabStop = false;
            this.gbDueño.Text = "Registros Mascotas - Dueños Borrados";
            // 
            // dgvResgistrosBorrados
            // 
            this.dgvResgistrosBorrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResgistrosBorrados.Location = new System.Drawing.Point(7, 46);
            this.dgvResgistrosBorrados.Name = "dgvResgistrosBorrados";
            this.dgvResgistrosBorrados.Size = new System.Drawing.Size(839, 236);
            this.dgvResgistrosBorrados.TabIndex = 31;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(349, 16);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(187, 24);
            this.label29.TabIndex = 30;
            this.label29.Text = "Registros Borrados";
            // 
            // Form16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(877, 308);
            this.Controls.Add(this.gbDueño);
            this.Name = "Form16";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registros Borrados";
            this.Load += new System.EventHandler(this.Form16_Load);
            this.gbDueño.ResumeLayout(false);
            this.gbDueño.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResgistrosBorrados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDueño;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DataGridView dgvResgistrosBorrados;
    }
}