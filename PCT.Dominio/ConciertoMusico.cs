using System;
using System.Collections.Generic;
using System.Text;

namespace PCT.Dominio
{
    /// <summary>
    /// Many to many entre conciertos y musicos
    /// http://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx
    /// https://github.com/aspnet/EntityFrameworkCore/issues/1368
    /// </summary>
    public class ConciertoMusico
    {
        public Concierto Concierto { get; set; }
        public Musico Musico { get; set; }
        public int MusicoId { get; set; }
        public int ConciertoId { get; set; }
    }
}
