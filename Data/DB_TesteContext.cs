using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MRO.Models;
using System.Configuration;

#nullable disable

namespace MRO.Data
{
    public partial class DB_TesteContext : DbContext
    {
        public DB_TesteContext()
        {
        }

        public DB_TesteContext(DbContextOptions<DB_TesteContext> options)
            : base(options)
        {
        }

    
        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string AMMDbConnection = System.Configuration.ConfigurationSettings.AppSettings["AMMDbConnection"];
                optionsBuilder.UseSqlServer("Data Source=REBECAPAIVA92E1\\SQLEXPRESS01;Database=BancoTeste;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

          
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Estoque).IsUnicode(false);

                entity.Property(e => e.Valor).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
