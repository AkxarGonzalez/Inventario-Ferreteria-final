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
    public partial class UserForm : Form
    {
        SqlConnection conex = new SqlConnection(@"Data Source=SISTEMAS\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True");
        SqlCommand cn = new SqlCommand();
        SqlDataReader dr;
        public UserForm()
        {
            
            InitializeComponent();
            LoadUser();
      
        }

        public void LoadUser()
        {
            int i = 0;
            dgvUsuarios.Rows.Clear();
            cn = new SqlCommand("SELECT * FROM Usuarios", conex);
                conex.Open();
            dr = cn.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUsuarios.Rows.Add(i, dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                
            }
            dr.Close();
            conex.Close();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUsuarios.Columns[e.ColumnIndex].Name;
            if (colName =="Editar")
            {
                
                UserModuleForm userModule = new UserModuleForm();

                userModule.txtUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtNombreCompleto.Text = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtContraseña.Text = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtPuesto.Text = dgvUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString();

                userModule.btnGuardar.Enabled = false;
                userModule.btnActualizar.Enabled = true;
                userModule.ShowDialog();

            }
            else if (colName =="Borrar")
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar este usuario?","Eliminar Registro",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    conex.Open();
                    cn = new SqlCommand("DELETE FROM Usuarios WHERE Usuario LIKE '" + dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conex);
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("El registro se ha eliminado con éxito!!");
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            UserModuleForm userModule = new UserModuleForm();  
            userModule.btnGuardar.Enabled = true;
            userModule.btnActualizar.Enabled = false;
            userModule.ShowDialog();
            LoadUser();
        }

        private void dgvUsuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string colName = dgvUsuarios.Columns[e.ColumnIndex].Name;
            if (colName == "Editar")
            {

                UserModuleForm userModule = new UserModuleForm();

                userModule.txtUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtNombreCompleto.Text = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtContraseña.Text = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtPuesto.Text = dgvUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString();

                userModule.btnGuardar.Enabled = false;
                userModule.btnActualizar.Enabled = true;
                userModule.txtUsuario.Enabled = false;
                userModule.ShowDialog();

            }
            else if (colName == "Borrar")
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conex.Open();
                    cn = new SqlCommand("DELETE FROM Usuarios WHERE Usuario LIKE '" + dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conex);
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("El registro se ha eliminado con éxito!!");
                }
            }
            LoadUser();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
