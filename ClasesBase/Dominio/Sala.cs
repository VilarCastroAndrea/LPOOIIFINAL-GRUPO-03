using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesBase.Dominio
{
    public class Sala
    {
        private int sla_NroSala;
        private string sla_Descripcion;
        private int sla_Capacidad;
        private bool sla_Disponible;

        /// <summary>
        /// Constructor sin parametro
        /// </summary>
        public Sala()
        {
        }

        /// <summary>
        /// Constructor con parametros para el alta
        /// </summary>
        /// <param name="sla_NroSala"></param>
        /// <param name="sla_Descripcion"></param>
        /// <param name="sla_Capacidad"></param>
        public Sala(int sla_NroSala, string sla_Descripcion, int sla_Capacidad)
        {
            this.sla_NroSala = sla_NroSala;
            this.sla_Descripcion = sla_Descripcion;
            this.sla_Capacidad = sla_Capacidad;
            this.sla_Disponible = true;
        }

        /// <summary>
        /// Constructor con parametros para modificacion
        /// </summary>
        /// <param name="sla_NroSala"></param>
        /// <param name="sla_Descripcion"></param>
        /// <param name="sla_Disponible"></param>
        /// <param name="sla_Capacidad"></param>
        public Sala(int sla_NroSala, string sla_Descripcion, bool sla_Disponible, int sla_Capacidad)
        {
            this.sla_NroSala = sla_NroSala;
            this.sla_Disponible = sla_Disponible;
            this.sla_Capacidad = sla_Capacidad;
        }

        /// <summary>
        /// Get & Set
        /// </summary>
        public int Sla_NroSala { get => sla_NroSala; set => sla_NroSala = value; }
        public string Sla_Descripcion { get => sla_Descripcion; set => sla_Descripcion = value; }
        public int Sla_Capacidad { get => sla_Capacidad; set => sla_Capacidad = value; }
        public bool Sla_Disponible { get => sla_Disponible; set => sla_Disponible = value; }
    }
}
