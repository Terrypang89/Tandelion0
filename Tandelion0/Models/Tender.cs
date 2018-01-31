using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tandelion0.Models
{
    public class Tender
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
        public string PIC { get; set; }
        public string Designation { get; set; }
        public Decimal HP { get; set; }
        public Decimal ContactNo { get; set; }
        public int? TradeID { get; set; }
        public virtual Trade Trade { get; set; }
        public ICollection<Invitation> Invitation { get; set; }

    }
}