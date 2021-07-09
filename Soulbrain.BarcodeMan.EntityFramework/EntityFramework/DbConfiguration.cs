using System.Data.Entity.SqlServer;

namespace Soulbrain.BarcodeMan.EntityFramework
{
    public class DbConfiguration: System.Data.Entity.DbConfiguration
    {
        public DbConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}
