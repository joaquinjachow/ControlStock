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
                cmbMadera.DataSource = madera.ObtenerMedidasMaderasDura();
                cmbMadera.DisplayMember = "Medida";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las medidas de maderas: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string medida = cmbMadera.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                madera.SumarCantidadPaquetes(medida, cantidad);
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
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                madera.RestarCantidadPaquetes(medida, cantidad);
                MessageBox.Show("Cantidad de paquetes restada correctamente.");
                txtCantidad.Text = "";
                madera.ListarMaderasDuras(GrillaMaderas);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restar cantidad de paquetes: " + ex.Message);
            }
        }
    }
}
