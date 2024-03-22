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
                cmbCalidad.DataSource = fenólicos.ObtenerCalidadesFenólicos();
                cmbCalidad.DisplayMember = "Calidad";
                cmbEspesor.DataSource = fenólicos.ObtenerEspesor();
                cmbEspesor.DisplayMember = "Espesor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las calidades y espesor de los fenólicos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string calidad = cmbCalidad.Text;
                string espesor = cmbEspesor.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                fenólicos.SumarCantidadHojas(cantidad, calidad, espesor);
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
                string calidad = cmbCalidad.Text;
                string espesor = cmbEspesor.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                fenólicos.RestarCantidadHojas(cantidad, calidad, espesor);
                MessageBox.Show("Cantidad de hojas restada correctamente.");
                txtCantidad.Text = "";
                fenólicos.ListarFenólicos(GrillaFenolicos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restar cantidad de hojas: " + ex.Message);
            }
        }

        private void cmbCalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string calidadSeleccionada = cmbCalidad.Text;
                DataTable EspesorFiltrado = fenólicos.ObtenerEspesorPorCalidad(calidadSeleccionada);
                cmbEspesor.DataSource = EspesorFiltrado;
                cmbEspesor.DisplayMember = "Espesor";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar los espesores por calidad: " + ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            fenólicos.GenerarReporteFenolicos();
            MessageBox.Show("Reporte generado con exito");
        }
    }
}
