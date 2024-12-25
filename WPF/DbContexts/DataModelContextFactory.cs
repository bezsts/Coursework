using Microsoft.EntityFrameworkCore;

namespace WPF.DbContexts
{
    public class DataModelContextFactory
    {
        private readonly string _connectionString;

        public DataModelContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DataModelContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new DataModelContext(options);
        }
    }
}
