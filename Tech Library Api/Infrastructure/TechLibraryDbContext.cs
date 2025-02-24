using Microsoft.EntityFrameworkCore;
using Tech_Library_Api.Domain.Entities;

namespace Tech_Library_Api.Infrastructure
{
    public class TechLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }  //Users é o nome da tabela no banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\desenvolvimento\\WebApi\\Workspaces\\Tech Library\\Tech Library Api\\Infrastructure\\database\\TechLibraryDb.db");
        }
    }
}
