using Microsoft.EntityFrameworkCore;
using TaskManager.API.Domain.Entities;

namespace TaskManager.API.Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
