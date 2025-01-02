using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Serilog;
namespace LINQ
{
    public static class SaveOutputCSV
    {
        public static string getPathFromString(String str)
        {
            string outputfilePath = "../../../ExpectedOutputData/";
            outputfilePath += str;
            outputfilePath += ".csv";
            return outputfilePath;
        }
        public static string getPathFromConsole()
        {

            string outputfilePath = "../../../ExpectedOutputData/";
            System.Console.WriteLine("Enter the file name to save result : ");
            var filename = Console.ReadLine();
            outputfilePath += filename;
            outputfilePath += ".csv";
            return outputfilePath;
        }
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
            
            Log.Information($"{nameof(filePath)}file written successfully!");
        }
    }
}
