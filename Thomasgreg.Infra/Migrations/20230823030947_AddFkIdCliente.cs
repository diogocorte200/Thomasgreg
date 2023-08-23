using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Thomasgreg.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddFkIdCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logradouros_clientes_ClienteId",
                table: "logradouros");

            migrationBuilder.DropIndex(
                name: "IX_logradouros_ClienteId",
                table: "logradouros");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "logradouros");

            migrationBuilder.CreateIndex(
                name: "IX_logradouros_IdCliente",
                table: "logradouros",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_logradouros_clientes_IdCliente",
                table: "logradouros",
                column: "IdCliente",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logradouros_clientes_IdCliente",
                table: "logradouros");

            migrationBuilder.DropIndex(
                name: "IX_logradouros_IdCliente",
                table: "logradouros");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "logradouros",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_logradouros_ClienteId",
                table: "logradouros",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_logradouros_clientes_ClienteId",
                table: "logradouros",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
