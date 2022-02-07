using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace DAL
{
    public class Acceso
    {
        //Creo objeto Connection Data Source=.\SQLEXPRESS;Initial Catalog=BDTP2;Integrated Security=True
        private SqlConnection conexion = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BDTP2;Integrated Security=True");
        //Creo el objeto transaction
        private SqlTransaction transaction;
        //Creo el objeto command
        SqlCommand cmd;

        //Metodo Generico para leer que devuelve un datatable
        public DataTable Leer(string consulta, Hashtable datos)
        {
            DataTable tabla = new DataTable();
            SqlDataAdapter Da;
            //paso la consulta
            cmd = new SqlCommand(consulta, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                Da = new SqlDataAdapter(cmd);
                if (datos != null)
                {
                    foreach (string dato in datos.Keys)
                    {
                        //Cargo los parametros de la consulta
                        cmd.Parameters.AddWithValue(dato, datos[dato]);
                    }
                }


            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }

            //Lleno la tabla
            Da.Fill(tabla);
            return tabla;
        }

        //leo un escalar-
        public bool LeerScalar(string consulta, Hashtable datos)
        {
            conexion.Open();
            //uso el constructor del objeto Command al instanciar el objeto
            cmd = new SqlCommand(consulta, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {

                if (datos != null)
                {
                    foreach (string dato in datos.Keys)
                    {
                        cmd.Parameters.AddWithValue(dato, datos[dato]);

                    }
                }

                int Respuesta = Convert.ToInt32(cmd.ExecuteScalar());
                conexion.Close();
                if (Respuesta > 0)
                { return true; }
                else
                { return false; }
            }
            catch (SqlException ex)
            { throw ex; }
            catch (Exception ex)
            { throw ex; }
            finally
            { //cierro la Conexion
                conexion.Close();
            }
        }

        //método escribir generico
        public bool Escribir(string consulta, Hashtable datos)
        {
            //Chequeo si la conexion quedo abierta
            if (conexion.State == ConnectionState.Closed)
            {
                //Data Source=.\SQLEXPRESS;Initial Catalog=BDTP2;Integrated Security=True
                conexion.ConnectionString = "Data Source =.\\SQLEXPRESS;Initial Catalog=BDTP2;Integrated Security=True";
                conexion.Open();
            }


            try
            {
                transaction = conexion.BeginTransaction();
                //Uso constructor de cmd
                cmd = new SqlCommand(consulta, conexion, transaction);
                cmd.CommandType = CommandType.StoredProcedure;

                if (datos != null)
                {
                    foreach (string dato in datos.Keys)
                    {
                        cmd.Parameters.AddWithValue(dato, datos[dato]);
                    }
                }

                int respuesta = cmd.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (SqlException ex)
            {

                //Si falla la transaccion tiro los cambios para atras
                transaction.Rollback();
                return false;
                throw ex;

            }
            catch (Exception ex)
            {

                //Si falla la transaccion tiro los cambios para atras
                transaction.Rollback();
                return false;
                throw ex;

            }

            finally
            { conexion.Close(); }



        }
    }
}
