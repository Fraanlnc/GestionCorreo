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
    public class BLLPieza : IGestor<BEPieza>
    {
        public BLLPieza()
        {
            oMPPPieza = new MPPPieza();
        }
        MPPPieza oMPPPieza;
        public bool Baja(BEPieza Objeto)
        {
            return oMPPPieza.Baja(Objeto);
        }

        public bool Guardar(BEPieza Objeto)
        {
            return oMPPPieza.Guardar(Objeto);
        }

        public BEPieza ListarObjeto(BEPieza Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEPieza> ListarTodo()
        {
            return oMPPPieza.ListarTodo();
        }
    }
}
