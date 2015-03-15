using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class VersionControlRecord
    {
        [Key]
        public int VersionControlRecordId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string AssemblyName { get; set; }

        [Required]
        public string Namespace { get; set; }

        [Required]
        public string ClassName { get; set; }

        public string MethodName { get; set; }
    }
}
