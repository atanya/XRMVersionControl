using System.Collections.Generic;

namespace WebApp.Models
{
    public class VersioningHistoryViewModel
    {
        public string AssemblyName { get; set; }

        public List<DomainModel.VersionControlRecord> Records { get; set; }
    }
}
