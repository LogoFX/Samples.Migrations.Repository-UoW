using System.Data;
using System.Data.SqlClient;
using JetBrains.Annotations;
using LogoFX.Data.DbContext.AdoDotNet;

// ReSharper disable once CheckNamespace
namespace Samples.Server.Data.Context.AdoDotNet.SampleDataSetTableAdapters
{
    [UsedImplicitly]
    partial class CourtsTableAdapter : IDataTableAdapter
    {
        public void SetConnection(IDbConnection connection)
        {
            Connection = (SqlConnection) connection;
        }

        public int Fill(DataTable dataTable)
        {
            return Fill((SampleDataSet.CourtsDataTable) dataTable);
        }
    }
}