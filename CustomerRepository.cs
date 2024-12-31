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
            List <Customer> customers = new List<Customer>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null // Disables header validation
            };
            var reader = new StreamReader(filePath);
            var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<Customer>();
            foreach (var customer in records)
            {
                customers.Add(customer);
            }
            return customers;
        }
    }
}
