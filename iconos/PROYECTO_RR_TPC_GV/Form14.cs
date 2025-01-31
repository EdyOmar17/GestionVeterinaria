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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            CargarEspecializaciones();
            CargarVeterinarios();
        }

        private void CargarEspecializaciones()
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Cargar especializaciones desde la tabla
                SqlDataAdapter daEspecializaciones = new SqlDataAdapter("SELECT ID_Especializacion, NombreEspecializacion FROM Especializacion", obj_Conexion.Conex);
                DataTable dtEspecializaciones = new DataTable();
                daEspecializaciones.Fill(dtEspecializaciones);

                // Asignar los datos al ComboBox
                cmbEspecializacion.DataSource = dtEspecializaciones;
                cmbEspecializacion.DisplayMember = "NombreEspecializacion";    // Nombre que se mostrará en el ComboBox
                cmbEspecializacion.ValueMember = "ID_Especializacion";  // Valor que se guardará internamente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especializaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVeterinarios()
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Consulta para obtener los veterinarios
                SqlDataAdapter daVeterinarios = new SqlDataAdapter("SELECT ID_Veterinario, Nombre, Apellido, Telefono, ID_Especializacion FROM Veterinario", obj_Conexion.Conex);
                DataTable dtVeterinarios = new DataTable();
                daVeterinarios.Fill(dtVeterinarios);

                DgvVeterinaria.DataSource = dtVeterinarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los veterinarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ConexionGV obj_Conexion = new ConexionGV();
            obj_Conexion.abrir();

            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtApellido.Text) ||
                    string.IsNullOrWhiteSpace(TxtTelefono.Text) || cmbEspecializacion.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insertar el nuevo veterinario
                string query = "INSERT INTO Veterinario (Nombre, Apellido, Telefono, ID_Especializacion) VALUES (@Nombre, @Apellido, @Telefono, @ID_Especializacion)";
                SqlCommand cmd = new SqlCommand(query, obj_Conexion.Conex);

                // Añadir parámetros
                cmd.Parameters.AddWithValue("@Nombre", TxtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido", TxtApellido.Text);
                cmd.Parameters.AddWithValue("@Telefono", TxtTelefono.Text);
                cmd.Parameters.AddWithValue("@ID_Especializacion", cmbEspecializacion.SelectedValue);

                // Ejecutar la consulta
                int resultado = cmd.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show("Veterinario guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarVeterinarios();  // Actualizar DataGridView después de insertar
                }
                else
                {
                    MessageBox.Show("Error al guardar el veterinario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvVeterinaria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow fila = DgvVeterinaria.Rows[e.RowIndex];

                // Mostrar los datos en los campos correspondientes

                TxtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                TxtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                TxtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                cmbEspecializacion.SelectedValue = fila.Cells["ID_Especializacion"].Value;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            // Verifica que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtApellido.Text) ||
                string.IsNullOrWhiteSpace(TxtTelefono.Text) || cmbEspecializacion.SelectedValue == null)
            {
                MessageBox.Show("Por favor, completa todos los campos antes de actualizar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                string query = "UPDATE Veterinario SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, ID_Especializacion = @ID_Especializacion WHERE ID_Veterinario = @ID";

                SqlCommand cmd = new SqlCommand(query, obj_Conexion.Conex);

                cmd.Parameters.AddWithValue("@Nombre", TxtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido", TxtApellido.Text);
                cmd.Parameters.AddWithValue("@Telefono", TxtTelefono.Text);
                cmd.Parameters.AddWithValue("@ID_Especializacion", cmbEspecializacion.SelectedValue);
                cmd.Parameters.AddWithValue("@ID", DgvVeterinaria.CurrentRow.Cells["ID_Veterinario"].Value);

                int resultado = cmd.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show("Datos actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refrescar el DataGridView para mostrar los datos actualizados
                    CargarVeterinarios();
                }
                else
                {
                    MessageBox.Show("Error al actualizar los datos del veterinario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DgvVeterinaria.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecciona un veterinario para eliminar.", "Sin selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mensaje de confirmación
            var resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este veterinario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    ConexionGV obj_Conexion = new ConexionGV();
                    obj_Conexion.abrir();

                    string query = "DELETE FROM Veterinario WHERE ID_Veterinario = @ID";
                    SqlCommand cmd = new SqlCommand(query, obj_Conexion.Conex);

                    // Obtiene el ID del veterinario seleccionado
                    cmd.Parameters.AddWithValue("@ID", DgvVeterinaria.CurrentRow.Cells["ID_Veterinario"].Value);

                    int resultadoEliminacion = cmd.ExecuteNonQuery();

                    if (resultadoEliminacion > 0)
                    {
                        MessageBox.Show("Veterinario eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refrescar el DataGridView para mostrar los cambios
                        CargarVeterinarios();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el veterinario. Puede que no exista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Verifica si los campos están llenos
            if (!string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                !string.IsNullOrWhiteSpace(TxtApellido.Text) ||
                !string.IsNullOrWhiteSpace(TxtTelefono.Text) ||
                cmbEspecializacion.SelectedValue != null)
            {
                // Limpiar los campos
                TxtNombre.Clear();
                TxtApellido.Clear();
                TxtTelefono.Clear();
                cmbEspecializacion.SelectedIndex = -1; // Resetea el ComboBox

                MessageBox.Show("Campos limpiados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los campos ya están vacíos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
