using AHDB.Data;
using AHDB.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.UI.ViewModels
{
    public class AddNoteViewModel : ViewModelBase
    {
        public AddNoteViewModel(RepairViewModel repair)
        {
            this.CreateNewNote = new CommandBase<object>(CreateNewNoteMethod, CanCreateNewNote);
            this.repair = repair;
            this.note = new NoteViewModel();
        }

        public Action CloseAction { get; set; }
        public Action RefreshAction { get; set; }

        private RepairViewModel repair;
        public RepairViewModel Repair
        {
            get { return repair; }
            set 
            { 
                repair = value;
                RaisePropertyChanged("Repair");
            }
        }

        private NoteViewModel note;
        public NoteViewModel Note
        {
            get { return note; }
            set 
            { 
                note = value;
                RaisePropertyChanged("Note");
            }
        }

        #region Commands
        public CommandBase<object> CreateNewNote { get; private set; }
        void CreateNewNoteMethod(object arg)
        {
            FactoryManager myManager = new FactoryManager();
            myManager.GetNoteManager().CreateNewNote(note.NoteText, repair.RepairID);
            RefreshAction();
            CloseAction();
        }
        bool CanCreateNewNote(object arg)
        {
            return true;
        }
        #endregion Commands
    }
}
