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
        private Dictionary<string, Usuario> usuarios;
        public LoginForm()
        {
            InitializeComponent();
            InicializarUsuarios();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("Acceso.txt"))
            {
                txtUsuario.Enabled = true;
                txtContraseña.Enabled = true;
                btnLogin.Enabled = true;
            }
            else
            {
                txtUsuario.Enabled = false;
                txtContraseña.Enabled = false;
                btnLogin.Enabled = false;
            }
        }

        private void InicializarUsuarios()
        {
            usuarios = new Dictionary<string, Usuario>();

            // Agregamos administradoras predefinidas
            usuarios.Add("camila", new Usuario("Camila Aguilera", "1234", Rol.ADMIN));
            usuarios.Add("melina", new Usuario("Melina Esquivel", "1234", Rol.ADMIN));
            usuarios.Add("magali", new Usuario("Magali Dargenzio", "1234", Rol.ADMIN));

            // Cargar usuarios desde archivo
            if (File.Exists("Acceso.txt"))
            {
                Encriptador encriptador = new Encriptador();
                string[] lineas = File.ReadAllLines("Acceso.txt");

                foreach (string linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;

                    string[] datos = linea.Split(';');

                    // Esperamos: ID;Usuario;Contraseña;NombreCompleto
                    if (datos.Length >= 4)
                    {
                        string userDesencriptado = encriptador.Desencriptar(datos[1]).ToLower();
                        string passDesencriptado = encriptador.Desencriptar(datos[2]);
                        string nombreCompleto = encriptador.Desencriptar(datos[3]);

                        if (!usuarios.ContainsKey(userDesencriptado))
                        {
                            usuarios.Add(userDesencriptado, new Usuario(nombreCompleto, passDesencriptado, Rol.CLIENTE));
                        }
                    }
                }
            }

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

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            RegistroForm registro = new RegistroForm(usuarios); //Abre el form de registro
            registro.ShowDialog();
            InicializarUsuarios();
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
