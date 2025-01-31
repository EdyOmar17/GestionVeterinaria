using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_RR_TPC_GV
{
    public partial class Form7 : Form
    {
        public Form7 (int form)
        {
            InitializeComponent();
            if (form == 1)
            {
                groupBox2.Visible = false;
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;
            }
        }

        //public Form7()
        //{
        //    InitializeComponent();

        //    // Establece un valor predeterminado para el formulario
        //    groupBox1.Visible = true;
        //    groupBox2.Visible = false;
        //}

        private void Form7_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string backupPath = txtRutaGuardarBackup.Text + "\\Backup_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
            try
            {
                if (!Directory.Exists(txtRutaGuardarBackup.Text))
                {
                    Directory.CreateDirectory(txtRutaGuardarBackup.Text);
                }

                using (SqlConnection connection = new SqlConnection("Server=REGIS-DORIS-EDY\\SQLEXPRESS; Database=GestionVeterinaria; Integrated Security=true;"))
                //using (SqlConnection connection = new SqlConnection("Server=(local); Database=GestionVeterinaria; uid=sa; pwd=123;"))
                {
                    string query = $"BACKUP DATABASE [GestionVeterinaria] TO DISK = '{backupPath}'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Copia de seguridad creada correctamente en: " + backupPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la copia de seguridad: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtRutaGuardarBackup.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "SQL Backup Files|*.bak|All Files|*.*";
                ofd.FileName = "";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaRestaurar.Text = ofd.FileName;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string restorePath = txtRutaRestaurar.Text;
            string databaseName = txtBackupRestaurada.Text;

            if (string.IsNullOrEmpty(restorePath))
            {
                MessageBox.Show("Por favor, selecciona un archivo de backup.");
                return;
            }

            if (string.IsNullOrEmpty(databaseName))
            {
                MessageBox.Show("Por favor, ingresa el nombre de la base de datos a restaurar.");
                return;
            }

            try
            {
                string dataFilePath = $@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\{databaseName}.mdf";
                string logFilePath = $@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\{databaseName}_log.ldf";
                string logicalDataName = "";
                string logicalLogName = "";

                using (SqlConnection connection = new SqlConnection("Server=REGIS-DORIS-EDY\\SQLEXPRESS; Integrated Security=true;"))
                //using (SqlConnection connection = new SqlConnection("Server=(local); Database=GestionVeterinaria; uid=sa; pwd=123;"))
                {
                    connection.Open();

                    // 1. Obtener nombres lógicos de los archivos en el backup
                    string fileListQuery = $"RESTORE FILELISTONLY FROM DISK = '{restorePath}'";
                    using (SqlCommand cmdFileList = new SqlCommand(fileListQuery, connection))
                    using (SqlDataReader reader = cmdFileList.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            logicalDataName = reader["LogicalName"].ToString();
                        }
                        if (reader.Read())
                        {
                            logicalLogName = reader["LogicalName"].ToString();
                        }
                    }

                    // 2. Ejecutar restauración de la base de datos usando los nombres lógicos
                    string restoreQuery = $@"
                        RESTORE DATABASE [{databaseName}]
                        FROM DISK = '{restorePath}'
                        WITH REPLACE,
                        MOVE '{logicalDataName}' TO '{dataFilePath}',
                        MOVE '{logicalLogName}' TO '{logFilePath}'";

                    using (SqlCommand command = new SqlCommand(restoreQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show($"Base de datos '{databaseName}' restaurada correctamente desde: {restorePath}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar la base de datos: " + ex.Message);
            }
        }

        private void txtBackupRestaurada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
