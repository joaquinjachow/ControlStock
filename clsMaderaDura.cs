﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace ControlStock
{
    internal class clsMaderaDura
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ControlStockDB.mdb";
        private string Tabla = "MaderaDura";

        public Int32 CantidadPaquetes;
        public String Medida;
        public Int32 CantidadTablasPaquete;
        public String Especie;

        public DataTable ObtenerEspeciesMaderaDura()
        {
            DataTable especie = new DataTable();
            try
            {
                string sql = "SELECT DISTINCT Especie FROM MaderaDura";
                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(especie);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener las especies de las maderas: " + e.Message);
            }
            return especie;
        }
        public DataTable ObtenerMedidasPorEspecies(string especies)
        {
            DataTable especie = new DataTable();
            try
            {
                string sql = "SELECT DISTINCT Medida FROM MaderaDura WHERE Especie = @Especie";
                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Especie", especies);

                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(especie);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener las medidas filtradas por especies: " + e.Message);
            }
            return especie;
        }
        public DataTable ObtenerMedidasMaderasDura()
        {
            DataTable medidas = new DataTable();
            try
            {
                string sql = "SELECT DISTINCT Medida FROM MaderaDura";
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
        public void AgregarNuevaMaderaDura()
        {
            try
            {
                string sql = "INSERT INTO MaderaDura ([Cantidad Paquetes], Medida, [Cantidad de Tablas por Paquete], Especie) " +
                             "VALUES (@CantidadPaquetes, @Medida, @CantidadTablasPaquete, @Especie)";

                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@CantidadPaquetes", CantidadPaquetes);
                    cmd.Parameters.AddWithValue("@Medida", Medida);
                    cmd.Parameters.AddWithValue("@CantidadTablasPaquete", CantidadTablasPaquete);
                    cmd.Parameters.AddWithValue("@Especie", string.IsNullOrEmpty(Especie) ? DBNull.Value : (object)Especie);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al agregar nueva madera dura: " + e.Message);
            }
        }
        public void ListarMaderasDuras(DataGridView Grilla)
        {
            try
            {
                string sql = "SELECT * FROM MaderaDura";
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
                            string espec = DR.IsDBNull(3) ? "" : DR.GetString(3);
                            string medid = DR.IsDBNull(1) ? "" : DR.GetString(1);
                            int cantPaq = DR.IsDBNull(0) ? 0 : DR.GetInt32(0);
                            int cantTablasPaq = DR.IsDBNull(2) ? 0 : DR.GetInt32(2);
                            int volumen = cantPaq * cantTablasPaq;
                            Grilla.Rows.Add(
                                DR.IsDBNull(3) ? string.Empty : espec,
                                DR.IsDBNull(1) ? string.Empty : medid,
                                DR.IsDBNull(0) ? (int?)null : cantPaq,
                                DR.IsDBNull(2) ? (int?)null : cantTablasPaq,
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
        public void SumarCantidadPaquetes(string medida, string especie, int cantidad)
        {
            try
            {
                string sql = $"UPDATE MaderaDura SET [Cantidad Paquetes] = [Cantidad Paquetes] + {cantidad} WHERE Medida = '{medida}' AND Especie = '{especie}'";

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
        public void RestarCantidadPaquetes(string medida, string especie, int cantidad)
        {
            try
            {
                string sql = $"UPDATE MaderaDura SET [Cantidad Paquetes] = [Cantidad Paquetes] - {cantidad} WHERE Medida = '{medida}' AND Especie = '{especie}'";

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
            var range = worksheet.Range("A10:E11");

            worksheet.Cell("B9").Value = "Vigencia Hasta:";
            worksheet.Range("B9:D9").Merge();
            worksheet.Cell("A10").Value = "Listado Maderas Duras:";
            worksheet.Range("A10:E10").Merge();
            worksheet.Cell("A10").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("A11").Value = "Especie";
            worksheet.Cell("B11").Value = "Medida";
            worksheet.Cell("C11").Value = "Cant Paquetes";
            worksheet.Cell("D11").Value = "Cant. Tablas x Paquete";
            worksheet.Cell("E11").Value = "Cant. Tablas Totales";

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
                    string espec = DR.IsDBNull(3) ? "" : DR.GetString(3);
                    string medid = DR.IsDBNull(1) ? "" : DR.GetString(1);
                    int cantPaq = DR.IsDBNull(0) ? 0 : DR.GetInt32(0);
                    int cantTablasPaq = DR.IsDBNull(2) ? 0 : DR.GetInt32(2);
                    int volumen = cantPaq * cantTablasPaq;

                    worksheet.Cell("A" + rowNum).Value = espec;
                    worksheet.Cell("B" + rowNum).Value = medid;
                    worksheet.Cell("C" + rowNum).Value = cantPaq;
                    worksheet.Cell("D" + rowNum).Value = cantTablasPaq;
                    worksheet.Cell("E" + rowNum).Value = volumen;

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
            worksheet.Column("D").Width = 25;
            worksheet.Column("E").Width = 25;
        }
        public void GenerarReporteMaderaDura()
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("MaderaDura");
                    LlenarEncabezado(worksheet);
                    LlenarDatos(worksheet);
                    AplicarEstilos(worksheet);

                    workbook.SaveAs("StockMaderaDura.xlsx");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
