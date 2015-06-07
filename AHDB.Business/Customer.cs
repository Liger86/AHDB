using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.Business;


namespace AHDB.Business
{
    public class Customer : IRepository<Customer>
    {
        #region Fields and properties
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

        private string companyName;
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        private DateTime dateCreatedAsUtcTime;
        public DateTime DateCreatedAsUtcTime
        {
            get { return dateCreatedAsUtcTime; }
            set { dateCreatedAsUtcTime = value; }
        }

        private ObservableCollection<Contact> contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }

        private ObservableCollection<Repair> repairs;
        public ObservableCollection<Repair> Repairs
        {
            get { return repairs; }
            set { repairs = value; }
        }
        #endregion Fields and properties

        #region IRepository members
        public string Create(Customer obj)
        {
            throw new NotImplementedException();
        }

        public Customer Retrieve(int key)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }
        #endregion IRepository members
    }
}