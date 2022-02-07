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
    public class BLLRuta : IGestor<BERuta>
    {
        public BLLRuta()
        {
            oMPPRuta = new MPPRuta();
        }
        MPPRuta oMPPRuta;
        public bool Baja(BERuta Objeto)
        {
            return oMPPRuta.Baja(Objeto);
        }

        public bool Guardar(BERuta Objeto)
        {
            return oMPPRuta.Guardar(Objeto);
        }

        public BERuta ListarObjeto(BERuta Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BERuta> ListarTodo()
        {
            return oMPPRuta.ListarTodo();
        }
    }
}
