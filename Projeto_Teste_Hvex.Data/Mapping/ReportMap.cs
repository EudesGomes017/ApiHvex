using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Projeto_Teste_Hvex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Data.Mapping
{
    internal class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("report");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasMaxLength(10).IsRequired().ValueGeneratedOnAdd(); //ValueGeneratedOnAdd quer dizer q autocremental
            builder.Property(c => c.CreatedAt).IsRequired(); //IsRequired se é requerida sim ou não
            builder.Property(c => c.UpdateAt).IsRequired(false);
            builder.Property(c => c.TestId).HasMaxLength(10).IsRequired();
            builder.Property(c => c.TransformerId).HasMaxLength(10).IsRequired();
            builder.Property(c => c.Status).IsRequired().HasDefaultValue(true);

            //um para um
            builder.HasOne(c => c.Transformer).WithOne(c => c.Report).IsRequired();
            //e um teste tem um transformador
            builder.HasOne(c => c.Test).WithOne(c => c.Report).IsRequired();

        }
    }
}
