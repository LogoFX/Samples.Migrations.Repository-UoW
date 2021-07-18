using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace LogoFX.Practices.Composition
{
    public class CompositionContainer : ICompositionContainer
    {
        private readonly string _rootPath;

        public CompositionContainer(string rootPath) => this._rootPath = rootPath;

        [ImportMany(typeof(ICompositionModule))]
        public IEnumerable<ICompositionModule> Modules { get; private set; }

        public void Compose()
        {
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            if (!Directory.Exists(this._rootPath))
                return;
            DirectoryCatalog directoryCatalog = new DirectoryCatalog(this._rootPath);
            aggregateCatalog.Catalogs.Add(directoryCatalog);
            System.ComponentModel.Composition.Hosting.CompositionContainer container = new System.ComponentModel.Composition.Hosting.CompositionContainer(aggregateCatalog);
            try
            {
                container.ComposeParts(this);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}