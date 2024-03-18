using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStock
{
    internal class clsMachimbre
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ControlStockDB.mdb";
        private string Tabla = "Machimbre";

        public Int32 NumeroPaquete;
        public Int32 CantidadPaquetes;
        public String Medida;
        public Int32 CantidadTablasPaquete;
        public String Calidad;

        public DataTable ObtenerMedidasMachimbre()
        {
            DataTable medidas = new DataTable();
            try
            {
                string sql = "SELECT DISTINCT Medida FROM Machimbre";
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
                MessageBox.Show("Error al obtener las medidas de los machimbres: " + e.Message);
            }
            return medidas;
        }
        public void AgregarNuevoMachimbre()
        {
            try
            {
                string sql = "INSERT INTO Machimbre ([Número Paquete], [Cantidad Paquetes], Medida, [Cantidad de Tablas por Paquete], Calidad) " +
                             "VALUES (@NumeroPaquete, @CantidadPaquetes, @Medida, @CantidadTablasPaquete, @Calidad)";

                using (OleDbConnection connection = new OleDbConnection(CadenaConexion))
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@NumeroPaquete", NumeroPaquete);
                    cmd.Parameters.AddWithValue("@CantidadPaquetes", CantidadPaquetes);
                    cmd.Parameters.AddWithValue("@Medida", Medida);
                    cmd.Parameters.AddWithValue("@CantidadTablasPaquete", CantidadTablasPaquete);
                    cmd.Parameters.AddWithValue("@Calidad", Calidad);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al agregar nuevo machimbre: " + e.Message);
            }
        }
        public void ListarMachimbre(DataGridView Grilla)
        {
            try
            {
                string sql = "SELECT * FROM Machimbre Dura";
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
                            Grilla.Rows.Add(
                                DR.IsDBNull(4) ? string.Empty : DR.GetString(4),
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
                string sql = $"UPDATE Machimbre SET [Cantidad Paquetes] = [Cantidad Paquetes] + {cantidad} WHERE Medida = '{medida}'";

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
                string sql = $"UPDATE Machimbre SET [Cantidad Paquetes] = [Cantidad Paquetes] - {cantidad} WHERE Medida = '{medida}'";

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
