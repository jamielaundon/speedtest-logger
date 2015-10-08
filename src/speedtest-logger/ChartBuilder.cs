using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using speedtest_common;
using System.Text;

namespace speedtest_logger
{
    public static class ChartBuilder
    {
        public static string chartString(IEnumerable<speedtest_common.Objects.Result> testResults)
        {
            //Format is [new Date(2015, 10, 01, 06, 00), 29.556, 17.89, 2.48],
            //NB Zero-based months
            List<String> ls = new List<string>();
            foreach (var result in testResults)
            {
                string str = String.Format("[new Date({0}, {1}, {2}, {3}, {4}), {5:0.00}, {6:0.00}, {7}]", result.logTime.Year, (result.logTime.Month - 1), result.logTime.Day, result.logTime.Hour, result.logTime.Minute, (decimal)result.download/1000, (decimal)result.upload/1000, result.ping);
                ls.Add(str);
            }
            return String.Join(",\n", ls);
        }
    }
}