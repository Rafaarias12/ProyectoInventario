using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoInventario.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Proveedor = table.Column<string>(type: "varchar(45)", nullable: true),
                    Documento = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(45)", nullable: true),
                    Procesador = table.Column<string>(type: "varchar(45)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pagina = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTicket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(45)", nullable: true),
                    ModeloId = table.Column<int>(type: "int", nullable: false),
                    Serial = table.Column<string>(type: "varchar(45)", nullable: false),
                    TipoEquipo = table.Column<string>(type: "varchar(45)", nullable: false),
                    Memoria = table.Column<int>(type: "int", nullable: false),
                    Disco = table.Column<int>(type: "int", nullable: false),
                    TipoMemoria = table.Column<string>(type: "varchar(45)", nullable: true),
                    TipoDisco = table.Column<int>(type: "int", nullable: false),
                    Teclado = table.Column<int>(type: "int", nullable: false),
                    Otro = table.Column<string>(type: "varchar(45)", nullable: false),
                    Mouse = table.Column<int>(type: "int", nullable: false),
                    Multifuncional = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<int>(type: "int", nullable: false),
                    SistemaOperativo = table.Column<string>(type: "varchar(45)", nullable: true),
                    Ip = table.Column<string>(type: "varchar(45)", nullable: true),
                    HojaVida = table.Column<string>(type: "varchar(255)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipos_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipos_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: true),
                    ModuloId = table.Column<int>(nullable: true),
                    Acceso = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permiso_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permiso_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(45)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(45)", nullable: false),
                    Correo = table.Column<string>(type: "varchar(255)", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(45)", nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(255)", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimientos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "varchar(45)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", nullable: false),
                    Clave = table.Column<string>(type: "varchar(45)", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    FechaEquipo = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Software_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime", nullable: false),
                    Documento = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actas_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actas_Usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntentosUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntentosUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntentosUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(255)", nullable: true),
                    TipoCasoId = table.Column<int>(type: "int", nullable: false),
                    Caso = table.Column<string>(type: "varchar(45)", nullable: true),
                    Solucion = table.Column<string>(type: "varchar(255)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TipoTicket_TipoCasoId",
                        column: x => x.TipoCasoId,
                        principalTable: "TipoTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actas_EquipoId",
                table: "Actas",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Actas_UserId",
                table: "Actas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_FacturaId",
                table: "Equipos",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_ModeloId",
                table: "Equipos",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_IntentosUsuarios_UsuarioId",
                table: "IntentosUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimientos_EquipoId",
                table: "Mantenimientos",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_ModuloId",
                table: "Permiso",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_RoleId",
                table: "Permiso",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Software_EquipoId",
                table: "Software",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EquipoId",
                table: "Ticket",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TipoCasoId",
                table: "Ticket",
                column: "TipoCasoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UsuarioId",
                table: "Ticket",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolesId",
                table: "Usuarios",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actas");

            migrationBuilder.DropTable(
                name: "IntentosUsuarios");

            migrationBuilder.DropTable(
                name: "Mantenimientos");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "TipoTicket");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
