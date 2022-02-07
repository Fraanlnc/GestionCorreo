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
    public class MPPLogin : IGestor<BELogin>
    {
        public MPPLogin()
        {
            oDatos = new Acceso();
        }
        Acceso oDatos;
        Hashtable Hdatos;
        public bool Baja(BELogin Objeto)
        {
            Hdatos = new Hashtable();
            //Parametro de baja
            Hdatos.Add("@Codigo", Objeto.Codigo);
            return oDatos.Escribir("s_Usuario_Baja", Hdatos);
        }

        public bool Guardar(BELogin Objeto)
        {
            Hdatos = new Hashtable();
            string Consulta = "s_Usuario_Alta";

            //Verifico si es una sucursal nueva o ya cargada
            if (Objeto.Codigo != 0)
            {
                Hdatos.Add("@Codigo", Objeto.Codigo);
                //Si ya esta cargado cambio la consulta a modificar
                Consulta = "s_Usuario_Modificar";



            }
            //Cargo los parametros
            Hdatos.Add("@Usuario", Objeto.Usuario);
            Hdatos.Add("@Contrasena", Objeto.Contrasena);





            return oDatos.Escribir(Consulta, Hdatos);
        }

        public BELogin ListarObjeto(BELogin Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BELogin> ListarTodo()
        {
            List<BELogin> listausuarios = new List<BELogin>();

            DataTable Dt = oDatos.Leer("s_Usuario_Listar", null);

            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow Item in Dt.Rows)
                {

                    BELogin log = new BELogin();
                    log.Codigo = Convert.ToInt32(Item["Codigo"]);
                    log.Usuario = Item["Usuario"].ToString();
                    log.Contrasena = Item["Contrasena"].ToString();


                 
                    listausuarios.Add(log);

                }

                return listausuarios;
            }
            else { return null; }
        }
    }
}
