using System.Data;

namespace LogoFX.Data.DbContext.AdoDotNet
{
    public interface IDataTableAdapter
    {
        void SetConnection(IDbConnection connection);

        int Fill(DataTable dataTable);
    }
}