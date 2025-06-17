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
        private Dictionary<string, Usuario> usuarios; //Declara una variable privada que representa la lista de usuarios del sistema.
        public RegistroForm(Dictionary<string, Usuario> usuarios) //Constructor del formulario
        {
            InitializeComponent(); //Llama al metodo que inicializa los controles del formulario
            this.usuarios = usuarios; //asigna el diccionario de usuarios que viene como parámetro del constructor (usuarios) a la variable privada de la clase llamada también usuarios.
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            string Reg = string.Empty; //linea a escribir del archivo
            Encriptador textoEncriptar = new Encriptador(); //encriptar datos del usuario

            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("Debe ingresar su nombre completo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return;
            }


            if (txtNuevoUsuario.Text != "") //verifica que el campo de nombre no este vacio
            {
                if (txtNuevaContraseña.Text != "") //verifica que el campo de contraseña no este vacio
                {
                    if (File.Exists("Acceso.txt"))
                    {
                        int id = 1; // Valor inicial

                        if (File.Exists("Acceso.txt"))
                        {
                            string[] lineas = File.ReadAllLines("Acceso.txt");

                            // Buscar la última línea válida que no esté vacía
                            string ultimaLinea = lineas.Reverse().FirstOrDefault(linea => !string.IsNullOrWhiteSpace(linea));

                            if (!string.IsNullOrEmpty(ultimaLinea))
                            {
                                string[] datos = ultimaLinea.Split(';');
                                if (datos.Length > 0 && int.TryParse(datos[0], out int ultimoId))
                                {
                                    id = ultimoId + 1;
                                }
                            }
                        }



                        //escribir el nuevo registro
                        FileStream archivo1 = new FileStream("Acceso.txt", FileMode.Append); //se abre el archivo en modo agregar
                        StreamWriter escritor = new StreamWriter(archivo1);
                        Reg = Convert.ToString(id) + ";" +
                              textoEncriptar.Encriptar(txtNuevoUsuario.Text) + ";" +
                              textoEncriptar.Encriptar(txtNuevaContraseña.Text) + ";" +
                              textoEncriptar.Encriptar(txtNombreCompleto.Text);
                        escritor.WriteLine(Reg);
                        MessageBox.Show("Se registro correctamente su usuario.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        txtNuevoUsuario.Text = "";
                        txtNombreCompleto.Text = "";
                        txtNuevaContraseña.Text = "";
                        txtNuevoUsuario.Focus();

                        escritor.Close();
                        archivo1.Close();


                    }
                    else
                    {
                        FileStream archivo = new FileStream("Acceso.txt", FileMode.Append);
                        StreamWriter escritor = new StreamWriter(archivo);
                        Reg = "1;" + textoEncriptar.Encriptar(txtNuevoUsuario.Text) + ";" + textoEncriptar.Encriptar(txtNuevaContraseña.Text);

                        MessageBox.Show("Se registro correctamente su usuario.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        txtNuevoUsuario.Text = "";
                        txtNuevaContraseña.Text = "";
                        txtNuevoUsuario.Focus();




                        escritor.Close();
                        archivo.Close();
                    }

                }

                else
                {
                    MessageBox.Show("Debe ingresar una contraseña", "Advertencia !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNuevaContraseña.Focus();
                }

            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre de usuario", "Advertencia !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevoUsuario.Focus();
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
