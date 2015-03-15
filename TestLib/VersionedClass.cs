using Common;

namespace TestLib
{
    [VersionControl("Tatyana A", "3/14/2015", "Add parameter method 'CombineName'")]
    public class VersionedClass
    {
        [VersionControl("Alex V", "3/15/2015", "Add parameter 'middleName'")]
        public string CombineName(string firstName, string middleName, string lastName)
        {
            return string.Empty;
        }

        public string UselessMethod(string firstName)
        {
            return string.Empty;
        }
    }
}
