using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Queries
    {
        public static List<Customer> Find(List<Customer> customers , string attributeName , string attributeValue)
        {
            var matchedCustomers = customers.Where(c =>
            {
                var property = typeof(Customer).GetProperty(attributeName);
                if (property != null)
                {
                    // Get the value of the property for the customer object
                    var value = property.GetValue(c)?.ToString();
                    return value != null && value.Equals(attributeValue, StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }).ToList();
            return matchedCustomers;
        }
    }
}
