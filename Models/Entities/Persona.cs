using System;
using System.Collections.Generic;

namespace personapi_dotnet.Models.Entities
{
    public partial class Persona
    {
        public int Cc { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Genero { get; set; } = null!;
        public byte? Edad { get; set; }
    }
}
