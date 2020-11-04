using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace ClasesBase
{
    public class TrabajarPelicula
    {
        /// <summary>
        /// Alta pelicula con stored procedure
        /// </summary>
        /// <param name="cliente"></param>
        public static void altaPelicula(Pelicula pelicula)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaPelicula";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@titulo", pelicula.Peli_Titulo);
            cmd.Parameters.AddWithValue("@duracion", pelicula.Peli_Duracion);
            cmd.Parameters.AddWithValue("@genero", pelicula.Peli_Genero);
            cmd.Parameters.AddWithValue("@clasificacion", pelicula.Peli_Clasificacion);
            cmd.Parameters.AddWithValue("@disponible", pelicula.Peli_Disponible);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de pelicula con stored procedure
        /// </summary>
        /// <param name="codigoPelicula"></param>
        /// <param name="disponible"></param>
        public static void bajaPelicula(int codigoPelicula, bool disponible)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaPelicula";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@codigoPelicula", codigoPelicula);
            cmd.Parameters.AddWithValue("@disponible", disponible);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de pelicula fisica con stored procedure
        /// </summary>
        /// <param name="codigoPelicula"></param>
        /// <param name="dis"></param>
        public static void bajaPeliculaFisica(int codigoPelicula)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaPeliculaFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@codigoPelicula", codigoPelicula);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Modificar pelicula con stored procedure
        /// </summary>
        /// <param name="pelicula"></param>
        public static void modificarPelicula(Pelicula pelicula)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarPelicula";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@titulo", pelicula.Peli_Titulo);
            cmd.Parameters.AddWithValue("@duracion", pelicula.Peli_Duracion);
            cmd.Parameters.AddWithValue("@genero", pelicula.Peli_Genero);
            cmd.Parameters.AddWithValue("@clasificacion", pelicula.Peli_Clasificacion);
            cmd.Parameters.AddWithValue("@codigoPelicula", pelicula.Peli_Codigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        
        /// <summary>
        /// Busca Pelicula por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Pelicula buscarPelicula(string id)
        {
            Pelicula pelicula = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscarPelicula";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                pelicula = new Pelicula();
                pelicula.Peli_Clasificacion = (string)reader["Clasificacion"];
                pelicula.Peli_Codigo = (int)reader["Codigo"];
                pelicula.Peli_Disponible = (bool)reader["Disponible"];
                pelicula.Peli_Duracion = (string)reader["Duracion"];
                pelicula.Peli_Genero = (string)reader["Genero"];
                pelicula.Peli_Titulo = (string)reader["Titulo"];
            }
            cnn.Close();
            return pelicula;
        }
        
        /// <summary>
        /// Busca pelicula por titulo y clasificacion no borrado
        /// </summary>
        /// <param name="sPattern"></param>
        /// <returns></returns>
        public static DataTable buscarPeliculaDisponible(string sPattern)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscarPeliculaDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            cmd.Parameters.AddWithValue("@titulo", "%" + sPattern + "%");
            cmd.Parameters.AddWithValue("@clasificacion", "%" + sPattern + "%");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Lista todas las peliculas
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Pelicula> traerPeliculas()
        {
            ObservableCollection<Pelicula> coleccionDePeliculas = new ObservableCollection<Pelicula>();
            Pelicula pelicula = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ListarPeliculas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                pelicula = new Pelicula();
                pelicula.Peli_Clasificacion = (string)reader["Clasificacion"];
                pelicula.Peli_Codigo = (int)reader["Codigo"];
                pelicula.Peli_Disponible = (bool)reader["Disponible"];
                pelicula.Peli_Duracion = (string)reader["Duracion"];
                pelicula.Peli_Genero = (string)reader["Genero"];
                pelicula.Peli_Titulo = (string)reader["Titulo"];
                coleccionDePeliculas.Add(pelicula);
            }
            cnn.Close();
            return coleccionDePeliculas;
        }

        /// <summary>
        /// Lista todas las peliculas
        /// </summary>
        /// <returns></returns>
        public static DataTable listaPelicula()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ListarPeliculas";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Listar peliculas disponibles
        /// </summary>
        /// <returns></returns>
        public static DataTable listaPeliculaDisponible()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarPeliculaDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
               
        /// <summary>
        /// Inicializa un objeto pelicula para mostrarlo en la vista
        /// </summary>
        /// <returns></returns>
        public Pelicula iniciarPelicula()
        {
            return new Pelicula();
        }
    }
}
