using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
namespace BE
{
    public class BESancion: BEEntidad
    {

        public BESancion()
        {

        }
        //Constructor sobrecargado, sin pasar Distribuidor para XML
        public BESancion(int pCodigo, string pDescripcion, int pDias, DateTime pFecha)
        {
            Codigo = pCodigo;
            Descipcion = pDescripcion;
            Dias_de_Suspension = pDias;
            Fecha_Suspension = pFecha;
         
            
        }

        
      


        public string Descipcion { get; set; }

        public int Dias_de_Suspension { get; set; }

        public DateTime Fecha_Suspension { get; set; }

        public BEDistribuidor Distribuidor { get; set; }
    }
}
