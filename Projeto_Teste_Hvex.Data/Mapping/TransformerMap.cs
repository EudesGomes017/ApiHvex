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
    public class TransformerMap : IEntityTypeConfiguration<Transformer>
    {
        public void Configure(EntityTypeBuilder<Transformer> builder)
        {
            builder.ToTable("transformer");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasMaxLength(10).IsRequired().ValueGeneratedOnAdd();
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.UpdateAt).IsRequired(false);
            builder.Property(c => c.Potency).HasDefaultValue(0).IsRequired();
            builder.Property(c => c.InternalNumber).HasDefaultValue(0).IsRequired();
            builder.Property(c => c.TensionClass).HasMaxLength(128).IsRequired();
            builder.Property(c => c.UserId).HasMaxLength(10).IsRequired(); //quando não colocamos nada por padrão ele vem true

            builder.HasMany(rp => rp.Reports)
                   .WithOne(tr => tr.Transformer)
                   .HasForeignKey(tr => tr.TransformerId);

            builder.HasMany(ts => ts.Tests)
                   .WithOne(tr => tr.Transformer)
                   .HasForeignKey(tr => tr.TransformerId);

        }
    }
}
