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
    public partial class frmSistemaControlStock : Form
    {
        public frmSistemaControlStock()
        {
            InitializeComponent();
        }

        private void machToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listadoDeMaderasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaStockPino Ventana = new frmListaStockPino();
            Ventana.Show();
        }

        private void listadoMaderasDurasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoStockMaderasDuras Ventana = new frmListadoStockMaderasDuras();
            Ventana.Show();
        }

        private void listadoDeMachimbresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaStockMachimbre Ventana = new frmListaStockMachimbre();
            Ventana.Show();
        }

        private void listadoDeFenólicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaStockFenólicos Ventana = new frmListaStockFenólicos();
            Ventana.Show();
        }

        private void agregarNuevaMaderaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrAgregarNuevoPino Ventana = new fmrAgregarNuevoPino();
            Ventana.Show();
        }

        private void agregarNuevaMaderaDuraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarNuevaMaderaDura Ventana = new frmAgregarNuevaMaderaDura();
            Ventana.Show();
        }

        private void agregarNuevoMachimbreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarNuevoMachimbre Ventana = new frmAgregarNuevoMachimbre();
            Ventana.Show();
        }

        private void agregarNuevoFenólicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarNuevoFenólicos Ventana = new frmAgregarNuevoFenólicos();
            Ventana.Show();
        }
    }
}
