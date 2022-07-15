using Domain;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Repositories
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<TestClass> testClass { get; set; }

        public DbSet<TestClassTwo> TestClassTwo { get; set; }
    }
}
