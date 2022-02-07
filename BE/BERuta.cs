using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BERuta : BEEntidad
    {

        public BERuta() { }

        #region "Propiedades"

        public DateTime FechaCreacion { get; set; }

        //fecha asignacion y fecha entrega pueden tener valores nulos al darlos de alta
        public DateTime? FechaAsignacion { get; set; }

        public DateTime? FechaEntrega { get; set; }
        public int Cantidad { get; set; }

        //1 a muchos: La ruta necesita de piezas cargadas para ser asignada y sacada a calle.
        //Una ruta sin piezas no tiene sentido
        public List<BEPieza> Piezas { get; set; }

        //1 a 1 
        public BEDistribuidor Distribuidor { get; set; } 

        public string Estado { get; set; }
        #endregion

        #region "Metodos"
        public override string ToString()
        {
            return "Ruta: " + this.Codigo + " FechaCreacion: " + this.FechaCreacion.ToShortDateString();
        }
        #endregion
    }
}
