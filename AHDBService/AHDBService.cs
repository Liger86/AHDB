using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AHDBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AHDBService" in both code and config file together.
    public class AHDBService : IAHDBService
    {
        public void SaveCustomer(string description, string companyName, DateTime dateCreatedAsUtcTime)
        {
            Console.WriteLine("{0} saved.", companyName );
        }
    }
}