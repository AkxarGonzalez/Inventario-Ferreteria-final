using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario_Ferreteria
{
    public partial class MainForm : Form
    {
        public string Puesto { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        
       
       //para mostrar el formulario de usuarios
       private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(childForm);
            PanelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            openChildForm(new ProveedoresForm());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            openChildForm(new MaquinasForm());
        }

        private void btnCodigo_Click(object sender, EventArgs e)
        {
            //if (Puesto == "Sistemas")
            {
                openChildForm(new InventarioForm());
            }
           //else if (Puesto == "Administrador")
                openChildForm(new InventarioForm());
           // else if (Puesto == "Encargado")
               // openChildForm(new InventarioForm());
            //MessageBox.Show("Usted no tiene acceso.");
            //openChildForm(new InventarioForm());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void customerButton5_Click(object sender, EventArgs e)
        {
            Form Entradas = new Entradas();
            Entradas.Show();
        }

        private void customerButton1_Click(object sender, EventArgs e)
        {
            Form Salidas = new Salidas();
            Salidas.Show();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Form Generar_Reportes = new Generar_Reporte();
            Generar_Reportes.Show();
        }

       private void MainForm_Load(object sender, EventArgs e)
        {
           switch (Puesto)
            {
                case "Sistemas":
                    btnCodigo.Enabled = true;
                    btnProveedores.Enabled = true;
                    btnCategorias.Enabled = true;
                    btnUsuarios.Enabled = true;
                    btnReporte.Enabled = true;
                    btnEntradas.Enabled = true;
                    btnSalidas.Enabled = true;
                    break;
                case "Encargado":
                    
                    btnCodigo.Enabled = true;
                    btnProveedores.Enabled = false;      
                    btnCategorias.Enabled = false;
                    btnUsuarios.Enabled = false;
                    btnReporte.Enabled = true;
                    btnEntradas.Enabled = true;
                    btnSalidas.Enabled = true;
                    
                    break;

                case "Empleado":
                    btnCategorias.Enabled = false;
                    btnEntradas.Enabled = false;
                    btnSalidas.Enabled = false;
                    btnReporte.Enabled = false;
                    btnUsuarios.Enabled = false;
                    btnProveedores.Enabled = false;
                    btnCodigo.Enabled = true;

                    break;
                default:
                    MessageBox.Show("Usted no tiene acceso.");
                    break;

            }
            
        }

        private void customerButton1_Click_1(object sender, EventArgs e)
        {
            Form Pedidos = new Pedidos();
            Pedidos.Show();
        }

        //private void btnCerrarSesion_Click(object sender, EventArgs e)
        //{
        //    DialogResult opcion;
        //    opcion = MessageBox.Show("DESEA CERRAR SESION DEL SISTEMA", "SISTEMA ALMACEN FERRETERIA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        //    if (opcion == DialogResult.OK)
        //    {
        //        this.Close();
        //    }
        //}
    }
}
