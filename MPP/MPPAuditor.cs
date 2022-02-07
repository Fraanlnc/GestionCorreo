using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using Abstraccion;
using System.Data;
using System.Collections;

namespace MPP
{
    public class MPPAuditor : IGestor<BEAuditor>
    {
        public MPPAuditor()
        {
            oDatos = new Acceso();
        }
        Acceso oDatos;
        Hashtable Hdatos;

        public bool ActualizarTablaIntermedia(BEAuditor Objeto)
        {
            List<BEAuditor> lista = new List<BEAuditor>();
            lista = this.ListarTodo();
            //chequeo por nombre y apellido apellido
            BEAuditor aux = lista.Find(x => x.Apellido == Objeto.Apellido && x.Nombre == Objeto.Nombre);

            Hdatos = new Hashtable();
            string Consulta = "s_EmpSuc_Alta";

            if (Objeto.Codigo != 0)
            {
                //paso aux de parametro que es el que tendra el codigo asignado por la BD
                Hdatos.Add("@CodLegajo", aux.Codigo);
                //Si ya esta cargado cambio la consulta a modificar
                Consulta = "s_EmpSuc_Modificar";



            }
            else
            {
                Hdatos.Add("@CodLegajo", aux.Codigo);
            }
            //Cargo los parametros
            Hdatos.Add("@CodSucursal", aux.Sucursal.Codigo);


            return oDatos.Escribir(Consulta, Hdatos);
        }
        public bool Baja(BEAuditor Objeto)
        {
            //Baja de tabla intermedia empleado-sucursal
            Hashtable Hdatos2 = new Hashtable();
            Hdatos2.Add("@CodLegajo", Objeto.Codigo);
            oDatos.Escribir("s_EmpSuc_Baja", Hdatos2);
            //Baja de tabla Empleado
            Hdatos = new Hashtable();
            //Parametro de baja
            Hdatos.Add("@Codigo", Objeto.Codigo);
            return oDatos.Escribir("s_Empleado_Baja", Hdatos);
        }

        public bool Guardar(BEAuditor Objeto)
        {
            Hdatos = new Hashtable();
            string Consulta = "s_Empleado_Alta";

            //Verifico si es un empleado nuevo o ya cargado
            if (Objeto.Codigo != 0)
            {
                Hdatos.Add("@Codigo", Objeto.Codigo);
                //Si ya esta cargado cambio la consulta a modificar
                Consulta = "s_Empleado_Modificar";



            }
            //Cargo los parametros
            Hdatos.Add("@Nombre", Objeto.Nombre);
            Hdatos.Add("@Apellido", Objeto.Apellido);
            Hdatos.Add("@CodSucursal", Objeto.Sucursal.Codigo);
            Hdatos.Add("@Personal_a_Cargo", DBNull.Value);
            Hdatos.Add("@Telefono", DBNull.Value);

            oDatos.Escribir(Consulta, Hdatos);

            //Carga de tabla intermedia Empleado-Sucursal

            return this.ActualizarTablaIntermedia(Objeto);
        }

        public BEAuditor ListarObjeto(BEAuditor Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEAuditor> ListarTodo()
        {
            List<BEAuditor> listaauditores = new List<BEAuditor>();

            DataTable Dt = oDatos.Leer("s_Empleado_Listar", null);

            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow Item in Dt.Rows)
                {
                    if(Convert.ToInt32(Item["CodSucursal"])==1)
                    {
                        BEAuditor aux = new BEAuditor();
                        aux.Codigo = Convert.ToInt32(Item["Codigo"]);
                        aux.Nombre = Item["Nombre"].ToString();
                        aux.Apellido = Item["Apellido"].ToString();
                        BESucursal suc = new BESucursal();

                        DataTable Dt2 = oDatos.Leer("s_Sucursal_Listar", null);
                        if (Dt2.Rows.Count > 0)
                        {
                            foreach (DataRow Item2 in Dt2.Rows)
                            {
                                if (Convert.ToInt32(Item2["Codigo"]) == 1)
                                {
                                    suc.Codigo = 1;
                                    suc.Nombre = Item2["Nombre"].ToString();
                                    suc.Direccion = Item2["Direccion"].ToString();
                                }
                            }
                        }
                        aux.Sucursal = suc;

                        //Se agregan los auditores a la lista creada
                        listaauditores.Add(aux);
                    }
                }

                return listaauditores;
            }
            else { return null; }
        }
    }
}
