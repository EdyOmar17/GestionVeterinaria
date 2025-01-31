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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        public void ActualizarDataGridView()
        {
            ConexionGV obj_Conexion = new ConexionGV();
            obj_Conexion.abrir();

            try
            {
                SqlCommand cmdCitas = new SqlCommand("sp_ObtenerCitas", obj_Conexion.Conex)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter da = new SqlDataAdapter(cmdCitas);
                DataTable dtCitas = new DataTable();
                da.Fill(dtCitas);

                DgvCitas.DataSource = dtCitas;

                int registrosEncontrados = dtCitas.Rows.Count;
                txtregistrosencontrados.Text = registrosEncontrados.ToString();

                SqlCommand countTotalMascotas = new SqlCommand("SELECT COUNT(*) FROM Mascota", obj_Conexion.Conex);
                int totalMascotas = (int)countTotalMascotas.ExecuteScalar();

                int registrosNoEncontrados = totalMascotas - registrosEncontrados;
                txtregistrosNoEnco.Text = registrosNoEncontrados.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las citas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                obj_Conexion.cerrar();
            }
        }

        private void btnBorrarRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvCitas.SelectedRows.Count == 0 || DgvCitas.SelectedRows[0].Cells["ID_Mascota"].Value == null || DgvCitas.SelectedRows[0].Cells["Fecha"].Value == null)
                {
                    MessageBox.Show("Por favor, selecciona una cita para borrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtén los valores del ID_Mascota y la Fecha de la cita seleccionada
                string idMascotaSeleccionado = DgvCitas.SelectedRows[0].Cells["ID_Mascota"].Value.ToString();
                DateTime fechaSeleccionada = DateTime.Parse(DgvCitas.SelectedRows[0].Cells["Fecha"].Value.ToString());

                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Iniciar una transacción para asegurar la consistencia
                using (SqlTransaction transaccion = obj_Conexion.Conex.BeginTransaction())
                {
                    try
                    {
                        // Eliminar la cita
                        SqlCommand cmdEliminarCita = new SqlCommand("DELETE FROM Cita WHERE ID_Mascota = @ID_Mascota AND Fecha = @Fecha", obj_Conexion.Conex, transaccion);
                        cmdEliminarCita.Parameters.AddWithValue("@ID_Mascota", idMascotaSeleccionado);
                        cmdEliminarCita.Parameters.AddWithValue("@Fecha", fechaSeleccionada);
                        int resultado = cmdEliminarCita.ExecuteNonQuery();

                        // Confirmar la transacción
                        transaccion.Commit();

                        if (resultado > 0)
                        {
                            MessageBox.Show("Cita borrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refrescar el DataGridView para mostrar los cambios
                            DgvCitas.Rows.RemoveAt(DgvCitas.SelectedRows[0].Index);
                        }
                        else
                        {
                            MessageBox.Show("Error al borrar la cita. Intenta nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // En caso de error, deshacer la transacción
                        transaccion.Rollback();
                        MessageBox.Show("Error al borrar la cita: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
