using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ClasesBase.Dominio
{
    public class Pelicula : IDataErrorInfo
    {
        private int peli_Codigo;
        private string peli_Titulo;
        private string peli_Duracion;
        private string peli_Genero;
        private string peli_Clasificacion;
        private string peli_Imagen;
        private string peli_Avence;
        private bool peli_Disponible;

        /// <summary>
        /// Constructor sin parametro
        /// </summary>
        public Pelicula()
        {
        }

        /// <summary>
        /// Constructor con parametros para el alta
        /// </summary>
        /// <param name="peli_Codigo"></param>
        /// <param name="peli_Titulo"></param>
        /// <param name="peli_Duracion"></param>
        /// <param name="peli_genero"></param>
        /// <param name="peli_clasificacion"></param>
        public Pelicula(int peli_Codigo, string peli_Titulo, string peli_Duracion, string peli_genero, string peli_clasificacion)
        {
            this.peli_Codigo = peli_Codigo;
            this.peli_Titulo = peli_Titulo;
            this.peli_Duracion = peli_Duracion;
            this.Peli_Genero = peli_genero;
            this.Peli_Clasificacion = peli_clasificacion;
            this.peli_Disponible = true;
        }

        /// <summary>
        /// Constructor con parametros para modificacion
        /// </summary>
        /// <param name="peli_Codigo"></param>
        /// <param name="peli_Titulo"></param>
        /// <param name="peli_Duracion"></param>
        /// <param name="peli_genero"></param>
        /// <param name="peli_clasificacion"></param>
        /// <param name="peli_Disponible"></param>
        public Pelicula(int peli_Codigo, string peli_Titulo, string peli_Duracion, string peli_genero, string peli_clasificacion, bool peli_Disponible)
        {
            this.peli_Codigo = peli_Codigo;
            this.peli_Titulo = peli_Titulo;
            this.peli_Duracion = peli_Duracion;
            this.Peli_Genero = peli_genero;
            this.Peli_Clasificacion = peli_clasificacion;
            this.peli_Disponible = peli_Disponible;
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
                    case "Peli_Titulo":
                        msg_error = validarTitulo();
                        break;
                    case "Peli_Duracion":
                        msg_error = validarDuracion();
                        break;
                    case "Peli_Imagen":
                        msg_error = validarImagen();
                        break;
                    case "Peli_Avance":
                        msg_error = validarImagen();
                        break;
                }
                return msg_error;
            }
        }

        private string validarTitulo()
        {
            if (string.IsNullOrEmpty(Peli_Titulo))
            {
                return "El TITULO es obligatorio.";
            }
            return null;
        }

        private string validarDuracion()
        {
            if (string.IsNullOrEmpty(Peli_Duracion))
            {
                return "La DURACION es obligatoria.";
            }
            return null;
        }

        private string validarImagen()
        {
            if (string.IsNullOrEmpty(Peli_Imagen))
            {
                return "La IMAGEN es obligatoria.";
            }
            return null;
        }

        private string validarAvance()
        {
            if (string.IsNullOrEmpty(Peli_Imagen))
            {
                return "La AVANCE es obligatoria.";
            }
            return null;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Peli_Codigo { get => peli_Codigo; set => peli_Codigo = value; }
        public string Peli_Titulo { get => peli_Titulo; set => peli_Titulo = value; }
        public string Peli_Duracion { get => peli_Duracion; set => peli_Duracion = value; }
        public string Peli_Genero { get => peli_Genero; set => peli_Genero = value; }
        public string Peli_Clasificacion { get => peli_Clasificacion; set => peli_Clasificacion = value; }
        public string Peli_Imagen { get => peli_Imagen; set => peli_Imagen = value; }
        public string Peli_Avence { get => peli_Avence; set => peli_Avence = value; }
        public bool Peli_Disponible { get => peli_Disponible; set => peli_Disponible = value; }
    }
}
