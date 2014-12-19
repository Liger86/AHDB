using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.Data.EntityManagers;
using System.Data.Entity;

namespace AHDB.Data
{
    class EntityFrameworkManager : IDataManager
    {
        public EntityManagers.IServiceManager GetServiceManager()
        {
            return new ServiceManager();
        }

        public EntityManagers.ICustomerManager GetCustomerManager()
        {
            return new CustomerManager();
        }


        class ServiceManager : IServiceManager
        {
            public List<Service> GetAllServices()
            {
                List<Service> services = new List<Service>();
                using (AHDBEntities myEntities = new AHDBEntities())
                {
                    foreach (var item in myEntities.Services.ToList())
                    {
                        services.Add(
                            new Service() 
                            {
                                Id = item.Id,
                                Description = item.Description, 
                                Customer = item.Customer 
                            });
                    }
                }
                return services;
            }

            public void CreateNewService(string description, int customerId)
            {
                using (AHDBEntities myEntities = new AHDBEntities())
                {
                    Service myService = new Service() { Description = description, CustomerId = customerId };
                    myEntities.Services.Add(myService);
                    myEntities.SaveChanges();
                }
            }
        }

        class CustomerManager : ICustomerManager
        {
            public List<Customer> GetAllCustomers()
            {
                using (AHDBEntities myEntities = new AHDBEntities())
                {
                    return myEntities.Customers.ToList();
                }
            }
        }
    }
}