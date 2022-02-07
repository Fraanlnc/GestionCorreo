using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEEncargado : BEEmpleado
    {
        public BEEncargado()
        {

        }
        #region "Propiedades"


        public int Personal_a_Cargo { get; set; }
        #endregion
        #region "Metodos"
        public override string ToString()
        {
            return this.Codigo + " " + this.Nombre;
        }
        #endregion
    }
}
