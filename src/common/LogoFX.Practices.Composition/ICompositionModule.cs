using LogoFX.Practices.IoC;

namespace LogoFX.Practices.Composition
{
    public interface ICompositionModule
    {
        void RegisterModule(IIocContainer container);
    }
}