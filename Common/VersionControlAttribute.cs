using System;

namespace Common
{
    public class VersionControlAttribute: Attribute
    {
        public string Author { get; private set; }

        public string Date { get; private set; }

        public string Comment { get; private set; }

        public VersionControlAttribute(string author, string date, string comment)
        {
            Author = author;
            Comment = comment;
            Date = date;
        }
    }
}
