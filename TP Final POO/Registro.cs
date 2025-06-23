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
    public partial class RegistroForm : Form
    {
        private readonly ServicioUsuarios _servicioUsuarios;
        public RegistroForm(ServicioUsuarios servicio) //Constructor del formulario
        {
            InitializeComponent();
            _servicioUsuarios = servicio;
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            string usuario = txtNuevoUsuario.Text;
            string pass = txtNuevaContraseña.Text;

            // Llamamos al método de registro actualizado
            bool exito = _servicioUsuarios.RegistrarUsuario(usuario, pass, out string mensajeError);

            if (exito)
            {
                MessageBox.Show("Se registró correctamente su usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(mensajeError, "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistroForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



}
