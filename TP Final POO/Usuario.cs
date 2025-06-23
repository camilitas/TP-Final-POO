using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_POO
{
    public class Usuario : ICloneable
    {
        // Propiedades comunes a todos los usuarios
        public int Id { get; protected set; } 
        public string NombreUsuario { get; protected set; }
        public string Password { get; protected set; }

        // Constructor base
        public Usuario(int id, string nombreUsuario, string password)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            Password = password;
        }

        //  POLIMORFISMO
        // Cada clase hija puede dar su propia implementación.
        public virtual string ObtenerDescripcionRol()
        {
            return "Usuario del sistema";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
