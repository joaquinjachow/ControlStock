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
    internal class clsMaderaDura
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ControlStockDB.mdb";

        public Int32 NumeroPaquete;
        public Int32 CantidadPaquetes;
        public String Medida;
        public Int32 CantidadTablasPaquete;
        public String Especie;

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
                string sql = "INSERT INTO MaderaDura ([Número Paquete], [Cantidad Paquetes], Medida, [Cantidad de Tablas por Paquete], Especie) " +
                             "VALUES (@NumeroPaquete, @CantidadPaquetes, @Medida, @CantidadTablasPaquete, @Especie)";

                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@NumeroPaquete", NumeroPaquete);
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
                            int campo1 = DR.IsDBNull(0) ? 0 : DR.GetInt32(1);
                            int campo4 = DR.IsDBNull(3) ? 0 : DR.GetInt32(3);
                            int volumen = campo1 * campo4;
                            string campo5 = DR.IsDBNull(4) ? string.Empty : DR.GetString(4);
                            Grilla.Rows.Add(
                                campo5,
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
                string sql = $"UPDATE MaderaDura SET [Cantidad Paquetes] = [Cantidad Paquetes] + {cantidad} WHERE Medida = '{medida}'";

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
                string sql = $"UPDATE MaderaDura SET [Cantidad Paquetes] = [Cantidad Paquetes] - {cantidad} WHERE Medida = '{medida}'";

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

    }
}
