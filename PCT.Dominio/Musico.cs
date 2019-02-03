using System;
using System.Collections.Generic;
using System.Text;

namespace PCT.Dominio
{
    public class Musico
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Instrumento Instrumentos { get; set; }
        public bool Publicar { get; set; }
        public bool EsIntegrantePermanente { get; set; }
    }
}
