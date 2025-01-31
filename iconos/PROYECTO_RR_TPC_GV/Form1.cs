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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chkVerContraseña.CheckedChanged += new EventHandler(chkVerContraseña_CheckedChanged);
            pictureBox3.MouseDown += new MouseEventHandler(pictureBox3_MouseDown);
            pictureBox3.MouseUp += new MouseEventHandler(pictureBox3_MouseUp);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexionGV obj_Conexion = new ConexionGV();
                obj_Conexion.abrir();

                // Obtener la contraseña encriptada del usuario
                SqlCommand cmd = new SqlCommand("select Contraseña from Usuario where Nick=@Nick", obj_Conexion.Conex);
                cmd.Parameters.AddWithValue("@Nick", this.txtUsername.Text);
                String cont = cmd.ExecuteScalar()?.ToString();

                if (string.IsNullOrEmpty(cont))
                {
                    MessageBox.Show("Usuario o Clave Inválidos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Desencriptar la contraseña
                SqlCommand cmd1 = new SqlCommand("EXEC usp_desencriptar @Nick", obj_Conexion.Conex);
                cmd1.Parameters.AddWithValue("@Nick", this.txtUsername.Text);
                String cont_des = cmd1.ExecuteScalar()?.ToString();

                if (this.txtPassword.Text == cont_des)
                {
                    MessageBox.Show("Bienvenido al sistema!!", "Acceso", 0, MessageBoxIcon.Asterisk);
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El password no es el correcto verifique", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPassword.Clear();
                    this.txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void chkVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerContraseña.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo Letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
