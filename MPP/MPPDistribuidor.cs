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
    public class MPPDistribuidor : IGestor<BEDistribuidor>
    {
        public MPPDistribuidor()
        {
            oDatos = new Acceso();
           // oMPPDis = new MPPDistribuidor(); rompe
        }
        Acceso oDatos;
        Hashtable Hdatos;
        //MPPDistribuidor oMPPDis;

        public bool ActualizarTablaIntermedia(BEDistribuidor Objeto)
        {
            List<BEDistribuidor> lista = new List<BEDistribuidor>();
            lista = this.ListarTodo();
            //chequeo por telefono ya que es unico por distribuidor
            BEDistribuidor aux = lista.Find(x => x.Telefono == Objeto.Telefono);

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
        public bool Baja(BEDistribuidor Objeto)
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

        public bool Guardar(BEDistribuidor Objeto)
        {
            Hdatos = new Hashtable();
            string Consulta = "s_Empleado_Alta";
            //Carga de tabla empleado
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
            Hdatos.Add("@Telefono", Objeto.Telefono);
            Hdatos.Add("@CodSucursal", Objeto.Sucursal.Codigo);
            Hdatos.Add("@Personal_a_Cargo", DBNull.Value);
            
           oDatos.Escribir(Consulta, Hdatos);
            //actualizo la tabla intermedia
            return this.ActualizarTablaIntermedia(Objeto);
           
        }

        public BEDistribuidor ListarObjeto(BEDistribuidor Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEDistribuidor> ListarTodo()
        {
          
            List<BEDistribuidor> listadistribuidores = new List<BEDistribuidor>();

            DataTable Dt = oDatos.Leer("s_Empleado_Listar", null);

            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow Item in Dt.Rows)
                {
                    //Creo objeto auxiliar
                    BEDistribuidor dis = new BEDistribuidor();
                    //Distribuidores son los unicos con telefono
                    if (!(Item["Telefono"] is DBNull))
                    {
                        dis.Codigo = Convert.ToInt32(Item["Codigo"]);
                        dis.Nombre = Item["Nombre"].ToString();
                        dis.Apellido = Item["Apellido"].ToString();
                        dis.Telefono = Convert.ToInt32(Item["Telefono"]);

                        //Cargo objeto sucursal del distribuidor
                        BESucursal suc = new BESucursal();
                        Hdatos = new Hashtable();
                        Hdatos.Add("@CodSucursal", Convert.ToInt32(Item["CodSucursal"]));
                        DataTable Dt2 = oDatos.Leer("s_EmpleadoSucursal_Asignada",Hdatos);

                        if (Dt2.Rows.Count > 0)
                        {

                            foreach (DataRow Item2 in Dt2.Rows)
                            {

                                suc.Codigo = Convert.ToInt32(Item2["Codigo"]);
                                suc.Nombre = Item2["Nombre"].ToString();
                                suc.Direccion = Item2["Direccion"].ToString();
                                
                            }
                            //Cargo el objeto sucursal al objeto distribuidor
                            dis.Sucursal = suc;
                        }
                        //Cargo el objeto distribuidor en una lista
                        listadistribuidores.Add(dis);
                    }
                    

                }

                return listadistribuidores;

            }
            else
            {
                return null;
            }


            
        }
    }
}
