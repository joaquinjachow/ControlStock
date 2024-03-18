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
    public partial class frmListaStockFenólicos : Form
    {
        private clsFenolicos fenólicos;
        public frmListaStockFenólicos()
        {
            InitializeComponent();
            fenólicos = new clsFenolicos();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            clsFenolicos fenolicos = new clsFenolicos();
            fenolicos.ListarFenólicos(GrillaFenolicos);
        }

        private void frmListaStockFenólicos_Load(object sender, EventArgs e)
        {
            try
            {
                cmbFenolico.DataSource = fenólicos.ObtenerCalidadesFenólicos();
                cmbFenolico.DisplayMember = "Calidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las calidades de los fenólicos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string calidad = cmbFenolico.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                fenólicos.SumarCantidadHojas(calidad, cantidad);
                MessageBox.Show("Cantidad de hojas agregada correctamente.");
                txtCantidad.Text = "";
                fenólicos.ListarFenólicos(GrillaFenolicos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar cantidad de hojas: " + ex.Message);
            }
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            try
            {
                string calidad = cmbFenolico.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                fenólicos.RestarCantidadHojas(calidad, cantidad);
                MessageBox.Show("Cantidad de hojas restada correctamente.");
                txtCantidad.Text = "";
                fenólicos.ListarFenólicos(GrillaFenolicos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restar cantidad de hojas: " + ex.Message);
            }
        }
    }
}
