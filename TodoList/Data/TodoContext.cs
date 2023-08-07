using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> opt) : base(opt)
        {
            
        }

        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<Coins> Coins { get; set; }
    }
}
