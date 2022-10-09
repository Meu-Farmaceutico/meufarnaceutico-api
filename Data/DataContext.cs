using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MeufarmaceuticoApi.Domain.Common;
using MeufarmaceuticoApi.Domain;

using System.IO;

namespace MeufarmaceuticoApi.Data
{
    public class DataContext : DbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Medication> Medication { get; set; }

        DbSet<Treatment> Treatments { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true).Build();

            options.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
    }
}
