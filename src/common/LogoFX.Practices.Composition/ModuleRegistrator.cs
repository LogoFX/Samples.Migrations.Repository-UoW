using LogoFX.Practices.IoC;

namespace LogoFX.Practices.Composition
{
    public class ModuleRegistrator : IModuleRegistrator
    {
        private readonly IIocContainer _iocContainer;
        private readonly ICompositionContainer _compositionContainer;

        public ModuleRegistrator(IIocContainer iocContainer, ICompositionContainer compositionContainer)
        {
            this._iocContainer = iocContainer;
            this._compositionContainer = compositionContainer;
        }

        public void RegisterModules()
        {
            if (this._compositionContainer.Modules == null)
                return;
            foreach (ICompositionModule module in this._compositionContainer.Modules)
                module.RegisterModule(this._iocContainer);
        }
    }
}