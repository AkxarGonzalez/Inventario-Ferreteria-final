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
    public partial class ProveedoresModuleForm : Form
    {
        SqlConnection conex = new SqlConnection(@"Data Source=SISTEMAS\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True");
        SqlCommand cn = new SqlCommand();
        public ProveedoresModuleForm()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (MessageBox.Show("Estas seguro de guardar este Proveedor?", "Guardando Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn = new SqlCommand("INSERT INTO Proveedores(Nombre,Telefono)VALUES(@Nombre,@Telefono)", conex);
                    cn.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cn.Parameters.AddWithValue("@Telefono", txtTelefono.Text);   
                    conex.Open();
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("El usuario ha sido guardado exitosamente");
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
            txtNombre.Clear();
            txtTelefono.Clear();    
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
              if (MessageBox.Show("Estas seguro de actualizar este Proveedor?", "Actualizar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              {
                cn = new SqlCommand("UPDATE Proveedores SET Nombre = @Nombre,Telefono=@Telefono WHERE pid LIKE '" + lblPld.Text + "' ", conex);
                cn.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cn.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                conex.Open();
                cn.ExecuteNonQuery();
                conex.Close();
                MessageBox.Show("El Proveedor ha sido actualizado exitosamente!!");
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
