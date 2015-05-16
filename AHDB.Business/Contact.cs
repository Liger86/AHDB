using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.Business
{
    public class Contact
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

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private string cellPhoneNumber;
        public string CellPhoneNumber
        {
            get { return cellPhoneNumber; }
            set { cellPhoneNumber = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private DateTime dateCreatedAsUtcTime;
        public DateTime DateCreatedAsUtcTime
        {
            get { return dateCreatedAsUtcTime; }
            set { dateCreatedAsUtcTime = value; }
        }

        private int? customerId;
        public int? CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private int? vendorId;
        public int? VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        private Customer customer;
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        private Vendor vendor;
        public Vendor Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }
    }
}