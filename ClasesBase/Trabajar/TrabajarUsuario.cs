using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using ClasesBase.Dominio;

namespace ClasesBase
{
    public class TrabajarUsuario
    {
        /// <summary>
        /// Alta usuario con stored procedure
        /// </summary>
        /// <param name="usuario"></param>
        public static void altaUsuario(Usuario usuario)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "altaUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@nombreUsuario", usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@password", usuario.Usu_Password);
            cmd.Parameters.AddWithValue("@apellidoNombre", usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@codigo", usuario.Rol_Codigo);
            cmd.Parameters.AddWithValue("@disponible", true);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Baja de usuario fisica con stored procedure
        /// </summary>
        /// <param name="usuarioId"></param>
        public static void bajaUsuarioFisica(int usuarioId)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "bajaUsuarioFisica";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@usuarioId", usuarioId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Modificar usuario con stored procedure
        /// </summary>
        /// <param name="usuario"></param>
        public static void modificarUsuario(Usuario usuario)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "modificarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", usuario.Usu_Id);
            cmd.Parameters.AddWithValue("@nombreUsuario", usuario.Usu_NombreUsuario);
            cmd.Parameters.AddWithValue("@password", usuario.Usu_Password);
            cmd.Parameters.AddWithValue("@apellidoNombre", usuario.Usu_ApellidoNombre);
            cmd.Parameters.AddWithValue("@codigoRol", usuario.Rol_Codigo);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        /// <summary>
        /// Buscar Usuario por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Usuario buscarUsuario(string id)
        {
            Usuario usuario = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "buscarUsuario";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new Usuario();
                usuario.Rol_Codigo = (int)reader["Codigo"];
                usuario.Usu_Disponible = (bool)reader["Disponible"];
                usuario.Usu_ApellidoNombre = (string)reader["Apellido y Nombre"];
                usuario.Usu_Id = (int)reader["ID"];
                usuario.Usu_NombreUsuario = (string)reader["Nombre de Usuario"];
                usuario.Usu_Password = (string)reader["Password"];
            }
            cnn.Close();
            return usuario;
        }

        /// <summary>
        /// Coleccion de Usuarios
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Usuario> traerUsuarios()
        {
            ObservableCollection<Usuario> coleccionUsuarios = new ObservableCollection<Usuario>();
            Usuario usuario = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarUsuarios";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new Usuario();
                usuario.Usu_Id = (int)reader["ID"];
                usuario.Usu_ApellidoNombre = (string)reader["Apellido y Nombre"];
                usuario.Usu_NombreUsuario = (string)reader["Nombre de Usuario"];
                usuario.Usu_Password = (string)reader["Password"];
                usuario.Rol_Codigo = (int)reader["Codigo"];
                usuario.Usu_Disponible = (bool)reader["Disponible"];

                coleccionUsuarios.Add(usuario);
            }
            cnn.Close();
            return coleccionUsuarios;
        }

        /// <summary>
        /// Coleccion de Usuario Disponible 
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Usuario> traerUsuarioDisponible()
        {
            ObservableCollection<Usuario> coleccionUsuarios = new ObservableCollection<Usuario>();
            Usuario usuario = null;

            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);
            cnn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "listarUsuarioDisponible";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@disponible", true);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario = new Usuario();
                usuario.Usu_Id = (int)reader["ID"];
                usuario.Usu_ApellidoNombre = (string)reader["Apellido y Nombre"];
                usuario.Usu_NombreUsuario = (string)reader["Nombre de Usuario"];
                usuario.Usu_Password = (string)reader["Password"];
                usuario.Rol_Codigo = (int)reader["Codigo"];
                usuario.Usu_Disponible = (bool)reader["Disponible"];

                coleccionUsuarios.Add(usuario);
            }
            cnn.Close();
            return coleccionUsuarios;
        }

        /// <summary>
        /// Inicializa un objeto del tipo usuario para las validaciones del formulario
        /// </summary>
        /// <returns></returns>
        public Usuario IniciarUsuario()
        {
            return new Usuario();
        }

        public static bool validarUsuario(string usuario, string contra)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.cinesConnectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT *FROM Usuario WHERE USU_nombreUsuario=@usu AND USU_password=@contra";
            cmd.Parameters.AddWithValue("@usu", usuario);
            cmd.Parameters.AddWithValue("@contra", contra);


            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            cnn.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {

                while (reader.Read())
                {   //almacena los datos en una clase para mantener la sesion

                    UsuarioLogin.usu_Id = reader.GetInt32(0);
                    UsuarioLogin.usu_NombreUsuario = reader.GetString(1);
                    UsuarioLogin.usu_Password = reader.GetString(2);
                    UsuarioLogin.usu_ApellidoNombre = reader.GetString(3);
                    UsuarioLogin.rol_Codigo = reader.GetInt32(4);
                }
                cnn.Close();
                return true;
            }
            else
            {
                cnn.Close();
                return false;
            }
        }
    }
}
