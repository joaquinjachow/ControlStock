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
    public partial class frmAgregarNuevaMaderaDura : Form
    {
        public frmAgregarNuevaMaderaDura()
        {
            InitializeComponent();
        }

        private void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            clsMaderaDura madera = new clsMaderaDura();
            madera.Especie = txtEspecie.Text;
            madera.CantidadPaquetes = Convert.ToInt32(txtCantidadPaquetes.Text);
            madera.Medida = txtMedida.Text;
            madera.CantidadTablasPaquete = Convert.ToInt32(txtCantidadTablas.Text);

            madera.AgregarNuevaMaderaDura();

            MessageBox.Show("Datos grabados!!!");

            txtEspecie.Text = "";
            txtCantidadPaquetes.Text = "";
            txtMedida.Text = "";
            txtCantidadTablas.Text = "";
        }
    }
}
