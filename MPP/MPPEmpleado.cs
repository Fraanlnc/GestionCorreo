using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using Abstraccion;
using System.Collections;
using System.Data;

namespace MPP
{
    public class MPPEmpleado : IGestor<BEEmpleado>
    {
        public MPPEmpleado()
        {
            oDatos = new Acceso();
        }
        Acceso oDatos;
       // Hashtable Hdatos;
        public bool Baja(BEEmpleado Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEEmpleado Objeto)
        {
            throw new NotImplementedException();
        }

        public BEEmpleado ListarObjeto(BEEmpleado Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEEmpleado> ListarTodo()
        {
            List<BEEmpleado> listaempleados = new List<BEEmpleado>();

            DataTable Dt = oDatos.Leer("s_Empleado_Listar", null);


            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow Item in Dt.Rows)
                {
                    BEEmpleado aux = new BEDistribuidor();
                    aux.Codigo=Convert.ToInt32(Item["Codigo"]);
                    aux.Nombre = Item["Nombre"].ToString();
                    aux.Apellido = Item["Apellido"].ToString();
                    BESucursal suc = new BESucursal();
                    suc.Codigo= Convert.ToInt32(Item["CodSucursal"]);
                    aux.Sucursal=suc;
                    listaempleados.Add(aux);
                }
                return listaempleados;
            }
            else { return null; }
            
        }
    }
}
