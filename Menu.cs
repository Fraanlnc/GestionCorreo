using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSucursales formSuc = new frmSucursales();
            formSuc.MdiParent = this;
            formSuc.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleados formEmpleados = new frmEmpleados();
            formEmpleados.MdiParent = this;
            formEmpleados.Show();
        }

        private void creacionDeRutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRutas formRutas = new frmRutas();
            formRutas.MdiParent = this;
            formRutas.Show();
        }

        private void asignacionEntregasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignacion formAsig = new frmAsignacion();
            formAsig.MdiParent = this;
            formAsig.Show();
        }

        private void graficoTortaChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void reportViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInformesRV formRV = new frmInformesRV();
            formRV.MdiParent = this;
            formRV.Show();
        }

        private void aBMLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMLogin formabmlog = new frmABMLogin();
            formabmlog.MdiParent = this;
            formabmlog.Show();
        }

        private void sancionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanciones formsanciones = new frmSanciones();
            formsanciones.MdiParent = this;
            formsanciones.Show();
        }

        private void estadoDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInforme forminfo = new frmInforme();
            forminfo.MdiParent = this;
            forminfo.Show();
        }
    }
}
