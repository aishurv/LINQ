using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace LINQ
{
    public class CustomerRepository
    {        
        public static List<Customer> ReadData(string filePath )
        {
            List <Customer> customers;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
           
            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, config);

            customers = csv.GetRecords<Customer>().ToList();
            return customers;
        }
    }
}
