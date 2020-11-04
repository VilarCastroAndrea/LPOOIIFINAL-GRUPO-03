using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ClasesBase.Dominio
{
    public class Usuario : INotifyPropertyChanged, IDataErrorInfo
    {
        private int usu_Id;
        private string usu_NombreUsuario;
        private string usu_Password;
        private string usu_ApellidoNombre;
        private int rol_Codigo;
        private bool usu_Disponible;

        /// <summary>
        /// Constructor sin parametro
        /// </summary>
        public Usuario()
        {
        }

        /// <summary>
        /// Constructor con parametros para el alta
        /// </summary>
        /// <param name="usu_NombreUsuario"></param>
        /// <param name="usu_Password"></param>
        /// <param name="usu_ApellidoNombre"></param>
        /// <param name="rol_Codigo"></param>
        public Usuario(string usu_NombreUsuario, string usu_Password, string usu_ApellidoNombre, int rol_Codigo)
        {
            this.usu_NombreUsuario = usu_NombreUsuario;
            this.usu_Password = usu_Password;
            this.usu_ApellidoNombre = usu_ApellidoNombre;
            this.rol_Codigo = rol_Codigo;
            this.usu_Disponible = true;
        }

        /// <summary>
        /// Constructor con parametros para modificacion
        /// </summary>
        /// <param name="usu_NombreUsuario"></param>
        /// <param name="usu_Password"></param>
        /// <param name="usu_ApellidoNombre"></param>
        /// <param name="rol_Codigo"></param>
        /// <param name="usu_Disponible"></param>
        public Usuario(string usu_NombreUsuario, string usu_Password, string usu_ApellidoNombre, int rol_Codigo, bool usu_Disponible)
        {
            this.usu_NombreUsuario = usu_NombreUsuario;
            this.usu_Password = usu_Password;
            this.usu_ApellidoNombre = usu_ApellidoNombre;
            this.rol_Codigo = rol_Codigo;
            this.usu_Disponible = usu_Disponible;
        }

        /// <summary>
        /// Implementacion System.NotImplementedException()
        /// </summary>
        public string Error
        {
            get { throw new System.NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string msg_error = null;
                switch (columnName)
                {
                    case "Usu_NombreUsuario":
                        msg_error = validarNombreUsuario();
                        break;
                    case "Usu_Password":
                        msg_error = validarPassword();
                        break;
                    case "Usu_ApellidoNombre":
                        msg_error = validarApellidoNombre();
                        break;
                }
                return msg_error;
            }
        }

        private string validarApellidoNombre()
        {
            if (string.IsNullOrEmpty(usu_ApellidoNombre))
            {
                return "El APELLIDO Y NOMBRE es obligatorio.";
            }
            else if (usu_ApellidoNombre.Length > 50)
            {
                return "El Apellido y nombre no debe superar los 50 caracteres.";
            }
            return null;
        }

        private string validarPassword()
        {
            if (string.IsNullOrEmpty(usu_Password))
            {
                return "LA CONTRASEÑA es obligatoria.";
            }
            else if (usu_Password.Length > 50)
            {
                return "La CONTRASEÑA no debe superar los 50 caracteres.";
            }
            else if (usu_Password.Length < 5)
            {
                return "La CONTRASEÑA debe ser mayor a 5 caracteres.";
            }
            return null;
        }

        private string validarNombreUsuario()
        {
            if (string.IsNullOrEmpty(usu_NombreUsuario))
            {
                return "El NOMBRE DE USUARIO es obligatorio.";
            }
            else if (usu_NombreUsuario.Length > 50)
            {
                return "El NOMBRE DE USUARIO no debe superar los 50 caracteres.";
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Usu_Id { get => usu_Id; set => usu_Id = value; }
        public string Usu_NombreUsuario { get => usu_NombreUsuario; set => usu_NombreUsuario = value; }
        public string Usu_Password { get => usu_Password; set => usu_Password = value; }
        public string Usu_ApellidoNombre { get => usu_ApellidoNombre; set => usu_ApellidoNombre = value; }
        public int Rol_Codigo { get => rol_Codigo; set => rol_Codigo = value; }
        public bool Usu_Disponible { get => usu_Disponible; set => usu_Disponible = value; }
    }

}
