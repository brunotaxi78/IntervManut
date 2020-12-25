using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntervManut.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "LinhaProd",
                columns: table => new
                {
                    LinhaProdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodLinha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaProd", x => x.LinhaProdId);
                });

            migrationBuilder.CreateTable(
                name: "Peca",
                columns: table => new
                {
                    PecaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPeca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peca", x => x.PecaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoIntervencao",
                columns: table => new
                {
                    TipoIntervencaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIntervencao", x => x.TipoIntervencaoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoTec",
                columns: table => new
                {
                    TipoTecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTec", x => x.TipoTecId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    EquipamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodEquipamento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CodAtivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LinhaProdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.EquipamentoId);
                    table.ForeignKey(
                        name: "FK_Equipamento_LinhaProd_LinhaProdId",
                        column: x => x.LinhaProdId,
                        principalTable: "LinhaProd",
                        principalColumn: "LinhaProdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tecnico",
                columns: table => new
                {
                    TecnicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoTecId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnico", x => x.TecnicoId);
                    table.ForeignKey(
                        name: "FK_Tecnico_TipoTec_TipoTecId",
                        column: x => x.TipoTecId,
                        principalTable: "TipoTec",
                        principalColumn: "TipoTecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intervencao",
                columns: table => new
                {
                    IntervencaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipamentoId = table.Column<int>(type: "int", nullable: false),
                    TecnicoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    TipoIntervencaoId = table.Column<int>(type: "int", nullable: false),
                    ResumoTrabalho = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervencao", x => x.IntervencaoId);
                    table.ForeignKey(
                        name: "FK_Intervencao_Equipamento_EquipamentoId",
                        column: x => x.EquipamentoId,
                        principalTable: "Equipamento",
                        principalColumn: "EquipamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intervencao_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intervencao_Tecnico_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnico",
                        principalColumn: "TecnicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Intervencao_TipoIntervencao_TipoIntervencaoId",
                        column: x => x.TipoIntervencaoId,
                        principalTable: "TipoIntervencao",
                        principalColumn: "TipoIntervencaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntervencaoPeca",
                columns: table => new
                {
                    IntervencaoPecaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntervencaoId = table.Column<int>(type: "int", nullable: false),
                    PecaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntervencaoPeca", x => x.IntervencaoPecaId);
                    table.ForeignKey(
                        name: "FK_IntervencaoPeca_Intervencao_IntervencaoId",
                        column: x => x.IntervencaoId,
                        principalTable: "Intervencao",
                        principalColumn: "IntervencaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntervencaoPeca_Peca_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Peca",
                        principalColumn: "PecaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TecnicoIntervencao",
                columns: table => new
                {
                    TecnicoIntervencaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TecnicoId = table.Column<int>(type: "int", nullable: true),
                    IntervencaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicoIntervencao", x => x.TecnicoIntervencaoId);
                    table.ForeignKey(
                        name: "FK_TecnicoIntervencao_Intervencao_IntervencaoId",
                        column: x => x.IntervencaoId,
                        principalTable: "Intervencao",
                        principalColumn: "IntervencaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TecnicoIntervencao_Tecnico_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnico",
                        principalColumn: "TecnicoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "EstadoId", "Descricao" },
                values: new object[,]
                {
                    { 1, "Criada" },
                    { 2, "Agendada" },
                    { 3, "Aguarda Material" },
                    { 4, "Concluída" }
                });

            migrationBuilder.InsertData(
                table: "LinhaProd",
                columns: new[] { "LinhaProdId", "CodLinha", "Descricao" },
                values: new object[,]
                {
                    { 1, "LP1", "Linha de Pão 1" },
                    { 2, "LP2", "Linha de Pão 2" },
                    { 3, "LP3", "Linha de Pão 3" }
                });

            migrationBuilder.InsertData(
                table: "TipoIntervencao",
                columns: new[] { "TipoIntervencaoId", "Descricao" },
                values: new object[,]
                {
                    { 1, "Preventiva" },
                    { 2, "Curativa" },
                    { 3, "Melhoria" },
                    { 4, "Serras" }
                });

            migrationBuilder.InsertData(
                table: "TipoTec",
                columns: new[] { "TipoTecId", "Tipo" },
                values: new object[,]
                {
                    { 1, "Interno" },
                    { 2, "Externo" },
                    { 3, "Temporário" }
                });

            migrationBuilder.InsertData(
                table: "Equipamento",
                columns: new[] { "EquipamentoId", "CodAtivo", "CodEquipamento", "LinhaProdId", "Nome" },
                values: new object[] { 1, null, "0001", 1, "Outro Equipamento" });

            migrationBuilder.InsertData(
                table: "Equipamento",
                columns: new[] { "EquipamentoId", "CodAtivo", "CodEquipamento", "LinhaProdId", "Nome" },
                values: new object[] { 2, null, "0002", 2, "Outro Equipamento" });

            migrationBuilder.InsertData(
                table: "Equipamento",
                columns: new[] { "EquipamentoId", "CodAtivo", "CodEquipamento", "LinhaProdId", "Nome" },
                values: new object[] { 3, null, "0003", 3, "Outro Equipamento" });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_LinhaProdId",
                table: "Equipamento",
                column: "LinhaProdId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencao_EquipamentoId",
                table: "Intervencao",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencao_EstadoId",
                table: "Intervencao",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencao_TecnicoId",
                table: "Intervencao",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervencao_TipoIntervencaoId",
                table: "Intervencao",
                column: "TipoIntervencaoId");

            migrationBuilder.CreateIndex(
                name: "IX_IntervencaoPeca_IntervencaoId",
                table: "IntervencaoPeca",
                column: "IntervencaoId");

            migrationBuilder.CreateIndex(
                name: "IX_IntervencaoPeca_PecaId",
                table: "IntervencaoPeca",
                column: "PecaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnico_TipoTecId",
                table: "Tecnico",
                column: "TipoTecId");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicoIntervencao_IntervencaoId",
                table: "TecnicoIntervencao",
                column: "IntervencaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TecnicoIntervencao_TecnicoId",
                table: "TecnicoIntervencao",
                column: "TecnicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntervencaoPeca");

            migrationBuilder.DropTable(
                name: "TecnicoIntervencao");

            migrationBuilder.DropTable(
                name: "Peca");

            migrationBuilder.DropTable(
                name: "Intervencao");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Tecnico");

            migrationBuilder.DropTable(
                name: "TipoIntervencao");

            migrationBuilder.DropTable(
                name: "LinhaProd");

            migrationBuilder.DropTable(
                name: "TipoTec");
        }
    }
}
