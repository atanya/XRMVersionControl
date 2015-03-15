using System.Collections.Generic;
using System.IO;
using DomainModel;

namespace VersionControlCoreApi
{
    public interface IVersionControlParser
    {
        List<VersionControlRecord> Parse(Stream stream, string assemblyName);
    }
}
