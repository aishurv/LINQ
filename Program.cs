// See https://aka.ms/new-console-template for more information
using System;
using CsvHelper;
namespace LINQ
{
    public class HandsOnLINQ
    {
        public static void Main ()
        {
            string inputfilePath = "../../../CustomerData.csv";//"CustomerData.csv" ;
            string outputfilePath = "../../../OutputCustomerData.csv";

            List<Customer> customers = CustomerRepository.ReadData(inputfilePath);



            SaveOutputCSV.WriteToCSV(customers, outputfilePath);

        }

    }
} 