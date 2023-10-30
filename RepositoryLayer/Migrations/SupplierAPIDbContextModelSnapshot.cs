﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer;

#nullable disable

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(SupplierAPIDbContext))]
    partial class SupplierAPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainLayer.Models.CatalogoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.Property<int?>("requerido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("CatalogoDocumento");
                });

            modelBuilder.Entity("DomainLayer.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreadoPor")
                        .HasColumnType("int");

                    b.Property<int?>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comprador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrupoCompra")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("DomainLayer.Models.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PaisId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Ciudad");
                });

            modelBuilder.Entity("DomainLayer.Models.ConfiguracionNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreadoPor")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int");

                    b.Property<int>("Dias")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Hora")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("ConfiguracionNotificacion");
                });

            modelBuilder.Entity("DomainLayer.Models.ConfiguracionGeneral", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int?>("CreadoPor")
                    .HasColumnType("int");

                b.Property<int>("EstadoId")
                    .HasColumnType("int");

                b.Property<DateTime?>("FechaCreacion")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("FechaModificacion")
                    .HasColumnType("datetime2");

                b.Property<int?>("ModificadoPor")
                    .HasColumnType("int");

                b.Property<int>("Codigo")
                    .HasColumnType("int");

                b.Property<string>("Valor1")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Valor2")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Valor3")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Valor4")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Valor5")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("EstadoId");

                b.ToTable("ConfiguracionGeneral");

            });

            modelBuilder.Entity("DomainLayer.Models.Documento", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int?>("CreadoPor")
                    .HasColumnType("int");

                b.Property<int?>("EstadoId")
                    .HasColumnType("int");

                b.Property<DateTime?>("FechaCreacion")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("FechaEmicion")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("FechaModificacion")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("FechaVencimiento")
                    .HasColumnType("datetime2");

                b.Property<int?>("ModificadoPor")
                    .HasColumnType("int");

                b.Property<string>("Nombre")
                    .HasColumnType("nvarchar(max)");

                b.Property<int?>("ProveedorId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("EstadoId");

                b.HasIndex("ProveedorId");

                b.ToTable("Documento");
            });

            modelBuilder.Entity("DomainLayer.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id")
                        .HasName("PK_IdEstado");

                    b.ToTable("Estado", (string)null);
                });

            modelBuilder.Entity("DomainLayer.Models.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("DomainLayer.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoProveedorSap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactoPrimario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactoSecundario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificacionTipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Idioma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Movil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaginaWeb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("DomainLayer.Models.ProveedorCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int?>("EstadoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProveedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("ProveedorCategoria");
                });

            modelBuilder.Entity("DomainLayer.Models.Referencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DocumentoId")
                        .HasColumnType("int");

                    b.Property<int?>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Referencia");
                });

            modelBuilder.Entity("DomainLayer.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("DomainLayer.Models.RolUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("RolUsuario");
                });

            modelBuilder.Entity("DomainLayer.Models.SubtipoCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int>("TipoCompraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.HasIndex("TipoCompraId");

                    b.ToTable("SubtipoCompra");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreadoPor")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int");

                    b.Property<string>("TipoCompras")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("TipoCompra");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreadoPor")
                        .HasColumnType("int")
                        .HasColumnName("CreadoPor");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Descripcion");

                    b.Property<int?>("EstadoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("EstadoId");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime")
                        .HasColumnName("fechaCreacion");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime")
                        .HasColumnName("FechaModificacion");

                    b.Property<int?>("ModificadoPor")
                        .HasColumnType("int")
                        .HasColumnName("ModificadoPor");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id")
                        .HasName("PK_TipoDocumentoId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Tipo_Documento", (string)null);
                });

            modelBuilder.Entity("DomainLayer.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("DomainLayer.Models.CatalogoDocumento", b =>
                {
                    b.HasOne("DomainLayer.Models.Estado", "Estados")
                        .WithMany("CatalogoDocumentos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.TipoDocumento", "TipoDocumentos")
                        .WithMany("CatalogoDocumentos")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");

                    b.Navigation("TipoDocumentos");
                });

            modelBuilder.Entity("DomainLayer.Models.Categoria", b =>
                {
                    b.HasOne("DomainLayer.Models.Estado", "Estado")
                        .WithMany("Categorias")
                        .HasForeignKey("EstadoId");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("DomainLayer.Models.Ciudad", b =>
                {
                    b.HasOne("DomainLayer.Models.Pais", "Pais")
                        .WithMany("Ciudades")
                        .HasForeignKey("PaisId");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("DomainLayer.Models.ConfiguracionNotificacion", b =>
                {
                    b.HasOne("DomainLayer.Models.Estado", "Estados")
                        .WithMany("ConfiguracionNotificaciones")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");
                });

            modelBuilder.Entity("DomainLayer.Models.ConfiguracionGeneral", b =>
                {                 
                    b.HasOne("DomainLayer.Models.Estado", "Estados")
                        .WithMany("ConfiguracionGenerales")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
            
                    b.Navigation("Estados");
                });

            modelBuilder.Entity("DomainLayer.Models.Documento", b =>
                {
                    b.HasOne("DomainLayer.Models.Estado", "Estados")
                        .WithMany("Documentos")
                        .HasForeignKey("EstadoId");

                    b.HasOne("DomainLayer.Models.Proveedor", "Proveedores")
                        .WithMany("Documentos")
                        .HasForeignKey("ProveedorId");

                    b.Navigation("Estados");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("DomainLayer.Models.Proveedor", b =>
                {
                    b.HasOne("DomainLayer.Models.Ciudad", "Ciudad")
                        .WithMany("Proveedores")
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.Estado", "Estado")
                        .WithMany("Proveedores")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("DomainLayer.Models.ProveedorCategoria", b =>
                {
                    b.HasOne("DomainLayer.Models.Categoria", "Categoria")
                        .WithMany("ProveedorCategorias")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("DomainLayer.Models.Estado", "Estado")
                        .WithMany("ProveedorCategorias")
                        .HasForeignKey("EstadoId");

                    b.HasOne("DomainLayer.Models.Proveedor", "Proveedor")
                        .WithMany("ProveedorCategorias")
                        .HasForeignKey("ProveedorId");

                    b.Navigation("Categoria");

                    b.Navigation("Estado");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("DomainLayer.Models.Referencia", b =>
                {
                    b.HasOne("DomainLayer.Models.Documento", "Documento")
                        .WithMany("Referencias")
                        .HasForeignKey("DocumentoId");

                    b.HasOne("DomainLayer.Models.Estado", "Estado")
                        .WithMany("Referencias")
                        .HasForeignKey("EstadoId");

                    b.Navigation("Documento");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("DomainLayer.Models.RolUsuario", b =>
                {
                    b.HasOne("DomainLayer.Models.Rol", "Rol")
                        .WithMany("RolUsuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.Usuario", "Usuario")
                        .WithMany("RolUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DomainLayer.Models.SubtipoCompra", b =>
                {
                    b.HasOne("DomainLayer.Models.Proveedor", "Proveedor")
                        .WithMany("SubtipoCompras")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Models.TipoCompra", "TipoCompra")
                        .WithMany("SubtipoCompras")
                        .HasForeignKey("TipoCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");

                    b.Navigation("TipoCompra");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoCompra", b =>
                {
                    b.HasOne("DomainLayer.Models.Estado", "Estado")
                        .WithMany("TipoCompras")
                        .HasForeignKey("EstadoId");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoDocumento", b =>
                {
                    b.HasOne("DomainLayer.Models.Estado", "Estado")
                        .WithMany("TipoDocumentos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_TipoDocumento_Estado");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("DomainLayer.Models.Usuario", b =>
                {
                    b.HasOne("DomainLayer.Models.Estado", "Estado")
                        .WithMany("Usuarios")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("DomainLayer.Models.Categoria", b =>
                {
                    b.Navigation("ProveedorCategorias");
                });

            modelBuilder.Entity("DomainLayer.Models.Ciudad", b =>
                {
                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("DomainLayer.Models.Documento", b =>
                {
                    b.Navigation("Referencias");
                });

            modelBuilder.Entity("DomainLayer.Models.Estado", b =>
                {
                    b.Navigation("CatalogoDocumentos");

                    b.Navigation("Categorias");

                    b.Navigation("ConfiguracionNotificaciones");

                    b.Navigation("ConfiguracionGenerales");

                    b.Navigation("Documentos");

                    b.Navigation("ProveedorCategorias");

                    b.Navigation("Proveedores");

                    b.Navigation("Referencias");

                    b.Navigation("TipoCompras");

                    b.Navigation("TipoDocumentos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("DomainLayer.Models.Pais", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("DomainLayer.Models.Proveedor", b =>
                {
                    b.Navigation("Documentos");

                    b.Navigation("ProveedorCategorias");

                    b.Navigation("SubtipoCompras");
                });

            modelBuilder.Entity("DomainLayer.Models.Rol", b =>
                {
                    b.Navigation("RolUsuarios");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoCompra", b =>
                {
                    b.Navigation("SubtipoCompras");
                });

            modelBuilder.Entity("DomainLayer.Models.TipoDocumento", b =>
                {
                    b.Navigation("CatalogoDocumentos");
                });

            modelBuilder.Entity("DomainLayer.Models.Usuario", b =>
                {
                    b.Navigation("RolUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
