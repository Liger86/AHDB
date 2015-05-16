using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AHDBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAHDBService" in both code and config file together.
    [ServiceContract]
    public interface IAHDBService
    {
        [OperationContract]
        void SaveCustomer(string description, string companyName, DateTime dateCreatedAsUtcTime);
    }
}
