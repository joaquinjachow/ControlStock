using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace ControlStock
{
    internal class clsPino
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ControlStockDB.mdb";
        private string Tabla = "Pino";

        public Int32 NumeroPaquete;
        public Int32 CantidadPaquetes;
        public String Medida;
        public Int32 CantidadTablasPaquete;
        public enum Secado { SecadoHorno, SecadoNatural };
        public Secado MetodoSecado;

        public DataTable ObtenerMedidasPino()
        {
            DataTable medidas = new DataTable();
            try
            {
                string sql = "SELECT DISTINCT Medida FROM Pino";
                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(medidas);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener las medidas de las maderas: " + e.Message);
            }
            return medidas;
        }
        public void AgregarNuevoPino()
        {
            try
            {
                string secadoValue = MetodoSecado.ToString();
                string sql = "INSERT INTO Pino ([Número Paquete], [Cantidad Paquetes], Medida, [Cantidad de Tablas por Paquete], Secado) " +
                             "VALUES (@NumeroPaquete, @CantidadPaquetes, @Medida, @CantidadTablasPaquete, @Secado)";

                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@NumeroPaquete", NumeroPaquete);
                    cmd.Parameters.AddWithValue("@CantidadPaquetes", CantidadPaquetes);
                    cmd.Parameters.AddWithValue("@Medida", Medida);
                    cmd.Parameters.AddWithValue("@CantidadTablasPaquete", CantidadTablasPaquete);
                    cmd.Parameters.AddWithValue("@Secado", secadoValue);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al agregar nuevo pino: " + e.Message);
            }
        }
        private string FormatearEnumSecado(string enumSecado)
        {
            string formattedSecado = System.Text.RegularExpressions.Regex.Replace(enumSecado, "(\\B[A-Z])", " $1");

            return char.ToUpper(formattedSecado[0]) + formattedSecado.Substring(1);
        }
        public void ListarPino(DataGridView Grilla)
        {
            try
            {
                string sql = "SELECT * FROM Pino";
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
                            int campo1 = DR.IsDBNull(1) ? 0 : DR.GetInt32(1);
                            int campo4 = DR.IsDBNull(3) ? 0 : DR.GetInt32(3);
                            int volumen = campo1 * campo4;
                            string secado = DR.IsDBNull(4) ? string.Empty : FormatearEnumSecado(DR.GetString(4));
                            Grilla.Rows.Add(
                                secado,
                                DR.IsDBNull(0) ? (int?)null : DR.GetInt32(0),
                                DR.IsDBNull(1) ? (int?)null : DR.GetInt32(1),
                                DR.IsDBNull(2) ? string.Empty : DR.GetString(2),
                                DR.IsDBNull(3) ? (int?)null : DR.GetInt32(3),
                                volumen
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
        public void SumarCantidadPaquetes(string medida, int cantidad)
        {
            try
            {
                string sql = $"UPDATE Pino SET [Cantidad Paquetes] = [Cantidad Paquetes] + {cantidad} WHERE Medida = '{medida}'";

                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al sumar cantidad de paquetes: " + e.Message);
            }
        }
        public void RestarCantidadPaquetes(string medida, int cantidad)
        {
            try
            {
                string sql = $"UPDATE Pino SET [Cantidad Paquetes] = [Cantidad Paquetes] - {cantidad} WHERE Medida = '{medida}'";

                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al restar cantidad de paquetes: " + e.Message);
            }
        }
        private void LlenarEncabezado(IXLWorksheet worksheet)
        {
            var range = worksheet.Range("A10:F11");

            worksheet.Cell("C9").Value = "Vigencia Hasta:";
            worksheet.Range("C9:D9").Merge();
            worksheet.Cell("A10").Value = "Listado de Pino:";
            worksheet.Range("A10:F10").Merge();
            worksheet.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("A11").Value = "Secado";
            worksheet.Cell("B11").Value = "N° Paquete";
            worksheet.Cell("C11").Value = "Cant Paquetes";
            worksheet.Cell("D11").Value = "Medida";
            worksheet.Cell("E11").Value = "Cant. Tablas x Paquete";
            worksheet.Cell("F11").Value = "Cant. Tablas Totales";

            range.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }
        private void LlenarDatos(IXLWorksheet worksheet)
        {
            int rowNum = 14;

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
                    int? campo0 = DR.IsDBNull(0) ? (int?)null : DR.GetInt32(0);
                    int campo1 = DR.IsDBNull(1) ? 0 : DR.GetInt32(1);
                    string campo2 = DR.IsDBNull(2) ? "" : DR.GetString(2);
                    int campo3 = DR.IsDBNull(3) ? 0 : DR.GetInt32(3);
                    int volumen = campo1 * campo3;
                    string secado = DR.IsDBNull(4) ? string.Empty : FormatearEnumSecado(DR.GetString(4));

                    worksheet.Cell("A" + rowNum).Value = secado;
                    worksheet.Cell("B" + rowNum).Value = campo0.HasValue ? campo0.Value.ToString() : "";
                    worksheet.Cell("C" + rowNum).Value = campo1;
                    worksheet.Cell("D" + rowNum).Value = campo2;
                    worksheet.Cell("E" + rowNum).Value = campo3;
                    worksheet.Cell("F" + rowNum).Value = volumen;

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

            worksheet.Column("A").Width = 16;
            worksheet.Column("B").Width = 17;
            worksheet.Column("C").Width = 17;
            worksheet.Column("D").Width = 20;
            worksheet.Column("E").Width = 25;
            worksheet.Column("F").Width = 25;
        }
        public void GenerarReportePino()
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Pino");
                    LlenarEncabezado(worksheet);
                    LlenarDatos(worksheet);
                    AplicarEstilos(worksheet);

                    workbook.SaveAs("StockPino.xlsx");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
