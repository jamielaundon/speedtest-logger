using Google.DataTable.Net.Wrapper;
using Google.DataTable.Net.Wrapper.Extension;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using speedtest_common.Objects;

namespace speedtest_logger.Controllers
{
    public class JsonController : Controller
    {
        // GET: json
        public string Index()
        {
            speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            IEnumerable<speedtest_common.Objects.Result> results = repo.getResultsDays(7); // Get 7 days of results
            return convertResultsToDatatable(ref results);
        }

        public string days(int rangeFrom)
        {
            speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            IEnumerable<speedtest_common.Objects.Result> results = repo.getResultsDays(rangeFrom); 
            return convertResultsToDatatable(ref results);
        }

        public string hours(int rangeFrom)
        {
            speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            IEnumerable<speedtest_common.Objects.Result> results = repo.getResultsHours(rangeFrom);
            return convertResultsToDatatable(ref results);
        }

        public string range(DateTime rangeFrom, DateTime rangeTo)
        {
            speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            IEnumerable<speedtest_common.Objects.Result> results = repo.getResultsRange(rangeFrom, rangeTo);
            return convertResultsToDatatable(ref results);
        }

        public string all()
        {
            speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            IEnumerable<speedtest_common.Objects.Result> results = repo.getAllResults();
            return convertResultsToDatatable(ref results);
        }

        
        private string convertResultsToDatatable(ref IEnumerable<Result> results)
        {
            var json = results.ToGoogleDataTable()
               .NewColumn(new Column(ColumnType.Datetime, "Time"), x => x.logTime)
               .NewColumn(new Column(ColumnType.Number, "Speed Down (MBps)"), x => (decimal)x.download / 1000)
               .NewColumn(new Column(ColumnType.Number, "Speed Up (MBps)"), x => (decimal)x.upload / 1000)
               .NewColumn(new Column(ColumnType.Number, "Ping Time (ms)"), x => x.ping)
               .Build()
               .GetJson();

            return json;
        }


        //We are attempting to generate:
        /*
        {
	"cols": [{
		"id": "",
		"label": "Time",
		"pattern": "",
		"type": "datetime"
	},
	{
		"id": "",
		"label": "Speed Down (MBps)",
		"pattern": "",
		"type": "number"
	},
	{
		"id": "",
		"label": "Speed Up (MBps)",
		"pattern": "",
		"type": "number"
	},
	{
		"id": "",
		"label": "Ping Time (ms)",
		"pattern": "",
		"type": "number"
	}],
	"rows": [{
		"c": [{
			"v": "Date(2015, 9, 18, 1, 0, 0)"
		},
		{
			"v": 40
		},
		{
			"v": 3
		},
		{
			"v": 50
		}]
	},
	{
		"c": [{
			"v": "Date(2015, 9, 18, 2, 0, 0)"
		},
		{
			"v": 45
		},
		{
			"v": 3
		},
		{
			"v": 50
		}]
	}]
    */
        
    }
}
