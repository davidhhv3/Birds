using _2.BirdsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace _4.BirdsInfrastructure.Data
{
    public class BirdsContext : DbContext
    {
        public BirdsContext() { }

        public BirdsContext(DbContextOptions<BirdsContext> options) : base(options)
        {
        }
        public virtual DbSet<Security> Security { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
