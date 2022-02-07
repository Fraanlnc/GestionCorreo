
namespace TP2
{
    partial class Menu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creacionDeRutasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignacionEntregasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sancionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.gestionToolStripMenuItem,
            this.informesToolStripMenuItem,
            this.sancionesToolStripMenuItem,
            this.sistemaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sucursalesToolStripMenuItem,
            this.empleadosToolStripMenuItem,
            this.creacionDeRutasToolStripMenuItem,
            this.asignacionEntregasToolStripMenuItem});
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            this.gestionToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.gestionToolStripMenuItem.Text = "Gestion";
            // 
            // sucursalesToolStripMenuItem
            // 
            this.sucursalesToolStripMenuItem.Name = "sucursalesToolStripMenuItem";
            this.sucursalesToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.sucursalesToolStripMenuItem.Text = "Sucursales";
            this.sucursalesToolStripMenuItem.Click += new System.EventHandler(this.sucursalesToolStripMenuItem_Click);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // creacionDeRutasToolStripMenuItem
            // 
            this.creacionDeRutasToolStripMenuItem.Name = "creacionDeRutasToolStripMenuItem";
            this.creacionDeRutasToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.creacionDeRutasToolStripMenuItem.Text = "Creacion de Rutas";
            this.creacionDeRutasToolStripMenuItem.Click += new System.EventHandler(this.creacionDeRutasToolStripMenuItem_Click);
            // 
            // asignacionEntregasToolStripMenuItem
            // 
            this.asignacionEntregasToolStripMenuItem.Name = "asignacionEntregasToolStripMenuItem";
            this.asignacionEntregasToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.asignacionEntregasToolStripMenuItem.Text = "Asignacion/Entregas";
            this.asignacionEntregasToolStripMenuItem.Click += new System.EventHandler(this.asignacionEntregasToolStripMenuItem_Click);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportViewerToolStripMenuItem,
            this.estadoDelSistemaToolStripMenuItem});
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // reportViewerToolStripMenuItem
            // 
            this.reportViewerToolStripMenuItem.Name = "reportViewerToolStripMenuItem";
            this.reportViewerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.reportViewerToolStripMenuItem.Text = "ReportViewer";
            this.reportViewerToolStripMenuItem.Click += new System.EventHandler(this.reportViewerToolStripMenuItem_Click);
            // 
            // sancionesToolStripMenuItem
            // 
            this.sancionesToolStripMenuItem.Name = "sancionesToolStripMenuItem";
            this.sancionesToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.sancionesToolStripMenuItem.Text = "SancionesXML";
            this.sancionesToolStripMenuItem.Click += new System.EventHandler(this.sancionesToolStripMenuItem_Click);
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMLoginToolStripMenuItem});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // aBMLoginToolStripMenuItem
            // 
            this.aBMLoginToolStripMenuItem.Name = "aBMLoginToolStripMenuItem";
            this.aBMLoginToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.aBMLoginToolStripMenuItem.Text = "ABM Login";
            this.aBMLoginToolStripMenuItem.Click += new System.EventHandler(this.aBMLoginToolStripMenuItem_Click);
            // 
            // estadoDelSistemaToolStripMenuItem
            // 
            this.estadoDelSistemaToolStripMenuItem.Name = "estadoDelSistemaToolStripMenuItem";
            this.estadoDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.estadoDelSistemaToolStripMenuItem.Text = "Horas Caminadas";
            this.estadoDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.estadoDelSistemaToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucursalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creacionDeRutasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignacionEntregasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sancionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadoDelSistemaToolStripMenuItem;
    }
}

