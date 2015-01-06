using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.Data.EntityManagers;
using System.Data.Entity;
using System.Collections.ObjectModel;

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
            public List<Repair> GetAllNotCompletedRepairsAndTheirVendor()
            {
                List<Repair> result = new List<Repair>();
                using (AHDBContext myContext = new AHDBContext())
                {
                    result = (from repair in myContext.Repairs.Include("Vendors").Include("Customer")
                                           where repair.Completed == false
                                           select repair).ToList();
                }
                return result;
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