using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.Data.Sql;
using Inventario_Ferreteria.Models;
using Inventario_Ferreteria.Clases;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.IO;


namespace Inventario_Ferreteria
{
    public partial class ConsultadePedidos : Form
    {

        public ConsultadePedidos()
        {

            InitializeComponent();
            


        }
       





        //private void fillcombo(){
        //    DataGridViewComboBoxColumn combo= new DataGridViewComboBoxColumn();
        //    combo.HeaderText = "texto001";
        //    combo.Name = "texto001";
        //    System.Collections.ArrayList row = new System.Collections.ArrayList()            {
        //       "a","b","c"
        //        };
        //   // combo.Items.AddRange(row);
        //    combo.DataSource = row;
        //    dgvListado.Columns.Add(combo);
        //    dgvListado.Refresh();

      

        //}
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Pedido _Objeto = new Pedido();
            _Objeto.FechaInicial = dtpFechaInicial.Value.Date.ToString("yyyy-MM-dd");
            _Objeto.FechaFinal = dtpFechaFinal.Value.Date.ToString("yyyy-MM-dd");
            _Objeto.Estatus = cboTipoMovimiento.Text.ToString();
            ////desde BD
            ////Estatus _Funcion = new Estatus();
            // DataTable _Estatus = _Funcion.Listar();
            //cboTipoMovimiento.DataSource = _Estatus;
            //cboTipoMovimiento.DisplayMember = "Descripcion";
            //cboTipoMovimiento.ValueMember = "Codigo";
            //_Objeto.Estatus = cboTipoMovimiento.SelectedValue.ToString();

            //
            //           List<string> lstEstatus = new List<string>();
            //           lstEstatus.Add("texto1");
            //           lstEstatus.Add("texto2");
            //           lstEstatus.Add("texto3");

            IPedido _Funcion = new IPedido();
            DataTable _Data = _Funcion.ReportePedidos(_Objeto);

            if (_Data.Rows.Count > 0) {
                dgvListado.Rows.Clear();                              
                dgvListado.AutoGenerateColumns = false;
                dgvListado.DataSource = _Data;              
                dgvListado.Refresh();
            }
            //fillcombo();
            dgvListado.Refresh();
            //else
            MessageBox.Show("NO HAY DATOS.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

           


        }

        private void ConsultadePedidos_Load(object sender, EventArgs e)
        {
           
        }
        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == colImgEliminar.Index)
            {
                //ELIMINAR
                MessageBox.Show($"Eliminar Pedido: {dgvListado.Rows[e.RowIndex].Cells[colPedidoId.Index].Value.ToString()}");
                string IdPedido = dgvListado.Rows[e.RowIndex].Cells[colPedidoId.Index].Value.ToString();

                IPedido _Funcion = new IPedido();

                //string Resultado = _Funcion.Eliminar(IdPedido);
                //MessageBox.Show(Resultado, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                MessageBox.Show(_Funcion.Eliminar(IdPedido), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.ColumnIndex == colEstatus.Index) {
                Actualizacion_pedidos factualiza = new  Actualizacion_pedidos();
                factualiza.nopedido = dgvListado.Rows[e.RowIndex].Cells[colPedidoId.Index].Value.ToString();
                factualiza.ShowDialog();

            //    MessageBox.Show($"mostrar formulario editar pedido: {dgvListado.Rows[e.RowIndex].Cells[colPedidoId.Index].Value.ToString()}");
            }

            else if (e.ColumnIndex == colBtnImprimir.Index)
            {
                //IMPRIMIR

                frmPedidoReporte frm = new frmPedidoReporte();
                frm.IdPedido = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells[colPedidoId.Index].Value.ToString());
                frm.ShowDialog();
                //_Formulario.FechaInicial = dtpFechaInicial.Value;
                //_Formulario.Fecha = dtpFechaFinal.Value;




                MessageBox.Show($"Imprimir  Pedido: {dgvListado.Rows[e.RowIndex].Cells[colPedidoId.Index].Value.ToString()}");
                string IdPedido = dgvListado.Rows[e.RowIndex].Cells[colPedidoId.Index].Value.ToString();

                IPedido _Funcion = new IPedido();

                DataTable _Data = _Funcion.Imprimir(IdPedido);
                if (_Data.Rows.Count > 0)
                {
                    //ABRIR REPORTVIEWER

                    //frmPedidoReporte _Formulario = new frmPedidoReporte();
                    //_Formulario.IdPEdido = IdPedido
                    //_Formulario.ShowDialog();
                    //SaveFileDialog guardar = new SaveFileDialog();
                    //guardar.ShowDialog();






                    //SaveFileDialog guardar = new SaveFileDialog();

                }
                else
                    MessageBox.Show("EL DOCUMENTO SE HA IMPRIMIDO CORRECTAMENTE", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } else if (dgvListado.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn && e.RowIndex >= 0) {
                // cambio de estatus
                DataGridViewComboBoxCell cbCel = (DataGridViewComboBoxCell)dgvListado.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // MessageBox.Show(cbCel.ToString());            
            }
         
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }

}
