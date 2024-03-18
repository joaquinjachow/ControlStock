using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlStock.clsPino;

namespace ControlStock
{
    public partial class fmrAgregarNuevoPino : Form
    {
        public fmrAgregarNuevoPino()
        {
            InitializeComponent();
        }

        private void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            clsPino pino = new clsPino();
            if (cmbSecado.SelectedItem != null)
            {
                Secado secadoSeleccionado = (Secado)cmbSecado.SelectedItem;
                pino.MetodoSecado = secadoSeleccionado;
            }
            else
            {
                MessageBox.Show("Por favor seleccione un método de secado.");
                return;
            }
            pino.NumeroPaquete = Convert.ToInt32(txtNumeroPaquete.Text);
            pino.CantidadPaquetes = Convert.ToInt32(txtCantidadPaquetes.Text);
            pino.Medida = txtMedida.Text;
            pino.CantidadTablasPaquete = Convert.ToInt32(txtCantidadTablas.Text);

            pino.AgregarNuevoPino();

            MessageBox.Show("Datos grabados!!!");

            cmbSecado.Text = "";
            txtNumeroPaquete.Text = "";
            txtCantidadPaquetes.Text = "";
            txtMedida.Text = "";
            txtCantidadTablas.Text = "";
        }

        private void fmrAgregarNuevoPino_Load(object sender, EventArgs e)
        {
            foreach (Secado secado in Enum.GetValues(typeof(Secado)))
            {
                cmbSecado.Items.Add(secado);
            }
        }
    }
}
