using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_RR_TPC_GV
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            // Obtener las fechas del DateTimePicker
            DateTime fechaInicio = dtpDesde.Value.Date;
            DateTime fechaFin = dtpHasta.Value.Date;

            // Cadena de conexión a la base de datos
            string connectionString = "Server=REGIS-DORIS-EDY\\SQLEXPRESS; Database=GestionVeterinaria; Integrated Security=true;"; // Reemplaza con tu cadena de conexión
            //string connectionString = "Server=(local); Database=GestionVeterinaria; uid=sa; pwd=123;";

            // Crear una conexión a SQL Server
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear un comando para ejecutar el procedimiento almacenado
                    using (SqlCommand command = new SqlCommand("ObtenerVeterinariosPorCitaEnRango", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar los parámetros para el procedimiento almacenado
                        command.Parameters.Add(new SqlParameter("@FechaInicio", fechaInicio));
                        command.Parameters.Add(new SqlParameter("@FechaFin", fechaFin));

                        // Crear un adaptador para llenar el DataGridView
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Mostrar los resultados en el DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Mostrar un mensaje de error en caso de que ocurra alguna excepción
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
