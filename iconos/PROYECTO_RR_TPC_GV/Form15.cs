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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        public void ActualizarDataGridView()
        {
            ConexionGV obj_Conexion = new ConexionGV();
            obj_Conexion.abrir();

            try
            {
                // Consulta para obtener la información de Mascota y la imagen asociada
                SqlCommand cmdMascotas = new SqlCommand(@"
                    SELECT 
                        m.ID_Mascota,
                        m.Nombre,
                        m.Especie,
                        m.Raza,
                        m.Fecha_nac,
                        m.ID_Dueño,
                        mi.Imagen
                    FROM 
                        Mascota m
                    LEFT JOIN 
                        Mascota_Imagen mi ON m.ID_Mascota = mi.ID_Mascota", obj_Conexion.Conex)
                {
                    CommandType = CommandType.Text
                };

                // Cargar los datos de la consulta en un DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmdMascotas);
                DataTable dtMascotas = new DataTable();
                da.Fill(dtMascotas);

                // Configurar el DataGridView para mostrar imágenes
                DgvImagenMascota.DataSource = null;
                DgvImagenMascota.Columns.Clear();

                // Añadir columnas manualmente y cargar los datos
                DgvImagenMascota.Columns.Add("ID_Mascota", "ID Mascota");
                DgvImagenMascota.Columns.Add("Nombre", "Nombre");
                DgvImagenMascota.Columns.Add("Especie", "Especie");
                DgvImagenMascota.Columns.Add("Raza", "Raza");
                DgvImagenMascota.Columns.Add("Fecha_nac", "Fecha de Nacimiento");
                DgvImagenMascota.Columns.Add("ID_Dueño", "ID Dueño");

                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                imgColumn.Name = "Imagen";
                imgColumn.HeaderText = "Imagen";
                imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                DgvImagenMascota.Columns.Add(imgColumn);

                // Cargar filas en el DataGridView
                foreach (DataRow row in dtMascotas.Rows)
                {
                    byte[] imgData = row["Imagen"] as byte[];
                    Image img = null;

                    if (imgData != null)
                    {
                        using (MemoryStream ms = new MemoryStream(imgData))
                        {
                            img = Image.FromStream(ms);
                        }
                    }

                    DgvImagenMascota.Rows.Add(
                        row["ID_Mascota"],
                        row["Nombre"],
                        row["Especie"],
                        row["Raza"],
                        row["Fecha_nac"],
                        row["ID_Dueño"],
                        img
                    );
                }

                // Ajustar el número de registros encontrados
                int registrosEncontrados = dtMascotas.Rows.Count;
                txtregistrosencontrados.Text = registrosEncontrados.ToString();

                // Calcular los registros no encontrados
                SqlCommand countTotalMascotas = new SqlCommand("SELECT COUNT(*) FROM Mascota", obj_Conexion.Conex);
                int totalMascotas = (int)countTotalMascotas.ExecuteScalar();
                int registrosNoEncontrados = totalMascotas - registrosEncontrados;
                txtregistrosNoEnco.Text = registrosNoEncontrados.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las mascotas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                obj_Conexion.cerrar();
            }
        }

        private void btnBorrarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
