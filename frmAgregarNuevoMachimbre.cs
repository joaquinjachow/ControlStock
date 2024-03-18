using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class frmAgregarNuevoMachimbre : Form
    {
        public frmAgregarNuevoMachimbre()
        {
            InitializeComponent();
        }

        private void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            clsMachimbre machimbre = new clsMachimbre();
            machimbre.Calidad = txtCalidad.Text;
            machimbre.NumeroPaquete = Convert.ToInt32(txtNumeroPaquete.Text);
            machimbre.CantidadPaquetes = Convert.ToInt32(txtCantidadPaquetes.Text);
            machimbre.Medida = txtMedida.Text;
            machimbre.CantidadTablasPaquete = Convert.ToInt32(txtCantidadTablas.Text);

            machimbre.AgregarNuevoMachimbre();

            MessageBox.Show("Datos grabados!!!");

            txtCalidad.Text = "";
            txtNumeroPaquete.Text = "";
            txtCantidadPaquetes.Text = "";
            txtMedida.Text = "";
            txtCantidadTablas.Text = "";
        }
    }
}
