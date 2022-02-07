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
    public class BLLAuditor :BLLEmpleado, IGestor<BEAuditor>
    {
        public BLLAuditor()
        {
            oMPPAud = new MPPAuditor();
        }
        MPPAuditor oMPPAud;

        public override int CalcularHorasCaminadas(BEEmpleado empleado)
        { 
            //Devuelvo un valor ficticio de horas caminadas por el auditor, sumando su legajo + 4
            return empleado.Codigo + 4;
        }

        public bool Baja(BEAuditor Objeto)
        {
            return oMPPAud.Baja(Objeto);
        }

        public bool Guardar(BEAuditor Objeto)
        {
            return oMPPAud.Guardar(Objeto);
        }

        public BEAuditor ListarObjeto(BEAuditor Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEAuditor> ListarTodo()
        {
            return oMPPAud.ListarTodo();
        }

       
    }
}
