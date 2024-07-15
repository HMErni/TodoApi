using Microsoft.EntityFrameworkCore;
using TodoApi2.Models;

namespace TodoApi2.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}