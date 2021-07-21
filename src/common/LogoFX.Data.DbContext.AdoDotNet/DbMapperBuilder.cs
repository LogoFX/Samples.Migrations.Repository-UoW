using System;
using System.Collections.Generic;
using System.Data;

namespace LogoFX.Data.DbContext.AdoDotNet
{
    public sealed class DbMapperBuilder
    {
        private readonly IDbConnection _connection;

        private readonly Dictionary<Type, IDataTableAdapter> _dataTableAdapters =
            new Dictionary<Type, IDataTableAdapter>();

        private readonly Dictionary<Type, DataTable> _dataTables = 
            new Dictionary<Type, DataTable>();

        private sealed class MapInfo<TEntity, TAdapter, TDataTable> : IMapInfo<TEntity>
            where TEntity : class
        {
            public MapInfo(Func<DataRow, TEntity> convertFunc)
            {
                ConvertFunc = convertFunc;
            }

            public Type DataTableType => typeof(TDataTable);

            public Type DataTableAdapterType => typeof(TAdapter);

            public Func<DataRow, TEntity> ConvertFunc { get; }
        }

        private readonly Dictionary<Type, IMapInfo> _mapInfoDictionary = new Dictionary<Type, IMapInfo>();

        public DbMapperBuilder(IDbConnection connection)
        {
            _connection = connection;
        }

        public void AddMapping<TEntity, TAdapter, TDataTable>(Func<DataRow, TEntity> convertFunc) 
            where TEntity : class
        {
            _mapInfoDictionary.Add(typeof(TEntity), new MapInfo<TEntity, TAdapter, TDataTable>(convertFunc));
        }

        public DataTable GetDataTable<TEntity>()
            where TEntity : class
        {
            return GetDataObject<DataTable, TEntity>(_dataTables, CreateDataTable<TEntity>);
        }

        public IEnumerable<TEntity> Convert<TEntity>(DataTable dataTable) 
            where TEntity : class
        {
            var info = GetInfo<TEntity>();

            foreach (DataRow row in dataTable.Rows)
            {
                yield return info.ConvertFunc(row);
            }
        }

        public TEntity Convert<TEntity>(DataRow dataRow)
            where TEntity : class
        {
            var info = GetInfo<TEntity>();
            return info.ConvertFunc(dataRow);
        }

        private IMapInfo<TEntity> GetInfo<TEntity>()
            where TEntity : class
        {
            return (IMapInfo<TEntity>)_mapInfoDictionary[typeof(TEntity)];
        }

        private T GetDataObject<T, TEntity>(IDictionary<Type, T> dictionary, Func<T> createFunc)
        {
            if (dictionary.TryGetValue(typeof(TEntity), out var dataObject))
            {
                return dataObject;
            }

            dataObject = createFunc();
            dictionary[typeof(TEntity)] = dataObject;

            return dataObject;
        }

        private T CreateDataObject<T, TEntity>(Func<IMapInfo<TEntity>, Type> typeFunc)
            where TEntity : class
        {
            var info = GetInfo<TEntity>();
            var dataObject = (T) Activator.CreateInstance(typeFunc(info));
            return dataObject;
        }

        private DataTable CreateDataTable<TEntity>() 
            where TEntity : class
        {
            var dataTable = CreateDataObject<DataTable, TEntity>(info => info.DataTableType);
            var dataAdapter = GetDataObject<IDataTableAdapter, TEntity>(_dataTableAdapters, CreateDataTableAdapter<TEntity>);
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        private IDataTableAdapter CreateDataTableAdapter<TEntity>()
            where TEntity : class
        {
            var dataTableAdapter = CreateDataObject<IDataTableAdapter, TEntity>(info => info.DataTableAdapterType);
            dataTableAdapter.SetConnection(_connection);
            return dataTableAdapter;
        }
    }
}