using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grupoCompra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comprador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracionNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dias = table.Column<int>(type: "int", nullable: false),
                    hora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionNotificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracionNotificacion_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Documento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentoId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoDocumento_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCompras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoCompra_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudad_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CatalogoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requerido = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoDocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogoDocumento_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogoDocumento_Tipo_Documento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "Tipo_Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificacionTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactoPrimario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactoSecundario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaginaWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Movil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idioma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoProveedorSap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedor_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proveedor_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEmicion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documento_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProveedorCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProveedorCategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProveedorCategoria_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProveedorCategoria_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubtipoCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCompraId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtipoCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubtipoCompra_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubtipoCompra_TipoCompra_TipoCompraId",
                        column: x => x.TipoCompraId,
                        principalTable: "TipoCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Referencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referencia_Documento_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "Documento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Referencia_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoDocumento_EstadoId",
                table: "CatalogoDocumento",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoDocumento_TipoDocumentoId",
                table: "CatalogoDocumento",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_EstadoId",
                table: "Categoria",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_PaisId",
                table: "Ciudad",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionNotificacion_EstadoId",
                table: "ConfiguracionNotificacion",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_EstadoId",
                table: "Documento",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_ProveedorId",
                table: "Documento",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_CiudadId",
                table: "Proveedor",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_EstadoId",
                table: "Proveedor",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCategoria_CategoriaId",
                table: "ProveedorCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCategoria_EstadoId",
                table: "ProveedorCategoria",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCategoria_ProveedorId",
                table: "ProveedorCategoria",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_DocumentoId",
                table: "Referencia",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_EstadoId",
                table: "Referencia",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_RolId",
                table: "RolUsuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuarioId",
                table: "RolUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtipoCompra_ProveedorId",
                table: "SubtipoCompra",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtipoCompra_TipoCompraId",
                table: "SubtipoCompra",
                column: "TipoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Documento_EstadoId",
                table: "Tipo_Documento",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCompra_EstadoId",
                table: "TipoCompra",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EstadoId",
                table: "Usuario",
                column: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoDocumento");

            migrationBuilder.DropTable(
                name: "ConfiguracionNotificacion");

            migrationBuilder.DropTable(
                name: "ProveedorCategoria");

            migrationBuilder.DropTable(
                name: "Referencia");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "SubtipoCompra");

            migrationBuilder.DropTable(
                name: "Tipo_Documento");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoCompra");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
