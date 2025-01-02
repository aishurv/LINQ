// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using CsvHelper;
using Serilog;

namespace LINQ
{
    public class HandsOnLINQ
    {
        public static void Main ()
        {
            Logger.LogInitializer(); // Logger initialization 

            Log.Information("Program Started !");

            string inputfilePath = "../../../CustomerData.csv";

            //string outputfilePath = "../../../OutputCustomerData.csv";

            List<Customer> customers = CustomerRepository.ReadData(inputfilePath);

            MenuHelper.Menu(customers);


            //SaveOutputCSV.WriteToCSV(customers, outputfilePath);
            Logger.LogClose(); // Log.CloseAndFlush();
        }
        
    }
} 