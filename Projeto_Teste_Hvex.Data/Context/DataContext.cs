using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto_Teste_Hvex.Data.Mapping;
using Projeto_Teste_Hvex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Teste_Hvex.Data.Context
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Test> Test { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Transformer> Transformer { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TestMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new TransformerMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
