using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario_Ferreteria
{
    public partial class frmPedidoReporte : Form
    {
        public frmPedidoReporte()
        {
            InitializeComponent();
        }
         public int IdPedido { get; set; }

    public string  FechaFinal { get; set; }
        private void frmPedidoReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ReportePedido.spConsultaPedido' Puede moverla o quitarla según sea necesario.
            this.spConsultaPedidoTableAdapter.Fill(this.ReportePedido.spConsultaPedido,IdPedido);

            this.reportViewer1.RefreshReport();
        }
    }
}
