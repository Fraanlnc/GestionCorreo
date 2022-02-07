using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPieza : BEEntidad
    {
        #region "Constructores"
        public BEPieza() { }

        //Constructor sobrecargado
        public BEPieza(int pCodigo, string pDestinatario, string pDireccion, string pLocalidad, double pMontoaCobrar) 
        { Codigo = pCodigo; Destinatario = pDestinatario; Direccion = pDireccion; Localidad = pLocalidad; MontoaCobrar = pMontoaCobrar; }
        #endregion

        #region "Propiedades"
        // public int Codigo { get; set; }

        public string Destinatario { get; set; }

        public string Direccion { get; set; }

        public string Localidad { get; set; }

        public double MontoaCobrar { get; set; }

        public DateTime? FechaEntrega { get; set; }
        public string Estado { get; set; }

        public string Anomalia { get; set; }

        public BERuta Ruta { get; set; }
        #endregion

        #region "Metodos"
        public override string ToString()
        {
            return this.Codigo + " " + this.Destinatario;
        }
        #endregion
    }
}
