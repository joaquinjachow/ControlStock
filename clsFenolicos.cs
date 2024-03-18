using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

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
                            Grilla.Rows.Add(
                                DR.IsDBNull(0) ? string.Empty : DR.GetString(0),
                                DR.IsDBNull(1) ? string.Empty : DR.GetString(1),
                                DR.IsDBNull(2) ? (int?)null : DR.GetInt32(2),
                                DR.IsDBNull(3) ? (int?)null : DR.GetInt32(3)
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
        public void SumarCantidadHojas(string calidad, int cantidad)
        {
            try
            {
                string sql = $"UPDATE Fenólicos SET [Cantidad de Hojas Totales] = [Cantidad de Hojas Totales] + {cantidad} WHERE Calidad = '{calidad}'";

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
        public void RestarCantidadHojas(string calidad, int cantidad)
        {
            try
            {
                string sql = $"UPDATE Fenólicos SET [Cantidad de Hojas Totales] = [Cantidad de Hojas Totales] - {cantidad} WHERE Calidad = '{calidad}'";

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

    }
}
