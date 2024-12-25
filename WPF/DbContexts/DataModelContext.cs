using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WPF.DbContexts
{
    public class DataModelContext : DbContext
    {
        public DataModelContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
