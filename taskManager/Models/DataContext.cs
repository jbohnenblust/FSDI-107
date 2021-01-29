using Microsoft.EntityFrameworkCore;

namespace taskManager.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //which models will become tables in the database
        public DbSet<Task> Tasks {get; set;}
    }
}