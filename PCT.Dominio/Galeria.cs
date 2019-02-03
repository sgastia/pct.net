using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCT.Dominio
{
    public class Galeria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGaleria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public IList<ItemGaleria> Items { get; set; }
    }
}
