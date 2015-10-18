using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace speedtest_logger.Controllers
{
    public class TableController : Controller
    {
        // GET: Table
        public ActionResult Index()
        {
            speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            IEnumerable<speedtest_common.Objects.Result> results = repo.getResultsDays(7); // Get 7 days of results
            return PartialView("~/Views/shared/table.cshtml",results);
        }

        public ActionResult days(int rangeFrom)
        {
            speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            IEnumerable<speedtest_common.Objects.Result> results = repo.getResultsDays(rangeFrom);
            return PartialView("~/Views/shared/table.cshtml", results);
        }

        public ActionResult hours(int rangeFrom)
        {
            speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            IEnumerable<speedtest_common.Objects.Result> results = repo.getResultsHours(rangeFrom);
            return PartialView("~/Views/shared/table.cshtml", results);
        }

        public ActionResult range(DateTime rangeFrom, DateTime rangeTo)
        {
            speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            IEnumerable<speedtest_common.Objects.Result> results = repo.getResultsRange(rangeFrom, rangeTo);
            return PartialView("~/Views/shared/table.cshtml", results);
        }

        public ActionResult all()
        {
            speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            IEnumerable<speedtest_common.Objects.Result> results = repo.getAllResults();
            return PartialView("~/Views/shared/table.cshtml", results);
        }
    }
}
