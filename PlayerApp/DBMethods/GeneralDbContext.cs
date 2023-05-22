using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlayerApp.Models.DBModel;
using System.IO;
using System.Linq;

namespace PlayerApp.DBMethods
{
    public class GeneralDbContext: DbContext
    {
        public GeneralDbContext()
       : base()
        {
            //Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

           
        }
        public DbSet<PlayerDetail> PlayerDetail { get; set; }
    }
}
