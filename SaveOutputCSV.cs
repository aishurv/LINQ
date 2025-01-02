using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace LINQ
{
    public static class SaveOutputCSV
    {
        public static void WriteToCSV(List<Customer> CustomersData,String filePath)
        {
            
            var writer = new StreamWriter(filePath);
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Write the header row and data
                if (CustomersData.Count!=0)
                    csv.WriteRecords(CustomersData);
                else
                    csv.WriteRecords("No Result Found !");
            }
            
            Console.WriteLine($" file written successfully!");
        }
    }
}
