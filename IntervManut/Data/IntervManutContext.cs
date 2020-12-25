using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IntervManut.Models;

namespace IntervManut.Data
{
    public class IntervManutContext : DbContext
    {
        public IntervManutContext(DbContextOptions<IntervManutContext> options)
            : base(options)
        {
        }

        public DbSet<IntervManut.Models.Equipamento> Equipamento { get; set; }

        public DbSet<IntervManut.Models.Estado> Estado { get; set; }

        public DbSet<IntervManut.Models.Intervencao> Intervencao { get; set; }

        public DbSet<IntervManut.Models.IntervencaoPeca> IntervencaoPeca { get; set; }

        public DbSet<IntervManut.Models.LinhaProd> LinhaProd { get; set; }

        public DbSet<IntervManut.Models.Peca> Peca { get; set; }

        public DbSet<IntervManut.Models.Tecnico> Tecnico { get; set; }

        public DbSet<IntervManut.Models.TecnicoIntervencao> TecnicoIntervencao { get; set; }

        public DbSet<IntervManut.Models.TipoIntervencao> TipoIntervencao { get; set; }

        public DbSet<IntervManut.Models.TipoTec> TipoTec { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoTec>().HasData(
                    new TipoTec() { TipoTecId = 1, Tipo = "Interno" },
                    new TipoTec() { TipoTecId = 2, Tipo = "Externo" },
                    new TipoTec() { TipoTecId = 3, Tipo = "Temporário" }
                );

            modelBuilder.Entity<TipoIntervencao>().HasData(
                    new TipoIntervencao() { TipoIntervencaoId = 1, Descricao = "Preventiva" },
                    new TipoIntervencao() { TipoIntervencaoId = 2, Descricao = "Curativa" },
                    new TipoIntervencao() { TipoIntervencaoId = 3, Descricao = "Melhoria" },
                    new TipoIntervencao() { TipoIntervencaoId = 4, Descricao = "Serras" }
                );

            modelBuilder.Entity<Estado>().HasData(
                   new Estado() { EstadoId = 1, Descricao = "Criada" },
                   new Estado() { EstadoId = 2, Descricao = "Agendada" },
                   new Estado() { EstadoId = 3, Descricao = "Aguarda Material" },
                   new Estado() { EstadoId = 4, Descricao = "Concluída" }
               );

            modelBuilder.Entity<LinhaProd>().HasData(
                  new LinhaProd() { LinhaProdId = 1, CodLinha = "LP1", Descricao = "Linha de Pão 1" },
                  new LinhaProd() { LinhaProdId = 2, CodLinha = "LP2", Descricao = "Linha de Pão 2" },
                  new LinhaProd() { LinhaProdId = 3, CodLinha = "LP3", Descricao = "Linha de Pão 3" }
              );

            modelBuilder.Entity<Equipamento>().HasData(
                  new Equipamento() { EquipamentoId = 1, CodEquipamento = "0001", Nome = "Outro Equipamento", LinhaProdId = 1 },
                  new Equipamento() { EquipamentoId = 2, CodEquipamento = "0002", Nome = "Outro Equipamento", LinhaProdId = 2 },
                  new Equipamento() { EquipamentoId = 3, CodEquipamento = "0003", Nome = "Outro Equipamento", LinhaProdId = 3 }
              );
        }

    }
}
