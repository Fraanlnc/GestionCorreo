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
    public class MPPSucursal : IGestor<BESucursal>
    {
        public MPPSucursal()
        {
            oDatos = new Acceso();
        }
        Acceso oDatos;
        Hashtable Hdatos;
        public bool Baja(BESucursal Objeto)
        {
            Hdatos = new Hashtable();
            //Parametro de baja
            Hdatos.Add("@Codigo", Objeto.Codigo);
            return oDatos.Escribir("s_Sucursal_Baja", Hdatos);
        }

        public bool Guardar(BESucursal Objeto)
        {
            Hdatos = new Hashtable();
            string Consulta = "s_Sucursal_Alta";

            //Verifico si es una sucursal nueva o ya cargada
            if (Objeto.Codigo != 0)
            {
                Hdatos.Add("@Codigo", Objeto.Codigo);
                //Si ya esta cargado cambio la consulta a modificar
                Consulta = "s_Sucursal_Modificar";



            }
            //Cargo los parametros
            Hdatos.Add("@Nombre", Objeto.Nombre);
            Hdatos.Add("@Direccion", Objeto.Direccion);
            
            



            return oDatos.Escribir(Consulta, Hdatos);
        }

        public BESucursal ListarObjeto(BESucursal Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BESucursal> ListarTodo()
        {
            List<BESucursal> listasucursales = new List<BESucursal>();

            DataTable Dt = oDatos.Leer("s_Sucursal_Listar", null);

            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow Item in Dt.Rows)
                {
                   
                        BESucursal suc = new BESucursal();
                        suc.Codigo = Convert.ToInt32(Item["Codigo"]);
                        suc.Nombre = Item["Nombre"].ToString();
                        suc.Direccion = Item["Direccion"].ToString();
                      
                                           
                        //Se agregan las sucursales a la lista creada
                        listasucursales.Add(suc);
                    
                }

                return listasucursales;
            }
            else { return null; }
        }
    }
}
