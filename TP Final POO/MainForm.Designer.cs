
namespace TP_Final_POO
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarNuevaMedicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarMedicionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.registrarNuevaMedicionToolStripMenuItem,
            this.consultarMedicionesToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.menuToolStripMenuItem.Text = "Cerrar Sesión";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // registrarNuevaMedicionToolStripMenuItem
            // 
            this.registrarNuevaMedicionToolStripMenuItem.Name = "registrarNuevaMedicionToolStripMenuItem";
            this.registrarNuevaMedicionToolStripMenuItem.Size = new System.Drawing.Size(153, 20);
            this.registrarNuevaMedicionToolStripMenuItem.Text = "Registrar nueva medicion";
            this.registrarNuevaMedicionToolStripMenuItem.Click += new System.EventHandler(this.registrarNuevaMedicionToolStripMenuItem_Click);
            // 
            // consultarMedicionesToolStripMenuItem
            // 
            this.consultarMedicionesToolStripMenuItem.Name = "consultarMedicionesToolStripMenuItem";
            this.consultarMedicionesToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.consultarMedicionesToolStripMenuItem.Text = "Consultar mediciones";
            this.consultarMedicionesToolStripMenuItem.Click += new System.EventHandler(this.consultarMedicionesToolStripMenuItem_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(20, 332);
            this.lblBienvenida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(35, 13);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "label1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarClientesToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.adminToolStripMenuItem.Text = "Administración";
            // 
            // gestionarClientesToolStripMenuItem
            // 
            this.gestionarClientesToolStripMenuItem.Name = "gestionarClientesToolStripMenuItem";
            this.gestionarClientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gestionarClientesToolStripMenuItem.Text = "Gestionar Clientes";
            this.gestionarClientesToolStripMenuItem.Click += new System.EventHandler(this.gestionarClientesToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarNuevaMedicionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarMedicionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarClientesToolStripMenuItem;
    }
}