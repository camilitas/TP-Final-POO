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
    //Permitir al usuario buscar, filtrar y analizar los datos guardados.
    public partial class ConsultarMedicion : Form
    {
        private GestorDeDatos gestorDeDatos;
        // --- Lista para mantener TODOS los datos en memoria ---
        private List<Medicion> todasLasMediciones;
        public ConsultarMedicion()
        {
            InitializeComponent();
            gestorDeDatos = new GestorDeDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultarMedicion_Load(object sender, EventArgs e)
        {
            // 1. Cargar todos los datos del CSV a nuestra lista en memoria
            todasLasMediciones = gestorDeDatos.LeerTodasLasMediciones();

            // 2. Configurar los controles de filtro
            ConfigurarFiltros();

            // 3. Aplicar el filtro inicial para mostrar todos los datos al principio
            AplicarFiltros();
        }

        private void ConfigurarFiltros()
        {
            // Llenar el ComboBox de localidades
            cmbLocalidades.Items.Add("-- Todas --"); // Opción para no filtrar por localidad

            // Obtenemos las localidades únicas de nuestras mediciones (sin repeticiones)
            var localidadesUnicas = todasLasMediciones.Select(m => m.Localidad).Distinct();
            foreach (var loc in localidadesUnicas)
            {
                cmbLocalidades.Items.Add(loc);
            }
            cmbLocalidades.SelectedIndex = 0; // Seleccionar "-- Todas --" por defecto

            // Establecer fechas por defecto (ej: el último mes)
            dtpFechaHasta.Value = DateTime.Now;
            dtpFechaDesde.Value = DateTime.Now.AddMonths(-1);
        }

        private void AplicarFiltros()
        {
            // Empezamos con la lista completa de mediciones
            IEnumerable<Medicion> medicionesFiltradas = todasLasMediciones;

            // --- Filtrado con LINQ ---

            // 1. Filtrar por Localidad (si no se eligió "-- Todas --")
            if (cmbLocalidades.SelectedIndex > 0)
            {
                string localidadSeleccionada = cmbLocalidades.SelectedItem.ToString();
                medicionesFiltradas = medicionesFiltradas.Where(m => m.Localidad == localidadSeleccionada);
            }

            // 2. Filtrar por Rango de Fechas
            DateTime fechaDesde = dtpFechaDesde.Value.Date; // Ignoramos la hora
            DateTime fechaHasta = dtpFechaHasta.Value.Date.AddDays(1).AddTicks(-1); // Hasta el final del día

            medicionesFiltradas = medicionesFiltradas.Where(m => m.FechaHoraMedicion >= fechaDesde && m.FechaHoraMedicion <= fechaHasta);

            // --- Actualizar la Interfaz ---

            // Convertimos el resultado a una Lista para usarla
            List<Medicion> resultadoFinal = medicionesFiltradas.ToList();

            // 3. Actualizar el DataGridView
            dgvResultados.DataSource = null;
            dgvResultados.DataSource = resultadoFinal;

            // Opcional: Personalizar columnas (igual que en el form anterior)
            if (dgvResultados.Columns.Count > 0)
            {
                dgvResultados.Columns["Localidad"].HeaderText = "Localidad";
                dgvResultados.Columns["FechaHoraMedicion"].HeaderText = "Fecha de Medición";
                dgvResultados.Columns["FechaHoraMedicion"].DefaultCellStyle.Format = "g";
                dgvResultados.Columns["CantidadAgua"].HeaderText = "Agua caída (mm)";
                dgvResultados.Columns["Responsable"].HeaderText = "Registrado por";
                dgvResultados.Columns["FechaHoraRegistro"].HeaderText = "Fecha de Registro";
                dgvResultados.Columns["FechaHoraRegistro"].DefaultCellStyle.Format = "g";
            }


            // 4. Calcular y mostrar la suma total de la lluvia filtrada
            double sumaLluvia = resultadoFinal.Sum(m => m.CantidadAgua);
            lblTotalLluvia.Text = $"Total de lluvia filtrada: {sumaLluvia:F2} mm"; // F2 formatea a 2 decimales
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void ConsultarMedicion_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }

        private void btnBuscarMaxPorHora_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos la hora seleccionada por el usuario
            int horaSeleccionada = (int)numHora.Value;

            // 2. Usamos LINQ sobre la lista que ya tenemos en memoria (todasLasMediciones)
            Medicion medicionMaxima = todasLasMediciones
                                        .Where(m => m.FechaHoraMedicion.Hour == horaSeleccionada)
                                        .OrderByDescending(m => m.CantidadAgua)
                                        .FirstOrDefault();

            // 3. Mostramos el resultado en el Label
            if (medicionMaxima != null)
            {
                lblResultadoHora.Text = $"Resultado: A las {horaSeleccionada}:00 hs, la localidad con más lluvia fue " +
                                      $"{medicionMaxima.Localidad} con {medicionMaxima.CantidadAgua} mm.";
            }
            else
            {
                lblResultadoHora.Text = $"Resultado: No se encontraron registros de lluvia para las {horaSeleccionada}:00 hs.";
            }
        
        }
    }
}
