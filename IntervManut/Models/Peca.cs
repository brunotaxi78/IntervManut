using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntervManut.Models
{
    public class Peca
    {
        public int PecaId { get; set; }

        public string CodPeca { get; set; }

        [Required]
        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public ICollection<IntervencaoPeca> IntervencoesPecas { get; set; }
    }
}
