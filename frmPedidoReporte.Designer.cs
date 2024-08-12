
namespace Inventario_Ferreteria
{
    partial class frmPedidoReporte
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spConsultaPedidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportePedido = new Inventario_Ferreteria.ReportePedido();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spConsultaPedidoTableAdapter = new Inventario_Ferreteria.ReportePedidoTableAdapters.spConsultaPedidoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spConsultaPedidoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportePedido)).BeginInit();
            this.SuspendLayout();
            // 
            // spConsultaPedidoBindingSource
            // 
            this.spConsultaPedidoBindingSource.DataMember = "spConsultaPedido";
            this.spConsultaPedidoBindingSource.DataSource = this.ReportePedido;
            // 
            // ReportePedido
            // 
            this.ReportePedido.DataSetName = "ReportePedido";
            this.ReportePedido.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spConsultaPedidoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Inventario_Ferreteria.Informe Pedido.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // spConsultaPedidoTableAdapter
            // 
            this.spConsultaPedidoTableAdapter.ClearBeforeFill = true;
            // 
            // frmPedidoReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmPedidoReporte";
            this.Text = "frmPedidoReporte";
            this.Load += new System.EventHandler(this.frmPedidoReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spConsultaPedidoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportePedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spConsultaPedidoBindingSource;
        private ReportePedido ReportePedido;
        private ReportePedidoTableAdapters.spConsultaPedidoTableAdapter spConsultaPedidoTableAdapter;
    }
}