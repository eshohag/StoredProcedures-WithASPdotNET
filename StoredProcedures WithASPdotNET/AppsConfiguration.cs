using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace StoredProcedures_WithASPdotNET
{
    public class AppsConfiguration : DbConfiguration
    {
        public AppsConfiguration()
        {
            //maximum try 3 times of execution of database otherwise error
            SetExecutionStrategy("System.Data.sqlClient", () => new SqlAzureExecutionStrategy(3, new TimeSpan(0, 0, 5)));
        }
    }
}