using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Inventario_Ferreteria
{
    public partial class Login : Form
    {
        SqlConnection conex = new SqlConnection(@"Data Source=SISTEMAS\SQLEXPRESS;Initial Catalog=bd_ferreteria;Integrated Security=True");
        SqlCommand cn = new SqlCommand();
        SqlDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxcontra_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxcontra.Checked == false)
                txtContrasena.UseSystemPasswordChar = true;
            else 
                txtContrasena.UseSystemPasswordChar = false;
        }

        private void lblBorrar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("SALIR DE LA APLICACION ","CONFIRMAR" , MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Application.Exit();
            }

            
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //if(txtUsuario.Text == ("Sistemas") && txtContrasena.Text == "Therapedic23")
            //{
            //    MainForm xform = new MainForm();
            //    xform.

            //}

            try
            {
                cn = new SqlCommand("SELECT Puesto, Nombre_Completo FROM Usuarios WHERE Usuario=@Usuario AND Contrasena = @Contrasena",conex);
                cn.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                cn.Parameters.AddWithValue("@Contrasena", txtContrasena.Text);
                conex.Open();



                //SqlDataAdapter da = new SqlDataAdapter(cn);
                //DataTable _Datos = new DataTable();
                //da.Fill(_Datos);

                dr = cn.ExecuteReader();
                dr.Read();
                if(dr.HasRows)
                {
                   

                    //MessageBox.Show("  BIENVENIDO   " + dr.GetValue(1));

                    Bienvenida bienvenida = new Bienvenida();
                    bienvenida.ShowDialog();
                    this.Hide();
                    MainForm main = new MainForm();
                    
                    main.Puesto = dr.GetValue(0).ToString();
                    //main.txtPuesto.Text = _Datos.Rows[0]["Puesto"].ToString();
                    main.ShowDialog();
                    
                    
                    
                }
                else
                {
                    
                    MessageBox.Show("Usuario o Contrasena invalido!!", "Acesso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                
                dr.Close();
                conex.Close();
                
               
                
                    
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void Logout(object sender,FormClosedEventArgs e)
        //{
        //    txtUsuario.Text = "";
        //    txtContrasena.Text = "";
        //    this.Show();
        //    txtUsuario.Select();
        //}

        private void btnEntrar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
