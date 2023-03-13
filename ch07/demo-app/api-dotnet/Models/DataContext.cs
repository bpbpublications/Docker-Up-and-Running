using Microsoft.EntityFrameworkCore;

namespace api_dotnet.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        { }

        public DbSet<Order> Orders { get; set; }
    }
}