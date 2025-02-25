using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Tech_Library_Api.Domain.Entities;

namespace Tech_Library_Api.Infrastructure
{
    public class TechLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }  //Users é o nome da tabela no banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Env.Load();

            var provider = Env.GetString("DB_PROVIDER");

            switch (provider)
            {
                case "Sqlite":
                    optionsBuilder.UseSqlite($"Data Source={Env.GetString("DB_SQLITE_PATH")}");
                    break;
                case "MSSQL":
                    var connectionString = $"Server={Env.GetString("DB_SERVER")};" +
                                   $"Database={Env.GetString("DB_DATABASE")};" +
                                   $"User Id={Env.GetString("DB_USER")};" +
                                   $"Password={Env.GetString("DB_PASSWORD")};" +
                                   $"TrustServerCertificate={Env.GetString("DB_TRUST_CERTIFICATE")};";
                    optionsBuilder.UseSqlServer(Env.GetString("DB_CONNECTION_STRING"));
                    break;
                default:
                    optionsBuilder.UseSqlite(Env.GetString("DB_CONNECTION_STRING"));
                    break;
            }

            
            //optionsBuilder.UseSqlite("Data Source=Infrastructure\\database\\TechLibraryDb.db");
            //optionsBuilder.UseSqlite("Data Source=C:\\desenvolvimento\\WebApi\\Workspaces\\Tech Library\\Tech Library Api\\Infrastructure\\database\\TechLibraryDb.db");
        }
    }
}