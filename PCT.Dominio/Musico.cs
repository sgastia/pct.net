using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCT.Dominio
{
    public class Musico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMusico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Instrumento Instrumentos { get; set; }
        public bool Publicar { get; set; }
        public bool EsIntegrantePermanente { get; set; }
        public IList<ConciertoMusico> Conciertos { get; set; }
    }
}
