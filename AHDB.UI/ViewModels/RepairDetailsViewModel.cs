using AHDB.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDB.UI.ViewModels
{
    public class RepairDetailsViewModel : ViewModelBase
    {
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

        public RepairDetailsViewModel(RepairViewModel repair)
        {
            this.repair = repair;
        }
    }
}
