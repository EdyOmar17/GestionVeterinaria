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
    public partial class Form12 : Form
    {
        //private string idMascota;
        private int idCita;

        public Form12(int idCita, string diagnosticoActual)
        {
            InitializeComponent();
            //this.idMascota = idMascota;
            this.idCita = idCita;

            txtDiagnostico.Text = diagnosticoActual;
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el nuevo diagnóstico ingresado por el usuario
                string nuevoDiagnostico = txtDiagnostico.Text;

                // Llamar a un método para actualizar el diagnóstico en la base de datos
                ActualizarDiagnostico(idCita, nuevoDiagnostico);

                // Cerrar el formulario después de guardar
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el diagnóstico: " + ex.Message);
            }
        }

        private void ActualizarDiagnostico(int idCita, string nuevoDiagnostico)
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                SqlCommand cmd = new SqlCommand("ActualizarDiagnostico", obj_Conexion.Conex);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_Cita", idCita);
                cmd.Parameters.AddWithValue("@NuevoDiagnostico", nuevoDiagnostico);

                cmd.ExecuteNonQuery();
                obj_Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
