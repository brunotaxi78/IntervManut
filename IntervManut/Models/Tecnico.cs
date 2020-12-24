using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntervManut.Models
{
    public class Tecnico
    {
        public int TecnicoId { get; set; }

        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        public string Empresa { get; set; }

        [ForeignKey("TipoTec")]
        public int TipoTecId { get; set; }

        public TipoTec TipoTec { get; set; }
    }
}
