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
                csv.WriteRecords(CustomersData);
            }
            Console.WriteLine($"{filePath} file written successfully!");
        }
    }
}
