using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_Final_POO
{
    public class Encriptador
    {
        public string Encriptar(string texto)
        {
            string resultado = string.Empty;
            byte[] encriptado = System.Text.Encoding.Unicode.GetBytes(texto);
            resultado = Convert.ToBase64String(encriptado);
            return resultado;
        }
    }
}

