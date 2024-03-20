using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock
{
    public partial class frmListadoStockMaderasDuras : Form
    {
        private clsMaderaDura madera;
        public frmListadoStockMaderasDuras()
        {
            InitializeComponent();
            madera = new clsMaderaDura();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            clsMaderaDura madera = new clsMaderaDura();
            madera.ListarMaderasDuras(GrillaMaderas);
        }

        private void frmListadoStockMaderasDuras_Load(object sender, EventArgs e)
        {
            try
            {
                cmbEspecie.DataSource = madera.ObtenerEspeciesMaderaDura();
                cmbEspecie.DisplayMember = "Especie";
                cmbMadera.DataSource = madera.ObtenerMedidasMaderasDura();
                cmbMadera.DisplayMember = "Medida";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las medidas y especies de maderas: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string medida = cmbMadera.Text;
                string especie = cmbEspecie.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                madera.SumarCantidadPaquetes(medida, especie, cantidad);
                MessageBox.Show("Cantidad de paquetes agregada correctamente.");
                txtCantidad.Text = "";
                madera.ListarMaderasDuras(GrillaMaderas);
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
                string medida = cmbMadera.Text;
                string especie = cmbEspecie.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                madera.RestarCantidadPaquetes(medida, especie, cantidad);
                MessageBox.Show("Cantidad de paquetes restada correctamente.");
                txtCantidad.Text = "";
                madera.ListarMaderasDuras(GrillaMaderas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restar cantidad de paquetes: " + ex.Message);
            }
        }

        private void cmbEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string especieSeleccionada = cmbEspecie.Text;
                DataTable medidasFiltradas = madera.ObtenerMedidasPorEspecies(especieSeleccionada);
                cmbMadera.DataSource = medidasFiltradas;
                cmbMadera.DisplayMember = "Medida";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar las medidas por especies: " + ex.Message);
            }
        }
    }
}
