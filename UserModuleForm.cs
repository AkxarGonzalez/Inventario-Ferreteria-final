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
    public partial class UserModuleForm : Form
    {
        SqlConnection conex = new SqlConnection(@"Data Source=SISTEMAS\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True");
        SqlCommand cn = new SqlCommand();

      public UserModuleForm()
        {
            InitializeComponent();
        }

        private void pictureBoxCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtContraseña.Text != txtReContraseña.Text)
                {
                    MessageBox.Show("La Contraseña no coincide","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Estas seguro de guardar este usuario?", "Guardando Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn = new SqlCommand("INSERT INTO Usuarios(Usuario,Nombre_Completo,Contrasena,Puesto)VALUES(@Usuario,@NombreCompleto,@Contrasena,@Puesto)", conex);
                    cn.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                    cn.Parameters.AddWithValue("@NombreCompleto", txtNombreCompleto.Text);
                    cn.Parameters.AddWithValue("@Contrasena", txtContraseña.Text);
                    cn.Parameters.AddWithValue("@Puesto", txtPuesto.Text);
                    
                    conex.Open();
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("El usuario ha sido guardado exitosamente");
                    clear();
                }
                 
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clear();
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        public void clear()
        {
            txtUsuario.Clear();
            txtNombreCompleto.Clear();
            txtContraseña.Clear();
            txtReContraseña.Clear();
            txtPuesto.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContraseña.Text != txtReContraseña.Text)
                {
                    MessageBox.Show("LA CONTRASEÑA NO ES CORRECTA", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("¿Está seguro de que desea actualizar este usuario?", "Actualizar Registro" , MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn = new SqlCommand("UPDATE USUARIOS SET Nombre_Completo = @Nombre_Completo, Contrasena=@Contrasena, Puesto=@puesto WHERE usuario LIKE '" + txtUsuario.Text + "' ", conex);
                    cn.Parameters.AddWithValue("@Nombre_Completo", txtNombreCompleto.Text);
                    cn.Parameters.AddWithValue("@Contrasena", txtContraseña.Text);
                    cn.Parameters.AddWithValue("@Puesto", txtPuesto.Text);
                    conex.Open();
                    cn.ExecuteNonQuery();
                    conex.Close();
                    MessageBox.Show("El Usuario ha sido actualizado!");
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
