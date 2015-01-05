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
                using (AHDBContext myContext = new AHDBContext())
                {
                    foreach (var item in myContext.Repairs.ToList())
                    {
                        repairs.Add(
                            new Repair() 
                            {
                                ID = item.ID,
                                Description = item.Description, 
                                Customer = item.Customer 
                            });
                    }
                }
                return repairs;
            }

            public void CreateNewRepair(string description, int customerId)
            {
                using (AHDBContext myContext = new AHDBContext())
                {
                    Repair myRepair = new Repair() { Description = description, ID = customerId };
                    myContext.Repairs.Add(myRepair);
                    myContext.SaveChanges();
                }
            }
        }

        class CustomerManager : ICustomerManager
        {
            public List<Customer> GetAllCustomers()
            {
                using (AHDBContext myEntities = new AHDBContext())
                {
                    return myEntities.Customers.ToList();
                }
            }
        }
    }
}