using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REL.DomainObjects
{
    public class UsuarioValidacion
    {
        public int? IdPersona { get; set; }
        public string Result { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? IdCompania { get; set; }
    }
}
