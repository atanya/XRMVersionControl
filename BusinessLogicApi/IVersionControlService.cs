using System.Collections.Generic;
using System.IO;
using DomainModel;

namespace BusinessLogicApi
{
    public interface IVersionControlService
    {
        List<VersionControlRecord> Save(Stream stream, string assemblyName);

        List<VersionControlRecord> Load(string assemblyName);
    }
}
