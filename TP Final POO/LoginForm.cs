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
    public partial class LoginForm : Form
    {
        private Dictionary<string, Usuario> usuarios;
        public LoginForm()
        {
            InitializeComponent();
            InicializarUsuarios();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InicializarUsuarios()
        {
            usuarios = new Dictionary<string, Usuario>();

            // Agregamos administradoras
            usuarios.Add("camila", new Usuario("Camila Aguilera", "1234", Rol.ADMIN));
            usuarios.Add("melina", new Usuario("Melina Esquivel", "1234", Rol.ADMIN));
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete ambos campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string user = txtUsuario.Text.Trim().ToLower();
            string pass = txtContraseña.Text;

            if (usuarios.ContainsKey(user))
            {
                Usuario usuario = usuarios[user];

                if (usuario.Password == pass)
                {
                    // Éxito
                    this.Hide();
                    MainForm mainForm = new MainForm(usuario);
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContraseña.Clear();
                }
            }
            else
            {
                MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
            }
        }
    }

    public enum Rol
    {
        ADMIN,
        SUPER_USUARIO,
        CLIENTE
    }

    public class Usuario
    {
        public string Nombre { get; set; }
        public string Password { get; set; }
        public Rol RolUsuario { get; set; }

        public Usuario(string nombre, string password, Rol rol)
        {
            Nombre = nombre;
            Password = password;
            RolUsuario = rol;
        }
    }
}
