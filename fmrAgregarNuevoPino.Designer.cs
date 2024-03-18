namespace ControlStock
{
    partial class fmrAgregarNuevoPino
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
            this.grpCargadeDatos = new System.Windows.Forms.GroupBox();
            this.lblSecado = new System.Windows.Forms.Label();
            this.txtCantidadTablas = new System.Windows.Forms.TextBox();
            this.lblCantidadTablas = new System.Windows.Forms.Label();
            this.txtNumeroPaquete = new System.Windows.Forms.TextBox();
            this.lblNumeroPaquete = new System.Windows.Forms.Label();
            this.txtMedida = new System.Windows.Forms.TextBox();
            this.btnAgregarNuevo = new System.Windows.Forms.Button();
            this.lblMedida = new System.Windows.Forms.Label();
            this.txtCantidadPaquetes = new System.Windows.Forms.TextBox();
            this.lblCantidadPaquetes = new System.Windows.Forms.Label();
            this.cmbSecado = new System.Windows.Forms.ComboBox();
            this.grpCargadeDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCargadeDatos
            // 
            this.grpCargadeDatos.Controls.Add(this.cmbSecado);
            this.grpCargadeDatos.Controls.Add(this.lblSecado);
            this.grpCargadeDatos.Controls.Add(this.txtCantidadTablas);
            this.grpCargadeDatos.Controls.Add(this.lblCantidadTablas);
            this.grpCargadeDatos.Controls.Add(this.txtNumeroPaquete);
            this.grpCargadeDatos.Controls.Add(this.lblNumeroPaquete);
            this.grpCargadeDatos.Controls.Add(this.txtMedida);
            this.grpCargadeDatos.Controls.Add(this.btnAgregarNuevo);
            this.grpCargadeDatos.Controls.Add(this.lblMedida);
            this.grpCargadeDatos.Controls.Add(this.txtCantidadPaquetes);
            this.grpCargadeDatos.Controls.Add(this.lblCantidadPaquetes);
            this.grpCargadeDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.grpCargadeDatos.Location = new System.Drawing.Point(12, 12);
            this.grpCargadeDatos.Name = "grpCargadeDatos";
            this.grpCargadeDatos.Size = new System.Drawing.Size(410, 270);
            this.grpCargadeDatos.TabIndex = 2;
            this.grpCargadeDatos.TabStop = false;
            this.grpCargadeDatos.Text = "Carga de datos";
            // 
            // lblSecado
            // 
            this.lblSecado.AutoSize = true;
            this.lblSecado.Location = new System.Drawing.Point(21, 32);
            this.lblSecado.Name = "lblSecado";
            this.lblSecado.Size = new System.Drawing.Size(63, 18);
            this.lblSecado.TabIndex = 21;
            this.lblSecado.Text = "Secado:";
            // 
            // txtCantidadTablas
            // 
            this.txtCantidadTablas.Location = new System.Drawing.Point(257, 191);
            this.txtCantidadTablas.Name = "txtCantidadTablas";
            this.txtCantidadTablas.Size = new System.Drawing.Size(142, 24);
            this.txtCantidadTablas.TabIndex = 4;
            this.txtCantidadTablas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCantidadTablas
            // 
            this.lblCantidadTablas.AutoSize = true;
            this.lblCantidadTablas.Location = new System.Drawing.Point(21, 191);
            this.lblCantidadTablas.Name = "lblCantidadTablas";
            this.lblCantidadTablas.Size = new System.Drawing.Size(222, 18);
            this.lblCantidadTablas.TabIndex = 19;
            this.lblCantidadTablas.Text = "Cantidad de Tablas por Paquete:";
            // 
            // txtNumeroPaquete
            // 
            this.txtNumeroPaquete.Location = new System.Drawing.Point(257, 70);
            this.txtNumeroPaquete.Name = "txtNumeroPaquete";
            this.txtNumeroPaquete.Size = new System.Drawing.Size(142, 24);
            this.txtNumeroPaquete.TabIndex = 1;
            this.txtNumeroPaquete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNumeroPaquete
            // 
            this.lblNumeroPaquete.AutoSize = true;
            this.lblNumeroPaquete.Location = new System.Drawing.Point(21, 70);
            this.lblNumeroPaquete.Name = "lblNumeroPaquete";
            this.lblNumeroPaquete.Size = new System.Drawing.Size(124, 18);
            this.lblNumeroPaquete.TabIndex = 17;
            this.lblNumeroPaquete.Text = "Número Paquete:";
            // 
            // txtMedida
            // 
            this.txtMedida.Location = new System.Drawing.Point(257, 153);
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.Size = new System.Drawing.Size(142, 24);
            this.txtMedida.TabIndex = 3;
            this.txtMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAgregarNuevo
            // 
            this.btnAgregarNuevo.Location = new System.Drawing.Point(257, 231);
            this.btnAgregarNuevo.Name = "btnAgregarNuevo";
            this.btnAgregarNuevo.Size = new System.Drawing.Size(142, 29);
            this.btnAgregarNuevo.TabIndex = 5;
            this.btnAgregarNuevo.Text = "Agregar Nuevo";
            this.btnAgregarNuevo.UseVisualStyleBackColor = true;
            this.btnAgregarNuevo.Click += new System.EventHandler(this.btnAgregarNuevo_Click);
            // 
            // lblMedida
            // 
            this.lblMedida.AutoSize = true;
            this.lblMedida.Location = new System.Drawing.Point(21, 153);
            this.lblMedida.Name = "lblMedida";
            this.lblMedida.Size = new System.Drawing.Size(60, 18);
            this.lblMedida.TabIndex = 9;
            this.lblMedida.Text = "Medida:";
            // 
            // txtCantidadPaquetes
            // 
            this.txtCantidadPaquetes.Location = new System.Drawing.Point(257, 113);
            this.txtCantidadPaquetes.Name = "txtCantidadPaquetes";
            this.txtCantidadPaquetes.Size = new System.Drawing.Size(142, 24);
            this.txtCantidadPaquetes.TabIndex = 2;
            this.txtCantidadPaquetes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCantidadPaquetes
            // 
            this.lblCantidadPaquetes.AutoSize = true;
            this.lblCantidadPaquetes.Location = new System.Drawing.Point(21, 113);
            this.lblCantidadPaquetes.Name = "lblCantidadPaquetes";
            this.lblCantidadPaquetes.Size = new System.Drawing.Size(136, 18);
            this.lblCantidadPaquetes.TabIndex = 2;
            this.lblCantidadPaquetes.Text = "Cantidad Paquetes:";
            // 
            // cmbSecado
            // 
            this.cmbSecado.FormattingEnabled = true;
            this.cmbSecado.Location = new System.Drawing.Point(257, 28);
            this.cmbSecado.Name = "cmbSecado";
            this.cmbSecado.Size = new System.Drawing.Size(142, 26);
            this.cmbSecado.TabIndex = 22;
            // 
            // fmrAgregarNuevoPino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 288);
            this.Controls.Add(this.grpCargadeDatos);
            this.Name = "fmrAgregarNuevoPino";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Nuevo Pino";
            this.Load += new System.EventHandler(this.fmrAgregarNuevoPino_Load);
            this.grpCargadeDatos.ResumeLayout(false);
            this.grpCargadeDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCargadeDatos;
        private System.Windows.Forms.TextBox txtNumeroPaquete;
        private System.Windows.Forms.Label lblNumeroPaquete;
        private System.Windows.Forms.TextBox txtMedida;
        private System.Windows.Forms.Button btnAgregarNuevo;
        private System.Windows.Forms.Label lblMedida;
        private System.Windows.Forms.TextBox txtCantidadPaquetes;
        private System.Windows.Forms.Label lblCantidadPaquetes;
        private System.Windows.Forms.TextBox txtCantidadTablas;
        private System.Windows.Forms.Label lblCantidadTablas;
        private System.Windows.Forms.Label lblSecado;
        private System.Windows.Forms.ComboBox cmbSecado;
    }
}