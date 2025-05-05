using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_Final_POO
{
    public partial class MainForm : Form
    {
        private Usuario usuarioActual;
        public MainForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            lblBienvenida.Text = $"Bienvenido/a {usuario.Nombre} - Rol: {usuario.RolUsuario}";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Oculta el formulario principal y vuelve al login
            this.Hide();

            // Mostrar nuevamente el login
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
