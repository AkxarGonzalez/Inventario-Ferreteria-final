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


namespace Inventario_Ferreteria
{


    public partial class Actualizacion_pedidos : Form

    {
        public string nopedido; 

        public Actualizacion_pedidos()
    {
        InitializeComponent();
            MessageBox.Show(nopedido);
    }

        private void Actualizacion_pedidos_Load(object sender, EventArgs e)
        {


          
         }
    }
}
