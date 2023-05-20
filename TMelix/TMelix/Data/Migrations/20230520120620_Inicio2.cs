using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMelix.Data.Migrations
{
    public partial class Inicio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeSubscricao_Filme_FilmesId",
                table: "FilmeSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeSubscricao_Subscricao_SubscricoesId",
                table: "FilmeSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieSubscricao_Serie_SeriesId",
                table: "SerieSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieSubscricao_Subscricao_SubscricoesId",
                table: "SerieSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscricao_Utilizador_UtilizadorFK",
                table: "Subscricao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizador",
                table: "Utilizador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscricao",
                table: "Subscricao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Serie",
                table: "Serie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filme",
                table: "Filme");

            migrationBuilder.RenameTable(
                name: "Utilizador",
                newName: "Utilizadores");

            migrationBuilder.RenameTable(
                name: "Subscricao",
                newName: "Subscricoes");

            migrationBuilder.RenameTable(
                name: "Serie",
                newName: "Series");

            migrationBuilder.RenameTable(
                name: "Filme",
                newName: "Filmes");

            migrationBuilder.RenameIndex(
                name: "IX_Subscricao_UtilizadorFK",
                table: "Subscricoes",
                newName: "IX_Subscricoes_UtilizadorFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizadores",
                table: "Utilizadores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscricoes",
                table: "Subscricoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeSubscricao_Filmes_FilmesId",
                table: "FilmeSubscricao",
                column: "FilmesId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeSubscricao_Subscricoes_SubscricoesId",
                table: "FilmeSubscricao",
                column: "SubscricoesId",
                principalTable: "Subscricoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieSubscricao_Series_SeriesId",
                table: "SerieSubscricao",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieSubscricao_Subscricoes_SubscricoesId",
                table: "SerieSubscricao",
                column: "SubscricoesId",
                principalTable: "Subscricoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscricoes_Utilizadores_UtilizadorFK",
                table: "Subscricoes",
                column: "UtilizadorFK",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeSubscricao_Filmes_FilmesId",
                table: "FilmeSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeSubscricao_Subscricoes_SubscricoesId",
                table: "FilmeSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieSubscricao_Series_SeriesId",
                table: "SerieSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieSubscricao_Subscricoes_SubscricoesId",
                table: "SerieSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscricoes_Utilizadores_UtilizadorFK",
                table: "Subscricoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utilizadores",
                table: "Utilizadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscricoes",
                table: "Subscricoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmes",
                table: "Filmes");

            migrationBuilder.RenameTable(
                name: "Utilizadores",
                newName: "Utilizador");

            migrationBuilder.RenameTable(
                name: "Subscricoes",
                newName: "Subscricao");

            migrationBuilder.RenameTable(
                name: "Series",
                newName: "Serie");

            migrationBuilder.RenameTable(
                name: "Filmes",
                newName: "Filme");

            migrationBuilder.RenameIndex(
                name: "IX_Subscricoes_UtilizadorFK",
                table: "Subscricao",
                newName: "IX_Subscricao_UtilizadorFK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utilizador",
                table: "Utilizador",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscricao",
                table: "Subscricao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Serie",
                table: "Serie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filme",
                table: "Filme",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeSubscricao_Filme_FilmesId",
                table: "FilmeSubscricao",
                column: "FilmesId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeSubscricao_Subscricao_SubscricoesId",
                table: "FilmeSubscricao",
                column: "SubscricoesId",
                principalTable: "Subscricao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieSubscricao_Serie_SeriesId",
                table: "SerieSubscricao",
                column: "SeriesId",
                principalTable: "Serie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieSubscricao_Subscricao_SubscricoesId",
                table: "SerieSubscricao",
                column: "SubscricoesId",
                principalTable: "Subscricao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscricao_Utilizador_UtilizadorFK",
                table: "Subscricao",
                column: "UtilizadorFK",
                principalTable: "Utilizador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
