using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tandelion0.Models
{
    public class Trade
    {
        public int ID { get; set; }
        public string TradeType { get; set; }
        public int NoTender { get; set; }
        public DateTime StartDate { get; set; }
        public int Progress { get; set; }
        public DateTime DueDate { get; set; }
        public int? ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Tender> Tender { get; set; }
    }
}