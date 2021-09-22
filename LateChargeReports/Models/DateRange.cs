using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LateChargeReports.Models
{
    public class DateRange
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public string FormatDateString(DateTime date)
        {
            return Convert.ToString(date).Split(' ')[0];
        }
    }
}