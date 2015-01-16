using AHDB.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.UI.ViewModels
{
    public class NoteViewModel : ViewModelBase
    {
        private int noteID;
        public int NoteID
        {
            get { return noteID; }
            set 
            { 
                noteID = value;
                RaisePropertyChanged("NoteID");
            }
        }

        private string noteText;
        public string NoteText
        {
            get { return noteText; }
            set 
            { 
                noteText = value;
                RaisePropertyChanged("NoteText");
            }
        }

        private DateTime dateCreateAsUtcTime;
        public DateTime DateCreatedAsUtcTime
        {
            get { return dateCreateAsUtcTime; }
            set { dateCreateAsUtcTime = value; }
        }

        private int repairID;
        public int RepairID
        {
            get { return repairID; }
            set { repairID = value; }
        }
    }
}
