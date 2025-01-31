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
    public partial class Form6 : Form
    {
        private string idVeterinarioGlobal;

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Utiliza el procedimiento almacenado para obtener datos de Veterinarios
                SqlDataAdapter daVeterinarios = new SqlDataAdapter("ListadoVeterinarios", obj_Conexion.Conex);
                daVeterinarios.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtVeterinarios = new DataTable();
                daVeterinarios.Fill(dtVeterinarios);

                dgvVeterinario.DataSource = dtVeterinarios;
                this.dgvVeterinario.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Marca toda la fila al pulsar en una celda
                this.dgvVeterinario.ReadOnly = true;

                obj_Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                // Obtén el valor del ID del veterinario seleccionado
                string idVeterinario = dgvVeterinario.Rows[e.RowIndex].Cells["ID_Veterinario"].Value.ToString();
                idVeterinarioGlobal = idVeterinario;

                CargarMascotasPorVeterinario(idVeterinario);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Método para cargar las mascotas atendidas por el veterinario seleccionado
        private void CargarMascotasPorVeterinario(string idVeterinario)
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Utiliza el procedimiento almacenado para obtener datos de Mascotas atendidas por el veterinario seleccionado
                SqlDataAdapter daMascotas = new SqlDataAdapter("ListadoMascotasPorVeterinario", obj_Conexion.Conex);
                daMascotas.SelectCommand.CommandType = CommandType.StoredProcedure;
                daMascotas.SelectCommand.Parameters.AddWithValue("@ID_Veterinario", idVeterinario);
                DataTable dtMascotas = new DataTable();
                daMascotas.Fill(dtMascotas);

                dgvMascota.DataSource = dtMascotas;

                obj_Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Método para insertar una nueva mascota y cita
        private void InsertarMascotaYCita(string idMascota, string nombreMascota, string especie, string raza, DateTime fechaNac, string dniDueño, int idVeterinario, DateTime fechaCita, string motivo, string diagnostico)
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                SqlCommand cmd = new SqlCommand("InsertarMascota", obj_Conexion.Conex);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_Mascota", idMascota);
                cmd.Parameters.AddWithValue("@Nombre", nombreMascota);
                cmd.Parameters.AddWithValue("@Especie", especie);
                cmd.Parameters.AddWithValue("@Raza", raza);
                cmd.Parameters.AddWithValue("@Fecha_nac", fechaNac);
                cmd.Parameters.AddWithValue("@DNI", dniDueño);
                cmd.Parameters.AddWithValue("@ID_Veterinario", idVeterinario);  // Parámetro de veterinario para la cita
                cmd.Parameters.AddWithValue("@FechaCita", fechaCita);
                cmd.Parameters.AddWithValue("@Motivo", motivo);
                cmd.Parameters.AddWithValue("@Diagnostico", diagnostico);

                cmd.ExecuteNonQuery();

                obj_Conexion.cerrar();

                // Refrescar el listado de mascotas por veterinario después de insertar la nueva mascota y cita
                CargarMascotasPorVeterinario(idVeterinario.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvMascota_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                // Verificar si la columna seleccionada es "Diagnostico"
                if (dgvMascota.Columns[e.ColumnIndex].Name == "Diagnostico")
                {
                    // Obtiene el valor del ID de la mascota seleccionada para cargar su diagnóstico
                    int idCita = Convert.ToInt32(dgvMascota.Rows[e.RowIndex].Cells["ID_Cita"].Value.ToString());
                    string diagnosticoActual = dgvMascota.Rows[e.RowIndex].Cells["Diagnostico"].Value.ToString();

                    // Crear una instancia del formulario de edición y pasarle el ID de la mascota y el diagnóstico actual
                    Form12 formEditar = new Form12(idCita, diagnosticoActual);
                    formEditar.ShowDialog();

                    // Actualizar el DataGridView después de editar el diagnóstico
                    CargarMascotasPorVeterinario(idVeterinarioGlobal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvMascota_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void CargarMascotas()
        //{
        //    try
        //    {
        //        // Establecer la conexión a la base de datos
        //        ConexionGV obj_Conexion = new ConexionGV();
        //        obj_Conexion.abrir();

        //        // Crear el comando SQL para seleccionar los datos de las mascotas
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM Mascotas", obj_Conexion.Conex);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();

        //        // Llenar el DataTable con los datos obtenidos
        //        da.Fill(dt);

        //        // Asignar el DataTable como fuente de datos del DataGridView
        //        dgvMascota.DataSource = dt;

        //        // Cerrar la conexión
        //        obj_Conexion.cerrar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al cargar las mascotas: " + ex.Message);
        //    }
        //}
    }
}
