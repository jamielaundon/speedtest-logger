using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using speedtest_common.Objects;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace speedtest_common.Repositories
{
    public class TestRepository
    {
        private System.Data.Common.DbConnection conn;
        public TestRepository(System.Data.Common.DbConnection connc)
        {
            conn = connc;
        }
        public IEnumerable<Result> getAllResults()
        {
            return conn.Query<Result>("Select * from speedtest");
        }
        public void create(Result result)
        {
            result.logTime = DateTime.Now;
            conn.Insert<Result>(result);
        }

    }
}
