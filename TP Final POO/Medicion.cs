using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_POO
{
    //Define la estructura de un único registro de lluvia.
    //propiedades de Medicion
    public class Medicion
    {
        public string Localidad { get; set; }
        public DateTime FechaHoraMedicion { get; set; }
        public double CantidadAgua { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaHoraRegistro { get; set; } // La hora en que se guarda el dato

        // Constructor para facilitar la creación de objetos
        public Medicion(string localidad, DateTime fechaHoraMedicion, double cantidadAgua, string responsable)
        {
            Localidad = localidad;
            FechaHoraMedicion = fechaHoraMedicion;
            CantidadAgua = cantidadAgua;
            Responsable = responsable;
            FechaHoraRegistro = DateTime.Now; // Se asigna automáticamente al crear el registro
        }

        // Método para convertir el objeto a texto para el CSV
        public string ToCsv()
        {
            return $"{Localidad};{FechaHoraMedicion:O};{CantidadAgua};{Responsable};{FechaHoraRegistro:O}";
        }

        // Método estático para crear un objeto Medicion desde una línea de CSV
        public static Medicion FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';'); // Divide la linea en partes usando ; como separador
            string localidad = values[0];
            DateTime fechaHoraMedicion = DateTime.Parse(values[1]);
            double cantidadAgua = double.Parse(values[2]);
            string responsable = values[3];

            // Creamos el objeto usando el constructor
            Medicion medicion = new Medicion(localidad, fechaHoraMedicion, cantidadAgua, responsable);

            // Asignamos la fecha de registro que viene del archivo
            medicion.FechaHoraRegistro = DateTime.Parse(values[4]);

            return medicion;
        }

    }
}
