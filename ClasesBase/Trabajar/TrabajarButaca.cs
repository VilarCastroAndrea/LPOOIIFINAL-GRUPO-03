using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using ClasesBase.Dominio;

namespace ClasesBase.Trabajar
{
    public class TrabajarButaca
    {
        /// <summary>
        /// Alta butaca con stored procedure
        /// </summary>
        /// <param name="butaca"></param>
        public static void altaButaca(Butaca butaca)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaButaca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@fila", butaca.But_Fila);
            cmd.Parameters.AddWithValue("@numero", butaca.But_Nro);
            cmd.Parameters.AddWithValue("@sala", butaca.Sla_NroSala);
            cmd.Parameters.AddWithValue("@disponible", true);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de butaca logica con stored procedure
        /// </summary>
        /// <param name="butId"></param>
        /// <param name="disponible"></param>
        public static void bajaButaca(int butId, bool disponible)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaButaca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@butId", butId);
            cmd.Parameters.AddWithValue("@disponible", disponible);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de butaca fisica con stored procedure
        /// </summary>
        /// <param name="butId"></param>
        public static void bajaButacaFisica(int butId)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaButacaFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", butId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Modificar butaca con stored procedure
        /// </summary>
        /// <param name="butaca"></param>
        public static void modificarButaca(Butaca butaca)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarButaca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", butaca.But_Id);
            cmd.Parameters.AddWithValue("@fila", butaca.But_Fila);
            cmd.Parameters.AddWithValue("@numero", butaca.But_Nro);
            cmd.Parameters.AddWithValue("@numeroSala", butaca.Sla_NroSala);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Buscar Butaca
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Butaca buscarButaca(string id)
        {
            Butaca butaca = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscarButaca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                butaca = new Butaca();
                butaca.But_Id = (int)reader["ID"];
                butaca.But_Disponible = (bool)reader["Disponible"];
                butaca.But_Fila = (string)reader["Fila"];
                butaca.But_Nro = (int)reader["Numero"];
            }
            cnn.Close();
            return butaca;
        }

        /// <summary>
        /// Coleccion de butacas
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Butaca> traerButacas()
        {
            ObservableCollection<Butaca> coleccionButacas = new ObservableCollection<Butaca>();
            Butaca butaca = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarButacas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                butaca = new Butaca();
                butaca.But_Fila = (string)reader["Fila"];
                butaca.But_Id = (int)reader["ID"];
                butaca.But_Nro = (int)reader["Numero"];
                butaca.But_Disponible = (bool)reader["Disponible"];
                butaca.Sla_NroSala = (int)reader["Numero de Sala"];
                coleccionButacas.Add(butaca);
            }
            cnn.Close();
            return coleccionButacas;
        }

        /// <summary>
        /// Listar butacas disponibles
        /// </summary>
        /// <returns></returns>
        public static DataTable listarButacasDisponibles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarButacaDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
