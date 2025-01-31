using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_RR_TPC_GV
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagenes (*.jpg; *.png) | *.jpg; *.png | All files (*.*)|*.*";
            ofd.Title = "Abrir imagen";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string urlImagen = ofd.FileName;
                pbImgen.Image = Image.FromFile(urlImagen);
                pbImgen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                MemoryStream archivoMemoria = new MemoryStream();
                pbImgen.Image.Save(archivoMemoria, ImageFormat.Jpeg);
                byte[] imagenBytes = archivoMemoria.ToArray();

                SqlCommand cmd = new SqlCommand("usp_AgregarImagen", obj_Conexion.Conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Mascota", txtCodigo.Text);
                cmd.Parameters.AddWithValue("@Imagen", imagenBytes);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Imagen guardada exitosamente.");
                obj_Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtApeNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void txtCodigo_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ConexionGV obj_Conexion = new ConexionGV();
            //    obj_Conexion.abrir();

            //    SqlCommand cmd = new SqlCommand("usp_BuscarMascotaPorID", obj_Conexion.Conex);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@ID_Mascota", txtCodigo.Text);

            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.Read())
            //    {
            //        txtNombreMascota.Text = dr["Nombre"].ToString();

            //        // Si la columna de imagen contiene datos, se convierte en Image
            //        if (dr["Imagen"] != DBNull.Value)
            //        {
            //            byte[] imgData = (byte[])dr["Imagen"];
            //            using (MemoryStream ms = new MemoryStream(imgData))
            //            {
            //                pbImgen.Image = Image.FromStream(ms); // Asigna la imagen al PictureBox
            //            }
            //        }
            //        else
            //        {
            //            pbImgen.Image = null; // Borra cualquier imagen previa
            //            MessageBox.Show("No se encontró una imagen para esta mascota. Puedes subir una.");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se encontró el Código de la Mascota proporcionado.");
            //    }

            //    obj_Conexion.cerrar();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}

            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                SqlCommand cmd = new SqlCommand("usp_BuscarMascotaPorID", obj_Conexion.Conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Mascota", txtCodigo.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtNombreMascota.Text = dr["Nombre"].ToString();

                    // Limpiar el PictureBox antes de cargar una nueva imagen
                    if (pbImgen.Image != null)
                    {
                        pbImgen.Image.Dispose();
                        pbImgen.Image = null;
                    }

                    // Si la columna de imagen contiene datos, se convierte en Image
                    if (dr["Imagen"] != DBNull.Value)
                    {
                        byte[] imgData = (byte[])dr["Imagen"];
                        using (MemoryStream ms = new MemoryStream(imgData))
                        {
                            Image nuevaImagen = Image.FromStream(ms);
                            pbImgen.Image = new Bitmap(nuevaImagen); // Asigna una copia de la imagen al PictureBox
                        }
                        pbImgen.SizeMode = PictureBoxSizeMode.StretchImage; // Ajusta la imagen al PictureBox
                    }
                    else
                    {
                        MessageBox.Show("No se encontró una imagen para esta mascota. Puedes subir una.");
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el Código de la Mascota proporcionado.");
                    // Limpiar imagen si no se encuentra la mascota
                    pbImgen.Image = null;
                }

                dr.Close(); // Asegurarse de cerrar el DataReader antes de cerrar la conexión
                obj_Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSalirFormulario_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario actual (Formulario 8)
            this.Close();
        }
    }
}
