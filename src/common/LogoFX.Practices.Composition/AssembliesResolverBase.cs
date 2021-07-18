using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LogoFX.Practices.Composition
{
    public abstract class AssembliesResolverBase : IAssembliesReadOnlyResolver
    {
        private readonly ICompositionModulesProvider _compositionModulesProvider;

        protected AssembliesResolverBase(
            ICompositionModulesProvider compositionModulesProvider)
        {
            _compositionModulesProvider = compositionModulesProvider;
        }

        protected abstract IEnumerable<Assembly> GetRootAssemblies();

        public IEnumerable<Assembly> GetAssemblies() => this.GetRootAssemblies()
            .Concat(_compositionModulesProvider.Modules != null
                ? _compositionModulesProvider.Modules.Select(t => t.GetType().Assembly)
                : new Assembly[0]);
    }
}