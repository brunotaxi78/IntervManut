using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntervManut.Models
{
    public class TecnicoIntervencao
    {
        public int TecnicoIntervencaoId { get; set; }

        [ForeignKey("Tecnico")]
        public int TecnicoId { get; set; }

        public Tecnico Tecnico { get; set; }

        [ForeignKey("Intervecao")]
        public int IntervencaoId { get; set; }

        public Intervencao Intervencao { get; set; }
    }
}
