using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstraccion;
using System.Security.Cryptography;
using System.Windows.Forms;
using MPP;

namespace BLL
{
    public class BLLLogin : IGestor<BELogin>
    {
        public BLLLogin()
        {
            oMPPLoguin = new MPPLogin();
        }
        MPPLogin oMPPLoguin;

        public bool Baja(BELogin Objeto)
        {
            return oMPPLoguin.Baja(Objeto);
        }

        public bool Guardar(BELogin Objeto)
        {
            return oMPPLoguin.Guardar(Objeto);
        }

        public BELogin ListarObjeto(BELogin Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BELogin> ListarTodo()
        {
            return oMPPLoguin.ListarTodo();
        }

        public string Encriptar(string contrasena)
        {
            try
            {
                //key necesaria para encriptar y desencriptar
                string key = "francosanchez";
                byte[] keyArray;
                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(contrasena);

                //Se utilizan las clases de encriptación MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();

                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
                tdes.Clear();

                //se regresa el resultado en forma de una cadena
                contrasena = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return contrasena;
        }
    }
}
