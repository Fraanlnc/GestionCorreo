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
    public partial class frmAsignacion : Form
    {
        public frmAsignacion()
        {
            InitializeComponent();
            oBEDis = new BEDistribuidor();
            oBLLDis = new BLLDistribuidor();
            oBERuta = new BERuta();
            oBLLRuta = new BLLRuta();
            oBEPieza = new BEPieza();
            oBLLPieza = new BLLPieza();
        }
        BEDistribuidor oBEDis;
        BLLDistribuidor oBLLDis;
        BERuta oBERuta;
        BLLRuta oBLLRuta;
        BEPieza oBEPieza;
        BLLPieza oBLLPieza;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAsignacion_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.MultiSelect = false;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView3.MultiSelect = false;

                //Cargar combobox
                comboBox1.DataSource = oBLLDis.ListarTodo();
                //Cargar rutas sin asignar
                List<BERuta> listarutas = new List<BERuta>();
                List<BERuta> sinasignar = new List<BERuta>();
                listarutas = oBLLRuta.ListarTodo();
                if (listarutas != null)
                {
                    foreach (BERuta p in listarutas)
                    {
                        if (p.Distribuidor == null)
                        {
                            sinasignar.Add(p);
                        }
                    }
                }
                //Se calcula la cantidad
                if (sinasignar != null)
                {
                    foreach (BERuta p in sinasignar)
                    {
                        if (p.Piezas != null) p.Cantidad = p.Piezas.Count;
                    }
                }
                dataGridView2.DataSource = sinasignar;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Capturo el distribuidor ingresado
                oBEDis = (BEDistribuidor)comboBox1.SelectedItem;
                //Creo lista de rutas
                List<BERuta> listarutas = new List<BERuta>();
                List<BERuta> listarutasasignadas = new List<BERuta>();
                //Cargo todas las rutas existentes
                listarutas = oBLLRuta.ListarTodo();

                if (listarutas != null)
                {
                    foreach (BERuta p in listarutas)
                    {
                        if (p.Distribuidor != null)
                        {
                            if (p.Distribuidor.Codigo == oBEDis.Codigo)
                            {
                                //agrego las que coincidan con el distribuidor
                                listarutasasignadas.Add(p);
                            }
                        }
                    
                    }
                }
                //Se calcula la cantidad
                if (listarutasasignadas != null)
                {
                    foreach (BERuta p in listarutasasignadas)
                    {
                        if (p.Piezas != null) p.Cantidad = p.Piezas.Count;
                    }
                }

                dataGridView1.DataSource = listarutasasignadas;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
            
        }
        void ActualizarGrillas()
        {
            try
            {
                //Cargar rutas sin asignar
                List<BERuta> listarutas = new List<BERuta>();
                List<BERuta> sinasignar = new List<BERuta>();
                listarutas = oBLLRuta.ListarTodo();
                if (listarutas != null)
                {
                    foreach (BERuta p in listarutas)
                    {
                        if (p.Distribuidor == null)
                        {
                            sinasignar.Add(p);
                        }
                    }
                }
                //Se calcula la cantidad
                if (sinasignar != null)
                {
                    foreach (BERuta p in sinasignar)
                    {
                        if (p.Piezas != null) p.Cantidad = p.Piezas.Count;
                    }
                }

                dataGridView2.DataSource = sinasignar;

                //Cargar Rutas Asignadas
                //Capturo el distribuidor ingresado
                oBEDis = (BEDistribuidor)comboBox1.SelectedItem;
                //Creo lista de rutas
                List<BERuta> listarutas2 = new List<BERuta>();
                List<BERuta> listarutasasignadas = new List<BERuta>();
                //Cargo todas las rutas existentes
                listarutas2 = oBLLRuta.ListarTodo();

                if (listarutas2 != null)
                {
                    foreach (BERuta p in listarutas2)
                    {
                        if (p.Distribuidor != null)
                        {
                            if (p.Distribuidor.Codigo == oBEDis.Codigo)
                            {
                                //agrego las que coincidan con el distribuidor
                                listarutasasignadas.Add(p);
                            }

                        }
                        
                    }
                }
                //Se calcula la cantidad
                if (listarutasasignadas != null)
                {
                    foreach (BERuta p in listarutasasignadas)
                    {
                        if (p.Piezas != null) p.Cantidad = p.Piezas.Count;
                    }
                }


                dataGridView1.DataSource = listarutasasignadas;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                oBEDis = (BEDistribuidor)comboBox1.SelectedItem;
                oBERuta = dataGridView2.SelectedRows[0].DataBoundItem as BERuta;

                if (oBERuta.Estado != "Completa")
                {
                    List<BEPieza> listapiezas = new List<BEPieza>();
                    List<BEPieza> piezasderuta = new List<BEPieza>();

                    listapiezas = oBLLPieza.ListarTodo();
                    if (listapiezas != null)
                    {
                        foreach (BEPieza p in listapiezas)
                        {
                            if (p.Ruta.Codigo == oBERuta.Codigo)
                            {
                                piezasderuta.Add(p);
                            }
                        }
                    }
                    if (piezasderuta.Count > 0)
                    {
                        //asignacion
                        oBERuta.Distribuidor = oBEDis;
                        oBERuta.FechaAsignacion = DateTime.Now;

                        //se guarda la modificacion de la ruta
                        oBLLRuta.Guardar(oBERuta);
                        //Actualizar datagrid 1 y 2
                        ActualizarGrillas();



                    }
                    else { MessageBox.Show("La ruta no tiene piezas, no puede ser asignada"); }
                }
                else { MessageBox.Show("No se puede asignar una ruta completa");}

                
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataGridView1.RowCount > 0)
                {
                    oBEDis = (BEDistribuidor)comboBox1.SelectedItem;
                    oBERuta = dataGridView1.SelectedRows[0].DataBoundItem as BERuta;

                    oBERuta.Distribuidor = null;
                   
                    oBLLRuta.Guardar(oBERuta);
                    ActualizarGrillas();
                    
                }
                else { MessageBox.Show("El distribuidor no tiene rutas asignadas");}
                

            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                List<BERuta> listarutas = new List<BERuta>();
                listarutas = oBLLRuta.ListarTodo();
                oBERuta = listarutas.Find(x => x.Codigo == Convert.ToInt32(textBox1.Text));
                if(oBERuta != null)
                {
                    List<BEPieza> listapiezas = new List<BEPieza>();
                    List<BEPieza> piezasderuta = new List<BEPieza>();
                    listapiezas = oBLLPieza.ListarTodo();
                    if (listapiezas != null)
                    {
                        foreach(BEPieza p in listapiezas)
                        {
                            if(oBERuta.Codigo == p.Ruta.Codigo)
                            {
                                piezasderuta.Add(p);
                            }
                        }
                    }
                    if (piezasderuta != null)
                    {
                        dataGridView3.DataSource = piezasderuta;
                    }
                    else { MessageBox.Show("La ruta no tiene piezas cargadas");}
                    
                }
                else { MessageBox.Show("La ruta ingresada no existe");}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //Traigo lista de rutas
                List<BERuta> listarutas = new List<BERuta>();
                listarutas = oBLLRuta.ListarTodo();
                //Busco la ruta ingresada en el textBox
                oBERuta = listarutas.Find(x => x.Codigo == Convert.ToInt32(textBox1.Text));
                if (oBERuta.Estado != "Completa")
                {
                    if (oBERuta != null)
                    {
                        oBERuta.FechaEntrega = DateTime.Now;
                        oBERuta.Estado = "Completa";
                        oBLLRuta.Guardar(oBERuta);
                        //Busco las piezas de la ruta
                        List<BEPieza> listapiezas = new List<BEPieza>();
                        List<BEPieza> piezasderuta = new List<BEPieza>();
                        listapiezas = oBLLPieza.ListarTodo();
                        if (listapiezas != null)
                        {

                            foreach (BEPieza p in listapiezas)
                            {
                                if (p.Ruta.Codigo == oBERuta.Codigo)
                                {
                                    piezasderuta.Add(p);
                                }
                            }
                        }
                        if (piezasderuta != null)
                        {
                            foreach (BEPieza p in piezasderuta)
                            {
                                if (p.Anomalia == "")
                                {
                                    p.Estado = "Entregado";
                                    p.FechaEntrega = DateTime.Now;
                                    oBLLPieza.Guardar(p);
                                }
                                else { p.Estado = "Con Anomalia"; oBLLPieza.Guardar(p); }
                            }

                        }
                    }
                    ActualizarGrillas();
                    ActualizarGrilla3();
                }
                else { MessageBox.Show("La ruta se encuentra completa, no se pueden modificar las piezas");}
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //Traigo lista de rutas
                List<BERuta> listarutas = new List<BERuta>();
                listarutas = oBLLRuta.ListarTodo();
                //Busco la ruta ingresada en el textBox
                oBERuta = listarutas.Find(x => x.Codigo == Convert.ToInt32(textBox1.Text));
                if (oBERuta.Estado != "Completa")
                {
                    oBEPieza = dataGridView3.SelectedRows[0].DataBoundItem as BEPieza;
                    oBEPieza.Anomalia = textBox2.Text;
                    oBLLPieza.Guardar(oBEPieza);

                    ActualizarGrilla3();
                    ActualizarGrillas();
                    textBox2.Text = "";
                }
                else { MessageBox.Show("La ruta se encuentra completa, no se puede modificar sus piezas");}


                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }

       void ActualizarGrilla3()
       {
            List<BERuta> listarutas = new List<BERuta>();
            listarutas = oBLLRuta.ListarTodo();
            oBERuta = listarutas.Find(x => x.Codigo == Convert.ToInt32(textBox1.Text));
            if (oBERuta != null)
            {
                List<BEPieza> listapiezas = new List<BEPieza>();
                List<BEPieza> piezasderuta = new List<BEPieza>();
                listapiezas = oBLLPieza.ListarTodo();
                if (listapiezas != null)
                {
                    foreach (BEPieza p in listapiezas)
                    {
                        if (oBERuta.Codigo == p.Ruta.Codigo)
                        {
                            piezasderuta.Add(p);
                        }
                    }
                }
                if (piezasderuta != null)
                {
                    dataGridView3.DataSource = piezasderuta;
                }
                else { MessageBox.Show("La ruta no tiene piezas cargadas"); }

            }
            else { MessageBox.Show("La ruta ingresada no existe"); }
        
       }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
