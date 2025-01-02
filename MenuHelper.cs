using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class MenuHelper
    {
        public static void Menu(List<Customer> customers)
        {
            List<string> ValidFindAttributes = new List<string>
            {
                "CustomerID",
                "CustomerName",
                "CustomerCity",
                "CustomerCountry",
                "CustomerCompany",
                "CustomerPhone",
                "CustomerEmail"
            };
            string outputfilePath = "../../../ExpectedOutputData/";
            //StartOfMainMenu:       
            int choice = GetOperationToPerform();
            switch (choice)
            {
                case 1:
                    string attribute = GetAttribute(ValidFindAttributes);
                    System.Console.WriteLine("Enter Value to Search : ");
                    var value = Console.ReadLine();
                    var ExpectedCustomers = Queries.Find(customers, attribute, value ?? string.Empty);

                    System.Console.WriteLine("Enter the file name to save result : ");
                    var filename = Console.ReadLine();
                    outputfilePath += filename;
                    outputfilePath += ".csv";
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
                Environment.Exit(0);
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
                    Environment.Exit(0);
                else
                    return ichoice;
            }
            System.Console.WriteLine("Enter Valid Choice Press 0 To exit !");

            return GetOperationToPerform();
        }
    }
}
