using System.Data;
using System.Data.SqlClient;
using System.Linq;
using JetBrains.Annotations;
using LogoFX.Data.DbContext.AdoDotNet;
using LogoFX.Data.Repository;
using Samples.Server.Data.Context.AdoDotNet.SampleDataSetTableAdapters;
using Samples.Server.Domain.Entities;

namespace Samples.Server.Data.Context.AdoDotNet
{
    [UsedImplicitly]
    public class AppDbContext : IDbContext
    {
        private readonly IConnectionStringService _connectionStringService;
        private DbMapperBuilder _dbMapperBuilder;
        private SqlConnection _connection;

        public AppDbContext(IConnectionStringService connectionStringService)
        {
            _connectionStringService = connectionStringService;
            Initialize();
        }

        private void Initialize()
        {
            var connectionString = _connectionStringService.GetConnectionString();

            _connection = new SqlConnection(connectionString);
            _dbMapperBuilder = new DbMapperBuilder(_connection);

            _dbMapperBuilder.AddMapping<Court, CourtsTableAdapter, SampleDataSet.CourtsDataTable>(dataRow =>
            {
                var courtsRow = (SampleDataSet.CourtsRow) dataRow;
                return new Court
                {
                    Id = courtsRow.id,
                    Name = courtsRow.name,
                    LevelId = courtsRow.levelId
                };
            });
        }

        IDbConnection IDbContext.Connection => _connection;

        IQueryable<T> IDbContext.Set<T>()
        {
            var dataTable = _dbMapperBuilder.GetDataTable<T>();
            var entities = _dbMapperBuilder.Convert<T>(dataTable);
            return entities.AsQueryable();
        }

        int IDbContext.SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}