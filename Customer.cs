using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public  class Customer
    {
        public required string CustomerID { get; set; }
        public string CustomerName { get; set; };
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }

        public string CustomerCompany { get; set; }

        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }

    }

}
