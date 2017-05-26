using System.IO;
using System.Reflection;

namespace MySalesApp.Data.Dal
{
    public class LiteDbConnection : IDbConnection
    {
        public string GetDbConnectionString()
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return Path.Combine(dir, "MySalesTripData.db");
        }
    }
}
