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
    public partial class Form16 : Form
    {
        // Configura la cadena de conexión de SQL Server
        private string connectionString = "Server=REGIS-DORIS-EDY\\SQLEXPRESS; Database=GestionVeterinaria; Integrated Security=true;";
        //private string connectionString = "Server=(local); Database=GestionVeterinaria; uid=sa; pwd=123;";

        public Form16()
        {
            InitializeComponent();
            CargarRegistroEliminados();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            //////////////////////////////////////////////////
        }

        private void CargarRegistroEliminados()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    ID_Dueño,
                    ID_Mascota,
                    MAX(NombreMascota) AS NombreMascota,
                    MAX(Especie) AS Especie,
                    MAX(Raza) AS Raza,
                    MAX(Fecha_nac) AS Fecha_nac,
                    STRING_AGG(Diagnostico, ', ') AS Diagnostico,
                    STRING_AGG(CONVERT(VARCHAR, FechaEliminacion, 120), ', ') AS FechasEliminacion
                FROM 
                    RegistroEliminados
                GROUP BY 
                    ID_Dueño, ID_Mascota";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvResgistrosBorrados.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }

    }
}
