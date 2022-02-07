using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BESucursal:BEEntidad
    {
        public BESucursal()
        {

        }

        #region "Propiedades"

        public string Nombre { get; set; }

        public string Direccion { get; set; }
        #endregion

        #region "Metodos"
        public override string ToString()
        {
            return this.Codigo + " " + this.Nombre;
            
        }
        #endregion
    }
}
