using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AHDB.Business
{
    public class Repair
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string purchaseOrder;
        public string PurchaseOrder
        {
            get { return purchaseOrder; }
            set { purchaseOrder = value; }
        }

        private string quoteNumber;
        public string QuoteNumber
        {
            get { return quoteNumber; }
            set { quoteNumber = value; }
        }

        private bool completed;
        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }

        private DateTime dateCreatedAsUtcTime;
        public DateTime DateCreatedAsUtcTime
        {
            get { return dateCreatedAsUtcTime; }
            set { dateCreatedAsUtcTime = value; }
        }

        private DateTime dateCompleted;
        public DateTime DateCompleted
        {
            get { return dateCompleted; }
            set { dateCompleted = value; }
        }

        private DateTime dueDate;
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        private int customerId;
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private Customer customer;
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private ObservableCollection<Note> notes;
        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        private ObservableCollection<VendorRepair> vendorRepairs;
        public ObservableCollection<VendorRepair> VendorRepairs
        {
            get { return vendorRepairs; }
            set { vendorRepairs = value; }
        }
    }
}