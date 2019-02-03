using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PCT.Dominio;
using System;
using System.Configuration;

namespace PCT.BD
{
    public class PCTContext : DbContext
    {
        /*
        Comandos en Package Manager Console
        PM> add-migration <NombreMigracion>
        PM> update-database –verbose
        http://www.entityframeworktutorial.net/efcore/entity-framework-core-console-application.aspx
        */

        public PCTContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            string connStr = configuration.GetConnectionString("PCTConnection");
            optionsBuilder.UseSqlServer(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConciertoMusico>().HasKey(cm => new { cm.ConciertoId, cm.MusicoId });

            modelBuilder.Entity<ConciertoMusico>()
                .HasOne<Concierto>(cm => cm.Concierto)
                .WithMany(c => c.Musicos)
                .HasForeignKey(cm => cm.ConciertoId);

            modelBuilder.Entity<ConciertoMusico>()
                .HasOne<Musico>(cm => cm.Musico)
                .WithMany(m => m.Conciertos)
                .HasForeignKey(cm => cm.MusicoId);

        }

        public DbSet<Concierto> Conciertos { get; set; }
        public DbSet<Musico> Musicos { get; set; }
        public DbSet<Galeria> Galerias { get; set; }
        public DbSet<ItemGaleria> ItemsGaleria { get; set; }
    }
}
