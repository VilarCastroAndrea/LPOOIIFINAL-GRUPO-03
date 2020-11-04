using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;


namespace ClasesBase
{
    public class TrabajarRol
    {
        /// <summary>
        /// Alta Rol con stored procedure
        /// </summary>
        /// <param name="rol"></param>
        public static void altaRol(Rol rol)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaRol";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@descripcion", rol.Rol_Descripcion);
            cmd.Parameters.AddWithValue("@disponible", true);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de rol logica con stored procedure
        /// </summary>
        /// <param name="codigoRol"></param>
        /// <param name="disponible"></param>
        public static void bajaRol(int codigoRol, bool disponible)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaRol";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@codigoRol", codigoRol);
            cmd.Parameters.AddWithValue("@disponible", disponible);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        
        /// <summary>
        /// Baja de rol fisica con stored procedure
        /// </summary>
        /// <param name="codigoRol"></param>
        public static void bajaRolFisica(int codigoRol)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaRolFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@rolCodigo", codigoRol);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        /// <summary>
        /// Modificar Rol con stored procedure
        /// </summary>
        /// <param name="rol"></param>
        public static void modificarRol(Rol rol)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarButaca";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@codigo", rol.Rol_Codigo);
            cmd.Parameters.AddWithValue("@descripcion", rol.Rol_Descripcion);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// Busca rol por id
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static Rol buscarRol(string codigo)
        {
            Rol rol = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscarRol";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@codigo", codigo);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                rol = new Rol();
                rol.Rol_Codigo = (int)reader["Codigo"];
                rol.Rol_Disponible = (bool)reader["Disponible"];
                rol.Rol_Descripcion = (string)reader["Descripcion"];
            }
            cnn.Close();
            return rol;
        }

        /// <summary>
        /// Lista todos los roles
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Rol> listarRoles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarRoles";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();

            Rol rol = null;
            ObservableCollection<Rol> listaRoles = new ObservableCollection<Rol>();

            while (reader.Read())
            {
                rol = new Rol();
                rol.Rol_Codigo = (int)reader["Codigo"];
                rol.Rol_Descripcion = (string)reader["Descripcion"];

                listaRoles.Add(rol);
            }
            cnn.Close();
            return listaRoles;
        }

        /// <summary>
        /// Listar Roles disponibles
        /// </summary>
        /// <returns></returns>
        public static DataTable listarRolesDisponibles()
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarRolDisponnible";
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