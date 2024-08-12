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
    public partial class InventarioForm : Form
    {
        SqlConnection conex = new SqlConnection(@"Data Source=SISTEMAS\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True");
        SqlCommand cn = new SqlCommand();
        SqlDataReader dr;
        public InventarioForm()
        {
            InitializeComponent();
            LoadInventario();

        }

        private void InventarioForm_Load(object sender, EventArgs e)
        {
            LoadInventario();
            EstadoItems(dgvInventario, colCantidad.Index);
        }

        public void LoadInventario()
        {
            int i = 0;
            dgvInventario.Rows.Clear();
            cn = new SqlCommand("SELECT * FROM Inventario WHERE CONCAT(Iid,Codigo,Descripcion,Maquina,Cantidad,Compatible,Casillero) LIKE '%"+txtBusqueda.Text+"%'", conex);
            conex.Open();
            dr = cn.ExecuteReader();
            
            while (dr.Read())
            {
                i++;
                dgvInventario.Rows.Add(i,  dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());

            }
            dr.Close();
            conex.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            InventarioModuleForm formModule = new InventarioModuleForm();
            formModule.btnGuardar.Enabled = true;
            formModule.btnActualizar.Enabled = false;
            formModule.ShowDialog();
            LoadInventario();
        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvInventario.Columns[e.ColumnIndex].Name;
            if (colName == "Editar")
            {

                InventarioModuleForm InventarioModule = new InventarioModuleForm();
                InventarioModule.lblind.Text = dgvInventario.Rows[e.RowIndex].Cells[0].Value.ToString();
                InventarioModule.txtCodigo.Text = dgvInventario.Rows[e.RowIndex].Cells[1].Value.ToString();
                InventarioModule.txtDescripcion.Text = dgvInventario.Rows[e.RowIndex].Cells[2].Value.ToString();
                InventarioModule.comboMaquina.Text = dgvInventario.Rows[e.RowIndex].Cells[3].Value.ToString();
                InventarioModule.txtCantidad.Text = dgvInventario.Rows[e.RowIndex].Cells[4].Value.ToString();
                InventarioModule.txtCompatible.Text = dgvInventario.Rows[e.RowIndex].Cells[5].Value.ToString();
                InventarioModule.txtCasillero.Text = dgvInventario.Rows[e.RowIndex].Cells[6].Value.ToString();

                InventarioModule.btnGuardar.Enabled = false;
                InventarioModule.btnActualizar.Enabled = true;
                
            
                InventarioModule.ShowDialog();

            }
            else if (colName == "Borrar")
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar este Codigo?", "Eliminar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conex.Open();
                    cn = new SqlCommand("DELETE FROM Inventario WHERE Codigo LIKE '" + dgvInventario.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conex);
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("El registro se ha eliminado con éxito!!");
                }
            }
            LoadInventario();
        }

        

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)

        {
            if(e.KeyChar ==(char)Keys.Enter)
            {
                LoadInventario();
                txtBusqueda.Text = "";
            }
            
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(this.dgvInventario.Columns[e.ColumnIndex].Name =="Cantidad")
            {
                if(Convert.ToInt32 (e.Value)<=10)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.BackColor = Color.Orange;
                }
            }
        }

        public void EstadoItems(DataGridView Dgv, int Columna)
        {
            if (Dgv.Rows.Count > 0)
            {
                foreach(DataGridViewRow Fila in Dgv.Rows)
                {
                    if (decimal.TryParse(Fila.Cells[Columna].Value.ToString(), out decimal Valor))
                    {
                        if (Convert.ToDecimal(Fila.Cells[Columna].Value.ToString()) <= 10)
                        {
                            Fila.Cells[Columna].Style.BackColor = Color.Orange;
                            Fila.Cells[Columna].Style.ForeColor = Color.Black;
                        }

                        if (Convert.ToDecimal(Fila.Cells[Columna].Value.ToString()) <= 5)
                        {
                            Fila.Cells[Columna].Style.BackColor = Color.Red;
                            Fila.Cells[Columna].Style.ForeColor = Color.White;
                        }
                    }
                }
            }
        }
    }
}
