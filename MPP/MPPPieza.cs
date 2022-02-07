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
    public class MPPPieza : IGestor<BEPieza>
    {
        public MPPPieza()
        {
            oDatos = new Acceso();
        }
        Acceso oDatos;
        Hashtable Hdatos;
        public bool Baja(BEPieza Objeto)
        {
            Hdatos = new Hashtable();
            //Parametro de baja
            Hdatos.Add("@Codigo", Objeto.Codigo);
            return oDatos.Escribir("s_Pieza_Baja", Hdatos);
        }

        public bool ExisteCodigo (BEPieza Objeto)
        {
            bool aux = false;

            List<BEPieza> listapiezas = new List<BEPieza>();
            listapiezas = this.ListarTodo();
            if (listapiezas != null)
            {
                foreach (BEPieza p in listapiezas)
                {
                    if (p.Codigo == Objeto.Codigo) aux = true;
                }

            }
           



            return aux;
        }

        public bool Guardar(BEPieza Objeto)
        {
            Hdatos = new Hashtable();
            string Consulta = "s_Pieza_Alta";
            //Verifico si es una pieza nueva o ya cargada
            if (ExisteCodigo(Objeto))
            {
                Hdatos.Add("@Codigo", Objeto.Codigo);
                //Si ya esta cargado cambio la consulta a modificar
                Consulta = "s_Pieza_Modificar";
            }
            else { Hdatos.Add("@Codigo", Objeto.Codigo); }

           
            //Cargo los parametros
            Hdatos.Add("@Destinatario", Objeto.Destinatario);
            Hdatos.Add("@Direccion", Objeto.Direccion);
            if (Objeto.FechaEntrega == null)
            {
                Hdatos.Add("@FechaEntrega", DBNull.Value);
            }
            else { Hdatos.Add("@FechaEntrega", Objeto.FechaEntrega); }

            if (Objeto.Anomalia == null)
            {
                Hdatos.Add("@Anomalia", DBNull.Value);
            }
            else { Hdatos.Add("@Anomalia", Objeto.Anomalia); }
           
            Hdatos.Add("@Localidad", Objeto.Localidad);
            Hdatos.Add("@Monto", Objeto.MontoaCobrar);
            Hdatos.Add("@Estado", Objeto.Estado);
            Hdatos.Add("@CodRuta", Objeto.Ruta.Codigo);

            return oDatos.Escribir(Consulta, Hdatos);
        }

        public BEPieza ListarObjeto(BEPieza Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEPieza> ListarTodo()
        {
            List<BEPieza> listapiezas = new List<BEPieza>();

            DataTable Dt = oDatos.Leer("s_Pieza_Listar", null);

            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow Item in Dt.Rows)
                {

                    BEPieza pieza = new BEPieza();
                    pieza.Codigo = Convert.ToInt32(Item["Codigo"]);
                    pieza.Destinatario = Item["Destinatario"].ToString();
                    pieza.Direccion = Item["Direccion"].ToString();
                    if(Item["FechaEntrega"] is DBNull)
                    {
                        pieza.FechaEntrega = null;
                    }
                    else { pieza.FechaEntrega = Convert.ToDateTime(Item["FechaEntrega"]); }
                    
                    pieza.Anomalia = Item["Anomalia"].ToString();
                    pieza.Localidad = Item["Localidad"].ToString();
                    pieza.MontoaCobrar = Convert.ToDouble(Item["Monto"]);
                    pieza.Estado = Item["Estado"].ToString();

                    DataTable Dt2 = oDatos.Leer("s_Ruta_Listar", null);

                    if (Dt2.Rows.Count > 0)
                    {
                        foreach (DataRow Item2 in Dt2.Rows)
                        {
                            if (Convert.ToInt32(Item["CodRuta"]) == Convert.ToInt32(Item2["Codigo"]))
                            {
                                BERuta aux = new BERuta();
                                aux.Codigo = Convert.ToInt32(Item2["Codigo"]);
                                aux.FechaCreacion = Convert.ToDateTime(Item2["FechaCreacion"]);
                                if (Item2["FechaAsignacion"] is DBNull)
                                {
                                    aux.FechaAsignacion = null;
                                }
                                else { aux.FechaAsignacion = Convert.ToDateTime(Item2["FechaAsignacion"]); }
                                if (Item2["FechaEntrega"] is DBNull)
                                {
                                    aux.FechaEntrega = null;
                                }
                                else { aux.FechaEntrega = Convert.ToDateTime(Item2["FechaEntrega"]); }

                                    
                                aux.Estado = Item2["Estado"].ToString();
                                //cargar distribuidor???
                                pieza.Ruta = aux;
                            }
                        }
                    }


                    //Se agregan las sucursales a la lista creada
                    listapiezas.Add(pieza);

                }

                return listapiezas;
            }
            else { return null; }
        }
    }
}
