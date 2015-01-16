﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AHDB.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AHDBContext : DbContext
    {
        public AHDBContext()
            : base("name=AHDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorRepair> VendorRepairs { get; set; }
    
        public virtual int spInsertContact(string description, string firstName, string lastName, string phoneNumber, string cellPhoneNumber, string email, Nullable<int> customerID, Nullable<int> vendorID)
        {
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("PhoneNumber", phoneNumber) :
                new ObjectParameter("PhoneNumber", typeof(string));
    
            var cellPhoneNumberParameter = cellPhoneNumber != null ?
                new ObjectParameter("CellPhoneNumber", cellPhoneNumber) :
                new ObjectParameter("CellPhoneNumber", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var customerIDParameter = customerID.HasValue ?
                new ObjectParameter("CustomerID", customerID) :
                new ObjectParameter("CustomerID", typeof(int));
    
            var vendorIDParameter = vendorID.HasValue ?
                new ObjectParameter("VendorID", vendorID) :
                new ObjectParameter("VendorID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertContact", descriptionParameter, firstNameParameter, lastNameParameter, phoneNumberParameter, cellPhoneNumberParameter, emailParameter, customerIDParameter, vendorIDParameter);
        }
    
        public virtual int spInsertCustomer(string description, string companyName)
        {
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var companyNameParameter = companyName != null ?
                new ObjectParameter("CompanyName", companyName) :
                new ObjectParameter("CompanyName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertCustomer", descriptionParameter, companyNameParameter);
        }
    
        public virtual int spInsertRepair(string description, string purchaseOrder, string quoteNumber, Nullable<System.DateTime> dueDate, Nullable<int> customerID)
        {
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var purchaseOrderParameter = purchaseOrder != null ?
                new ObjectParameter("PurchaseOrder", purchaseOrder) :
                new ObjectParameter("PurchaseOrder", typeof(string));
    
            var quoteNumberParameter = quoteNumber != null ?
                new ObjectParameter("QuoteNumber", quoteNumber) :
                new ObjectParameter("QuoteNumber", typeof(string));
    
            var dueDateParameter = dueDate.HasValue ?
                new ObjectParameter("DueDate", dueDate) :
                new ObjectParameter("DueDate", typeof(System.DateTime));
    
            var customerIDParameter = customerID.HasValue ?
                new ObjectParameter("CustomerID", customerID) :
                new ObjectParameter("CustomerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertRepair", descriptionParameter, purchaseOrderParameter, quoteNumberParameter, dueDateParameter, customerIDParameter);
        }
    
        public virtual int spInsertVendor(string description, string companyName)
        {
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var companyNameParameter = companyName != null ?
                new ObjectParameter("CompanyName", companyName) :
                new ObjectParameter("CompanyName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertVendor", descriptionParameter, companyNameParameter);
        }
    
        public virtual int spInsertVendorRepair(Nullable<int> repairID, Nullable<int> vendorID)
        {
            var repairIDParameter = repairID.HasValue ?
                new ObjectParameter("RepairID", repairID) :
                new ObjectParameter("RepairID", typeof(int));
    
            var vendorIDParameter = vendorID.HasValue ?
                new ObjectParameter("VendorID", vendorID) :
                new ObjectParameter("VendorID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertVendorRepair", repairIDParameter, vendorIDParameter);
        }
    
        public virtual int spInsertNote(string noteText, Nullable<int> repairID)
        {
            var noteTextParameter = noteText != null ?
                new ObjectParameter("NoteText", noteText) :
                new ObjectParameter("NoteText", typeof(string));
    
            var repairIDParameter = repairID.HasValue ?
                new ObjectParameter("RepairID", repairID) :
                new ObjectParameter("RepairID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertNote", noteTextParameter, repairIDParameter);
        }
    }
}
