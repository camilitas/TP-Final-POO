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
    public partial class RegistroMedicion : Form
    {
        private Usuario usuarioLogueado;
        private GestorDeDatos gestorDeDatos;

        public RegistroMedicion(Usuario usuario)
        {
            InitializeComponent();
            usuarioLogueado = usuario;
            gestorDeDatos = new GestorDeDatos();

            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegistroMedicion_FormClosed);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void RegistroMedicion_Load(object sender, EventArgs e)
        {
            cmbLocalidades.Items.Add("La Plata");
            cmbLocalidades.Items.Add("Quilmes");
            cmbLocalidades.Items.Add("Avellaneda");
            cmbLocalidades.Items.Add("Lanús");
            cmbLocalidades.Items.Add("Lomas de Zamora");

            if (cmbLocalidades.Items.Count > 0)
            {
                cmbLocalidades.SelectedIndex = 0;
            }

            // Mostramos el nombre del responsable 
            txtResponsable.Text = usuarioLogueado.NombreUsuario;

            // Configuramos el DateTimePicker 
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.CustomFormat = "dd/MM/yyyy HH:00";

            dgvMediciones.Columns["Eliminar"].Visible = usuarioLogueado is Administrador;
            CargarDatosEnGrid();


        }

        private void CargarDatosEnGrid()
        {
            
            List<Medicion> mediciones = gestorDeDatos.LeerTodasLasMediciones();

            
            // El DataGridView crea las columnas basándose en las propiedades de la clase Medicion
            dgvMediciones.DataSource = null; // Limpiamos la fuente de datos anterior
            dgvMediciones.DataSource = mediciones;

            
            if (dgvMediciones.Columns.Count > 0)
            {
                dgvMediciones.Columns["Localidad"].HeaderText = "Localidad";
                dgvMediciones.Columns["FechaHoraMedicion"].HeaderText = "Fecha de Medición";
                dgvMediciones.Columns["FechaHoraMedicion"].DefaultCellStyle.Format = "g"; // Formato de fecha corta y hora
                dgvMediciones.Columns["CantidadAgua"].HeaderText = "Agua caída (mm)";
                dgvMediciones.Columns["Responsable"].HeaderText = "Registrado por";
                dgvMediciones.Columns["FechaHoraRegistro"].HeaderText = "Fecha de Registro";
                dgvMediciones.Columns["FechaHoraRegistro"].DefaultCellStyle.Format = "g";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //  validaciones 
            if (cmbLocalidades.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una localidad.", "Dato Faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numCantidadAgua.Value <= 0)
            {
                MessageBox.Show("La cantidad de agua debe ser mayor a cero.", "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Inicio alerta

            // Definimos un límite. Si la diferencia con la medición anterior supera esto, alertamos.
            const double LIMITE_ALERTA_MM = 100.0;

            string localidadSeleccionada = cmbLocalidades.SelectedItem.ToString();
            double cantidadActual = (double)numCantidadAgua.Value;

            // Leemos las mediciones existentes para buscar la última de esta localidad
            var medicionesAnteriores = gestorDeDatos.LeerTodasLasMediciones();

            // Usamos LINQ para encontrar la última medición para la localidad seleccionada
            Medicion ultimaMedicion = medicionesAnteriores
                                        .Where(m => m.Localidad == localidadSeleccionada)
                                        .OrderByDescending(m => m.FechaHoraMedicion)
                                        .FirstOrDefault();

            if (ultimaMedicion != null)
            {
                // Si encontramos una medición anterior, calculamos la diferencia
                double diferencia = Math.Abs(cantidadActual - ultimaMedicion.CantidadAgua);

                if (diferencia > LIMITE_ALERTA_MM)
                {
                    // La diferencia es muy grande, mostramos una advertencia con opción de continuar o cancelar
                    DialogResult respuesta = MessageBox.Show(
                        $"Alerta: La cantidad de lluvia ({cantidadActual} mm) es drásticamente diferente a la última medición ({ultimaMedicion.CantidadAgua} mm) para {localidadSeleccionada}.\n\n¿Está seguro de que desea registrar este valor?",
                        "Posible Medición Anormal",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    // Si el usuario presiona "No", detenemos el proceso de guardado
                    if (respuesta == DialogResult.No)
                    {
                        return; // Salimos del método
                    }
                }
            }
            // Acá termina la alerta


            // Si llegamos hasta acá, es porque la medición es normal o el usuario confirmó guardarla
            var nuevaMedicion = new Medicion(
                localidad: localidadSeleccionada,
                fechaHoraMedicion: dtpFechaHora.Value,
                cantidadAgua: cantidadActual,
                responsable: usuarioLogueado.NombreUsuario
            );

            try
            {
                gestorDeDatos.GuardarMedicion(nuevaMedicion);
                MessageBox.Show("¡Medición registrada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                numCantidadAgua.Value = 0;
                cmbLocalidades.SelectedIndex = 0;
                dtpFechaHora.Value = DateTime.Now;

                CargarDatosEnGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistroMedicion_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }

        private void RegistroMedicion_FormClosed_1(object sender, FormClosedEventArgs e)
        {

        }

        private void dgvMediciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se hizo clic en una celda  de la columna Eliminar.
            
            if (e.RowIndex >= 0 && dgvMediciones.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                // Pedimos confirmación para evitar borrados accidentales.
                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de que desea eliminar esta medición?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    // Obtenemos el objeto Medicion completo de la fila en la que se hizo clic.
                    Medicion medicionSeleccionada = (Medicion)dgvMediciones.Rows[e.RowIndex].DataBoundItem;

                    // Llamamos al método del gestor para eliminarla usando su ID único.
                    gestorDeDatos.EliminarMedicion(medicionSeleccionada.Id);

                    // Recargamos el dgv para que se vea el cambio al instante.
                    CargarDatosEnGrid();

                    MessageBox.Show("Medición eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
