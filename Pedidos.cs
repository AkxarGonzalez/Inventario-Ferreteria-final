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
using System.Diagnostics;
using System.Drawing.Printing;

namespace Inventario_Ferreteria
{
    public partial class Pedidos : Form
    {
        string strConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True";
     
        public Pedidos()
        {
            InitializeComponent();
        }


        private void textBox3_Leave(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lblNombre.Text = "";         
            lblArea.Text = "";
            lblAutoriza.Text = "";
            lblComprador.Text = "";

            dataGridView1.DataSource = null;
            using (var conexion = new SqlConnection(strConexion))
            {
                conexion.Open();
                // por store procedure
                var cmd = new SqlCommand("spNuevoPedido", conexion); 
                cmd.CommandType = CommandType.StoredProcedure;
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        lblPedido.Text = rd["PedidoId"].ToString();
                       
                        lblFecha.Text = Convert.ToDateTime(rd["Fecha"]).ToString("dd-MM-yyyy");                       
                    }
                }
                conexion.Close();
            }
            //btnNuevo.Enabled = false;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.Rows.Add(new object[] { Codigo, Descripcion, Cantidad, Maquina });
                //dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
                //lblNombre.Text = "";
                //lblArea.Text = "";
                //lblAutoriza.Text = "";
                //lblComprador.Text = "";


             //  dataGridView1.DataSource = null;
                using (var conexion = new SqlConnection(strConexion))
                {
                    conexion.Open();


                    DataTable dtDetalle = new DataTable("Detalle");                  
                    dtDetalle.Columns.Add("Codigo", typeof(string));
                    dtDetalle.Columns.Add("Descripcion", typeof(string));
                    dtDetalle.Columns.Add("Maquina", typeof(string));
                    dtDetalle.Columns.Add("Cantidad", typeof(int));
                    dtDetalle.Columns.Add("Estatus", typeof(string));
                    dtDetalle.Columns.Add("Pedido", typeof(int));

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        DataRow dataRow = dtDetalle.NewRow();
                                            
                        dataRow["Codigo"] = row.Cells["Codigo"].Value.ToString();
                        dataRow["Descripcion"] =row.Cells["Descripcion"].Value.ToString();
                        dataRow["Cantidad"] = int.Parse(row.Cells["Cantidad"].Value.ToString());
                        //dataRow["Cantidad"] = 5;
                        dataRow["Maquina"] = row.Cells["Maquina"].Value.ToString();
                        dataRow["Estatus"] = "1";
                        dataRow["Pedido"] = 1;
                                               
                        dtDetalle.Rows.Add(dataRow);
                        //conexion.Open();
                        
                     
                        
                        //dataGridView1.Rows.Clear();
                        

                        // conexion.Close();

                    }



                    // por store procedure
                    var cmd = new SqlCommand("spNuevoPedido", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conexion;
                    SqlParameter parametroTabla = new SqlParameter("@tbldetallepedido", SqlDbType.Structured);                  
                    parametroTabla.TypeName = "dbo.TipoPedidoDetalle";
                    parametroTabla.Value = dtDetalle;
                    cmd.Parameters.Add(parametroTabla);                    
                   
                    cmd.Parameters.AddWithValue("@Codigo", txtEmpleado.Text);
                    cmd.Parameters.AddWithValue("@Comprador", lblComprador.Text);
                    cmd.Parameters.AddWithValue("@Autoriza", lblAutoriza.Text);
                    cmd.Parameters.AddWithValue("@Justificacion", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Estatus", "1"); 
                    cmd.Parameters.AddWithValue("@PedidoId", lblPedido.Text);
                    //desarrollado por mi
                    using (var rd = cmd.ExecuteReader())
                    { 
                        while (rd.Read())
                        {
                            lblPedido.Text = rd["PedidoId"].ToString();
                            lblFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
                            MessageBox.Show("EL PEDIDO ACTUAL SE HA GUARDADO EXITOSAMENTE");
                }
      conexion.Close();
                txtEmpleado.Text = "";
                lblNombre.Text = "";
                lblFecha.Text = "";
                lblPedido.Text = "";
                lblArea.Text = "";
                lblMaquina.Text = "";
                dataGridView1.DataSource = null;
                txtEmpleado.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en guardar: {ex.Message}");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
         
            dataGridView1.Rows.Add(new object[] { txtCodigo.Text,lblDescripcion.Text,txtCantidad.Text,lblMaquina.Text});
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            txtCodigo.Text = "";
            lblExistencia.Text = "";
            lblDescripcion.Text = "";
            txtCantidad.Text = "";
            lblMaquina.Text = "";
            txtCodigo.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            lblExistencia.Text = "";
            lblDescripcion.Text = "";
            txtCantidad.Text = "";
            lblMaquina.Text = "";
        }

        private void txtEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                using (var conexion = new SqlConnection(strConexion))
                {
                    conexion.Open();
                    // por store procedure
                    var cmd = new SqlCommand("spBuscarempleado", conexion); 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@empleado", txtEmpleado.Text);
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lblNombre.Text = rd["nombre"].ToString();
                            lblArea.Text = rd["Area"].ToString();
                            lblComprador.Text = rd["Comprador"].ToString();
                            lblAutoriza.Text = rd["Autoriza"].ToString();
                        }
                    }

                    conexion.Close();
                }
                txtCodigo.Focus();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                using (var conexion = new SqlConnection(strConexion))
                {
                    conexion.Open();
                    // por store procedure
                    var cmd = new SqlCommand("spBuscarProducto", conexion); 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lblDescripcion.Text = rd["Descripcion"].ToString();
                            lblExistencia.Text = rd["Cantidad"].ToString();
                            lblMaquina.Text = rd["Maquina"].ToString();
                        }
                    }
                    
                    conexion.Close();
                }
                txtCantidad.Focus();
            }
        }

        private void btnVerPedido_Click(object sender, EventArgs e)
        {
            Form Formulario = new ConsultadePedidos();
            Formulario.Show();
        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void lblPedido_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ ESTAS SEGURO DE ELIMINAR EL ARTICULO SELECCIONADO?", "CONFIRMACION", MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void txtEmpleado_TextChanged(object sender, EventArgs e)
        {
            lblPedido.Text = "0000";
            lblFecha.Text = "";
            lblComprador.Text = "";
            lblAutoriza.Text = "";
        }
    }
    
}
