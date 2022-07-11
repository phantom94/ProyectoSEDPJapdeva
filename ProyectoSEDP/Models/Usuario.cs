using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoSEDP.Models
{
    public partial class Usuario
    {
        public int CodigoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string ContrasennaUsuario { get; set; }
        public string FotoUsuario { get; set; }
    }
}
