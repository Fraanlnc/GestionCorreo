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
    public class MPPEncargado : IGestor<BEEncargado>
    {
        public MPPEncargado()
        {
            oDatos = new Acceso();
        }
        Acceso oDatos;
        Hashtable Hdatos;

        public bool ActualizarTablaIntermedia(BEEncargado Objeto)
        {
            List<BEEncargado> lista = new List<BEEncargado>();
            lista = this.ListarTodo();
            //chequeo por nombre y apellido apellido
            BEEncargado aux = lista.Find(x => x.Apellido == Objeto.Apellido && x.Nombre == Objeto.Nombre);

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
        public bool Baja(BEEncargado Objeto)
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

        public bool Guardar(BEEncargado Objeto)
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
            Hdatos.Add("@Telefono", DBNull.Value);
            Hdatos.Add("@CodSucursal", Objeto.Sucursal.Codigo);
            Hdatos.Add("@Personal_a_Cargo", Objeto.Personal_a_Cargo);



            oDatos.Escribir(Consulta, Hdatos);

            //Carga de tabla intermedia Empleado-Sucursal

            return this.ActualizarTablaIntermedia(Objeto);
        }

        public BEEncargado ListarObjeto(BEEncargado Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEEncargado> ListarTodo()
        {
            List<BEEncargado> listaencargados = new List<BEEncargado>();

            DataTable Dt = oDatos.Leer("s_Empleado_Listar", null);

            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow Item in Dt.Rows) 
                {
                    //Creo objeto auxiliar
                    BEEncargado enc = new BEEncargado();
                    //Encargados son los unicos con personal a cargo
                    if (!(Item["Personal_a_Cargo"] is DBNull))
                    {
                        enc.Codigo = Convert.ToInt32(Item["Codigo"]);
                        enc.Nombre = Item["Nombre"].ToString();
                        enc.Apellido = Item["Apellido"].ToString();
                       

                        //Cargo objeto sucursal del distribuidor
                        BESucursal suc = new BESucursal();
                        Hdatos = new Hashtable();
                        Hdatos.Add("@CodSucursal", Convert.ToInt32(Item["CodSucursal"]));
                        DataTable Dt2 = oDatos.Leer("s_EmpleadoSucursal_Asignada", Hdatos);

                        if (Dt2.Rows.Count > 0)
                        {

                            foreach (DataRow Item2 in Dt2.Rows)
                            {

                                suc.Codigo = Convert.ToInt32(Item2["Codigo"]);
                                suc.Nombre = Item2["Nombre"].ToString();
                                suc.Direccion = Item2["Direccion"].ToString();

                            }
                            //Cargo el objeto sucursal al objeto encargado
                            enc.Sucursal = suc;
                        }
                        //Para saber el personal a cargo, cuento cuantos distribuidores hay en esa sucursal
                        Hdatos = new Hashtable();
                        Hdatos.Add("@CodSucursal", suc.Codigo);
                        DataTable Dt3 = oDatos.Leer("s_EmpleadoSucursal_Listar", Hdatos);
                        //Creo lista de distribuidores de la sucursal
                        List<BEDistribuidor> listadistribuidores = new List<BEDistribuidor>();

                        if (Dt3.Rows.Count > 0)
                        {
                            foreach (DataRow Item3 in Dt3.Rows)
                            {
                                if (!(Item3["Telefono"] is DBNull))
                                {
                                    BEDistribuidor aux = new BEDistribuidor();
                                    aux.Codigo = Convert.ToInt32(Item3["Codigo"]);
                                    aux.Nombre = Item3["Nombre"].ToString();
                                    aux.Apellido = Item3["Apellido"].ToString();
                                    aux.Telefono = Convert.ToInt32(Item3["Telefono"]);
                                    listadistribuidores.Add(aux);
                                }
                                
                                    
                            }

                            enc.Personal_a_Cargo = listadistribuidores.Count;
                                
                        }
                        listaencargados.Add(enc);
                    }
                    
                }
                return listaencargados;
            }
            else
            {
                return null;
            }


        }
    }
}
