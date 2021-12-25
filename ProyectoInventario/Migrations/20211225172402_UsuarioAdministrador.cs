using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoInventario.Migrations
{
    public partial class UsuarioAdministrador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Usuarios_UsuarioId",
                table: "Ticket");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Usuarios",
                type: "varchar(45)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Ticket",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AdminUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(45)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(45)", nullable: false),
                    Correo = table.Column<string>(type: "varchar(255)", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(45)", nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(255)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Delegar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioAdminId = table.Column<int>(nullable: false),
                    IdAdmin = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: false),
                    IdTicket = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delegar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delegar_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delegar_AdminUser_UsuarioAdminId",
                        column: x => x.UsuarioAdminId,
                        principalTable: "AdminUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delegar_TicketId",
                table: "Delegar",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Delegar_UsuarioAdminId",
                table: "Delegar",
                column: "UsuarioAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Usuarios_UsuarioId",
                table: "Ticket",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Usuarios_UsuarioId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "Delegar");

            migrationBuilder.DropTable(
                name: "AdminUser");

            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Usuarios_UsuarioId",
                table: "Ticket",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
