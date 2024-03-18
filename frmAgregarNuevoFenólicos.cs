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
    public partial class frmAgregarNuevoFenólicos : Form
    {
        public frmAgregarNuevoFenólicos()
        {
            InitializeComponent();
        }

        private void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            clsFenolicos fenólicos = new clsFenolicos();
            fenólicos.Calidad = txtCalidad.Text;
            fenólicos.Espesor = txtEspesor.Text;
            fenólicos.CantidadHojasPaquete = Convert.ToInt32(txtCantidadHojasPaquete.Text);
            fenólicos.CantidadHojasTotales = Convert.ToInt32(txtCantidadHojasTotales.Text);

            fenólicos.AgregarNuevoFenolicos();

            MessageBox.Show("Datos grabados!!!");

            txtCalidad.Text = "";
            txtEspesor.Text = "";
            txtCantidadHojasPaquete.Text = "";
            txtCantidadHojasTotales.Text = "";
        }
    }
}
