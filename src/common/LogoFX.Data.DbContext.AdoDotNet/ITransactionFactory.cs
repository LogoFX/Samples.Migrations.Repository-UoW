using System.Data;

namespace LogoFX.Data.DbContext.AdoDotNet
{
    public interface ITransactionFactory
    {
        IDbTransaction CreateTransaction();
    }
}