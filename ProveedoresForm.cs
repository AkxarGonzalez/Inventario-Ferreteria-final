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

namespace Inventario_Ferreteria
{
    public partial class ProveedoresForm : Form
    {
        SqlConnection conex = new SqlConnection(@"Data Source=SISTEMAS\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True");
        SqlCommand cn = new SqlCommand();
        SqlDataReader dr;
        public ProveedoresForm()
        {
            InitializeComponent();
            LoadProveedores();
        }

        public void LoadProveedores()
        {
            int i = 0;
            dgvProveedores.Rows.Clear();
            cn = new SqlCommand("SELECT * FROM Proveedores", conex);
            conex.Open();
            dr = cn.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProveedores.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());

            }
            dr.Close();
            conex.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProveedoresModuleForm moduleForm = new ProveedoresModuleForm();
            moduleForm.btnGuardar.Enabled = true;
            moduleForm.btnActualizar.Enabled = false;
            moduleForm.ShowDialog();
            LoadProveedores();
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProveedores.Columns[e.ColumnIndex].Name;
            if (colName == "Editar")
            {

                ProveedoresModuleForm proveedoresModule = new ProveedoresModuleForm();

                proveedoresModule.lblPld.Text = dgvProveedores.Rows[e.RowIndex].Cells[1].Value.ToString();
                proveedoresModule.txtNombre.Text = dgvProveedores.Rows[e.RowIndex].Cells[2].Value.ToString();
                proveedoresModule.txtTelefono.Text = dgvProveedores.Rows[e.RowIndex].Cells[3].Value.ToString();
                
                proveedoresModule.btnGuardar.Enabled = false;
                proveedoresModule.btnActualizar.Enabled = true;         
                proveedoresModule.ShowDialog();

            }
            else if (colName == "Borrar")
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conex.Open();
                    cn = new SqlCommand("DELETE FROM Proveedores WHERE pid LIKE '" + dgvProveedores.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conex);
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("El registro se ha eliminado con éxito!!");
                }
            }
            LoadProveedores();
        }
    }
}
