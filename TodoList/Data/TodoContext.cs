using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> opt) : base(opt)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefas>()
                .HasOne(tarefas => tarefas.Coins)
                .WithOne(coins => coins.Tarefas)
                .HasForeignKey<Coins>(coins => coins.TarefasId);
        }

        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<Coins> Coins { get; set; }
    }
}
