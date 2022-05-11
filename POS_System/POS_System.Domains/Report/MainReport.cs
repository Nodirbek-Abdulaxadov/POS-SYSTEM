using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.Domains.Report
{
    public class MainReport
    {
        [Required, Key]
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double TotalIncomingPrice { get; set; }
        public double TotalSellingPrice { get; set; }
        //sof foyda
        public double NetProfit { get; set; }
    }
}
