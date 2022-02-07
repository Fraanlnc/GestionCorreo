using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using BE;

namespace BLL
{
    public class BLLSancion
    {
        public BLLSancion()
        {
           
        }

        public bool ValidarCodigo(BESancion sancion)
        {
            bool existe = false;
            //consulta de busqueda para ver si encuentra el codigo
            var consulta =
              from Sanciones in XElement.Load("Sanciones.XML").Elements("Sancion")
              where (string)Sanciones.Attribute("Codigo") == sancion.Codigo.ToString()
              select new BESancion
              {
                  Codigo = Convert.ToInt32(Convert.ToString(Sanciones.Attribute("Codigo").Value).Trim()),
                  Descipcion = Convert.ToString(Sanciones.Element("Descripcion").Value).Trim(),
                  Dias_de_Suspension = Convert.ToInt32(Convert.ToString(Sanciones.Element("Dias_de_Suspension").Value).Trim()),
                  Fecha_Suspension = Convert.ToDateTime(Convert.ToString((Sanciones.Element("Fecha_Suspension").Value).Trim()))
              };//Fin de consulta.

            List<BESancion> ListaSanciones = consulta.ToList<BESancion>();

            //si la lista tiene al menos 1 elemento, el codigo ya fue ingresado
            if (ListaSanciones.Count > 0)
            {
                existe = true;
            }
            

            return existe;
        }
        //no lo uso
        public void EscribirXML(BESancion sancion, BEDistribuidor dis)
        {
          
            XmlTextWriter xml = new XmlTextWriter("Sanciones.XML", System.Text.Encoding.UTF8);

            xml.Formatting = Formatting.Indented;
            xml.Indentation = 4;
            xml.WriteStartDocument(true);
            xml.WriteStartElement("Sanciones");

            if (sancion != null)
            {
                xml.WriteStartElement("Sancion");
                xml.WriteAttributeString("Codigo", sancion.Codigo.ToString());
                xml.WriteElementString("Descripcion", sancion.Descipcion);
                xml.WriteElementString("Dias_de_Suspension", sancion.Dias_de_Suspension.ToString());
                xml.WriteElementString("Fecha_Suspension", sancion.Fecha_Suspension.ToString());
                xml.WriteElementString("Distribuidor", dis.Codigo + " " + dis.Nombre + " " + dis.Apellido);

                xml.WriteEndElement();

            }

            xml.Close();
            
        }

        
        public void AgregarXML(BESancion sancion, BEDistribuidor dis)
        {
            try
            {
                //Se intenta abrir el documento
                XDocument xmlDoc1 = XDocument.Load("Sanciones.XML");
            }
            catch
            {
                //Si no existe se crea
                XmlTextWriter xmlDoc = new XmlTextWriter("Sanciones.XML", System.Text.Encoding.UTF8);

                xmlDoc.Formatting = Formatting.Indented;
                //xmlDoc.Indentation = 4;
                xmlDoc.WriteStartDocument(true);
                xmlDoc.WriteStartElement("Sanciones");
                xmlDoc.Close();
            }






            XDocument xmlDoc2 = XDocument.Load("Sanciones.XML");
            //Carga de sancion
            xmlDoc2.Element("Sanciones").Add(new XElement("Sancion",
                                            new XAttribute("Codigo", Convert.ToString(sancion.Codigo).Trim()),
                                            new XElement("Descripcion", sancion.Descipcion.Trim()),
                                            new XElement("Dias_de_Suspension", Convert.ToString(sancion.Dias_de_Suspension).Trim()),
                                            new XElement("Fecha_Suspension", Convert.ToString(sancion.Fecha_Suspension.ToShortDateString()).Trim()),
                                            new XElement("Distribuidor", dis.Codigo.ToString().Trim())));

            //luego el metodo save guarda lo ingresado en el XML
            xmlDoc2.Save("Sanciones.XML");

            

            
           
        }

        public List<BESancion> BuscarXML (BEDistribuidor dis)
        {
            

            var consulta =
               from Sanciones in XElement.Load("Sanciones.XML").Elements("Sancion")
               where (string)Sanciones.Element("Distribuidor") == dis.Codigo.ToString()
               select new BESancion
               {
                   Codigo = Convert.ToInt32(Convert.ToString(Sanciones.Attribute("Codigo").Value).Trim()),
                   Descipcion = Convert.ToString(Sanciones.Element("Descripcion").Value).Trim(),
                    Dias_de_Suspension = Convert.ToInt32(Convert.ToString(Sanciones.Element("Dias_de_Suspension").Value).Trim()),
                   Fecha_Suspension = Convert.ToDateTime(Convert.ToString((Sanciones.Element("Fecha_Suspension").Value).Trim()))
               };//Fin de consulta.

            List<BESancion> ListaSanciones = consulta.ToList<BESancion>();
            foreach (BESancion p in ListaSanciones)
            {
                p.Distribuidor = dis;
            }

            return ListaSanciones;
        }
        public List<BESancion> LeerXML()
        { //Primero cargo una lista de codigos de distribuidores
            var consultaDistribuidor =
                from Sanciones in XElement.Load("Sanciones.XML").Elements("Sancion")

                select new BEDistribuidor
                {
                    Codigo = Convert.ToInt32(Convert.ToString(Sanciones.Element("Distribuidor").Value).Trim()),       
                };

            List<BEDistribuidor> listadistribuidores = consultaDistribuidor.ToList<BEDistribuidor>();

            //cargo las propiedades restantes de los distribuidores encontrados

            BLLDistribuidor oBLLDis = new BLLDistribuidor();
            List<BEDistribuidor> lista = new List<BEDistribuidor>();
            //traigo todos los distribuidores
            lista = oBLLDis.ListarTodo();

            List<BEDistribuidor> listadistribuidoresfinal = new List<BEDistribuidor>();

            foreach(BEDistribuidor p in listadistribuidores)
            {
                BEDistribuidor aux = new BEDistribuidor();
                //busco y capturo el objeto distribuidor completo
                aux = lista.Find(x => x.Codigo == p.Codigo);
                //lo agrego a la lista
                listadistribuidoresfinal.Add(aux);
            }



            //Despues cargo una lista de las sanciones sin distribuidores
            var consulta =
                from Sanciones in XElement.Load("Sanciones.XML").Elements("Sancion")

                select new BESancion
                {
                    Codigo = Convert.ToInt32(Convert.ToString(Sanciones.Attribute("Codigo").Value).Trim()),
                    Descipcion = Convert.ToString(Sanciones.Element("Descripcion").Value).Trim(),
                   // Distribuidor =Convert.ToString(Sanciones.Element("Distribuidor").Value).Trim(),
                        
                    Dias_de_Suspension = Convert.ToInt32(Convert.ToString(Sanciones.Element("Dias_de_Suspension").Value).Trim()),
                    Fecha_Suspension = Convert.ToDateTime(Convert.ToString((Sanciones.Element("Fecha_Suspension").Value).Trim()))
                };//Fin de consulta.

            List<BESancion> ListaSanciones = consulta.ToList<BESancion>();

    
            //Creo contador
            int i = 0;
            //recorro lista distribuidor
            foreach (BEDistribuidor p in listadistribuidoresfinal)
            {
                //Asigno los distribuidores 
                ListaSanciones[i].Distribuidor = p; ;
                i++;
            }


            return ListaSanciones;
        }
    }
}
