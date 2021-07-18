using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Dispatcher;
using LogoFX.Practices.Composition;

namespace LogoFX.Web.Core
{
    public class AssembliesResolver : AssembliesResolverBase, IAssembliesResolver
    {
	    public AssembliesResolver(
		    ICompositionModulesProvider compositionModulesProvider)
		    : base(compositionModulesProvider)
	    {
	    }

	    protected override IEnumerable<Assembly> GetRootAssemblies() => new[]
	    {
		    GetEntryAssembly()
	    };

	    ICollection<Assembly> IAssembliesResolver.GetAssemblies() => GetAssemblies().ToList();

	    private static Assembly GetEntryAssembly()
	    {
		    if (HttpContext.Current == null || HttpContext.Current.ApplicationInstance == null)
			    return null;
		    var type = HttpContext.Current.ApplicationInstance.GetType();
		    while (type?.BaseType != null && type.BaseType.Name != "HttpApplication")
			    type = type.BaseType;
		    return type.Assembly;
	    }
    }
}
