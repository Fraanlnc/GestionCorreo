using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace TP2
{
    public partial class frmABMLogin : Form
    {
        public frmABMLogin()
        {
            InitializeComponent();
            oBELogin = new BELogin();
            oBLLLogin = new BLLLogin();
        }
        BELogin oBELogin;
        BLLLogin oBLLLogin;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BELogin aux = new BELogin();
                aux=dataGridView1.SelectedRows[0].DataBoundItem as BELogin;
                if (aux.Codigo == 1)
                {
                    MessageBox.Show("El usuario administrador no se puede dar de baja");
                }
                else
                {
                    oBLLLogin.Baja(aux);
                    ActualizarGrilla();
                    Limpiar();

                }
              

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void frmABMLogin_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                ActualizarGrilla();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                oBELogin = dataGridView1.SelectedRows[0].DataBoundItem as BELogin;

                textBox1.Text = oBELogin.Codigo.ToString();
                textBox2.Text = oBELogin.Usuario;
                textBox3.Text = oBELogin.Contrasena;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }
        void ActualizarGrilla()
        {
            try
            {
                dataGridView1.DataSource = null;
                List<BELogin> listausuarios = new List<BELogin>();
                listausuarios = oBLLLogin.ListarTodo();
                dataGridView1.DataSource = listausuarios;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length > 0)
                {
                    //El usuario solo admite letras, sin numeros ni espacios
                    bool usuario = Regex.IsMatch(textBox2.Text, "^([a-zA-Z]+$)");
                    if (usuario == false)
                    {
                        //usuario mal ingresado
                        MessageBox.Show("El usuario debe ser sólo alfabético");
                    }
                    else
                    {
                        //usuario bien ingresado

                        //chequeo de campo contraseña
                        if (textBox3.Text.Length > 0)
                        {
                            //la contraseña admitirá letras y numeros
                            bool contrasena = Regex.IsMatch(textBox3.Text, "^([0-9a-zA-Z]+$)");
                            if (contrasena == false)
                            {
                                //contrasena mal ingresada
                                MessageBox.Show("La contraseña debe contener sólo números y letras");
                            }
                            else
                            {
                                //contraseña bien ingresada

                                //Hechos los chequeos con regex, se procede al alta
                                BELogin aux = new BELogin();
                                aux.Usuario = textBox2.Text;
                                //Encripto 
                                aux.Contrasena = oBLLLogin.Encriptar(textBox3.Text);
                                oBLLLogin.Guardar(aux);
                                //Actualizo grilla
                                ActualizarGrilla();
                                Limpiar();

                            }
                        }
                        else
                        {
                            MessageBox.Show("El campo contraseña se encuentra vacío");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("El campo usuario se encuentra vacío");
                }


               

            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }
        void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                   
                    if (textBox1.Text == "1")
                    {
                        MessageBox.Show("El Usuario Admin no se puede modificar");
                    }
                    else
                    {

                        if (textBox2.Text.Length > 0)
                        {
                            //El usuario solo admite letras, sin numeros ni espacios
                            bool usuario = Regex.IsMatch(textBox2.Text, "^([a-zA-Z]+$)");
                            if (usuario == false)
                            {
                                //usuario mal ingresado
                                MessageBox.Show("El usuario debe ser sólo alfabético");
                            }
                            else
                            {
                                //usuario bien ingresado

                                //chequeo de campo contraseña
                                if (textBox3.Text.Length > 0)
                                {
                                    //la contraseña admitirá letras y numeros
                                    bool contrasena = Regex.IsMatch(textBox3.Text, "^([0-9a-zA-Z]+$)");
                                    if (contrasena == false)
                                    {
                                        //contrasena mal ingresada
                                        MessageBox.Show("La contraseña debe contener sólo números y letras");
                                    }
                                    else
                                    {
                                        //contraseña bien ingresada

                                        //Hechos los chequeos con regex, se procede al alta
                                        BELogin aux = new BELogin();
                                        aux.Codigo = Convert.ToInt32(textBox1.Text);
                                        aux.Usuario = textBox2.Text;
                                        //Encripto 
                                        aux.Contrasena = oBLLLogin.Encriptar(textBox3.Text);
                                        oBLLLogin.Guardar(aux);
                                        //Actualizo grilla
                                        ActualizarGrilla();
                                        Limpiar();

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El campo contraseña se encuentra vacío");
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("El campo usuario se encuentra vacío");
                        }

                    }

                }
                else { MessageBox.Show("Complete los campos");}
              

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
