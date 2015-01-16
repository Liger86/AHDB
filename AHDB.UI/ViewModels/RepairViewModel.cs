using AHDB.Data;
using AHDB.DataTransfer;
using AHDB.UI.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AHDB.UI.ViewModels
{
    public class RepairViewModel : ViewModelBase
    {
        // Additional properties for custom stuff are at bottom

        private int repairID;
        public int RepairID
        {
            get { return repairID; }
            set 
            { 
                repairID = value;
                RaisePropertyChanged("RepairID");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set 
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }

        private string purchaseOrder;
        public string PurchaseOrder
        {
            get { return purchaseOrder; }
            set 
            { 
                purchaseOrder = value;
                RaisePropertyChanged("PurchaseOrder");
            }
        }

        private string quoteNumber;
        public string QuoteNumber
        {
            get { return quoteNumber; }
            set 
            { 
                quoteNumber = value;
                RaisePropertyChanged("QuoteNumber");
            }
        }

        private Nullable<bool> completed;
        public Nullable<bool> Completed
        {
            get { return completed; }
            set 
            { 
                completed = value;
                RaisePropertyChanged("Completed");
            }
        }

        private Nullable<DateTime> dateCreated;
        public Nullable<DateTime> DateCreated
        {
            get { return dateCreated; }
            set 
            { 
                dateCreated = value;
                RaisePropertyChanged("DateCreated");
            }
        }

        private Nullable<DateTime> dateCompleted;
        public Nullable<DateTime> DateCompleted
        {
            get { return dateCompleted; }
            set 
            { 
                dateCompleted = value;
                RaisePropertyChanged("DateCompleted");
            }
        }

        private Nullable<DateTime> dueDate;
        public Nullable<DateTime> DueDate
        {
            get { return dueDate; }
            set 
            { 
                dueDate = value;
                RaisePropertyChanged("DueDate");
            }
        }

        private CustomerViewModel customer;
        public CustomerViewModel Customer
        {
            get { return customer; }
            set 
            { 
                customer = value;
                RaisePropertyChanged("Customer");
            }
        }

        private ObservableCollection<NoteViewModel> notes;
        public ObservableCollection<NoteViewModel> Notes
        {
            get 
            {
                PopulateNotes();
                return notes; 
            }
            set
            { 
                notes = value;
                RaisePropertyChanged("Notes");
            }
        }

        private NoteViewModel selectedNote = new NoteViewModel();
        public NoteViewModel SelectedNote
        {
            get { return selectedNote; }
            set 
            {
                selectedNote = value;
                RaisePropertyChanged("SelectedNote");
            }
        }

        private ObservableCollection<VendorRepairViewModel> vendorRepairs;
        public ObservableCollection<VendorRepairViewModel> VendorRepairs
        {
            get { return vendorRepairs; }
            set 
            {
                vendorRepairs = value;
                RaisePropertyChanged("VendorRepairs");
            }
        }

        #region Methods
        void PopulateNotes()
        {
            FactoryManager myManager = new FactoryManager();

            List<NoteDTO> result = myManager.GetNoteManager().GetNotesByRepair(this.repairID);

            notes = new ObservableCollection<NoteViewModel>((from note in result
                                                            select new NoteViewModel()
                                                            {
                                                                NoteID = note.ID,
                                                                NoteText = note.NoteText,
                                                                DateCreatedAsUtcTime = note.DateCreatedAsUtcTime,
                                                                RepairID = note.RepairID
                                                            }).ToList());
        }
        #endregion

        #region Additional properties
        private int pastDueColorLevel;
        public int PastDueColorLevel
        {
            get 
            {
                switch (DateTime.Compare((DateTime)dueDate, DateTime.Now))
                {
                    case 1:
                        pastDueColorLevel = 1;
                        break;
                    case 0:
                        pastDueColorLevel = 0;
                        break;
                    default:
                        pastDueColorLevel = -1;
                        break;
                }
                return pastDueColorLevel; 
            }
            set 
            { 
                pastDueColorLevel = value;
                RaisePropertyChanged("PastDueColorLevel");
            }
        }

        private bool repairHasNoVendors;
        public bool RepairHasNoVendors
        {
            get
            {
                if (this.vendorRepairs.Count >= 1)
                {
                    repairHasNoVendors = false;
                }
                else
                {
                    repairHasNoVendors = true;
                }
                return repairHasNoVendors;
            }
            set
            {
                repairHasNoVendors = value;
                RaisePropertyChanged("IsVendorNull");
            }
        }
        #endregion
    }
}