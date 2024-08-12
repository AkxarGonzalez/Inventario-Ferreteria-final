using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventario_Ferreteria.Clases
{
    internal class Busqueda
    {
        public void BuscarCodigo(TextBox txtCodigo,TextBox txtDescripcion,TextBox txtMaquina,TextBox txtCantidad,TextBox txtCompatible,TextBox txtCasillero)
        {
            Cconexion objeto = new Cconexion();
            SqlConnection conn = objeto.establecerConexion();

            try
            {
                conn.Open();
                string sql = "select Inventario.Codigo, Inventario.Descripcion,Inventario.Maquina,Inventario.Cantidad,Inventario.Compatible,Inventario.Casillero from Inventario where Inventario.Codigo='" + txtCodigo.Text + "'";
                SqlCommand cmd = new  SqlCommand(sql,conn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtCodigo.Text = rdr[1].ToString();
                    txtDescripcion.Text = rdr[2].ToString();
                    txtMaquina.Text = rdr[3].ToString();
                    txtCantidad.Text = rdr[4].ToString();
                    txtCompatible.Text = rdr[5].ToString();
                    txtCasillero.Text = rdr[6].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("NO SE  LOGRO REALIZAR LA BUSQUEDA, ERROR: " + ex.ToString());
            }
        }

       
        }
    }

