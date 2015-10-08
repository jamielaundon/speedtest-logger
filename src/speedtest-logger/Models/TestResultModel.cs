using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace speedtest_logger.Models
{
    public class TestResultModel
    {

        private speedtest_common.Objects.Result dbObj = null;

        public TestResultModel()
        {
            dbObj = new speedtest_common.Objects.Result();
        }

        public TestResultModel(speedtest_common.Objects.Result r)
        {
            dbObj = r;
        }
        public speedtest_common.Objects.Result databaseObject { get { return dbObj; } }

        public int download
        {
            get { return dbObj.download; }
            set { dbObj.download = value; }
        }
        public int ping
        {
            get { return dbObj.ping; }
            set { dbObj.ping = value; }
        }
        public int upload
        {
            get { return dbObj.upload; }
            set { dbObj.upload = value; }
        }
        public int serverid
        {
            get { return dbObj.serverid; }
            set { dbObj.serverid = value; }
        }

        public DateTime logTime
        {
            get { return dbObj.logTime; }
        }

        public string hash { get; set; }
        
    }
}