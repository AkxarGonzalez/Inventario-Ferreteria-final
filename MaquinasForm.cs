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
    public partial class MaquinasForm : Form
    {
        SqlConnection conex = new SqlConnection(@"Data Source=SISTEMAS\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True");
        SqlCommand cn = new SqlCommand();
        SqlDataReader dr;
        public MaquinasForm()
        {
            InitializeComponent();
            LoadMaquinas();
        }

        public void LoadMaquinas()
        {
            int i = 0;
            dgvMaquinas.Rows.Clear();
            cn = new SqlCommand("SELECT * FROM Maquinas", conex);
            conex.Open();
            dr = cn.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvMaquinas.Rows.Add(i, dr[0].ToString(), dr[1].ToString());

            }
            dr.Close();
            conex.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MaquinasModuleForms formModule = new MaquinasModuleForms();
            formModule.btnGuardar.Enabled = true;
            formModule.btnActualizar.Enabled = false;
            formModule.ShowDialog();
            LoadMaquinas();
            
        }

        private void dgvMaquinas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvMaquinas.Columns[e.ColumnIndex].Name;
            if (colName == "Editar")
            {

                MaquinasModuleForms formModule = new MaquinasModuleForms();

                formModule.lblMaqld.Text = dgvMaquinas.Rows[e.RowIndex].Cells[1].Value.ToString();
                formModule.txtNombreMaq.Text = dgvMaquinas.Rows[e.RowIndex].Cells[2].Value.ToString();
                

                formModule.btnGuardar.Enabled = false;
                formModule.btnActualizar.Enabled = true;
                formModule.ShowDialog();

            }
            else if (colName == "Borrar")
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar esta Maquina?", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conex.Open();
                    cn = new SqlCommand("DELETE FROM Maquinas WHERE maqid LIKE '" + dgvMaquinas.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conex);
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("El registro se ha eliminado con éxito!!");
                }
            }
            LoadMaquinas();
        }
    }
}
