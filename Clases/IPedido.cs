using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventario_Ferreteria.Models;

namespace Inventario_Ferreteria.Clases
{
    public class IPedido
    {
        private SqlConnection _Conexion = null;
        private SqlCommand _Comando = null;
        private SqlDataAdapter _Adapter = null;

        public DataTable ReportePedidos(Pedido _Entidad)
        { 
            DataSet _DataSet = new DataSet();

            try
            {
                Cconexion _Cnx = new Cconexion();
                _Conexion = _Cnx.establecerConexion();

                if (_Conexion != null && _Conexion.State == ConnectionState.Open)
                    _Conexion.Close();

                _Conexion.Open();
                _Comando = new SqlCommand();
                _Comando.Connection = _Conexion;
                _Comando.CommandType = CommandType.StoredProcedure;
                _Comando.CommandText = "uspReportePedidos";

                _Comando.Parameters.AddWithValue("@FechaInicial", _Entidad.FechaInicial);
                _Comando.Parameters.AddWithValue("@FechaFinal", _Entidad.FechaFinal);
                _Comando.Parameters.AddWithValue("@Estatus", _Entidad.Estatus);
                
                

                _Adapter = new SqlDataAdapter(_Comando);
                _Adapter.Fill(_DataSet, "uspReportePedidos");
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (_Conexion != null)
                    _Conexion.Close();
            }

            return _DataSet.Tables["uspReportePedidos"];
        }

        public string Eliminar(string IdPedido)
        {
            string Respuesta = string.Empty;
            try
            {
                Cconexion _Cnx = new Cconexion();
                _Conexion = _Cnx.establecerConexion();

                if (_Conexion != null && _Conexion.State == ConnectionState.Open)
                    _Conexion.Close();

                _Conexion.Open();
                _Comando = new SqlCommand();
                _Comando.Connection = _Conexion;
                _Comando.CommandType = CommandType.StoredProcedure;
                _Comando.CommandText = "uspPedidoEliminar";

                _Comando.Parameters.AddWithValue("@IdPedido", IdPedido);

                Respuesta = (string)_Comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            finally
            {
                if (_Conexion != null)
                    _Conexion.Close();
            }

            return Respuesta;
        }
        
        public DataTable Imprimir(string IdPedido) //ORIGINAL
        {
            return new DataTable();
        }
    }
}
