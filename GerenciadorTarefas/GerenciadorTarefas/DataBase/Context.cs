using GerenciadorTarefas.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.DataBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
    }
}