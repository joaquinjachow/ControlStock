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
    public partial class frmListaStockPino : Form
    {
        private clsPino pino;
        public frmListaStockPino()
        {
            InitializeComponent();
            pino = new clsPino();

        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            clsPino pino = new clsPino();
            pino.ListarPino(GrillaMaderas);
        }

        private void frmListaStockMaderas_Load(object sender, EventArgs e)
        {
            try
            {
                cmbSecado.DataSource = pino.ObtenerSecadoPino();
                cmbSecado.DisplayMember = "Secado";
                cmbPino.DataSource = pino.ObtenerMedidasPino();
                cmbPino.DisplayMember = "Medida";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las medidas y secado de maderas: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string medida = cmbPino.Text;
                string secado = cmbSecado.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                pino.SumarCantidadPaquetes(medida, secado, cantidad);
                MessageBox.Show("Cantidad de paquetes agregada correctamente.");
                txtCantidad.Text = "";
                pino.ListarPino(GrillaMaderas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar cantidad de paquetes: " + ex.Message);
            }
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            try
            {
                string medida = cmbPino.Text;
                string secado = cmbSecado.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                pino.RestarCantidadPaquetes(medida, secado, cantidad);
                MessageBox.Show("Cantidad de paquetes restada correctamente.");
                txtCantidad.Text = "";
                pino.ListarPino(GrillaMaderas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restar cantidad de paquetes: " + ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            pino.GenerarReportePino();
            MessageBox.Show("Reporte generado con exito");
        }

        private void cmbSecado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string secadoSeleccionado = cmbSecado.Text;
            DataTable medidasFiltradas = pino.ObtenerMedidasPorSecado(secadoSeleccionado);
            cmbPino.DataSource = medidasFiltradas;
            cmbPino.DisplayMember = "Medida";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las medidas por secado: " + ex.Message);
            }
        }
    }
}
