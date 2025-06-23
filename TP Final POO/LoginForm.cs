using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TP_Final_POO
{
    public partial class LoginForm : Form
    {
        private readonly ServicioUsuarios _servicioUsuarios;
        private Dictionary<string, Usuario> usuarios;
        public LoginForm()
        {
            InitializeComponent();
           
            _servicioUsuarios = new ServicioUsuarios();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool archivoExiste = File.Exists("Acceso.txt");
            txtUsuario.Enabled = archivoExiste;
            txtContraseña.Enabled = archivoExiste;
            btnLogin.Enabled = archivoExiste;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Delegamos la validación al servicio
            Usuario usuarioValidado = _servicioUsuarios.ValidarCredenciales(txtUsuario.Text, txtContraseña.Text);

            if (usuarioValidado != null)
            {
                // Éxito
                this.Hide();
                // Pasamos el objeto (puede ser Admin o Cliente) al siguiente formulario.
                MainForm mainForm = new MainForm(usuarioValidado, _servicioUsuarios);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtUsuario.Focus();
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            RegistroForm registro = new RegistroForm(_servicioUsuarios);
            registro.ShowDialog();
        }
    }


}
