using System;
using System.Data;

namespace LogoFX.Data.DbContext.AdoDotNet
{
    internal interface IMapInfo
    {
        Type DataTableType { get; }

        Type DataTableAdapterType { get; }
    }

    internal interface IMapInfo<out TEntity> : IMapInfo
        where TEntity : class
    {
        Func<DataRow, TEntity> ConvertFunc { get; }
    }
}