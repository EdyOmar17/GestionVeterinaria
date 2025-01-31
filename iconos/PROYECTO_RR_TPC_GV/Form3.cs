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
    public partial class Form3 : Form
    {
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public Form3()
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

            // Implementación de la interfaz IDisposable
            public void Dispose()
            {
                // Liberar los recursos de la conexión
                if (Conex != null)
                {
                    Conex.Dispose();
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarVeterinarios();
            CargarEspecies();
        }

        private void CargarVeterinarios()
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                DataTable dt_VETERINARIOS = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("EXEC CargarVeterinarios", obj_Conexion.Conex);
                da.Fill(dt_VETERINARIOS);

                cmbVeterinaria.Items.Clear();
                if (dt_VETERINARIOS.Rows.Count > 0)
                {
                    foreach (DataRow row in dt_VETERINARIOS.Rows)
                    {
                        string nombreCompleto = row["Nombre"].ToString() + " " + row["Apellido"].ToString();
                        cmbVeterinaria.Items.Add(nombreCompleto);
                    }
                    cmbVeterinaria.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("No se encontraron veterinarios.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarEspecies()
        {
            this.cmbEspecie.Items.Add("(Seleccione)");
            this.cmbEspecie.Items.Add("Perro");
            this.cmbEspecie.Items.Add("Gato");
            
            this.cmbEspecie.SelectedIndex = 0;
            this.cmbEspecie.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnBuscarPac_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }

        private void LimpiarCamposDueño()
        {
            txtNumeroDocumento.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void btnGuardarDueño_Click(object sender, EventArgs e)
        {
            try
            {
                if (CamposDueñoCompletos())
                {
                    using (ConexionGV obj_Conexion = new ConexionGV())
                    {
                        obj_Conexion.abrir();

                        SqlCommand cmdInsertarDueño = new SqlCommand("InsertarDueño", obj_Conexion.Conex);
                        cmdInsertarDueño.CommandType = CommandType.StoredProcedure;
                        cmdInsertarDueño.Parameters.AddWithValue("@DNI", txtNumeroDocumento.Text);
                        cmdInsertarDueño.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmdInsertarDueño.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                        cmdInsertarDueño.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                        cmdInsertarDueño.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                        cmdInsertarDueño.Parameters.AddWithValue("@CorreoElectronico", txtCorreo.Text);

                        int resultado = cmdInsertarDueño.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("Dueño guardado exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("El dueño ya existe o no se pudo guardar. Verifica la información.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, completa todos los campos.");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) // Código de error personalizado
                {
                    MessageBox.Show("El dueño ya existe en la base de datos.");
                }
                else
                {
                    MessageBox.Show("Error en la base de datos: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool CamposDueñoCompletos()
        {
            return !string.IsNullOrWhiteSpace(txtNumeroDocumento.Text) &&
                   !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                   !string.IsNullOrWhiteSpace(txtApellido.Text) &&
                   !string.IsNullOrWhiteSpace(txtDireccion.Text) &&
                   !string.IsNullOrWhiteSpace(txtTelefono.Text) &&
                   !string.IsNullOrWhiteSpace(txtCorreo.Text);
        }

        private void LlenarDatosDueño(string dni)
        {
            using (ConexionGV obj_Conexion = new ConexionGV())
            {
                obj_Conexion.abrir();
                SqlCommand cmd = new SqlCommand("SELECT Nombre, Apellido, Direccion, Telefono, CorreoElectronico FROM Dueño WHERE DNI = @DNI", obj_Conexion.Conex);
                cmd.Parameters.AddWithValue("@DNI", dni);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNombre.Text = reader["Nombre"].ToString();
                    txtApellido.Text = reader["Apellido"].ToString();
                    txtDireccion.Text = reader["Direccion"].ToString();
                    txtTelefono.Text = reader["Telefono"].ToString();
                    txtCorreo.Text = reader["CorreoElectronico"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el DNI proporcionado.");
                }

                reader.Close();
            }
        }


        private void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            int idPropietario;
            if (int.TryParse(txtnumprop.Text, out idPropietario))
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();
                try
                {
                    // Crear el comando para seleccionar los datos del propietario
                    SqlCommand cmd = new SqlCommand(
                        "SELECT Nombre, Apellido, Direccion, Telefono, CorreoElectronico, DNI " +
                        "FROM Dueño WHERE DNI = @DNI", obj_Conexion.Conex);

                    cmd.Parameters.AddWithValue("@DNI", idPropietario);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Mostrar los datos en las etiquetas
                        lblNomProp.Text = reader["Nombre"].ToString();
                        lblApeProp.Text = reader["Apellido"].ToString();
                        lblDirecProp.Text = reader["Direccion"].ToString();
                        lblTelProp.Text = reader["Telefono"].ToString();
                        lblCorreoProp.Text = reader["CorreoElectronico"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Propietario no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el propietario: " + ex.Message);
                }
                finally
                {
                    obj_Conexion.cerrar();
                }
            }
            else
            {
                MessageBox.Show("Ingrese un DNI válido.");
            }
        }

        private bool CamposMascotaCompletos()
        {
            return !string.IsNullOrWhiteSpace(txtNomMasc.Text) &&
                   !string.IsNullOrWhiteSpace(txtRazaMasc.Text) &&
                   cmbEspecie.SelectedIndex > 0 &&
                   !string.IsNullOrWhiteSpace(txtEdadMasc.Text);
        }

        private string GenerarIDMascota()
        {
            return txtNomMasc.Text.Substring(0, 2) + txtRazaMasc.Text.Substring(0, 2) + txtnumprop.Text.Substring(0, 2);
        }

        private void btnguardarPac_Click(object sender, EventArgs e)
        {
            // Crear un objeto de la clase conexión
            ConexionGV obj_Conexion = new ConexionGV();
            // Abrir la conexión
            obj_Conexion.abrir();

            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtNomMasc.Text) || string.IsNullOrWhiteSpace(txtRazaMasc.Text) || string.IsNullOrWhiteSpace(txtEdadMasc.Text) || string.IsNullOrWhiteSpace(cmbEspecie.Text) || string.IsNullOrWhiteSpace(txtnumprop.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Obtener el último ID de la mascota
                    string ultimoIDMascotaQuery = "SELECT TOP 1 ID_Mascota FROM Mascota ORDER BY ID_Mascota DESC";
                    SqlCommand cmdUltimoID = new SqlCommand(ultimoIDMascotaQuery, obj_Conexion.Conex);
                    string ultimoIDMascota = cmdUltimoID.ExecuteScalar()?.ToString();

                    // Generar un nuevo ID para la mascota
                    int nuevoID = int.Parse(ultimoIDMascota.Substring(1)) + 1;
                    string nuevoIDMascota = "M" + nuevoID.ToString("D3");

                    // Obtener el ID del dueño por su DNI
                    string queryDueño = "SELECT ID_Dueño FROM Dueño WHERE DNI = @DNI";
                    SqlCommand cmdDueño = new SqlCommand(queryDueño, obj_Conexion.Conex);
                    cmdDueño.Parameters.AddWithValue("@DNI", txtnumprop.Text);
                    int idDueño = (int)cmdDueño.ExecuteScalar();

                    if (idDueño > 0)
                    {
                        // Query de inserción para la mascota
                        SqlCommand cmdMascota = new SqlCommand("InsertarMascota", obj_Conexion.Conex);
                        cmdMascota.CommandType = CommandType.StoredProcedure;
                        // Añadir los parámetros con los valores del formulario
                        cmdMascota.Parameters.AddWithValue("@ID_Mascota", nuevoIDMascota);
                        cmdMascota.Parameters.AddWithValue("@Nombre", txtNomMasc.Text);
                        cmdMascota.Parameters.AddWithValue("@Especie", cmbEspecie.Text);
                        cmdMascota.Parameters.AddWithValue("@Raza", txtRazaMasc.Text);
                        cmdMascota.Parameters.AddWithValue("@Fecha_nac", txtEdadMasc.Text);
                        cmdMascota.Parameters.AddWithValue("@DNI", txtnumprop.Text);
                        cmdMascota.Parameters.AddWithValue("@Veterinario", cmbVeterinaria.Text);
                        cmdMascota.Parameters.AddWithValue("@Motivo", txtMotivo.Text);
                        cmdMascota.Parameters.AddWithValue("@FechaCita", txtFechaCita.Text);
                        //cmdMascota.Parameters.AddWithValue("@ID_Dueño", idDueño);

                        // Ejecutar la consulta
                        int resultado = cmdMascota.ExecuteNonQuery();

                        // Verificar si se insertó correctamente
                        if (resultado > 0)
                        {
                            MessageBox.Show("Mascota registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar la mascota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dueño no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // En caso de error, mostrar mensaje
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCamposMascota()
        {
            txtNomMasc.Clear();
            txtRazaMasc.Clear();
            txtEdadMasc.Clear();
            cmbEspecie.SelectedIndex = -1;
            txtnumprop.Clear();
        }

        private void btnNRegistroDueño_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void btnNuevoRegPac_Click(object sender, EventArgs e)
        {
            txtNomMasc.Clear();
            cmbEspecie.SelectedIndex = 0;
            txtRazaMasc.Clear();
            txtEdadMasc.Clear();
            lblNomProp.Text = "";
            lblApeProp.Text = "";
            lblDirecProp.Text = "";
            lblTelProp.Text = "";
            lblCorreoProp.Text = "";
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNomMasc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtRazaMasc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEdadMasc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            //{
            //    MessageBox.Show("Solo Numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Handled = true;
            //    return;
            //}
        }

        private void txtEdadMasc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiagnostico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            //{
            //    MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Handled = true;
            //    return;
            //}
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtnumprop_KeyPress(object sender, KeyPressEventArgs e)
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
