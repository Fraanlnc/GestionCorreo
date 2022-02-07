using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace TP2
{
    public partial class UC_Login : UserControl
    {
        public UC_Login()
        {
            InitializeComponent();
            oBELogin = new BELogin();
            oBLLLogin = new BLLLogin();
        }
        BELogin oBELogin;
        BLLLogin oBLLLogin;

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<BELogin> listausuarios = new List<BELogin>();
                //Cargo lista de usuarios del sistema
                listausuarios = oBLLLogin.ListarTodo();

                //Creo objeto usuario con lo ingresado

                oBELogin.Usuario = textBox1.Text;
                //Metodo de encriptacion
                oBELogin.Contrasena = oBLLLogin.Encriptar(textBox2.Text);
                //Recorro lista de usuarios
                foreach(BELogin p in listausuarios)
                {
                    //Valido lo ingresado contra la lista traida de la base de datos
                    if (p.Usuario == oBELogin.Usuario)
                    {
                        if (p.Contrasena == oBELogin.Contrasena)
                        {
                           
                            Menu formMenu = new Menu();
                            formMenu.Show();

                            
                            this.Hide();
                        }
                        else { MessageBox.Show("Contraseña incorrecta");}
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void UC_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
