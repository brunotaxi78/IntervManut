using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntervManut.Models
{
    public class LinhaProd
    {
        public int LinhaProdId { get; set; }

        [Required]
        public string CodLinha { get; set; }

        public string Descricao { get; set; }

        public ICollection<Equipamento> Equioamentos { get; set; }
    }
}
