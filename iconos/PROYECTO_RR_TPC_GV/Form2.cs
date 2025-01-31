using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_RR_TPC_GV
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "Equipo: " + Environment.MachineName;
            this.toolStripStatusLabel2.Text = "Usuario: " + Environment.UserName;
            this.toolStripStatusLabel3.Text = "Fecha: " + DateTime.Now.ToShortDateString();
        }

        private void mnuRegistrar_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form3>();
        }

        private void mnuBusqueda_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form5>();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form3>();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form3>();
        }

        private void ejecutarFormBoletaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form4>();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "/Manual del Software Paws Ven-Per Clínica Veterinaria.pdf");
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form5>();
        }

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form5>();
        }

        private void consultaVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form6>();
        }

        private void AbrirFormulario<T>() where T : Form, new()
        {
            Form formulario = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new T();
                formulario.Show();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void AbrirFormularioParametro<T>(params object[] args) where T : Form
        {
            Form formulario = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = (T)Activator.CreateInstance(typeof(T), args);
                formulario.Show();
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void mnuListado_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form6>();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form6>();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form6>();
        }

        private void TS_Generarbackup_Click(object sender, EventArgs e)
        {
            AbrirFormularioParametro<Form7>(1);
        }

        private void TS_restaurarBackup_Click(object sender, EventArgs e)
        {
            AbrirFormularioParametro<Form7>(2);
        }

        private void consultaMascotaPorDueñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form10>();
        }

        private void consultaVeterinarioDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form11>();
        }

        private void cRUDMASCOTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form8>();
        }

        private void cRUDMASCOTASIMAGENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form9>();
        }

        private void consultaCitasCreadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form13>();
        }

        private void cRUDVETERINAROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form14>();
        }

        private void consultaMascotaConImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form15>();
        }

        private void resgistrosMascotaDueñoImagenDueñoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form16>();
        }

        private void dueñosMascotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form17>();
        }

        private void mascotaCitaVeterinarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form18>();
        }
    }
}
