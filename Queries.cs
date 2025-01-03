using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
namespace LINQ
{
    public class Queries
    {
        public static List<Customer> Find(List<Customer> customers , string attributeName , string attributeValue)
        {
            Log.Information($"Find {attributeValue} of {attributeName}");
#nullable disable
            var property = typeof(Customer).GetProperty(attributeName);
            
            var matchedCustomers = customers.Where(c =>
            {
                var value = property.GetValue(c)?.ToString();
                return !string.IsNullOrEmpty(value) &&
                       !string.IsNullOrEmpty(attributeValue) &&
                       value.Equals(attributeValue, StringComparison.OrdinalIgnoreCase);
            }).ToList();
            return matchedCustomers;
        }
        public static List<Customer> SortCustomers(List<Customer> customers, string attributeName, bool ascending = true)
        {
            var property = typeof(Customer).GetProperty(attributeName);            
            return ascending
                ? customers.OrderBy(c => property.GetValue(c, null)).ToList()
                : customers.OrderByDescending(c => property.GetValue(c, null)).ToList();
        }
        public static IEnumerable<IGrouping<object, Customer>> GroupByAttribute(List<Customer> collection, string attributeName)
        {
            var property = typeof(Customer).GetProperty(attributeName);
            
            return collection.GroupBy(item => property.GetValue(item, null));
        }


    }
}
