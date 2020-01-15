using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace ControllerTestApi.Resolver
{
    //https://www.strathweb.com/2012/06/using-controllers-from-an-external-assembly-in-asp-net-web-api/
    public class AssembliesResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            ICollection<Assembly> baseAssemblies = base.GetAssemblies();
            List<Assembly> assemblies = new List<Assembly>(baseAssemblies);
            var controllersAssembly = Assembly.LoadFrom("ExternalControllers.dll");
            baseAssemblies.Add(controllersAssembly);
            return assemblies;
        }
    }

    public class CustomAssemblyResolver : IAssembliesResolver
    {
        public ICollection<Assembly> GetAssemblies()
        {
            List<Assembly> baseAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var controllersAssembly = Assembly.LoadFrom(@"ExternalControllers.dll");
            baseAssemblies.Add(controllersAssembly);
            return baseAssemblies;
        }
    }
}