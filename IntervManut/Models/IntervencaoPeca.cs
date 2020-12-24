using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntervManut.Models
{
    public class IntervencaoPeca
    {
        public int IntervencaoPecaId { get; set; }

        [ForeignKey("Inervencao")]
        public int IntervencaoId { get; set; }

        public Intervencao Intervencao { get; set; }

        [ForeignKey("Peca")]
        public int PecaId { get; set; }

        public Peca Peca { get; set; }
    }
}
