using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace speedtest_common
{
    public class dbConfig
    {
        public static System.Data.Common.DbConnection create(string connectionString)
        {
            return new System.Data.SqlClient.SqlConnection(connectionString);
        }
    }
}
