using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
namespace ClasesBase
{
    public class TrabajarProyeccion
    {
        /// <summary>
        /// Alta Proyeccion con stored procedure
        /// </summary>
        /// <param name="proyeccion"></param>
        public static void altaProyeccion(Proyeccion proyeccion)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaProyeccion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@fecha", proyeccion.Proy_Fecha);
            cmd.Parameters.AddWithValue("@hora", proyeccion.Proy_Hora);
            cmd.Parameters.AddWithValue("@sala", proyeccion.Sla_NroSala);
            cmd.Parameters.AddWithValue("@peliCodigo", proyeccion.Peli_Codigo);
            cmd.Parameters.AddWithValue("@disponible", true);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de proyeccion logica con stored procedure
        /// </summary>
        /// <param name="proyeccionCodigo"></param>
        /// <param name="disponible"></param>
        public static void bajaProyeccion(int proyeccionCodigo, bool disponible)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaProyeccion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@proyeccionCodigo", proyeccionCodigo);
            cmd.Parameters.AddWithValue("@disponible", disponible);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        
        /// <summary>
        /// Baja de proyeccion fisica con stored procedure
        /// </summary>
        /// <param name="proyeccionCodigo"></param>
        public static void bajaProyeccionFisica(int proyeccionCodigo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaProyeccionFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@proyeccionCodigo", proyeccionCodigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Modificar Proyeccion con stored procedure
        /// </summary>
        /// <param name="proyeccion"></param>
        public static void modificarProyeccion(Proyeccion proyeccion)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarProyeccion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@codigo", proyeccion.Proy_Codigo);
            cmd.Parameters.AddWithValue("@fecha", proyeccion.Proy_Fecha);
            cmd.Parameters.AddWithValue("@hora", proyeccion.Proy_Hora);
            cmd.Parameters.AddWithValue("@numeroSala", proyeccion.Sla_NroSala);
            cmd.Parameters.AddWithValue("@peliCodigo", proyeccion.Peli_Codigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Busca proyeccion por id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static Proyeccion buscarProyeccion(string codigo)
        {
            Proyeccion proyeccion = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscarProyeccion";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@codigo", codigo);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                proyeccion = new Proyeccion();
                proyeccion.Proy_Codigo = (int)reader["Codigo"];
                proyeccion.Proy_Disponible = (bool)reader["Disponible"];
                proyeccion.Proy_Fecha = (string)reader["Fecha"];
                proyeccion.Proy_Hora = (string)reader["Hora"];
                proyeccion.Sla_NroSala = (int)reader["Numero de Sala"];
                proyeccion.Peli_Codigo = (int)reader["Codigo de Pelicula"];
            }
            cnn.Close();
            return proyeccion;
        }

        /// <summary>
        /// Lista todas las proyecciones
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Proyeccion> traerProyecciones()
        {
            ObservableCollection<Proyeccion> coleccionProyecciones = new ObservableCollection<Proyeccion>();
            Proyeccion proyeccion = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarProyecciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                proyeccion = new Proyeccion();
                proyeccion.Proy_Codigo = (int)reader["Codigo"];
                proyeccion.Peli_Codigo = (int)reader["Codigo de Pelicula"];
                proyeccion.Proy_Fecha = (string)reader["Fecha"];
                proyeccion.Proy_Hora = (string)reader["Hora"];
                proyeccion.Sla_NroSala = (int)reader["Numero de Sala"];
                coleccionProyecciones.Add(proyeccion);
            }
            cnn.Close();
            return coleccionProyecciones;
        }

        /// <summary>
        /// Lista todas las proyecciones
        /// </summary>
        /// <returns></returns>
        public static DataTable listarProyecciones()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarProyecciones";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        
        /// <summary>
        /// Listar Proyecciones disponibles
        /// </summary>
        /// <returns></returns>
        public static DataTable listarProyeccionesDisponibles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarProyeccionDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Inicializa un objeto proyeccion para la validacion del formulario.
        /// </summary>
        /// <returns></returns>
        public Proyeccion iniciarProyeccion()
        {
            Proyeccion pro = new Proyeccion();
            pro.Peli_Codigo = -1;
            return pro;
        }
    }
}