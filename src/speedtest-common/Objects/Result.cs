using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace speedtest_common.Objects
{
    [Table("speedtest")]
    public class Result
    {
        [Key]
        public int id { get; set; }
        public int download { get; set; }
        public int ping { get; set; }
        public int upload { get; set; }
        public int serverid { get; set; }
        public DateTime logTime { get; set; }
        
    }
}
