using System;
public class DataContext
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true).Build();

            options.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
    }
}