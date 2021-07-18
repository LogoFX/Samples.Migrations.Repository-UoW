using LogoFX.Practices.Composition;
using LogoFX.Practices.IoC;

namespace LogoFX.Web.Core
{
	public class BootstrapperInitializationFacade : BootstrapperInitializationFacadeBase
	{
		public BootstrapperInitializationFacade(IIocContainer iocContainer)
			: base(iocContainer)
		{
		}

		protected override IAssembliesReadOnlyResolver CreateAssembliesResolver() 
			=> new AssembliesResolver(CompositionContainer);
	}
}