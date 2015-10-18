using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using speedtest_logger.Models;
using System.Configuration;
using Newtonsoft.Json;

namespace speedtest_logger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //speedtest_common.Repositories.TestRepository repo = new speedtest_common.Repositories.TestRepository(speedtest_common.dbConfig.create(ConfigurationManager.ConnectionStrings["speedtest_logger.Properties.Settings.logConnectionString"].ConnectionString));
            //IEnumerable<speedtest_common.Objects.Result> results = repo.getResultsDays(7); // Get 7 days of results by default
            //return View(results);
            return View(); // V2 We now return an empty View.  The data is loaded via Ajax instead.
        }
    }
}