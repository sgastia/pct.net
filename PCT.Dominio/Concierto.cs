using System;
using System.Collections.Generic;
using System.Text;

namespace PCT.Dominio
{
    public class Concierto
    {
        public List<Musico> Participantes { get; set; }
        public bool Publicar { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public System.Drawing.Bitmap Poster { get; set; }

    }
}
