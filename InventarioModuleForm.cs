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
    public partial class InventarioModuleForm : Form
    {
        SqlConnection conex = new SqlConnection(@"Data Source=SISTEMAS\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True");
        SqlCommand cn = new SqlCommand();
        SqlDataReader dr;
        public InventarioModuleForm()
        {
            InitializeComponent();
            loadMaquinas();
        }

        public void loadMaquinas()
        {
          comboMaquina.Items.Clear();
            cn = new SqlCommand("SELECT Nombre FROM Maquinas", conex);
            conex.Open();
            dr = cn.ExecuteReader();
            while(dr.Read())
            {
                comboMaquina.Items.Add(dr[0].ToString());
            }
            dr.Close();
            conex.Close();
        }

        private void pictureBoxCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
              
                if (MessageBox.Show("Estas seguro de guardar este Codigo?", "Guardando Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn = new SqlCommand("INSERT INTO Inventario(Codigo,Descripcion,Maquina,Cantidad,Compatible,Casillero)VALUES(@Codigo, @Descripcion, @Maquina, @Cantidad, @Compatible, @Casillero)", conex);
                    cn.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                    cn.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                    cn.Parameters.AddWithValue("@Maquina", comboMaquina.Text);
                    cn.Parameters.AddWithValue("@Cantidad", Convert.ToInt16(txtCantidad.Text));
                    cn.Parameters.AddWithValue("@Compatible", txtCompatible.Text);
                    cn.Parameters.AddWithValue("@Casillero", Convert.ToInt16(txtCasillero.Text));
                    conex.Open();
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("El Codigo ha sido guardado exitosamente");
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtCantidad.Clear();
            txtCompatible.Clear();
            txtCasillero.Clear();
            comboMaquina.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
              
                if (MessageBox.Show("¿Está seguro de que desea actualizar este Codigo?", "Actualizar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn = new SqlCommand("UPDATE INVENTARIO SET Codigo = @Codigo, Descripcion=@Descripcion, Maquina=@Maquina, Cantidad=@Cantidad, Compatible=@Compatible, Casillero=@Casillero  WHERE Iid LIKE '" + lblind.Text + "' ", conex);
                    cn.Parameters.AddWithValue("@Codigo", txtCodigo.Text);
                    cn.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                    cn.Parameters.AddWithValue("@Maquina", comboMaquina.Text);
                    cn.Parameters.AddWithValue("@Cantidad", Convert.ToInt16(txtCantidad.Text));
                    cn.Parameters.AddWithValue("@Compatible", txtCompatible.Text);
                    cn.Parameters.AddWithValue("@Casillero", Convert.ToInt16(txtCasillero.Text));
                    conex.Open();
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("El Inventario ha sido actualizado!");
                    this.Dispose();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InventarioModuleForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblind_Click(object sender, EventArgs e)
        {

        }

        private void comboMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCompatible_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCasillero_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
