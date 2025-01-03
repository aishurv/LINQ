using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace LINQ
{
    internal static class MenuHelper
    {
        public static List<string> ValidFindAttributes = 
            [
                "CustomerID",
                "CustomerName",
                "CustomerCity",
                "CustomerCountry",
                "CustomerCompany",
                "CustomerPhone",
                "CustomerEmail"
            ];
        public static List<string> ValidSortAttributes =
            [
                "CustomerID",
                "CustomerName",
                "CustomerCity",
                "CustomerCountry",
                "CustomerCompany",
                "CustomerPhone",
                "CustomerEmail"
            ];
        public static void Menu(List<Customer> customers)
        {
            
            //StartOfMainMenu:       
            int choice = GetOperationToPerform();
            switch (choice)
            {
                case 1:
                    string attribute = GetAttribute(ValidFindAttributes);
                    System.Console.WriteLine("Enter Value to Search : ");
                    var value = Console.ReadLine();
                    var ExpectedCustomers = Queries.Find(customers, attribute, value ?? string.Empty);

                    string outputfilePath = SaveOutputCSV.getPathFromConsole();
                    SaveOutputCSV.WriteToCSV(ExpectedCustomers, outputfilePath);

                    break;
                case 2:
                    attribute = GetAttribute(ValidSortAttributes);
                    System.Console.WriteLine("Enter Ascending or descending order: ");
                    var order = Console.ReadLine();
                    order = order ?? "ascending";
                    bool isAscending = true;
                    isAscending = order[0]=='D'||order[0]=='d'?false:true;
                    ExpectedCustomers = Queries.SortCustomers(customers, attribute, isAscending);

                    outputfilePath = SaveOutputCSV.getPathFromConsole();
                    SaveOutputCSV.WriteToCSV(ExpectedCustomers, outputfilePath);

                    break;
                default:
                    Console.WriteLine("Thank You !");
                    break;
            }

        }
        public static string GetAttribute(List<string> attributes)
        {
            foreach (string attribute in attributes)
            {
                Console.WriteLine(attribute);
            }
            System.Console.WriteLine("Enter Atribute to find (From Above Choice): ");
            string inputAttribute = Console.ReadLine() ?? "EXIT";
            if (attributes.Any(attr => attr.Equals(inputAttribute, StringComparison.OrdinalIgnoreCase)))
            {
                return inputAttribute;
            }
            if (inputAttribute == "EXIT")
                MenuHelper.ExitApplication();
            System.Console.WriteLine("Enter Valid Choice Press EXIT To exit !");
            return GetAttribute(attributes);
        }
        public static int GetOperationToPerform()
        {
            System.Console.WriteLine("Find :    1 ");
            System.Console.WriteLine("Sort :    2 ");
            System.Console.WriteLine("Group :   3 ");
            System.Console.WriteLine("Enter Operation (From Above Choice): ");
            string choice = Console.ReadLine() ?? "1";
            if (int.TryParse(choice, out int ichoice))
            {
                if (ichoice == 0)
                    MenuHelper.ExitApplication();
                else
                    return ichoice;
            }
            System.Console.WriteLine("Enter Valid Choice Press 0 To exit !");

            return GetOperationToPerform();
        }
        public static void ExitApplication()
        {
            Log.Warning("User Want to Exit !");
            Logger.LogClose();
            Environment.Exit(0);
        }
    }
}
