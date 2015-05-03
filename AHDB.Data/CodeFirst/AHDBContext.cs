namespace AHDB.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AHDBContext : DbContext
    {
        public AHDBContext()
            : base("name=AHDBContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Repair> Repairs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorRepair> VendorRepairs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Repairs)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Repair>()
                .HasMany(e => e.Notes)
                .WithRequired(e => e.Repair)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Repair>()
                .HasMany(e => e.VendorRepairs)
                .WithRequired(e => e.Repair)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.VendorRepairs)
                .WithRequired(e => e.Vendor)
                .WillCascadeOnDelete(false);
        }
    }
}
