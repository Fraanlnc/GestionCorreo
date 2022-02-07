using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEAuditor:BEEmpleado
    {
        public BEAuditor()
        {

        }

        #region "Metodos"
        public override string ToString()
        {
            return this.Codigo + " " + this.Nombre;
        }
        #endregion
    }
}
