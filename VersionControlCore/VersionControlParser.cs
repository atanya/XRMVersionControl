using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Common;
using DomainModel;
using VersionControlCoreApi;

namespace VersionControlCore
{
    public class VersionControlParser : IVersionControlParser
    {
        public List<VersionControlRecord> Parse(Stream stream, string assemblyName)
        {
            var result = new List<VersionControlRecord>();

            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            var assembly = Assembly.Load(buffer);

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                result.AddRange(SelectAttributes(type, assemblyName, type.Namespace, type.Name));

                var methods = type.GetMethods(
                    BindingFlags.DeclaredOnly 
                    |BindingFlags.Public 
                    | BindingFlags.NonPublic 
                    | BindingFlags.Instance 
                    | BindingFlags.Static);
                foreach (var method in methods)
                {
                    result.AddRange(SelectAttributes(method, assemblyName, type.Namespace, type.Name, method.Name));
                }
            }

            return result;
        }

        private IEnumerable<VersionControlRecord> SelectAttributes(
            MemberInfo mi, 
            string assemblyName,
            string nameSpace,
            string typeName,
            string methodName = "")
        {
            var attrs = Attribute.GetCustomAttributes(mi);

            return attrs.OfType<VersionControlAttribute>()
                .Select(vca => new VersionControlRecord
                {
                    UserName = vca.Author,
                    Date = vca.Date,
                    Comment = vca.Comment,
                    AssemblyName = assemblyName,
                    ClassName = typeName,
                    Namespace = nameSpace,
                    MethodName = methodName,
                });
        }
    }
}
