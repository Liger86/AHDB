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
        public EntityManagers.IRepairManager GetRepairManager()
        {
            return new RepairManager();
        }

        public EntityManagers.ICustomerManager GetCustomerManager()
        {
            return new CustomerManager();
        }


        class RepairManager : IRepairManager
        {
            public List<Repair> GetAllRepairs()
            {
                List<Repair> repairs = new List<Repair>();
                using (AHDBEntities myEntities = new AHDBEntities())
                {
                    foreach (var item in myEntities.Repairs.ToList())
                    {
                        repairs.Add(
                            new Repair() 
                            {
                                Id = item.Id,
                                Description = item.Description, 
                                Customer = item.Customer 
                            });
                    }
                }
                return repairs;
            }

            public void CreateNewRepair(string description, int customerId)
            {
                using (AHDBEntities myEntities = new AHDBEntities())
                {
                    Repair myRepair = new Repair() { Description = description, CustomerId = customerId };
                    myEntities.Repairs.Add(myRepair);
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