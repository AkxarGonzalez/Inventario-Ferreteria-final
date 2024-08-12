
namespace Inventario_Ferreteria
{
    partial class ConsultadePedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultadePedidos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.colPedidoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colBtnImprimir = new System.Windows.Forms.DataGridViewImageColumn();
            this.colImgEliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComprador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutoriza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJustificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 43);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(322, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consulta de Pedidos";
            // 
            // cboTipoMovimiento
            // 
            this.cboTipoMovimiento.FormattingEnabled = true;
            this.cboTipoMovimiento.Items.AddRange(new object[] {
            "Recibidos",
            "En Curso",
            "Pendiente por Surtir",
            "Todos"});
            this.cboTipoMovimiento.Location = new System.Drawing.Point(401, 54);
            this.cboTipoMovimiento.Name = "cboTipoMovimiento";
            this.cboTipoMovimiento.Size = new System.Drawing.Size(202, 21);
            this.cboTipoMovimiento.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(311, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "Estatus";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(640, 51);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(187, 32);
            this.btnGenerar.TabIndex = 26;
            this.btnGenerar.Text = "Buscar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(177, 51);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaFinal.TabIndex = 24;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(27, 49);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(103, 20);
            this.dtpFechaInicial.TabIndex = 23;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPedidoId,
            this.Estatus2,
            this.colBtnImprimir,
            this.colImgEliminar,
            this.colFecha,
            this.colComprador,
            this.colAutoriza,
            this.colJustificacion,
            this.colEstatus});
            this.dgvListado.Location = new System.Drawing.Point(12, 89);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.Size = new System.Drawing.Size(886, 268);
            this.dgvListado.TabIndex = 27;
            this.dgvListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellClick);
            this.dgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellContentClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "...";
            this.dataGridViewImageColumn1.Image = global::Inventario_Ferreteria.Properties.Resources.icons8_basura_llena_100;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // colPedidoId
            // 
            this.colPedidoId.DataPropertyName = "PedidoId";
            this.colPedidoId.HeaderText = "IdPedido";
            this.colPedidoId.Name = "colPedidoId";
            this.colPedidoId.ReadOnly = true;
            // 
            // Estatus2
            // 
            this.Estatus2.HeaderText = "Column1";
            this.Estatus2.Items.AddRange(new object[] {
            "uno",
            "dos",
            "tres",
            "cuatro"});
            this.Estatus2.Name = "Estatus2";
            this.Estatus2.ReadOnly = true;
            // 
            // colBtnImprimir
            // 
            this.colBtnImprimir.HeaderText = "";
            this.colBtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("colBtnImprimir.Image")));
            this.colBtnImprimir.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colBtnImprimir.Name = "colBtnImprimir";
            this.colBtnImprimir.ReadOnly = true;
            this.colBtnImprimir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBtnImprimir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBtnImprimir.Width = 30;
            // 
            // colImgEliminar
            // 
            this.colImgEliminar.HeaderText = "";
            this.colImgEliminar.Image = global::Inventario_Ferreteria.Properties.Resources.icons8_basura_llena_100;
            this.colImgEliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colImgEliminar.Name = "colImgEliminar";
            this.colImgEliminar.ReadOnly = true;
            this.colImgEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colImgEliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colImgEliminar.Width = 30;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colComprador
            // 
            this.colComprador.DataPropertyName = "Comprador";
            this.colComprador.HeaderText = "Comprador";
            this.colComprador.Name = "colComprador";
            this.colComprador.ReadOnly = true;
            // 
            // colAutoriza
            // 
            this.colAutoriza.DataPropertyName = "Autoriza";
            this.colAutoriza.HeaderText = "Autoriza";
            this.colAutoriza.Name = "colAutoriza";
            this.colAutoriza.ReadOnly = true;
            // 
            // colJustificacion
            // 
            this.colJustificacion.DataPropertyName = "Justificacion";
            this.colJustificacion.HeaderText = "Juisticación";
            this.colJustificacion.Name = "colJustificacion";
            this.colJustificacion.ReadOnly = true;
            // 
            // colEstatus
            // 
            this.colEstatus.DataPropertyName = "Estado";
            this.colEstatus.HeaderText = "Estatus";
            this.colEstatus.Name = "colEstatus";
            this.colEstatus.ReadOnly = true;
            this.colEstatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ConsultadePedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(901, 503);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTipoMovimiento);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultadePedidos";
            this.Text = "Consulta de Pedidos";
            this.Load += new System.EventHandler(this.ConsultadePedidos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cboTipoMovimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPedidoId;
        private System.Windows.Forms.DataGridViewComboBoxColumn Estatus2;
        private System.Windows.Forms.DataGridViewImageColumn colBtnImprimir;
        private System.Windows.Forms.DataGridViewImageColumn colImgEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComprador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutoriza;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJustificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstatus;
    }
}