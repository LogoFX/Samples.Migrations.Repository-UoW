using System.Collections.Generic;

namespace LogoFX.Practices.Composition
{
    public interface ICompositionModulesProvider
    {
        IEnumerable<ICompositionModule> Modules { get; }
    }
}