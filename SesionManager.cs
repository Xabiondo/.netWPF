using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xabiOFICIAL
{
    public static class SesionManager
    {
        public static Usuario UsuarioLogueado { get; set; }

        public static void IniciarSesion(Usuario usuario)
        {
            UsuarioLogueado = usuario;
        }

        public static void CerrarSesion()
        {
            UsuarioLogueado = null;
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string UsuarioNombre { get; set; }
        public string Correo { get; set; }

        public Usuario(int id, string usuarioNombre, string correo)
        {
            Id = id;
            UsuarioNombre = usuarioNombre;
            Correo = correo;
        }
    }
}