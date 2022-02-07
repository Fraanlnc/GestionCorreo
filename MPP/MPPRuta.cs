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
    public class MPPRuta : IGestor<BERuta>
    {
        public MPPRuta()
        {
            oDatos = new Acceso();
        }
        Acceso oDatos;
        Hashtable Hdatos;
        public bool Baja(BERuta Objeto)
        {
            Hdatos = new Hashtable();
            //Parametro de baja
            Hdatos.Add("@Codigo", Objeto.Codigo);
            return oDatos.Escribir("s_Ruta_Baja", Hdatos);
        }

        public bool Guardar(BERuta Objeto)
        {
            Hdatos = new Hashtable();
            string Consulta = "s_Ruta_Alta";

            //Verifico si es una ruta nueva o ya cargada
            if (Objeto.Codigo != 0)
            {
                Hdatos.Add("@Codigo", Objeto.Codigo);
                //Si ya esta cargado cambio la consulta a modificar
                Consulta = "s_Ruta_Modificar";



            }
            //Cargo los parametros
            Hdatos.Add("@FechaCreacion", Objeto.FechaCreacion);
           
            //si fecha asignacion es null
            if (Objeto.FechaAsignacion == null)
            {
                Hdatos.Add("@FechaAsignacion", DBNull.Value);
            }
            else
            {  //Si fecha asignacion no es null
                Hdatos.Add("@FechaAsignacion", Objeto.FechaAsignacion);
            }
            
           

            if (Objeto.FechaEntrega == null)
            {
                Hdatos.Add("@FechaEntrega", DBNull.Value);
            }
            else { Hdatos.Add("@FechaEntrega", Objeto.FechaEntrega); }
            Hdatos.Add("@Estado", Objeto.Estado);
            if (Objeto.Distribuidor == null)
            {
                Hdatos.Add("@CodDistribuidor", DBNull.Value);
            }
            else { Hdatos.Add("@CodDistribuidor", Objeto.Distribuidor.Codigo); }
            


            return oDatos.Escribir(Consulta, Hdatos);
        }

        public BERuta ListarObjeto(BERuta Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BERuta> ListarTodo()
        {

            List<BERuta> listarutas = new List<BERuta>();

            DataTable Dt = oDatos.Leer("s_Ruta_Listar", null);

            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow Item in Dt.Rows)
                {

                    BERuta ruta = new BERuta();
                    ruta.Codigo = Convert.ToInt32(Item["Codigo"]);
                    ruta.FechaCreacion = Convert.ToDateTime(Item["FechaCreacion"]);
                    if (Item["FechaAsignacion"] is DBNull)
                    {
                        ruta.FechaAsignacion = null;
                    }
                    else { ruta.FechaAsignacion = Convert.ToDateTime(Item["FechaAsignacion"]); }
                    if(Item["FechaEntrega"] is DBNull)
                    {
                        ruta.FechaEntrega = null;
                    }
                    else { ruta.FechaEntrega = Convert.ToDateTime(Item["FechaEntrega"]); }
                    
                    ruta.Estado = Item["Estado"].ToString();
                    
                    //Cargar distribuidor a la ruta
                    if (!(Item["CodDistribuidor"] is DBNull))
                    {
                        DataTable Dt2 = oDatos.Leer("s_Empleado_Listar", null);

                        if (Dt2.Rows.Count > 0)
                        {
                            foreach (DataRow Item2 in Dt2.Rows)
                            {
                                if (Convert.ToInt32(Item2["Codigo"]) == Convert.ToInt32(Item["CodDistribuidor"]))
                                {
                                    BEDistribuidor aux = new BEDistribuidor();
                                    aux.Codigo = Convert.ToInt32(Item2["Codigo"]);
                                    aux.Nombre = Item2["Nombre"].ToString();
                                    aux.Apellido = Item2["Apellido"].ToString();
                                    aux.Telefono = Convert.ToInt32(Item2["Telefono"]);

                                    //Cargar sucursal al distribuidor
                                    DataTable Dt3 = oDatos.Leer("s_Sucursal_Listar", null);

                                    if (Dt3.Rows.Count > 0)
                                    {
                                        foreach (DataRow Item3 in Dt3.Rows)
                                        {
                                            if (Convert.ToInt32(Item3["Codigo"]) == Convert.ToInt32(Item2["CodSucursal"]))
                                            {
                                                BESucursal suc = new BESucursal();
                                                suc.Codigo = Convert.ToInt32(Item3["Codigo"]);
                                                suc.Nombre = Item3["Nombre"].ToString();
                                                suc.Direccion = Item3["Direccion"].ToString();
                                                //Asigno sucursal a distribuidor
                                                aux.Sucursal = suc;
                                            }
                                        }
                                        
                                    }
                                    //Asigno distribuidor a ruta
                                    ruta.Distribuidor = aux;
                                }
                            }
                        }
                    }
                    else { ruta.Distribuidor = null; }

                    //Cargo la lista de piezas de esa ruta
                    List<BEPieza> listapiezas = new List<BEPieza>();

                    DataTable Dt4 = oDatos.Leer("s_Pieza_Listar", null);

                    if (Dt4.Rows.Count > 0)
                    {
                        foreach (DataRow Item4 in Dt4.Rows)
                        {
                            if (ruta.Codigo == Convert.ToInt32(Item4["CodRuta"]))
                            {
                                BEPieza pieza = new BEPieza();
                                pieza.Codigo = Convert.ToInt32(Item4["Codigo"]);
                                pieza.Destinatario = Item4["Destinatario"].ToString();
                                pieza.Direccion = Item4["Direccion"].ToString();
                                if (Item4["FechaEntrega"] is DBNull)
                                {
                                    pieza.FechaEntrega = null;
                                }
                                else { pieza.FechaEntrega = Convert.ToDateTime(Item4["FechaEntrega"]); }
                                
                                pieza.Anomalia = Item4["Anomalia"].ToString();
                                pieza.Localidad = Item4["Localidad"].ToString();
                                pieza.MontoaCobrar = Convert.ToDouble(Item4["Monto"]);
                                pieza.Estado = Item4["Estado"].ToString();
                                pieza.Ruta = ruta;
                                listapiezas.Add(pieza);
                            }
                            ruta.Piezas = listapiezas;
                        }
                    }
                           

                    //Se agregan las sucursales a la lista creada
                    listarutas.Add(ruta);

                }

                return listarutas;
            }
            else { return null; }
        }
    }
}
