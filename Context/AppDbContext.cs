using EasyToDoWeb.Models;
using Microsoft.EntityFrameworkCore;
namespace EasyToDoWeb.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria  { get; set; }
        public DbSet<Models.Tasks> Tarefas { get; set; }

    }
}
