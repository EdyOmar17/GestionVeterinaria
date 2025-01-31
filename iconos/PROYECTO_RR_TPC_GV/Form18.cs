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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            MostrarReporte_MascotaCitaVeterinario();
        }

        private void MostrarReporte_MascotaCitaVeterinario()
        {
            DataSet1_MascotaCitaVeterinario ds = new DataSet1_MascotaCitaVeterinario();
            DataSet1_MascotaCitaVeterinarioTableAdapters.usp_GenerarReporteMascotasCitasVeterinariosTableAdapter da = new DataSet1_MascotaCitaVeterinarioTableAdapters.usp_GenerarReporteMascotasCitasVeterinariosTableAdapter();
            da.Fill(ds.usp_GenerarReporteMascotasCitasVeterinarios);

            //Creamos un Objeto del Reporte DueñoMascota
            CrystalReport1_MascotaCitaVeterinario rep1 = new CrystalReport1_MascotaCitaVeterinario();

            //Asignamos los Datos del Reporte
            rep1.SetDataSource(ds);

            //Enviamos la Data al Visor de Reportes
            crystalReportViewer1.ReportSource = rep1;
        }
    }
}
