using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCT.Dominio
{
    /// <summary>
    /// Foto o video de una galeria
    /// </summary>
    public class ItemGaleria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdItemGaleria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Link { get; set; }
    }
}
