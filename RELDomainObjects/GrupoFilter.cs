using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REL.DomainObjects
{
    public class GrupoFilter
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdPersona { get; set; }
        public int? IdCompania { get; set; }

        public DateTime? FechaAltaFrom { get; set; }
        public DateTime? FechaAltaTo { get; set; }
    }
}
