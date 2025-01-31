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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROYECTO_RR_TPC_GV
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public class ConexionGV : IDisposable
        {
            public SqlConnection Conex { get; private set; }

            public ConexionGV()
            {
                // Inicializar la conexión aquí
                Conex = new SqlConnection("Server=REGIS-DORIS-EDY\\SQLEXPRESS; Database=GestionVeterinaria; Integrated Security=true;");
                //Conex = new SqlConnection("Server=(local); Database=GestionVeterinaria; uid=sa; pwd=123;");
            }

            public void abrir()
            {
                if (Conex.State == ConnectionState.Closed)
                {
                    Conex.Open();
                }
            }

            public void cerrar()
            {
                if (Conex.State == ConnectionState.Open)
                {
                    Conex.Close();
                }
            }

            public void Dispose()
            {
                cerrar();
                Conex.Dispose();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscarMascota_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Cambiar la consulta para buscar en la tabla Mascota
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Mascota WHERE Nombre LIKE @NombreMascota + '%'", obj_Conexion.Conex);
                da.SelectCommand.Parameters.AddWithValue("@NombreMascota", txtBuscarMascota.Text.Trim());

                DataTable dt = new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;

                this.dataGridView1.AllowUserToAddRows = false;
                this.dataGridView1.ReadOnly = true;

                // Mostrar registros encontrados
                int registrosEncontrados = dt.Rows.Count;
                this.txtregistrosencontrados.Text = registrosEncontrados.ToString();

                // Calcular total de registros en la tabla Mascota
                SqlCommand countTotalMascotas = new SqlCommand("SELECT COUNT(*) FROM Mascota", obj_Conexion.Conex);
                int totalMascotas = (int)countTotalMascotas.ExecuteScalar();

                // Calcular registros no encontrados
                int registrosNoEncontrados = totalMascotas - registrosEncontrados;
                this.txtregistrosNoEnco.Text = registrosNoEncontrados.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtBuscarMascota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnBorrarMascota_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada y si el campo "ID_Mascota" no es nulo
            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows[0].Cells["ID_Mascota"].Value == null)
            {
                MessageBox.Show("Por favor, selecciona una mascota para borrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtén el valor de ID_Mascota de la fila seleccionada
            string idMascotaSeleccionado = dataGridView1.SelectedRows[0].Cells["ID_Mascota"].Value.ToString();

            try
            {
                using (ConexionGV obj_Conexion = new ConexionGV())
                {
                    obj_Conexion.abrir();

                    using (SqlTransaction transaccion = obj_Conexion.Conex.BeginTransaction())
                    {
                        try
                        {
                            // Eliminar todas las citas asociadas a la mascota
                            SqlCommand cmdEliminarCitas = new SqlCommand("DELETE FROM Cita WHERE ID_Mascota = @ID_Mascota", obj_Conexion.Conex, transaccion);
                            cmdEliminarCitas.Parameters.AddWithValue("@ID_Mascota", idMascotaSeleccionado);
                            cmdEliminarCitas.ExecuteNonQuery();

                            // Eliminar todas las imágenes asociadas a la mascota
                            SqlCommand cmdEliminarImagenes = new SqlCommand("DELETE FROM Mascota_Imagen WHERE ID_Mascota = @ID_Mascota", obj_Conexion.Conex, transaccion);
                            cmdEliminarImagenes.Parameters.AddWithValue("@ID_Mascota", idMascotaSeleccionado);
                            cmdEliminarImagenes.ExecuteNonQuery();

                            // Eliminar la mascota
                            SqlCommand cmdEliminarMascota = new SqlCommand("DELETE FROM Mascota WHERE ID_Mascota = @ID_Mascota", obj_Conexion.Conex, transaccion);
                            cmdEliminarMascota.Parameters.AddWithValue("@ID_Mascota", idMascotaSeleccionado);
                            cmdEliminarMascota.ExecuteNonQuery();

                            // Verificar si el dueño tiene más mascotas
                            SqlCommand cmdVerificarMascotas = new SqlCommand("SELECT COUNT(*) FROM Mascota WHERE ID_Dueño = (SELECT ID_Dueño FROM Mascota WHERE ID_Mascota = @ID_Mascota)", obj_Conexion.Conex, transaccion);
                            cmdVerificarMascotas.Parameters.AddWithValue("@ID_Mascota", idMascotaSeleccionado);
                            int mascotasRestantes = (int)cmdVerificarMascotas.ExecuteScalar();

                            // Si no tiene más mascotas, eliminar al dueño
                            if (mascotasRestantes == 0)
                            {
                                SqlCommand cmdEliminarDueño = new SqlCommand("DELETE FROM Dueño WHERE ID_Dueño = (SELECT ID_Dueño FROM Mascota WHERE ID_Mascota = @ID_Mascota)", obj_Conexion.Conex, transaccion);
                                cmdEliminarDueño.Parameters.AddWithValue("@ID_Mascota", idMascotaSeleccionado);
                                cmdEliminarDueño.ExecuteNonQuery();
                            }

                            // Confirmar la transacción
                            transaccion.Commit();

                            MessageBox.Show("Registro de mascota borrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refrescar el DataGridView para mostrar los cambios
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                        }
                        catch (Exception ex)
                        {
                            // En caso de error, deshacer la transacción
                            transaccion.Rollback();
                            MessageBox.Show("Error al borrar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
