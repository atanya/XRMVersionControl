using System.Collections.Generic;
using System.IO;
using DomainModel;

namespace DataAccessApi
{
    public interface IVersionControlRepository
    {
        void Save(List<VersionControlRecord> records);

        List<VersionControlRecord> Load(string assemblyName);
    }
}
