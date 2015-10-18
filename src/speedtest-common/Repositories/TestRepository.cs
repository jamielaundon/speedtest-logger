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
            //Get all results
            return conn.Query<Result>("Select * from speedtest");
        }

        public IEnumerable<Result> getResultsHours(int hours)
        {
            //Get all results in the last n hours
            return conn.Query<Result>("Select * from speedtest where logTime >= @minRange",
                        new { minRange = DateTime.Now.AddHours(-hours) });
        }

        public IEnumerable<Result> getResultsDays(int days)
        {
            //Get all results in the last n days, starting at midnight
            return conn.Query<Result>("Select * from speedtest where logTime >= @minRange",
                        new { minRange = DateTime.Today.AddDays(-days+1) });
        }

        public IEnumerable<Result> getResultsRange(DateTime startDate, DateTime endDate)
        {
            //Get all results between two times, inclusive.
            return conn.Query<Result>("Select * from speedtest where logTime >= @minRange and logTime <=@maxRange",
                        new { minRange = startDate, maxRange = endDate });
        }

        public void create(Result result)
        {
            // Create a log entry
            result.logTime = DateTime.Now;
            conn.Insert<Result>(result);
        }

        
    }
}
