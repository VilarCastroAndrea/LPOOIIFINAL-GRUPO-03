using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    class TrabajarSala
    {

        /// <summary>
        /// Alta Sala con stored procedure
        /// </summary>
        /// <param name="sala"></param>
        public static void altaSala(Sala sala)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaSala";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@descripcion", sala.Sla_Descripcion);
            cmd.Parameters.AddWithValue("@disponible", true);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de sala logica con stored procedure
        /// </summary>
        /// <param name="numeroSala"></param>
        /// <param name="disponible"></param>
        public static void bajaSala(int numeroSala, bool disponible)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaSala";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@numeroSala", numeroSala);
            cmd.Parameters.AddWithValue("@disponible", disponible);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de Sala fisica con stored procedure
        /// </summary>
        /// <param name="numeroSala"></param>
        public static void bajaSalaFisica(int numeroSala)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaSalaFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@numeroSala", numeroSala);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        /// <summary>
        /// Modificar Sala con stored procedure
        /// </summary>
        /// <param name="sala"></param>
        public static void modificarSala(Sala sala)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarSala";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@numeroSala", sala.Sla_NroSala);
            cmd.Parameters.AddWithValue("@descripcion", sala.Sla_Descripcion);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// Busca sala por id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static Sala buscarSala(string numero)
        {
            Sala sala = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscarSala";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@numero", numero);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                sala = new Sala();
                sala.Sla_NroSala = (int)reader["Numero de Sala"];
                sala.Sla_Disponible = (bool)reader["Disponible"];
                sala.Sla_Descripcion = (string)reader["Descripcion"];
            }
            cnn.Close();
            return sala;
        }
        
        /// <summary>
        /// Lista todas las Salas
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Sala> traerSalas()
        {
            ObservableCollection<Sala> coleccionSalas = new ObservableCollection<Sala>();
            Sala sala = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarSalas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                sala = new Sala();
                sala.Sla_Descripcion = (string)reader["Descripcion"];
                sala.Sla_NroSala = (int)reader["Numero de Sala"];
                sala.Sla_Disponible = (bool)reader["Disponible"];
                coleccionSalas.Add(sala);
            }
            cnn.Close();
            return coleccionSalas;
        }

        /// <summary>
        /// Lista todos las Salas
        /// </summary>
        /// <returns></returns>
        public static DataTable listarSalas()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarSalas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Listar Salas disponibles
        /// </summary>
        /// <returns></returns>
        public static DataTable listarSalasDisponibles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarSalaDisponibles";
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
