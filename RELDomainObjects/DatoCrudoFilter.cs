using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REL.DomainObjects
{
    public class DatoCrudoFilter
    {
        public int? IdCompania { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? IdPuntuacion { get; set; }
        public string Comentario { get; set; }
        public DateTime? FechaAltaFrom { get; set; }
        public DateTime? FechaAltaTo { get; set; }
    }
}
