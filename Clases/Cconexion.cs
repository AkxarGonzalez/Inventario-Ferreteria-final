using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventario_Ferreteria.Clases
{
    internal class Cconexion
    {
        SqlConnection conex =  new SqlConnection();

        static string servidor= "SISTEMAS\\SQLEXPRESS";
        static string bd="bd_ferreteria";
        static string usuario="ferreteria";
        static string password="Therapedic23";


        //string cadenaconexion = "Data Source=" + servidor + "," + "User id=" + usuario + ";" + "password=" + password + ";" + "Initial Catalog=" + bd + ";" + "persist Security Info=true";
        string cadenaconexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True";

        public SqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaconexion;
                conex.Open();
                //MessageBox.Show("Se conecto a la base de datos");
            }

            catch(SqlException e)
            {
                MessageBox.Show("No se conecto a la base de datos"+e.ToString());
            }

            return conex;
        }

    }
}
