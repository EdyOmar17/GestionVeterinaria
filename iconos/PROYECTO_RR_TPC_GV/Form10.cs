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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Utiliza el procedimiento almacenado para obtener datos de Veterinarios
                SqlDataAdapter daVeterinarios = new SqlDataAdapter("usp_ObtenerDueños", obj_Conexion.Conex); // Asegúrate de que este procedimiento almacenado exista
                daVeterinarios.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtVeterinarios = new DataTable();
                daVeterinarios.Fill(dtVeterinarios);

                dgvDueño.DataSource = dtVeterinarios;
                this.dgvDueño.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Marca toda la fila al pulsar en una celda
                this.dgvDueño.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvDueño_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int fila = this.dgvDueño.CurrentRow.Index;
                if (fila < 0) return;

                // Asegúrate de que estás utilizando la columna correcta para obtener el ID del dueño
                string idDueño = this.dgvDueño.CurrentRow.Cells["ID_Dueño"].Value.ToString();

                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Utiliza el procedimiento almacenado para obtener mascotas por dueño
                SqlDataAdapter daMascotas = new SqlDataAdapter("usp_ObtenerMascotasPorDueño", obj_Conexion.Conex); // Llama al procedimiento almacenado correcto
                daMascotas.SelectCommand.CommandType = CommandType.StoredProcedure;
                daMascotas.SelectCommand.Parameters.AddWithValue("@ID_DUEÑO", idDueño); // Pasa el ID del dueño como parámetro
                DataTable dtMascotas = new DataTable();
                daMascotas.Fill(dtMascotas);

                // Asignar el DataTable al DataGridView
                dgvMascota.DataSource = dtMascotas;

                // Opcional: Configurar el DataGridView de mascotas
                this.dgvMascota.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvMascota.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
