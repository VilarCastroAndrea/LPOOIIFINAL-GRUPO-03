using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase.Dominio
{
    public class Rol
    {
        private int rol_Codigo;
        private string rol_Descripcion;
        private bool rol_Disponible;

        /// <summary>
        /// Constructor sin parametro
        /// </summary>
        public Rol()
        {
        }

        /// <summary>
        /// Constructor con parametros para el alta
        /// </summary>
        /// <param name="rol_Codigo"></param>
        /// <param name="rol_Descripcion"></param>
        public Rol(int rol_Codigo, string rol_Descripcion)
        {
            this.Rol_Codigo = rol_Codigo;
            this.Rol_Descripcion = rol_Descripcion;
            this.Rol_Disponible = true;
        }

        /// <summary>
        /// Constructor con parametros para modificacion
        /// </summary>
        /// <param name="rol_Codigo"></param>
        /// <param name="rol_Descripcion"></param>
        /// <param name="rol_Disponible"></param>
        public Rol(int rol_Codigo, string rol_Descripcion, bool rol_Disponible)
        {
            this.Rol_Codigo = rol_Codigo;
            this.Rol_Descripcion = rol_Descripcion;
            this.Rol_Disponible = rol_Disponible;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Rol_Codigo { get => rol_Codigo; set => rol_Codigo = value; }
        public string Rol_Descripcion { get => rol_Descripcion; set => rol_Descripcion = value; }
        public bool Rol_Disponible { get => rol_Disponible; set => rol_Disponible = value; }
    }
}
