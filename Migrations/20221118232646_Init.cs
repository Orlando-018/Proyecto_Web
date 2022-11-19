using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Primeruso.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Fecha_Nacimient = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HOTEL",
                columns: table => new
                {
                    ID_HOTEL = table.Column<int>(type: "int", nullable: false),
                    Nombre_Hotel = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOTEL", x => x.ID_HOTEL);
                });

            migrationBuilder.CreateTable(
                name: "Tipo de Habitaciones",
                columns: table => new
                {
                    ID_Tipo_Habitacion = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo de Habitaciones", x => x.ID_Tipo_Habitacion);
                });

            migrationBuilder.CreateTable(
                name: "Tipo de pago",
                columns: table => new
                {
                    ID_Tipo_Pago = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo de pago", x => x.ID_Tipo_Pago);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    ID_Comentario = table.Column<int>(type: "int", nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    Contenido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.ID_Comentario);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    ID_Habitacion = table.Column<int>(type: "int", nullable: false),
                    ID_HOTEL = table.Column<int>(type: "int", nullable: false),
                    Num_Habitacion = table.Column<byte>(type: "tinyint", nullable: false),
                    Costo_Habitacion = table.Column<decimal>(type: "money", nullable: false),
                    ID_Tipo_Habitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.ID_Habitacion);
                    table.ForeignKey(
                        name: "FK_Habitacion_HOTEL",
                        column: x => x.ID_HOTEL,
                        principalTable: "HOTEL",
                        principalColumn: "ID_HOTEL");
                    table.ForeignKey(
                        name: "FK_Habitacion_Tipo de Habitaciones",
                        column: x => x.ID_Tipo_Habitacion,
                        principalTable: "Tipo de Habitaciones",
                        principalColumn: "ID_Tipo_Habitacion");
                });

            migrationBuilder.CreateTable(
                name: "Reservacion",
                columns: table => new
                {
                    ID_Reservacion = table.Column<int>(type: "int", nullable: false),
                    ID_Habitacion = table.Column<int>(type: "int", nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservacion", x => x.ID_Reservacion);
                    table.ForeignKey(
                        name: "FK_Reservacion_Habitacion",
                        column: x => x.ID_Habitacion,
                        principalTable: "Habitacion",
                        principalColumn: "ID_Habitacion");
                    table.ForeignKey(
                        name: "FK_Reservacion_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    ID_Pago = table.Column<int>(type: "int", nullable: false),
                    Costo_Habitacion = table.Column<decimal>(type: "money", nullable: false),
                    ID_Reservacion = table.Column<int>(type: "int", nullable: false),
                    ID_Tipo_Pago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.ID_Pago);
                    table.ForeignKey(
                        name: "FK_Pago_Reservacion",
                        column: x => x.ID_Reservacion,
                        principalTable: "Reservacion",
                        principalColumn: "ID_Reservacion");
                    table.ForeignKey(
                        name: "FK_Pago_Tipo de pago1",
                        column: x => x.ID_Tipo_Pago,
                        principalTable: "Tipo de pago",
                        principalColumn: "ID_Tipo_Pago");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ID_Usuario",
                table: "Comentario",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_ID_HOTEL",
                table: "Habitacion",
                column: "ID_HOTEL");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_ID_Tipo_Habitacion",
                table: "Habitacion",
                column: "ID_Tipo_Habitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ID_Reservacion",
                table: "Pago",
                column: "ID_Reservacion");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ID_Tipo_Pago",
                table: "Pago",
                column: "ID_Tipo_Pago");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_ID_Habitacion",
                table: "Reservacion",
                column: "ID_Habitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_ID_Usuario",
                table: "Reservacion",
                column: "ID_Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Reservacion");

            migrationBuilder.DropTable(
                name: "Tipo de pago");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HOTEL");

            migrationBuilder.DropTable(
                name: "Tipo de Habitaciones");
        }
    }
}
