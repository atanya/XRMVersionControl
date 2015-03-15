using Common;

namespace TestLib
{
    public class ClassWithPrivateVersionedMethod
    {
        [VersionControl("Jane M", "3/12/2015", "Working on issue-1234")]
        private string CompletelyUselessMethod()
        {
            return "";
        }

        [VersionControl("Jane M", "3/10/2015", "Working on issue-1234")]
        public static string StaticMethod()
        {
            return "";
        }
    }
}
