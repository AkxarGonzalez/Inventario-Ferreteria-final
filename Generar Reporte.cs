using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using Microsoft.Reporting.WinForms;


namespace Inventario_Ferreteria
{
    public partial class Generar_Reporte : Form
    {
        string FechaInicial = string.Empty;
        string FechaFinal = string.Empty;
        string TipoMovimiento = "Ingreso"; // Ajusta según tus necesidades

        public Generar_Reporte()
        {
            InitializeComponent();
        }

       




        private void Generar_Reporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetPrincipal.spinvenatrio' Puede moverla o quitarla según sea necesario.
            this.spinvenatrioTableAdapter.Fill(this.DataSetPrincipal.spinvenatrio);


            // TODO: esta línea de código carga datos en la tabla 'DataSetPrincipal.spinvenatrio' Puede moverla o quitarla según sea necesario.
            //this.spinvenatrioTableAdapter.Fill(this.DataSetPrincipal.spinvenatrio,cboTipoMovimiento.Text,dptFechaInicial.Value,dptFechaFinal.Value);                                 


            //this.reportViewer1.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            

            
            
            //ReportParameter[] parametros = new ReportParameter[3];
            //parametros[0] = new ReportParameter("FechaInicial", dtpFechaInicial.Value.ToString("yyyy-MM-dd"));
            //parametros[1] = new ReportParameter("FechaFinal", dtpFechaFinal.Value.ToString("yyyy-MM-dd"));
            //parametros[2] = new ReportParameter("TipoMovimiento", cboTipoMovimiento.Text);

            FechaInicial = dtpFechaInicial.Value.ToString("yyyy-MM-dd");
            FechaFinal = dtpFechaFinal.Value.ToString("yyyy-MM-dd");
            
            // TODO: esta línea de código carga datos en la tabla 'DataSetPrincipal.spinvenatrio' Puede moverla o quitarla según sea necesario.
            //spinvenatrioTableAdapter.Fill(DataSetPrincipal.uspinvenatrio,TipoMovimiento,FechaInicial,FechaFinal);
            spinvenatrioTableAdapter.Fill(DataSetPrincipal.spinvenatrio,cboTipoMovimiento.Text,FechaInicial,FechaFinal);

            
            this.reportViewer1.RefreshReport();








        }
    }
}
