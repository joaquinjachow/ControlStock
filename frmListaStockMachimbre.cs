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
    public partial class frmListaStockMachimbre : Form
    {
        private clsMachimbre machimbre;
        public frmListaStockMachimbre()
        {
            InitializeComponent();
            machimbre = new clsMachimbre();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            clsMachimbre machimbre = new clsMachimbre();
            machimbre.ListarMachimbre(GrillaMachimbre);
        }

        private void frmListaStockMachimbre_Load(object sender, EventArgs e)
        {
            try
            {
                cmbCalidad.DataSource = machimbre.ObtenerCalidadMachimbre();
                cmbCalidad.DisplayMember = "Calidad";
                cmbMachimbre.DataSource = machimbre.ObtenerMedidasMachimbre();
                cmbMachimbre.DisplayMember = "Medida";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las medidas y calidades de los machimbres: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string medida = cmbMachimbre.Text;
                string calidad = cmbCalidad.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                machimbre.SumarCantidadPaquetes(medida, calidad, cantidad);
                MessageBox.Show("Cantidad de paquetes agregada correctamente.");
                txtCantidad.Text = "";
                machimbre.ListarMachimbre(GrillaMachimbre);
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
                string medida = cmbMachimbre.Text;
                string calidad = cmbCalidad.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                machimbre.RestarCantidadPaquetes(medida, calidad, cantidad);
                MessageBox.Show("Cantidad de paquetes restada correctamente.");
                txtCantidad.Text = "";
                machimbre.ListarMachimbre(GrillaMachimbre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restar cantidad de paquetes: " + ex.Message);
            }
        }

        private void cmbCalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string calidadSeleccionada = cmbCalidad.Text;
                DataTable medidasFiltradas = machimbre.ObtenerMedidasPorCalidad(calidadSeleccionada);
                cmbMachimbre.DataSource = medidasFiltradas;
                cmbMachimbre.DisplayMember = "Medida";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las medidas por calidades: " + ex.Message);
            }
        }
    }
}
