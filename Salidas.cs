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
using Inventario_Ferreteria.Models;



namespace Inventario_Ferreteria
{
    public partial class Salidas : Form
    {
        string strConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True";
        public Salidas()
        {
            InitializeComponent();
        }

        private void Entradas_Load(object sender, EventArgs e)
        {

        }
        private void ActualzaInventario(Inventario inventario)
        {
            //  try
            // {   // consulta registro tabla Inventario
            using (var conexion = new SqlConnection(strConexion))
            {
                conexion.Open();
                // por store procedure
                var cmd = new SqlCommand("spObtenerRegistroInventario", conexion); // no lo veo en la base de datos 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", inventario.Codigo);

                // por cadena de texto
                //var cmd = new SqlCommand("SELECT codigo,cantidad,descripcion FROM inventario WHERE codigo='"+ inventario.Codigo + "'", conexion);
                //cmd.CommandType = CommandType.Text;

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {

                        inventario.Codigo = rd["Codigo"].ToString();
                        inventario.Descripcion = rd["Descripcion"].ToString();
                        inventario.Cantidad = Convert.ToInt16(rd["cantidad"]);
                        

                    }
                }
                conexion.Close();
            }


            // Actualiza Existencia
            //using (var conexion = new SqlConnection(strConexion))
            //{
            //    conexion.Open();
            //    // por store procedure 
            //    var cmd = new SqlCommand("spActualizaRegistroInventario", conexion);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@codigo", inventario.Codigo);
            //    cmd.Parameters.AddWithValue("@cantidad", inventario.Cantidad);


            //    // por cadena de texto
            //    //var cmd = new SqlCommand("UPDATE inventario set cantidad=" + inventario.Cantidad + " WHERE codigo='"+ inventario.Codigo + "'", conexion);
            //    //cmd.CommandType = CommandType.Text;
            //    cmd.ExecuteNonQuery();
            //    conexion.Close();
            //}
            txtCodigodeBarras.Text = inventario.Codigo.ToString();
            txtDescripcion.Text = inventario.Descripcion;
            txtExistencia.Text = inventario.Cantidad.ToString();
            txtSolicitante.Text = "";
            txtCantidadTotal.Text = "0";
            txtCantidadTotal.Focus();
            //MessageBox.Show("entrada correcta");
            //txtCodigodeBarras.Text = "";
            //txtDescripcion.Text = "";
            //txtExistencia.Text = "";
            //txtCodigodeBarras.Focus();

            //   }
            //   catch (Exception ex)
            //   {
            //       MessageBox.Show(ex.Message);
            //  }
        }


        private void txtCodigodeBarras_KeyPress(object sender, KeyPressEventArgs e)
        {

            Inventario inventario = new Inventario();
            if (e.KeyChar == (char)Keys.Enter)
            {
                inventario.Codigo = txtCodigodeBarras.Text;
                ActualzaInventario(inventario);
                txtCantidadTotal.Focus();
                
            }

        }

        private void txtCodigodeBarras_TextChanged(object sender, EventArgs e)
        {


        }

        private void Entradas_Load_1(object sender, EventArgs e)
        {

        }

        private void txtCantidadTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Inventario invnvo = new Inventario();
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Actualiza Existencia
                if ((txtCantidadTotal.Text != "" && txtCodigodeBarras.Text != "") || txtCodigodeBarras.Text != "0")
                {
                   
                    invnvo.Codigo = txtCodigodeBarras.Text;
                    invnvo.Descripcion = txtDescripcion.Text;
                    invnvo.Cantidad = Convert.ToInt32(txtCantidadTotal.Text);
                    invnvo.Movimiento = "Salida";
                    invnvo.Fecha = DateTime.Now.ToString("yyyy-MM-dd");
                    invnvo.Solicitante = txtSolicitante.Text.ToUpper();
                    

                    using (var conexion = new SqlConnection(strConexion))
                    {
                        conexion.Open();
                        ////  por store procedure
                        //// var cmd1 = new SqlCommand("spActualizaRegistroInventario", conexion);
                        //  cmd1.CommandType = CommandType.StoredProcedure;
                        //  cmd1.Parameters.AddWithValue("@codigo", invnvo.Codigo);
                        //  cmd1.Parameters.AddWithValue("@cantidad", invnvo.Cantidad);


                        // por cadena de texto
                        var cmd = new SqlCommand("uspInsertarmovimiento", conexion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigo", invnvo.Codigo);
                        cmd.Parameters.AddWithValue("@movimiento", invnvo.Movimiento);
                        cmd.Parameters.AddWithValue("@cantidad", invnvo.Cantidad);
                        cmd.Parameters.AddWithValue("@Solicitante", invnvo.Solicitante);
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                        MessageBox.Show("SALIDA CORRECTA");
                        txtCodigodeBarras.Text = "";
                        txtDescripcion.Text = "";
                        txtExistencia.Text = "";
                        txtCantidadTotal.Text = "0";
                        txtSolicitante.Text = "";
                        txtCodigodeBarras.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No puede actualizar si la cantidad de entrada esta vacia");
                    txtCodigodeBarras.Focus();

                }
            }
        }
    }
}

