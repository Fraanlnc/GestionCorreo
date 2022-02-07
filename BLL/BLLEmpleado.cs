using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstraccion;
using MPP;

namespace BLL
{
    public abstract class BLLEmpleado
    {
        public BLLEmpleado()
        {
        }

        public abstract int CalcularHorasCaminadas(BEEmpleado empleado);
        
    }
}
