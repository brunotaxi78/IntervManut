using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntervManut.Models
{
    public class TipoTec
    {
        public int TipoTecId { get; set; }

        public string Tipo { get; set; }

        public ICollection<Tecnico> Tecnicos { get; set; }
    }
}
