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
    public partial class GestionUsuariosForm : Form
    {
        private readonly ServicioUsuarios _servicioUsuarios;
        public GestionUsuariosForm(ServicioUsuarios servicio)
        {
            InitializeComponent();
            _servicioUsuarios = servicio;
        }

        private void GestionUsuariosForm_Load(object sender, EventArgs e)
        {
            CargarGrillaClientes();
        }

        private void CargarGrillaClientes()
        {
            // Le decimos al dgv que no cree columnas automáticamente.
            dgvClientes.AutoGenerateColumns = false;

            // Limpiamos las columnas y los datos 
            dgvClientes.Columns.Clear();
            dgvClientes.DataSource = null;

            // Creamos la columna para el nombre de usuario.
            DataGridViewTextBoxColumn columnaUsuario = new DataGridViewTextBoxColumn();
            columnaUsuario.HeaderText = "Nombre de Usuario"; // Texto de la cabecera.
            columnaUsuario.DataPropertyName = "NombreUsuario"; // Propiedad a enlazar de la clase Cliente.
            columnaUsuario.Name = "NombreUsuario";
            columnaUsuario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Para que ocupe el espacio disponible.
            dgvClientes.Columns.Add(columnaUsuario);

            // Creamos la columna con el botón para eliminar.
            DataGridViewButtonColumn columnaBoton = new DataGridViewButtonColumn();
            columnaBoton.HeaderText = "Acción";
            columnaBoton.Text = "Eliminar"; // Texto que aparecerá en cada botón.
            columnaBoton.Name = "Eliminar";
            columnaBoton.UseColumnTextForButtonValue = true; // Importante para que se muestre el texto.
            dgvClientes.Columns.Add(columnaBoton);

            // Finalmente, obtenemos la lista de clientes y la asignamos como fuente de datos.
            dgvClientes.DataSource = _servicioUsuarios.ObtenerClientes();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // verificamos que se haya hecho clic en una celda válida
            // y que esa celda sea de la columna de botones Eliminar
 
            if (e.RowIndex >= 0 && dgvClientes.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                // Obtenemos el objeto Cliente completo de la fila donde se hizo clic.
                Cliente clienteSeleccionado = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;

                // Mostramos un mensaje de confirmación 
                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar al cliente '{clienteSeleccionado.NombreUsuario}'?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Si el administrador presiona que si
                if (respuesta == DialogResult.Yes)
                {
                    // Llamamos al método del servicio
                    bool exito = _servicioUsuarios.EliminarCliente(clienteSeleccionado.NombreUsuario);

                    if (exito)
                    {
                        MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Volvemos a cargar el dgv para que el cambio se vea en el momento
                        CargarGrillaClientes();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error y no se pudo eliminar al cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
