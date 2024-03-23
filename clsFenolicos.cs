using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using static ControlStock.clsPino;
using ClosedXML.Excel;

namespace ControlStock
{
    internal class clsFenolicos
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ControlStockDB.mdb";
        private string Tabla = "Fenólicos";

        public String Calidad;
        public String Espesor;
        public Int32 CantidadHojasPaquete;
        public Int32 CantidadHojasTotales;

        public DataTable ObtenerCalidadesFenólicos()
        {
            DataTable Calidad = new DataTable();
            try
            {
                string sql = "SELECT DISTINCT Calidad FROM Fenólicos";
                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(Calidad);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener las calidades de los fenólicos: " + e.Message);
            }
            return Calidad;
        }
        public DataTable ObtenerEspesorPorCalidad(string calidad)
        {
            DataTable espesor = new DataTable();
            try
            {
                string sql = "SELECT DISTINCT Espesor FROM Fenólicos WHERE Calidad = @Calidad";
                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Calidad", calidad);

                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(espesor);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener el espesor filtrado por calidad: " + e.Message);
            }
            return espesor;
        }
        public DataTable ObtenerEspesor()
        {
            DataTable espesor = new DataTable();
            try
            {
                string sql = "SELECT DISTINCT Espesor FROM Fenólicos";
                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(espesor);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener el espesor de los fenólicos: " + e.Message);
            }
            return espesor;
        }
        public void AgregarNuevoFenolicos()
        {
            try
            {
                String sql = "INSERT INTO Fenólicos (Calidad, Espesor, [Cantidad de Hojas por Paquete], [Cantidad de Hojas Totales]) " +
                             "VALUES (@Calidad, @Espesor, @CantidadHojasPaquete, @CantidadHojasTotales)";

                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;

                comando.Parameters.AddWithValue("@Calidad", Calidad);
                comando.Parameters.AddWithValue("@Espesor", Espesor);
                comando.Parameters.AddWithValue("@CantidadHojasPaquete", CantidadHojasPaquete);
                comando.Parameters.AddWithValue("@CantidadHojasTotales", CantidadHojasTotales);

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void ListarFenólicos(DataGridView Grilla)
        {
            try
            {
                string sql = "SELECT * FROM Fenólicos";
                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    connection.Open();
                    OleDbDataReader DR = cmd.ExecuteReader();
                    Grilla.Rows.Clear();
                    if (DR.HasRows)
                    {
                        while (DR.Read())
                        {
                            string calid = DR.IsDBNull(0) ? "" : DR.GetString(0);
                            string espes = DR.IsDBNull(1) ? "" : DR.GetString(1);
                            int cantHojasPaq = DR.IsDBNull(2) ? 0 : DR.GetInt32(2);
                            int cantHojasTotal = DR.IsDBNull(3) ? 0 : DR.GetInt32(3);

                            Grilla.Rows.Add(
                                DR.IsDBNull(0) ? string.Empty : calid,
                                DR.IsDBNull(1) ? string.Empty : espes,
                                DR.IsDBNull(2) ? (int?)null : cantHojasPaq,
                                DR.IsDBNull(3) ? (int?)null : cantHojasTotal
                            );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void SumarCantidadHojas(int cantidad, string calidad, string espesor)
        {
            try
            {
                string sql = $"UPDATE Fenólicos SET [Cantidad de Hojas Totales] = [Cantidad de Hojas Totales] + {cantidad} WHERE Calidad = '{calidad}' AND Espesor = '{espesor}'";

                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al sumar cantidad de hojas: " + e.Message);
            }
        }
        public void RestarCantidadHojas(int cantidad, string calidad, string espesor)
        {
            try
            {
                string sql = $"UPDATE Fenólicos SET [Cantidad de Hojas Totales] = [Cantidad de Hojas Totales] - {cantidad} WHERE Calidad = '{calidad}' AND Espesor = '{espesor}'";

                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al restar cantidad de hojas: " + e.Message);
            }
        }
        private void LlenarEncabezado(IXLWorksheet worksheet)
        {
            var range = worksheet.Range("A10:D11");

            worksheet.Cell("B9").Value = "Vigencia Hasta:";
            worksheet.Range("B9:C9").Merge();
            worksheet.Cell("A10").Value = "Listado de Pino:";
            worksheet.Range("A10:D10").Merge();
            worksheet.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("A11").Value = "Calidad";
            worksheet.Cell("B11").Value = "Espesor";
            worksheet.Cell("C11").Value = "Cant Hojas x Paquete";
            worksheet.Cell("D11").Value = "Cantidad Hojas Totales";


            range.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }
        private void LlenarDatos(IXLWorksheet worksheet)
        {
            int rowNum = 12;

            conexion.ConnectionString = CadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = Tabla;
            OleDbDataReader DR = comando.ExecuteReader();

            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    string calid = DR.IsDBNull(0) ? "" : DR.GetString(0);
                    string espes = DR.IsDBNull(1) ? "" : DR.GetString(1);
                    int cantHojasPaq = DR.IsDBNull(2) ? 0 : DR.GetInt32(2);
                    int cantHojasTotal = DR.IsDBNull(3) ? 0 : DR.GetInt32(3);

                    worksheet.Cell("A" + rowNum).Value = calid;
                    worksheet.Cell("B" + rowNum).Value = espes;
                    worksheet.Cell("C" + rowNum).Value = cantHojasPaq;
                    worksheet.Cell("D" + rowNum).Value = cantHojasTotal;

                    rowNum++;
                }
            }
            conexion.Close();
        }
        private void AplicarEstilos(IXLWorksheet worksheet)
        {
            worksheet.PageSetup.PageOrientation = XLPageOrientation.Landscape;
            worksheet.PageSetup.PaperSize = XLPaperSize.A4Paper;
            worksheet.CellsUsed().Style.Font.FontSize = 12;
            worksheet.Cell("A10").Style.Font.FontSize = 24;

            worksheet.Cells().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            var rangeWithData = worksheet.Range(worksheet.FirstCellUsed(), worksheet.LastCellUsed());
            var tableBorder = rangeWithData.Style.Border;
            tableBorder.InsideBorder = XLBorderStyleValues.Thin;
            tableBorder.OutsideBorder = XLBorderStyleValues.Thin;
            tableBorder.BottomBorder = XLBorderStyleValues.Thin;
            tableBorder.TopBorder = XLBorderStyleValues.Thin;
            tableBorder.LeftBorder = XLBorderStyleValues.Thin;
            tableBorder.RightBorder = XLBorderStyleValues.Thin;

            var vigenciaRow = worksheet.Row(9);
            foreach (var cell in vigenciaRow.Cells())
            {
                cell.Style.Border.OutsideBorder = XLBorderStyleValues.None;
                cell.Style.Border.InsideBorder = XLBorderStyleValues.None;
            }

            worksheet.Column("A").Width = 20;
            worksheet.Column("B").Width = 20;
            worksheet.Column("C").Width = 25;
            worksheet.Column("D").Width = 25;
        }
        public void GenerarReporteFenolicos()
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Fenólicos");
                    LlenarEncabezado(worksheet);
                    LlenarDatos(worksheet);
                    AplicarEstilos(worksheet);

                    workbook.SaveAs("StockFenólicos.xlsx");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
