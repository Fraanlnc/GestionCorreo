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
    public class BLLSucursal : IGestor<BESucursal>
    {
        public BLLSucursal() 
        {
            oMPPSuc = new MPPSucursal();
        }
        MPPSucursal oMPPSuc;
        public bool Baja(BESucursal Objeto)
        {
            return oMPPSuc.Baja(Objeto);
        }

        public bool Guardar(BESucursal Objeto)
        {
            return oMPPSuc.Guardar(Objeto);
        }

        public BESucursal ListarObjeto(BESucursal Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BESucursal> ListarTodo()
        {
            return oMPPSuc.ListarTodo();
        }
    }
}
