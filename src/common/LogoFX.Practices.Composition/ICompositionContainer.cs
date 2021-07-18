namespace LogoFX.Practices.Composition
{
    public interface ICompositionContainer : ICompositionModulesProvider
    {
        void Compose();
    }
}