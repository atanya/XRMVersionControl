using System.Collections.Generic;
using System.Linq;
using DataAccessApi;
using DomainModel;

namespace DataAccess
{
    public class VersionControlRepository : IVersionControlRepository
    {
        public DataContext DataContext { get; set; }

        public void Save(List<VersionControlRecord> records)
        {
            DataContext.VersionControlRecords.AddRange(records);
            DataContext.Commit();
        }

        public List<VersionControlRecord> Load(string assemblyName)
        {
            return DataContext.VersionControlRecords
                .Where(record=> record.AssemblyName.ToLower().Equals(assemblyName.ToLower()))
                .OrderByDescending(record=> record.Date).ToList();
        }
    }
}
