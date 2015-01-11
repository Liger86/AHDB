using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.Data.EntityManagers
{
    public interface ICustomerManager
    {
        void CreateNewCustomer(string description, string companyName);
        List<Customer> GetAllCustomers();
    }
}
