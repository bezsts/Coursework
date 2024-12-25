using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WPF.DbContexts
{
    public class DataModelDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataModelContext>
    {
        public DataModelContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=database.db").Options;

            return new DataModelContext(options);
        }
    }
}
