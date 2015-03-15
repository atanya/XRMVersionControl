using System.Collections.Generic;
using System.IO;
using System.Linq;
using BusinessLogicApi;
using DataAccessApi;
using DomainModel;
using VersionControlCoreApi;

namespace BusinessLogic
{
    public class VersionControlService : IVersionControlService
    {
        public IVersionControlParser Parser { get; set; }
        public IVersionControlRepository Repository { get; set; }

        public List<VersionControlRecord> Save(Stream stream, string assemblyName)
        {
            var result = Parser.Parse(stream, assemblyName);

            var currentRecords = Repository.Load(assemblyName);

            //filter out duplicates
            var recordsToAdd = result.Where(
                newRecord => !(currentRecords.Any(oldRecord => newRecord.Date.Equals(oldRecord.Date) &&
                                                               newRecord.UserName.Equals(oldRecord.UserName) &&
                                                               newRecord.Comment.Equals(oldRecord.Comment)))).ToList();
            if (recordsToAdd.Any())
            {
                Repository.Save(recordsToAdd);
            }

            return Load(assemblyName);
        }

        public List<VersionControlRecord> Load(string assemblyName)
        {
            return Repository.Load(assemblyName);
        }
    }
}
