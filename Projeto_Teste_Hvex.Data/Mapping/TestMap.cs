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
    internal class TestMap : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.ToTable("test");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasMaxLength(10).IsRequired().ValueGeneratedOnAdd();
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.UpdateAt).IsRequired(false);
            builder.Property(c => c.DurationInSeconds).HasDefaultValue(0).IsRequired();
            builder.Property(c => c.TransformerId).HasMaxLength(10).IsRequired();
            builder.Property(c => c.Status).IsRequired().HasDefaultValue(true);

            //builder.HasOne(c => c.Transformer).WithMany(c => c.Tests).HasForeignKey(c => c.TransformerId).IsRequired();
            //builder.HasOne(c => c.Report).WithOne(c => c.Test).IsRequired();
        }
    }
}
