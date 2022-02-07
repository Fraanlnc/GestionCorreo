using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEDistribuidor:BEEmpleado
    {
        #region "Constructores"
        public BEDistribuidor()
        {

        }
        //Constructor sobrecargado
        public BEDistribuidor(string pNombre, string pApellido, BESucursal pSucursal, int pTelefono)
        {
            
            Nombre = pNombre;
            Apellido = pApellido;
            Sucursal = pSucursal;
            Telefono = pTelefono;
        }
        #endregion

        #region "Propiedades"
       

        public int Telefono { get; set; }
        #endregion

        #region "Metodos"
        public override string ToString()
        {
            return this.Codigo + " " + this.Nombre + " " + this.Apellido;
        }
        #endregion
    }
}
