using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;

namespace PROYECTO_RR_TPC_GV
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            MostrarReporte_DueñoMascota();
        }

        private void MostrarReporte_DueñoMascota()
        {
            DataSet1_DueñoMascota ds = new DataSet1_DueñoMascota();
            DataSet1_DueñoMascotaTableAdapters.usp_GenerarReporteDueñosMascotasTableAdapter da = new DataSet1_DueñoMascotaTableAdapters.usp_GenerarReporteDueñosMascotasTableAdapter();
            da.Fill(ds.usp_GenerarReporteDueñosMascotas);

            //Creamos un Objeto del Reporte DueñoMascota
            CrystalReport1_DueñoMascota rep1 = new CrystalReport1_DueñoMascota();

            //Asignamos los Datos del Reporte
            rep1.SetDataSource(ds);

            //Enviamos la Data al Visor de Reportes
            crystalReportViewer1.ReportSource = rep1;
        }
    }
}
