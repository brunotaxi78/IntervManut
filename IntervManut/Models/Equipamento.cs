using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntervManut.Models
{
    public class Equipamento
    {
        public int EquipamentoId { get; set; }

        [Required]
        [StringLength(20)]
        public string CodEquipamento { get; set; }

        public string CodAtivo { get; set; }

        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        [ForeignKey("LinhaProd")]
        public int LinhaProdId { get; set; }

        public LinhaProd LinhaProd { get; set; }

        public ICollection<Intervencao> Intervencoes { get; set; }
    }
}
