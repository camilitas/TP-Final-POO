using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_POO
{
    //Centraliza toda la lógica de lectura y escritura del archivo Mediciones.csv
    public class GestorDeDatos
    {
        // 'const' significa que el valor de esta variable no puede cambiar.
        private const string _rutaArchivo = "Mediciones.csv";

        //Guarda una medicion en el archivo
        public void GuardarMedicion(Medicion medicion)
        {
            // 'using' asegura que el archivo se cierre correctamente, incluso si hay un error.
            // 'StreamWriter' es la clase para escribir en archivos de texto.
            // FileMode.Append para agregar al final sin borrar lo anterior
            using (StreamWriter sw = new StreamWriter(_rutaArchivo, true))
            {
                // Llama al método ToCsv() del objeto medicion y escribe la línea resultante.
                sw.WriteLine(medicion.ToCsv());
            }
        }

        public List<Medicion> LeerTodasLasMediciones()
        {
            List<Medicion> mediciones = new List<Medicion>();

            if (!File.Exists(_rutaArchivo))
            {
                return mediciones; // Devuelve lista vacía si no existe el archivo
            }

            var lineas = File.ReadAllLines(_rutaArchivo).Where(line => !string.IsNullOrWhiteSpace(line));

            // Recorre cada línea leída.
            foreach (var linea in lineas)
            {
                // Usa el método que creamos en Medicion para convertir la línea de texto a un objeto.
                mediciones.Add(Medicion.FromCsv(linea));
            }

            return mediciones;
        }
    }
}
