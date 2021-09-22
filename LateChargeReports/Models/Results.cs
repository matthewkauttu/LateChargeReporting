using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LateChargeReports.Models
{
    public class Results
    {
        public Results()
        {
            this.DataList = new List<sqlData>();
            this.QueryDates = new DateRange();
        }

        public List<sqlData> DataList { get; set; }
        public DateRange QueryDates { get; set; }
    }
}