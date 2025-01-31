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
    public partial class Form8 : Form
    {
        public Form8()
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

        private void Form8_Load(object sender, EventArgs e)
        {
            CargarMascotas();
        }

        private void CargarMascotas()
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Utiliza el procedimiento almacenado para obtener datos de Mascotas
                SqlDataAdapter daMascotas = new SqlDataAdapter("ListadoMascotas", obj_Conexion.Conex);
                daMascotas.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtMascotas = new DataTable();
                daMascotas.Fill(dtMascotas);

                dgvCRUDMascotas.DataSource = dtMascotas;
                this.dgvCRUDMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Marca toda la fila al pulsar en una celda
                this.dgvCRUDMascotas.ReadOnly = true;

                obj_Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool CamposMascotaCompletos()
        {
            return !string.IsNullOrWhiteSpace(TxtCodigo.Text) &&
               !string.IsNullOrWhiteSpace(TxtNombre.Text) &&
               !string.IsNullOrWhiteSpace(TxtRaza.Text) &&
               !string.IsNullOrWhiteSpace(TxtEspecie.Text) &&
               !string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) &&
               !string.IsNullOrWhiteSpace(Txt_ID_dueño.Text);
        }

        private void LimpiarCampos()
        {

            TxtCodigo.Text = string.Empty;
            TxtNombre.Text = string.Empty;
            TxtRaza.Text = string.Empty;
            TxtEspecie.Text = string.Empty;
            txtFechaNacimiento.Text = string.Empty;
            Txt_ID_dueño.Text = string.Empty;
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CamposMascotaCompletos())  // Validación de campos
                {
                    ConexionGV obj_Conexion = new ConexionGV();
                    obj_Conexion.abrir();

                    using (var cmdActualizarMascota = new SqlCommand("usp_Actualizar_Mascota", obj_Conexion.Conex))
                    {
                        cmdActualizarMascota.CommandType = CommandType.StoredProcedure;

                        // Asignar los parámetros
                        cmdActualizarMascota.Parameters.AddWithValue("@ID_MASCOTA", TxtCodigo.Text);
                        cmdActualizarMascota.Parameters.AddWithValue("@NOMBRE", TxtNombre.Text);
                        cmdActualizarMascota.Parameters.AddWithValue("@RAZA", TxtRaza.Text);
                        cmdActualizarMascota.Parameters.AddWithValue("@ESPECIE", TxtEspecie.Text);
                        cmdActualizarMascota.Parameters.AddWithValue("@FECHA_NAC", DateTime.Parse(txtFechaNacimiento.Text));  // Formato de fecha

                        // Ejecutar el comando
                        cmdActualizarMascota.Parameters.Add(new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        });

                        cmdActualizarMascota.ExecuteNonQuery();
                        int result = (int)cmdActualizarMascota.Parameters["@ReturnVal"].Value;

                        if (result == 1)
                        {
                            MessageBox.Show("Datos de la mascota actualizados exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarMascotas();
                        }
                        else
                        {
                            MessageBox.Show("El registro de la mascota no existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la base de datos: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCRUDMascotas.Rows[e.RowIndex];

                // Rellena los TextBox con los datos seleccionados
                TxtCodigo.Text = row.Cells["ID_Mascota"].Value.ToString();
                TxtNombre.Text = row.Cells["Nombre"].Value.ToString();
                TxtRaza.Text = row.Cells["Raza"].Value.ToString();
                TxtEspecie.Text = row.Cells["Especie"].Value.ToString();
                txtFechaNacimiento.Text = Convert.ToDateTime(row.Cells["Fecha_nac"].Value).ToString("yyyy-MM-dd");
                Txt_ID_dueño.Text = row.Cells["ID_Dueño"].Value.ToString();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual (Formulario 8)
            this.Close();
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtRaza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtEspecie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Form8_Load_1(object sender, EventArgs e)
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Utiliza el procedimiento almacenado para obtener datos de Mascotas
                SqlDataAdapter daMascotas = new SqlDataAdapter("ListadoMascotas", obj_Conexion.Conex);
                daMascotas.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dtMascotas = new DataTable();
                daMascotas.Fill(dtMascotas);

                dgvCRUDMascotas.DataSource = dtMascotas;
                this.dgvCRUDMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Marca toda la fila al pulsar en una celda
                this.dgvCRUDMascotas.ReadOnly = true;

                obj_Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verifica que hay una fila seleccionada en el DataGridView
            if (dgvCRUDMascotas.SelectedRows.Count > 0)
            {
                // Obtiene el ID_Mascota de la fila seleccionada
                string idMascota = dgvCRUDMascotas.SelectedRows[0].Cells["ID_Mascota"].Value.ToString();

                try
                {
                    ConexionGV obj_Conexion = new ConexionGV();
                    obj_Conexion.abrir();

                    // Configura el comando para ejecutar el procedimiento almacenado
                    SqlCommand cmdEliminar = new SqlCommand("EliminarMascota", obj_Conexion.Conex);
                    cmdEliminar.CommandType = CommandType.StoredProcedure;
                    cmdEliminar.Parameters.AddWithValue("@ID_Mascota", idMascota);

                    // Ejecuta el comando
                    int rowsAffected = cmdEliminar.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Mascota eliminada exitosamente.");
                        // Refresca el DataGridView para mostrar los cambios
                        CargarMascotas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la mascota.");
                    }

                    obj_Conexion.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una mascota para eliminar.");
            }
        }
    }
}
