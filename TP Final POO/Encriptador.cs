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
            byte[] encriptado = Encoding.UTF8.GetBytes(texto); 
            return Convert.ToBase64String(encriptado);
        }

        public string Desencriptar(string texto)
        {
            byte[] datos = Convert.FromBase64String(texto);
            return Encoding.UTF8.GetString(datos); 
        } 
    }

}

