using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IntervManut.Models
{
    public class Intervencao
    {
        public int IntervencaoId { get; set; }

        [Required]
        public string Descricao { get; set; }

        [ForeignKey("Equipamento")]
        [Required]
        public int EquipamentoId { get; set; }

        public Equipamento Equipamento { get; set; }

        [ForeignKey("Tecnico")]
        public int TecnicoId { get; set; }

        public Tecnico Tecnico { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataFim { get; set; }

        [ForeignKey("Estado")]
        public int EstadoId { get; set; }

        public Estado Estado { get; set; }

        [ForeignKey("TipoIntervencao")]
        public int TipoIntervencaoId { get; set; }

        public TipoIntervencao TipoIntervencao { get; set; }

        public string ResumoTrabalho { get; set; }

        public ICollection<IntervencaoPeca> IntervencoesPecas { get; set; }

    }
}
