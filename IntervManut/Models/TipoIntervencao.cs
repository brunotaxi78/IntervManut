using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntervManut.Models
{
    public class TipoIntervencao
    {
        public int TipoIntervencaoId { get; set; }

        [Required]
        public string Descricao { get; set; }

        public ICollection<Intervencao> Intervencoes { get; set; }
    }
}
