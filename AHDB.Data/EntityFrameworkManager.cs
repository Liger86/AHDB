using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.Data.EntityManagers;
using System.Data.Entity;
using System.Collections.ObjectModel;
using AHDB.DataTransfer;

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

        public EntityManagers.IVendorManager GetVendorManager()
        {
            return new VendorManager();
        }

        public EntityManagers.IVendorRepairManager GetVendorRepairManager()
        {
            return new VendorRepairManager();
        }

        public EntityManagers.INoteManager GetNoteManager()
        {
            return new NoteManager();
        }

        class RepairManager : IRepairManager
        {
            public List<RepairDTO> GetAllNotCompletedRepairsAndTheirVendors()
            {
                List<RepairDTO> result = new List<RepairDTO>();
                using (AHDBContext myContext = new AHDBContext())
                {
                    result = (from repair in myContext.Repairs
                              where repair.Completed == false
                              select new RepairDTO
                              {
                                  ID = repair.ID,
                                  Description = repair.Description,
                                  PurchaseOrder = repair.PurchaseOrder,
                                  QuoteNumber = repair.QuoteNumber,
                                  Completed = repair.Completed,
                                  DateCreatedAsUtcTime = repair.DateCreatedAsUtcTime,
                                  DateCompleted = repair.DateCompleted,
                                  DueDate = repair.DueDate,
                                  CustomerID = repair.CustomerID,
                                  Customer = new CustomerDTO
                                  {
                                      ID = repair.Customer.ID,
                                      CompanyName = repair.Customer.CompanyName,
                                  },
                                  VendorRepairs = (from vendorRepair in repair.VendorRepairs
                                                   where vendorRepair.Completed != true
                                                   select new VendorRepairDTO
                                                   {
                                                       RepairID = vendorRepair.RepairID,
                                                       VendorID = vendorRepair.VendorID,
                                                       Completed = vendorRepair.Completed,
                                                       DateCreatedAsUtcTime = vendorRepair.DateCreatedAsUtcTime,
                                                       Vendor = new VendorDTO 
                                                       {
                                                           ID = vendorRepair.Vendor.ID,
                                                           CompanyName = vendorRepair.Vendor.CompanyName,
                                                           DateCreatedAsUtcTime = vendorRepair.Vendor.DateCreatedAsUtcTime
                                                       }
                                                   }).ToList(),
                              }).ToList();
                }
                return result;
            }

            public void CreateNewRepair(string description,
                string purchaseOrder, string quoteNumber, Nullable<DateTime> dueDate, int customerID)
            {
                //Convert incomming due date to utc and store it.
                if (dueDate != null)
                {
                    dueDate = DateTime.SpecifyKind((DateTime)dueDate, DateTimeKind.Local);
                }
                else
                {
                    dueDate = DateTime.Now.ToUniversalTime();
                }

                Repair repair = new Repair();
                repair.Description = description;
                repair.PurchaseOrder = purchaseOrder;
                repair.QuoteNumber = quoteNumber;
                repair.Completed = false;
                repair.DueDate = dueDate.Value.ToUniversalTime();
                repair.CustomerID = customerID;

                using(AHDBContext myContext = new AHDBContext())
                {
                    myContext.spInsertRepair(repair.Description, repair.PurchaseOrder, repair.QuoteNumber, repair.DueDate, repair.CustomerID);
                    myContext.SaveChanges();
                }
            }


            public void DeleteRepair(int repairID)
            {
                using (AHDBContext myContext = new AHDBContext())
                {
                    myContext.spDeleteRepair(repairID);
                }
            }


            public void UpdateRepair(int repairID, string description, string purchaseOrder, string quoteNumber, 
                Nullable<bool> completed, DateTime? dateCompleted, DateTime? dueDate)
            {
                if (completed == true && (dateCompleted == null))
                {
                    dateCompleted = DateTime.UtcNow;
                }

                using (AHDBContext myContext = new AHDBContext())
                {
                    myContext.spUpdateRepair(repairID, description, purchaseOrder, quoteNumber, completed, 
                        dateCompleted, dueDate);
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

            public void CreateNewCustomer(string description, string companyName)
            {
                using (AHDBContext myContext = new AHDBContext())
                {
                    myContext.spInsertCustomer(description, companyName);
                    myContext.SaveChanges();
                }
            }
        }
        class VendorManager : IVendorManager
        {
            public void CreateNewVendor(string description, string companyName)
            {
                using (AHDBContext myContext = new AHDBContext())
                {
                    myContext.spInsertVendor(description, companyName);
                    myContext.SaveChanges();
                }
            }

            public List<VendorDTO> GetVendorList()
            {
                List<VendorDTO> result = new List<VendorDTO>();
                using (AHDBContext myContext = new AHDBContext())
                {
                    result = (from vendor in myContext.Vendors
                              select new VendorDTO()
                              {
                                  ID = vendor.ID,
                                  CompanyName = vendor.CompanyName
                              }).ToList();
                }
                return result;
            }
        }
        class VendorRepairManager : IVendorRepairManager
        {
            public void AssignVendorToRepair(int repairID, int vendorID)
            {
                using (AHDBContext myContext = new AHDBContext())
                {
                    myContext.spInsertVendorRepair(repairID, vendorID);
                    myContext.SaveChanges();
                }
            }
        }
        class NoteManager : INoteManager
        {
            public List<NoteDTO> GetNotesByRepair(int repairID)
            {
                List<NoteDTO> result = new List<NoteDTO>();
                using (AHDBContext myContext = new AHDBContext())
                {
                    result = (from note in myContext.Notes
                              where note.RepairID == repairID
                              select new NoteDTO()
                              {
                                  ID = note.ID,
                                  NoteText = note.NoteText,
                                  DateCreatedAsUtcTime = note.DateCreatedAsUtcTime,
                                  RepairID = note.RepairID
                              }).ToList();
                }
                return result;
            }

            public void CreateNewNote(string noteText, int repairID)
            {
                using (AHDBContext myContext = new AHDBContext())
                {
                    myContext.spInsertNote(noteText, repairID);
                }
            }
        }
    }
}