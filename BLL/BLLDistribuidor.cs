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
    public class BLLDistribuidor : BLLEmpleado, IGestor<BEDistribuidor>
    {
        public BLLDistribuidor()
        {
            oMPPDis = new MPPDistribuidor();
        }
        MPPDistribuidor oMPPDis;

        public override int CalcularHorasCaminadas(BEEmpleado emp)
        {
            //Se calcula que el distribuidor camina aprox 8 horas por ruta
            List<BERuta> listarutas = new List<BERuta>();
            List<BERuta> listarutasasignadas = new List<BERuta>();
            BLLRuta oBLLRuta = new BLLRuta();
            listarutas = oBLLRuta.ListarTodo();

            foreach (BERuta p in listarutas)
            {
                if (p.Distribuidor != null)
                {
                    if (p.Distribuidor.Codigo == emp.Codigo)
                    {
                        //Se almacenan las rutas asignadas al distribuidor
                        listarutasasignadas.Add(p);
                    }
                }
                
            }

            //Por cada ruta asignada al distribuidor, se multiplica por 8 que son las horas supuestas que camino con esa ruta

            return listarutasasignadas.Count * 8;
        }
        public bool Baja(BEDistribuidor Objeto)
        {
            return oMPPDis.Baja(Objeto);
        }

        public bool Guardar(BEDistribuidor Objeto)
        {
            return oMPPDis.Guardar(Objeto);
        }

        public BEDistribuidor ListarObjeto(BEDistribuidor Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEDistribuidor> ListarTodo()
        {
            return oMPPDis.ListarTodo();
        }
    }
}
