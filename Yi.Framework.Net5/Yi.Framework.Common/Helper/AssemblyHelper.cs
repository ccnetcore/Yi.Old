using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Yi.Framework.Common.Helper
{
    public class AssemblyHelper
    {
        public static List<Type> GetClass(string assemblyFile, string className = null, string spaceName=null)
        {
            Assembly assembly = Assembly.Load(assemblyFile);
            return assembly.GetTypes().Where(m => m.IsClass 
            && className == null?true:m.Name==className
            && spaceName == null ? true :m.Namespace == spaceName
             ).ToList();
        }

    }
}
