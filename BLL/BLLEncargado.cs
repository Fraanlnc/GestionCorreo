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
    public class BLLEncargado : BLLEmpleado, IGestor<BEEncargado>
    {
        public BLLEncargado()
        {
            oMPPEnc = new MPPEncargado();
        }
        MPPEncargado oMPPEnc;

        public override int CalcularHorasCaminadas(BEEmpleado emp)
        {
            //El encargado no genera horas caminadas
            return 0;
        }
        public bool Baja(BEEncargado Objeto)
        {
            return oMPPEnc.Baja(Objeto);
        }

        public bool Guardar(BEEncargado Objeto)
        {
            return oMPPEnc.Guardar(Objeto);
        }

        public BEEncargado ListarObjeto(BEEncargado Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEEncargado> ListarTodo()
        {
            return oMPPEnc.ListarTodo();
        }
    }
}
