using System.Data;

namespace LogoFX.Data.Repository.EntityFramework
{
    public class RepositoryConfiguration
    {
        public TransactionTypes TransactionType = TransactionTypes.DbTransaction;
        public IsolationLevel IsolationLevel = IsolationLevel.ReadUncommitted;

        public bool ProxyCreationEnabled = false;
        public bool RethrowExceptions = false;
        public bool UseTransaction = true;
        public bool LazyConnection = false;
        public bool SaveLastExecutedMethodInfo = false;

        public int CommandTimeout = 300;

        public string ConnectionString = string.Empty;
    }
}