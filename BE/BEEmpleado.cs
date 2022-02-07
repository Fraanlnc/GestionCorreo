using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEEmpleado : BEEntidad
    {
        #region "Constructores"
        public BEEmpleado() { }

        #endregion
        #region "Propiedades"
       // public int Legajo { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }


        public BESucursal Sucursal { get; set; }

        #endregion


    }
}
