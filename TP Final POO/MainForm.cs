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
        private ServicioUsuarios _servicioUsuarios;
        public MainForm(Usuario usuario, ServicioUsuarios servicio)
        {
            InitializeComponent();
            usuarioActual = usuario;
            _servicioUsuarios = servicio;
            lblBienvenida.Text = $"Bienvenido/a {usuario.NombreUsuario} - Rol: {usuario.ObtenerDescripcionRol()}";
            // Hacemos visible el menú de admin solo si el usuario es de tipo Administrador.
            adminToolStripMenuItem.Visible = usuarioActual is Administrador;
            consultarMedicionesToolStripMenuItem.Visible = usuarioActual is Cliente;
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

        private void registrarNuevaMedicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            RegistroMedicion medicion = new RegistroMedicion(usuarioActual);
            medicion.Show();
        }

        private void consultarMedicionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            ConsultarMedicion consultar = new ConsultarMedicion();
            consultar.Show();
        }

        private void gestionarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionUsuariosForm formGestion = new GestionUsuariosForm(_servicioUsuarios);
            formGestion.ShowDialog(); 
        }
    }
}
