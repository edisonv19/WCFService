using System;

namespace REL.DomainObjects
{
    public class VotoFilter
    {
        public int? IdPersona { get; set; }
        public string Puntuacion { get; set; }
        public string Comentario { get; set; }

        public DateTime? FechaAltaFrom { get; set; }
        public DateTime? FechaAltaTo { get; set; }
    }
}
