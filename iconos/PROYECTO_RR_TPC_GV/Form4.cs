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
    public partial class Form4 : Form
    {
        public Form4()
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


        private void txtBuscarDueñoDNI_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string dni = txtBuscarDueñoDNI.Text.Trim();
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                if (string.IsNullOrEmpty(dni))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Dueño", obj_Conexion.Conex);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;
                    this.txtregistrosencontrados.Text = dt.Rows.Count.ToString();
                    this.dataGridView1.AllowUserToAddRows = false;
                    this.dataGridView1.ReadOnly = true;
                    int Mostradas = dt.Rows.Count;
                    this.txtregistrosencontrados.Text = Mostradas.ToString();

                    SqlCommand countTotalOrders = new SqlCommand("SELECT COUNT(*) FROM Dueño", obj_Conexion.Conex);
                    int totalOrders = (int)countTotalOrders.ExecuteScalar();
                    int Nomostradas = totalOrders - Mostradas;
                    this.txtregistrosNoEnco.Text = Nomostradas.ToString();
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Dueño WHERE DNI LIKE @DNI + '%'", obj_Conexion.Conex);
                    da.SelectCommand.Parameters.AddWithValue("@DNI", dni);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;
                    this.txtregistrosencontrados.Text = dt.Rows.Count.ToString();
                    this.dataGridView1.AllowUserToAddRows = false;
                    this.dataGridView1.ReadOnly = true;
                    int Mostradas = dt.Rows.Count;
                    this.txtregistrosencontrados.Text = Mostradas.ToString();

                    SqlCommand countTotalOrders = new SqlCommand("SELECT COUNT(*) FROM Dueño", obj_Conexion.Conex);
                    int totalOrders = (int)countTotalOrders.ExecuteScalar();
                    int Nomostradas = totalOrders - Mostradas;
                    this.txtregistrosNoEnco.Text = Nomostradas.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private string dniSeleccionado;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                dniSeleccionado = row.Cells["DNI"].Value.ToString();
            }
        }

        private void btnBorrarDueño_Click(object sender, EventArgs e)
        {
            // Verifica si hay una fila seleccionada y si el campo "DNI" no es nulo
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un registro para borrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows[0].Cells["DNI"].Value == null)
            {
                MessageBox.Show("El campo 'DNI' está vacío. Verifica que el registro contenga un DNI.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtén el valor del DNI de la fila seleccionada
            string dniSeleccionado = dataGridView1.SelectedRows[0].Cells["DNI"].Value.ToString();

            // Comprueba si el valor es válido
            if (string.IsNullOrEmpty(dniSeleccionado))
            {
                MessageBox.Show("El valor de 'DNI' está vacío. Verifica la columna 'DNI' en el DataGridView.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (ConexionGV obj_Conexion = new ConexionGV())
                {
                    obj_Conexion.abrir();

                    // Iniciar una transacción para asegurar la consistencia
                    using (SqlTransaction transaccion = obj_Conexion.Conex.BeginTransaction())
                    {
                        try
                        {
                            // Primero, eliminar todas las mascotas asociadas al dueño
                            SqlCommand cmdEliminarMascotas = new SqlCommand("DELETE FROM Mascota WHERE ID_Dueño = (SELECT ID_Dueño FROM Dueño WHERE DNI = @DNI)", obj_Conexion.Conex, transaccion);
                            cmdEliminarMascotas.Parameters.AddWithValue("@DNI", dniSeleccionado);
                            cmdEliminarMascotas.ExecuteNonQuery();

                            // Luego, eliminar al dueño
                            SqlCommand cmdEliminarDueño = new SqlCommand("DELETE FROM Dueño WHERE DNI = @DNI", obj_Conexion.Conex, transaccion);
                            cmdEliminarDueño.Parameters.AddWithValue("@DNI", dniSeleccionado);
                            int resultado = cmdEliminarDueño.ExecuteNonQuery();

                            // Confirmar la transacción
                            transaccion.Commit();

                            if (resultado > 0)
                            {
                                MessageBox.Show("Registro borrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Refrescar el DataGridView para mostrar los cambios
                                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            }
                            else
                            {
                                MessageBox.Show("Error al borrar el registro. Intenta nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

        private void txtBuscarDueñoDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
