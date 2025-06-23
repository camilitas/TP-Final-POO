using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_POO
{
    //Define la estructura de un único registro de lluvia.

    public class Medicion : IComparable
    {
        public Guid Id { get; private set; }
        public string Localidad { get; set; }
        public DateTime FechaHoraMedicion { get; set; }
        public double CantidadAgua { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaHoraRegistro { get; set; } // La hora en que se guarda el dato

        // Constructor para facilitar la creación de objetos
        public Medicion(string localidad, DateTime fechaHoraMedicion, double cantidadAgua, string responsable)
        {
            Id = Guid.NewGuid(); // Se genera un ID único automáticamente.
            Localidad = localidad;
            FechaHoraMedicion = fechaHoraMedicion;
            CantidadAgua = cantidadAgua;
            Responsable = responsable;
            FechaHoraRegistro = DateTime.Now;
        }

        private Medicion() { }

         public int CompareTo(object obj)
    {
        // Primero, verificamos que el objeto con el que comparamos no sea nulo
        // y que sea del tipo Medicion.
        if (obj == null) return 1;

        if (obj is Medicion otraMedicion)
        {
            // Esto ordenará las mediciones por fecha, de la más antigua a la más nueva.
            return this.FechaHoraMedicion.CompareTo(otraMedicion.FechaHoraMedicion);
        }
        else
        {
            // Si intentan compararlo con algo que no es una Medicion, figura error
            throw new ArgumentException("El objeto a comparar no es una Medicion.");
        }
    }

        // Método para convertir el objeto a texto para el CSV
        public string ToCsv()
        {
            return $"{Id};{Localidad};{FechaHoraMedicion:O};{CantidadAgua};{Responsable};{FechaHoraRegistro:O}";
        }

        // Método estático para crear un objeto Medicion desde una línea de CSV
        public static Medicion FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';'); // Divide la linea en partes usando ; como separador

            Medicion medicion = new Medicion();

            // Asignamos las propiedades desde los valores del CSV.
            medicion.Id = Guid.Parse(values[0]); // Leemos el ID desde el archivo.
            medicion.Localidad = values[1];
            medicion.FechaHoraMedicion = DateTime.Parse(values[2]);
            medicion.CantidadAgua = double.Parse(values[3]);
            medicion.Responsable = values[4];
            medicion.FechaHoraRegistro = DateTime.Parse(values[5]);

            return medicion;
        }

    }
}
