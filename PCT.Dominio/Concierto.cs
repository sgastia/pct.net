using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCT.Dominio
{
    public class Concierto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConcierto { get; set; }
        public IList<ConciertoMusico> Musicos { get; set; }
        public bool Publicar { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string UrlPoster { get; set; }
        public DateTime Fecha { get; set; }
    }
}
