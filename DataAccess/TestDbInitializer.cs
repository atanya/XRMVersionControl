using System.Data.Entity;
using DomainModel;

namespace DataAccess
{
    public class TestDbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.VersionControlRecords.Add(new VersionControlRecord
            {
                UserName = "Tatyana A",
                Date = "1/1/2015",
                Comment = "Init",
                ClassName = "VersionedClass",
                Namespace = "TestLib",
                AssemblyName = "TestLib.dll"
            });

            context.VersionControlRecords.Add(new VersionControlRecord
            {
                UserName = "Tatyana A",
                Date = "1/1/2015",
                Comment = "Working on PBI-123",
                ClassName = "VersionedClass",
                MethodName = "CombineName",
                Namespace = "TestLib",
                AssemblyName = "TestLib.dll"
            });
        }
    }
}
