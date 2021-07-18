using System;

namespace LogoFX.Practices.IoC
{
    public static class ServiceLocator
    {
        private static IServiceLocator _current;

        public static IServiceLocator Current
        {
            get => _current ?? throw new NullReferenceException("Service Locator must be set");
            set => _current = value;
        }
    }
}