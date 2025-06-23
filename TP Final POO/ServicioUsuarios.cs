using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_Final_POO
{

    public class ServicioUsuarios
    {
        private readonly string _rutaArchivo = "Acceso.txt";
        private readonly Encriptador _encriptador = new Encriptador();
        private Dictionary<string, Usuario> _usuarios;

        public ServicioUsuarios()
        {
            _usuarios = new Dictionary<string, Usuario>();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            _usuarios.Clear();

            // administradores predefinidos 
            _usuarios.Add("camila", new Administrador(0, "camila", "1234"));
            _usuarios.Add("melina", new Administrador(0, "melina", "1234"));
            _usuarios.Add("magali", new Administrador(0, "magali", "1234"));

            // Cargar usuarios desde archivo
            if (!File.Exists(_rutaArchivo))
            {
                return;
            }

            string[] lineas = File.ReadAllLines(_rutaArchivo);
            foreach (string linea in lineas)
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;

                string[] datos = linea.Split(';');

                if (datos.Length >= 3)
                {
                    int id = int.Parse(datos[0]);
                    string userDesencriptado = _encriptador.Desencriptar(datos[1]).ToLower();
                    string passDesencriptado = _encriptador.Desencriptar(datos[2]);

                    if (!_usuarios.ContainsKey(userDesencriptado))
                    {
                        // Creamos el cliente 
                        var cliente = new Cliente(id, userDesencriptado, passDesencriptado);
                        _usuarios.Add(userDesencriptado, cliente);
                    }
                }
            }
        }

        public Usuario ValidarCredenciales(string nombreUsuario, string password)
        {
            string userKey = nombreUsuario.Trim().ToLower();
            if (_usuarios.ContainsKey(userKey))
            {
                Usuario usuario = _usuarios[userKey];
                if (usuario.Password == password)
                {
                    return usuario;
                }
            }
            return null;
        }

        public bool RegistrarUsuario(string nombreUsuario, string password, out string mensajeError)
        {
            mensajeError = string.Empty;
            string userKey = nombreUsuario.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(userKey) || string.IsNullOrWhiteSpace(password))
            {
                mensajeError = "El nombre de usuario y la contraseña son obligatorios.";
                return false;
            }

            if (_usuarios.ContainsKey(userKey))
            {
                mensajeError = "El nombre de usuario ya existe.";
                return false;
            }

            try
            {
                int nuevoId = 1;
                if (File.Exists(_rutaArchivo))
                {
                    var ultimoCliente = _usuarios.Values.OfType<Cliente>().OrderByDescending(c => c.Id).FirstOrDefault();
                    if (ultimoCliente != null)
                    {
                        nuevoId = ultimoCliente.Id + 1;
                    }
                }

                // Encriptar datos 
                string userEncriptado = _encriptador.Encriptar(userKey);
                string passEncriptado = _encriptador.Encriptar(password);

                // Crear la nueva línea para el archivo (formato: ID;Usuario;Contraseña)
                string nuevaLinea = $"{nuevoId};{userEncriptado};{passEncriptado}";

                File.AppendAllText(_rutaArchivo, nuevaLinea + Environment.NewLine);

                // Agregar en memoria
                var nuevoCliente = new Cliente(nuevoId, userKey, password);
                _usuarios.Add(userKey, nuevoCliente);

                return true; // Éxito
            }
            catch (Exception)
            {
                mensajeError = "Ocurrió un error inesperado al registrar el usuario.";
                return false;
            }
        }

        public List<Cliente> ObtenerClientes()
        {
            //  Creamos una lista vacía para guardar los clientes que encontremos.
            List<Cliente> listaDeClientes = new List<Cliente>();

            // Recorremos cada usuario 
            foreach (Usuario usuario in _usuarios.Values)
            {
                // Verificamos si el usuario actual es de la clase Cliente.
                if (usuario is Cliente)
                {
                    //  Si lo es, lo convertimos a Cliente y lo agregamos a nuestra lista.
                    listaDeClientes.Add((Cliente)usuario);
                }
            }

            // Devolvemos la lista que llenamos.
            return listaDeClientes;
        }

        public bool EliminarCliente(string nombreUsuario)
        {
            string userKey = nombreUsuario.ToLower();

            // Verificamos que el usuario exista y que sea un Cliente (no se pueden borrar admins).
            if (!_usuarios.ContainsKey(userKey) || !(_usuarios[userKey] is Cliente))
            {
                return false;
            }

            try
            {
                // Eliminarlo de la lista en memoria para que la sesión actual no lo vea más.
                _usuarios.Remove(userKey);

                // Re-escribir el archivo Acceso.txt sin el usuario eliminado.
                //   Para esto crearemos una lista con las líneas de los usuarios que SÍ QUEDARON.
                List<string> lineasParaEscribir = new List<string>();

                // Recorremos todos los usuarios que quedaron en memoria.
                foreach (Usuario usuario in _usuarios.Values)
                {
                    // Solo nos interesan los clientes para re-escribir el archivo.
                    if (usuario is Cliente)
                    {
                        // Re-creamos la línea encriptada para cada cliente que queda.
                        string userEncriptado = _encriptador.Encriptar(usuario.NombreUsuario);
                        string passEncriptado = _encriptador.Encriptar(usuario.Password);
                        lineasParaEscribir.Add($"{usuario.Id};{userEncriptado};{passEncriptado}");
                    }
                }

                // Sobrescribimos el archivo con la nueva lista de usuarios (ya no contiene al eliminado).
                File.WriteAllLines(_rutaArchivo, lineasParaEscribir);

                return true;
            }
            catch (Exception)
            {
                // Si algo sale mal recarga
                
                CargarUsuarios();
                return false;
            }
        }
    }
}
