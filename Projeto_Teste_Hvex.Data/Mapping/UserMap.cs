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
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasMaxLength(10).IsRequired().ValueGeneratedOnAdd();
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.UpdateAt).IsRequired(false);
            builder.Property(c => c.Email).HasMaxLength(128).IsRequired(false);
            builder.Property(c => c.TransformerId).HasMaxLength(10).IsRequired(false);

           builder.HasMany(c => c.Transformers).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired();          
        }
    }
}
