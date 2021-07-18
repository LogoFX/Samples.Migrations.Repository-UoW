using System.Collections.Generic;
using System.Reflection;

namespace LogoFX.Practices.Composition
{
    public interface IAssembliesReadOnlyResolver
    {
        IEnumerable<Assembly> GetAssemblies();
    }
}