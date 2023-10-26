using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.EntityMapper
{
    public class RolMap : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(x => x.Id)
                  .HasName("PK_RolId");

            builder.ToTable("Rol");

            builder.Property(x => x.Id)
               .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();
            builder.Property(x => x.Codigo)
                .HasColumnName("Codigo")
                .HasColumnType("varchar(50)")
                .IsRequired(false);
            builder.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("varchar(100)")
                .IsRequired(false);


        }
    }
}
