using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace ClasesBase.Dominio
{
    public class Proyeccion : IDataErrorInfo
    {
        private int proy_Codigo;
        private string proy_Fecha;
        private string proy_Hora;
        private int sla_NroSala;
        private int peli_Codigo;
        private bool proy_Disponible;

        /// <summary>
        /// Constructor sin parametro
        /// </summary>
        public Proyeccion()
        {
        }

        /// <summary>
        /// Constructor con parametros para el alta
        /// </summary>
        /// <param name="proy_Codigo"></param>
        /// <param name="proy_Fecha"></param>
        /// <param name="proy_Hora"></param>
        /// <param name="sla_NroSala"></param>
        /// <param name="peli_Codigo"></param>
        public Proyeccion(int proy_Codigo, string proy_Fecha, string proy_Hora, int sla_NroSala, int peli_Codigo)
        {
            this.proy_Codigo = proy_Codigo;
            this.proy_Fecha = proy_Fecha;
            this.proy_Hora = proy_Hora;
            this.sla_NroSala = sla_NroSala;
            this.peli_Codigo = peli_Codigo;
            this.proy_Disponible = true;
        }

        /// <summary>
        /// Constructor con parametros para modificacion
        /// </summary>
        /// <param name="proy_Codigo"></param>
        /// <param name="proy_Fecha"></param>
        /// <param name="proy_Hora"></param>
        /// <param name="sla_NroSala"></param>
        /// <param name="peli_Codigo"></param>
        /// <param name="proy_Disponible"></param>
        public Proyeccion(int proy_Codigo, string proy_Fecha, string proy_Hora, int sla_NroSala, int peli_Codigo, bool proy_Disponible)
        {
            this.proy_Codigo = proy_Codigo;
            this.proy_Fecha = proy_Fecha;
            this.proy_Hora = proy_Hora;
            this.sla_NroSala = sla_NroSala;
            this.peli_Codigo = peli_Codigo;
            this.proy_Disponible = proy_Disponible;
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
                    case "Proy_Fecha":
                        msg_error = validar_Fecha();
                        break;
                    case "Proy_Hora":
                        msg_error = validar_Hora();
                        break;
                    case "Peli_Codigo":
                        msg_error = validar_PeliCodigo();
                        break;
                }
                return msg_error;
            }
        }

        private string validar_PeliCodigo()
        {
            if (Peli_Codigo < 0)
            {
                return "Debe seleccionar un TITULO";
            }
            return null;
        }
        
        private string validar_Hora()
        {
            if (string.IsNullOrEmpty(Proy_Hora))
            {
                return "Debe Ingresar la HORA de la proyeccion.";
            }
            return null;
        }
        
        private string validar_Fecha()
        {
            if (string.IsNullOrEmpty(Proy_Fecha))
            {
                return "Debe Ingresar la FECHA de la proyeccion.";
            }
            return null;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Proy_Codigo { get => proy_Codigo; set => proy_Codigo = value; }
        public string Proy_Fecha { get => proy_Fecha; set => proy_Fecha = value; }
        public string Proy_Hora { get => proy_Hora; set => proy_Hora = value; }
        public int Sla_NroSala { get => sla_NroSala; set => sla_NroSala = value; }
        public int Peli_Codigo { get => peli_Codigo; set => peli_Codigo = value; }
        public bool Proy_Disponible { get => proy_Disponible; set => proy_Disponible = value; }
    }
}
