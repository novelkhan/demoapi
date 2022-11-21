using demoapi.Models;
using Microsoft.EntityFrameworkCore;

namespace demoapi.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options)
        {

        }

        public DbSet<EmployeeModel> employees { get; set; }
    }
}
