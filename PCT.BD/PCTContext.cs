using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PCT.Dominio;
using System;
using System.Configuration;

namespace PCT.BD
{
    public class PCTContext : DbContext
    {

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

        }

        public DbSet<Concierto> Conciertos { get; set; }
        public DbSet<Musico> Musicos { get; set; }
        public DbSet<Galeria> Galerias { get; set; }
        public DbSet<ItemGaleria> ItemsGaleria { get; set; }
    }
}
