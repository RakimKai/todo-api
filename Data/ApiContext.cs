
using Microsoft.EntityFrameworkCore;
using todo_api.Models;

namespace todo_api.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }  
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        } 
    }
}
