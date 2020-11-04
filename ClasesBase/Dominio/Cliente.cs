using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ClasesBase.Dominio
{
    public class Cliente : IDataErrorInfo
    {
        private int cli_DNI;
        private string cli_Nombre;
        private string cli_Apellido;
        private string cli_Telefono;
        private string cli_Email;
        private bool cli_Disponible;

        /// <summary>
        /// Constructor sin parametro
        /// </summary>
        public Cliente()
        {
        }

        /// <summary>
        /// Constructor con parametros para el alta
        /// </summary>
        /// <param name="cli_DNI"></param>
        /// <param name="cli_Nombre"></param>
        /// <param name="cli_Apellido"></param>
        /// <param name="cli_Telefono"></param>
        /// <param name="cli_Email"></param>
        public Cliente(int cli_DNI, string cli_Nombre, string cli_Apellido, string cli_Telefono, string cli_Email)
        {
            this.cli_DNI = cli_DNI;
            this.cli_Nombre = cli_Nombre;
            this.cli_Apellido = cli_Apellido;
            this.cli_Telefono = cli_Telefono;
            this.cli_Email = cli_Email;
            this.cli_Disponible = true;
        }

        /// <summary>
        /// Constructor con parametros para modificacion
        /// </summary>
        /// <param name="cli_DNI"></param>
        /// <param name="cli_Nombre"></param>
        /// <param name="cli_Apellido"></param>
        /// <param name="cli_Telefono"></param>
        /// <param name="cli_Email"></param>
        /// <param name="cli_Disponible"></param>
        public Cliente(int cli_DNI, string cli_Nombre, string cli_Apellido, string cli_Telefono, string cli_Email, bool cli_Disponible)
        {
            this.cli_DNI = cli_DNI;
            this.cli_Nombre = cli_Nombre;
            this.cli_Apellido = cli_Apellido;
            this.cli_Telefono = cli_Telefono;
            this.cli_Email = cli_Email;
            this.cli_Disponible = cli_Disponible;
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
                    case "CliDNI":
                        msg_error = validar_Dni();
                        break;
                    case "CliApellido":
                        msg_error = validar_Apellido();
                        break;
                    case "CliNombre":
                        msg_error = validar_Nombre();
                        break;
                    case "CliTelefono":
                        msg_error = validar_Telefono();
                        break;
                }
                return msg_error;
            }
        }

        private string validarTelefono()
        {
            if (String.IsNullOrEmpty(Cli_Telefono))
            {
                return "El valor del campo es obligatorio";
            }
            return null;
        }

        private string validarNombre()
        {
            if (String.IsNullOrEmpty(Cli_Nombre))
            {
                return "El valor del campo es obligatorio";
            }
            return null;
        }

        private string validarApellido()
        {
            if (String.IsNullOrEmpty(Cli_Apellido))
            {
                return "El valor del campo es obligatorio";
            }
            return null;
        }

        private string validarDni()
        {
            if (String.IsNullOrEmpty(Cli_DNI.ToString()))
            {
                return "El valor del campo es obligatorio";
            }
            else if (Cli_DNI < 10000000)
            {
                return "El DNI debe ser de 8 digitos";
            }
            else if (Cli_DNI > 1000000)
            {
                return "El DNI no debe superar los 8 digitos";
            }
            return null;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Cli_DNI { get => cli_DNI; set => cli_DNI = value; }
        public string Cli_Nombre { get => cli_Nombre; set => cli_Nombre = value; }
        public string Cli_Apellido { get => cli_Apellido; set => cli_Apellido = value; }
        public string Cli_Telefono { get => cli_Telefono; set => cli_Telefono = value; }
        public string Cli_Email { get => cli_Email; set => cli_Email = value; }
        public bool Cli_Disponible { get => cli_Disponible; set => cli_Disponible = value; }
    }
}
