using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    table.PrimaryKey("PK_EstadoId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaisId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: true),
                    descripcion = table.Column<string>(type: "varchar(200)", nullable: true),
                    grupoCompra = table.Column<string>(type: "varchar(200)", nullable: true),
                    comprador = table.Column<string>(type: "varchar(200)", nullable: true),
                    estadoId = table.Column<int>(type: "int", nullable: true),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Estado",
                        column: x => x.estadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracionGeneral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Valor1 = table.Column<string>(type: "varchar(200)", nullable: true),
                    Valor2 = table.Column<string>(type: "varchar(200)", nullable: true),
                    Valor3 = table.Column<string>(type: "varchar(200)", nullable: true),
                    Valor4 = table.Column<string>(type: "varchar(200)", nullable: true),
                    Valor5 = table.Column<string>(type: "varchar(200)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionGeneralId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracionGeneral_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracionNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dias = table.Column<int>(type: "int", nullable: true),
                    hora = table.Column<TimeSpan>(type: "time", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionNotificacionId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracionNotificacion_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Documento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
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
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    UserIdAzure = table.Column<string>(type: "varchar(150)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsiarioId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: true),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CiudadId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudad_Pais",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: true),
                    requerido = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoDocumentoId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogoDocumento_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogoDocumento_TipoDocumento",
                        column: x => x.TipoDocumentoId,
                        principalTable: "Tipo_Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubtipoCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(100)", nullable: true),
                    TipoCompraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtipoCompraId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubtipoCompra_TipoCompra",
                        column: x => x.TipoCompraId,
                        principalTable: "TipoCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.PrimaryKey("PK_RolUsuarioId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Rol",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "varchar(200)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: true),
                    Identificacion = table.Column<string>(type: "varchar(200)", nullable: true),
                    IdentificacionTipo = table.Column<string>(type: "varchar(200)", nullable: true),
                    ContactoPrimario = table.Column<string>(type: "varchar(200)", nullable: true),
                    ContactoSecundario = table.Column<string>(type: "varchar(200)", nullable: true),
                    Direccion = table.Column<string>(type: "varchar(200)", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(200)", nullable: true),
                    PaginaWeb = table.Column<string>(type: "varchar(200)", nullable: true),
                    Movil = table.Column<string>(type: "varchar(200)", nullable: true),
                    Idioma = table.Column<string>(type: "varchar(200)", nullable: true),
                    Observacion = table.Column<string>(type: "varchar(200)", nullable: true),
                    CodigoProveedorSap = table.Column<string>(type: "varchar(200)", nullable: true),
                    Aspitante = table.Column<int>(type: "int", nullable: true),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    SubtipoCompraId = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedor_Ciudad",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proveedor_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proveedor_SubtipoCompra",
                        column: x => x.SubtipoCompraId,
                        principalTable: "SubtipoCompra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proveedor_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(250)", nullable: true),
                    FechaEmicion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    CatalogoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocumentoId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documento_CatalogoDocumento",
                        column: x => x.CatalogoDocumentoId,
                        principalTable: "CatalogoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documento_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documento_Proveedor",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorCategoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_ProveedorCategoria_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Referencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(200)", nullable: true),
                    Contacto = table.Column<string>(type: "varchar(100)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(20)", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreadoPor = table.Column<int>(type: "int", nullable: true),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenciaId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referencia_Estado",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Referencia_Proveedor",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Categoria_estadoId",
                table: "Categoria",
                column: "estadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_PaisId",
                table: "Ciudad",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionGeneral_EstadoId",
                table: "ConfiguracionGeneral",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionNotificacion_EstadoId",
                table: "ConfiguracionNotificacion",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documento_CatalogoDocumentoId",
                table: "Documento",
                column: "CatalogoDocumentoId");

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
                name: "IX_Proveedor_SubtipoCompraId",
                table: "Proveedor",
                column: "SubtipoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_UsuarioId",
                table: "Proveedor",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCategoria_CategoriaId",
                table: "ProveedorCategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCategoria_ProveedorId",
                table: "ProveedorCategoria",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_EstadoId",
                table: "Referencia",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Referencia_ProveedorId",
                table: "Referencia",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_RolId",
                table: "RolUsuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuarioId",
                table: "RolUsuario",
                column: "UsuarioId");

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

            // INSERT ESTADOS
            migrationBuilder.Sql("INSERT INTO Estado (Nombre) VALUES ('Activo')");
            migrationBuilder.Sql("INSERT INTO Estado (Nombre) VALUES ('Inactivo')");
            migrationBuilder.Sql("INSERT INTO Estado (Nombre) VALUES ('Pendiente')");
            migrationBuilder.Sql("INSERT INTO Estado (Nombre) VALUES ('Revisión')");
            migrationBuilder.Sql("INSERT INTO Estado (Nombre) VALUES ('Aprobado')");
            migrationBuilder.Sql("INSERT INTO Estado (Nombre) VALUES ('Rechazado')");

            // INSERT ROLES
            migrationBuilder.Sql("INSERT INTO Rol (Codigo, Nombre) VALUES ('ADMIN', 'Rol Administrador')");
            migrationBuilder.Sql("INSERT INTO Rol (Codigo, Nombre) VALUES ('PRO', 'Rol Proveedor')");
            migrationBuilder.Sql("INSERT INTO Rol (Codigo, Nombre) VALUES ('INT', 'Rol Interno')");

            // INSERT CONFIGURACION GENERAL
            migrationBuilder.Sql("INSERT INTO ConfiguracionGeneral (Codigo, Valor1, Valor2, Valor3, Valor4, Valor5, EstadoId) VALUES ('JWT', 'CCN_SUPPLIERS_PORTAL', 'a9e11bd1-1160-4a20-a10d-b1a11f8a448e', 'ccn-sup-2023', 'suppliers-api', '30', 1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracionGeneral");

            migrationBuilder.DropTable(
                name: "ConfiguracionNotificacion");

            migrationBuilder.DropTable(
                name: "Documento");

            migrationBuilder.DropTable(
                name: "ProveedorCategoria");

            migrationBuilder.DropTable(
                name: "Referencia");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "CatalogoDocumento");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Tipo_Documento");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "SubtipoCompra");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "TipoCompra");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
