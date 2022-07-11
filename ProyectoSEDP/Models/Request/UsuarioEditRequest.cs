using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSEDP.Models.Request
{
    public class UsuarioEditRequest
    {
        public int codigoUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string correoUsuario { get; set; }
        public string contrasennaUsuario { get; set; }
        public string fotoUsuario { get; set; }


    }
}
