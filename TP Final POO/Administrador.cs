using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Final_POO
{
    public class Administrador : Usuario
    {
        
        public Administrador(int id, string nombreUsuario, string password)
            : base(id, nombreUsuario, password)
        {
        }

        
        public override string ObtenerDescripcionRol()
        {
            return "Administrador";
        }
    }
}
