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
    public partial class MaquinasModuleForms : Form
    {
        SqlConnection conex = new SqlConnection(@"Data Source=SISTEMAS\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True");
        SqlCommand cn = new SqlCommand();
        public MaquinasModuleForms()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Estas seguro de guardar esta nueva maquina?", "Guardando Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn = new SqlCommand("INSERT INTO Maquinas(Nombre)VALUES(@Nombre)", conex);
                    cn.Parameters.AddWithValue("@Nombre", txtNombreMaq.Text);                  
                    conex.Open();
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("La Maquina  ha sido guardada exitosamente");
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
            txtNombreMaq.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Estas seguro de actualizar esta Maquina?", "Actualizar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn = new SqlCommand("UPDATE Maquinas SET Nombre = @Nombre  WHERE maqid LIKE '" + lblMaqld.Text + "' ", conex);
                    cn.Parameters.AddWithValue("@Nombre", txtNombreMaq.Text);               
                    conex.Open();
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("La Maquina ha sido actualizada exitosamente!!");
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
