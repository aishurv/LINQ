// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Reflection;
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

            //MenuHelper.Menu(customers);

            //HandsOnLINQ.findAllAttributeWith0thValue(customers);
            HandsOnLINQ.SortByAllAttributes(customers,true);
            HandsOnLINQ.SortByAllAttributes(customers, false);
            //SaveOutputCSV.WriteToCSV(customers, outputfilePath);
            Logger.LogClose(); // Log.CloseAndFlush();
        }

        public static void findAllAttributeWith0thValue(List<Customer> customers)
        {
            if (customers == null || customers.Count == 0)
            {
                Log.Information("The customer list is empty or null.");
                return;
            }

            var customer = customers[0];
            foreach (var attr in MenuHelper.ValidFindAttributes)
            {
                var property = customer.GetType().GetProperty(attr);
                if (property != null)
                {
                    var value = property.GetValue(customer);
#nullable disable
                    string search = value != null ? value.ToString().Trim() : string.Empty;
                    var ExpectedCustomers = Queries.Find(customers, attr, search);

                    string outputfilePath = SaveOutputCSV.getPathFromString($"{attr}_{search}");
                    SaveOutputCSV.WriteToCSV(ExpectedCustomers, outputfilePath);
                }
                else
                {
                    Console.WriteLine($"Attribute '{attr}' does not exist in the Customer class.");
                }
            }
        }

        public static void SortByAllAttributes(List<Customer> customers,bool isAscending)
        {
            if (customers == null || customers.Count == 0)
            {
                Log.Information("The customer list is empty or null.");
                return;
            }
            foreach (var attr in MenuHelper.ValidSortAttributes)
            {
                var ExpectedCustomers = Queries.SortCustomers(customers, attr, isAscending);
                string outputfilePath = SaveOutputCSV.getPathFromString($"{attr}_Sort_{isAscending}");
                SaveOutputCSV.WriteToCSV(ExpectedCustomers, outputfilePath);
            }
        }


    }
} 