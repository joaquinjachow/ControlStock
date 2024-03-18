namespace ControlStock
{
    partial class frmListaStockFenólicos
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
            this.grpMaderas = new System.Windows.Forms.GroupBox();
            this.grpCambios = new System.Windows.Forms.GroupBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnRestar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cmbFenolico = new System.Windows.Forms.ComboBox();
            this.lblCalidadFenolico = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.GrillaFenolicos = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpMaderas.SuspendLayout();
            this.grpCambios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaFenolicos)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMaderas
            // 
            this.grpMaderas.Controls.Add(this.grpCambios);
            this.grpMaderas.Controls.Add(this.btnExportar);
            this.grpMaderas.Controls.Add(this.btnListar);
            this.grpMaderas.Controls.Add(this.GrillaFenolicos);
            this.grpMaderas.Location = new System.Drawing.Point(12, 12);
            this.grpMaderas.Name = "grpMaderas";
            this.grpMaderas.Size = new System.Drawing.Size(712, 812);
            this.grpMaderas.TabIndex = 2;
            this.grpMaderas.TabStop = false;
            this.grpMaderas.Text = "Fenólicos";
            // 
            // grpCambios
            // 
            this.grpCambios.Controls.Add(this.lblCantidad);
            this.grpCambios.Controls.Add(this.btnRestar);
            this.grpCambios.Controls.Add(this.btnAgregar);
            this.grpCambios.Controls.Add(this.txtCantidad);
            this.grpCambios.Controls.Add(this.cmbFenolico);
            this.grpCambios.Controls.Add(this.lblCalidadFenolico);
            this.grpCambios.Location = new System.Drawing.Point(7, 651);
            this.grpCambios.Name = "grpCambios";
            this.grpCambios.Size = new System.Drawing.Size(302, 155);
            this.grpCambios.TabIndex = 21;
            this.grpCambios.TabStop = false;
            this.grpCambios.Text = "Agregado de Fenólicos";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCantidad.Location = new System.Drawing.Point(9, 73);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(111, 15);
            this.lblCantidad.TabIndex = 24;
            this.lblCantidad.Text = "Cantidad de Hojas:";
            // 
            // btnRestar
            // 
            this.btnRestar.Location = new System.Drawing.Point(201, 108);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(92, 36);
            this.btnRestar.TabIndex = 5;
            this.btnRestar.Text = "Restar";
            this.btnRestar.UseVisualStyleBackColor = true;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(103, 108);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(92, 36);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(146, 73);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(147, 20);
            this.txtCantidad.TabIndex = 3;
            // 
            // cmbFenolico
            // 
            this.cmbFenolico.FormattingEnabled = true;
            this.cmbFenolico.Location = new System.Drawing.Point(146, 34);
            this.cmbFenolico.Name = "cmbFenolico";
            this.cmbFenolico.Size = new System.Drawing.Size(147, 21);
            this.cmbFenolico.TabIndex = 2;
            // 
            // lblCalidadFenolico
            // 
            this.lblCalidadFenolico.AutoSize = true;
            this.lblCalidadFenolico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCalidadFenolico.Location = new System.Drawing.Point(9, 35);
            this.lblCalidadFenolico.Name = "lblCalidadFenolico";
            this.lblCalidadFenolico.Size = new System.Drawing.Size(122, 15);
            this.lblCalidadFenolico.TabIndex = 19;
            this.lblCalidadFenolico.Text = "Calidad del Fenólico:";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(553, 707);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(150, 50);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(553, 651);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(150, 50);
            this.btnListar.TabIndex = 0;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // GrillaFenolicos
            // 
            this.GrillaFenolicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrillaFenolicos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column2,
            this.Column5,
            this.Column6});
            this.GrillaFenolicos.Location = new System.Drawing.Point(7, 20);
            this.GrillaFenolicos.Name = "GrillaFenolicos";
            this.GrillaFenolicos.Size = new System.Drawing.Size(696, 625);
            this.GrillaFenolicos.TabIndex = 100;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Calidad";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Espesor";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Cantidad de Hojas por Paquete";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Cantidad de Hojas Totales";
            this.Column6.Name = "Column6";
            this.Column6.Width = 150;
            // 
            // frmListaStockFenólicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 832);
            this.Controls.Add(this.grpMaderas);
            this.Name = "frmListaStockFenólicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Stock Fenólicos";
            this.Load += new System.EventHandler(this.frmListaStockFenólicos_Load);
            this.grpMaderas.ResumeLayout(false);
            this.grpCambios.ResumeLayout(false);
            this.grpCambios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrillaFenolicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMaderas;
        private System.Windows.Forms.GroupBox grpCambios;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnRestar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cmbFenolico;
        private System.Windows.Forms.Label lblCalidadFenolico;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView GrillaFenolicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}