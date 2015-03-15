using System.Data.Entity;
using DomainModel;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<VersionControlRecord> VersionControlRecords { get; set; }

        public DataContext()
            : base("DefaultConnection")
        {
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
