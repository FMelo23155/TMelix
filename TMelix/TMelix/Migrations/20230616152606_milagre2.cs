using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMelix.Migrations
{
    public partial class milagre2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeSubscricao_Filme_FilmeId",
                table: "FilmeSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeSubscricao_Subscricao_SubscricaoId",
                table: "FilmeSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieSubscricao_Serie_SerieId",
                table: "SerieSubscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_SerieSubscricao_Subscricao_SubscricaoId",
                table: "SerieSubscricao");

            migrationBuilder.RenameColumn(
                name: "SubscricaoId",
                table: "SerieSubscricao",
                newName: "SubscricoesId");

            migrationBuilder.RenameColumn(
                name: "SerieId",
                table: "SerieSubscricao",
                newName: "SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_SerieSubscricao_SubscricaoId",
                table: "SerieSubscricao",
                newName: "IX_SerieSubscricao_SubscricoesId");

            migrationBuilder.RenameColumn(
                name: "SubscricaoId",
                table: "FilmeSubscricao",
                newName: "SubscricoesId");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "FilmeSubscricao",
                newName: "FilmesId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmeSubscricao_SubscricaoId",
                table: "FilmeSubscricao",
                newName: "IX_FilmeSubscricao_SubscricoesId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "a5828675-2a11-46e1-ad57-7b632f46d66e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "33646dec-8da7-4a3b-a977-884324eebd93");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "s",
                column: "ConcurrencyStamp",
                value: "7010fd4d-ad2a-42f4-8f1f-c6b0522c07af");

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

            migrationBuilder.RenameColumn(
                name: "SubscricoesId",
                table: "SerieSubscricao",
                newName: "SubscricaoId");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "SerieSubscricao",
                newName: "SerieId");

            migrationBuilder.RenameIndex(
                name: "IX_SerieSubscricao_SubscricoesId",
                table: "SerieSubscricao",
                newName: "IX_SerieSubscricao_SubscricaoId");

            migrationBuilder.RenameColumn(
                name: "SubscricoesId",
                table: "FilmeSubscricao",
                newName: "SubscricaoId");

            migrationBuilder.RenameColumn(
                name: "FilmesId",
                table: "FilmeSubscricao",
                newName: "FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmeSubscricao_SubscricoesId",
                table: "FilmeSubscricao",
                newName: "IX_FilmeSubscricao_SubscricaoId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a",
                column: "ConcurrencyStamp",
                value: "4013e411-520b-4ea3-a9fd-e9e08b009051");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c",
                column: "ConcurrencyStamp",
                value: "29fb13ba-067c-416d-8a86-01d02bbd458c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "s",
                column: "ConcurrencyStamp",
                value: "45a825b3-f4a0-43e4-86ba-076a7c5622ba");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeSubscricao_Filme_FilmeId",
                table: "FilmeSubscricao",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeSubscricao_Subscricao_SubscricaoId",
                table: "FilmeSubscricao",
                column: "SubscricaoId",
                principalTable: "Subscricoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieSubscricao_Serie_SerieId",
                table: "SerieSubscricao",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SerieSubscricao_Subscricao_SubscricaoId",
                table: "SerieSubscricao",
                column: "SubscricaoId",
                principalTable: "Subscricoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
