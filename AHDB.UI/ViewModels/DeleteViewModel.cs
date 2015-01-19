using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHDB.UI.Common;

namespace AHDB.UI.ViewModels
{
    public class DeleteViewModel : ViewModelBase
    {
        IViewModel entity;

        public Action CloseAction { get; set; }
        public Action RefreshAction { get; set; }

        public DeleteViewModel(IViewModel entity)
        {
            this.entity = entity;
            this.DeleteCommand = new CommandBase<object>(DeleteCommandMethod, CanDeleteCommand);
        }

        #region Commands
        public CommandBase<object> DeleteCommand { get; private set; }
        void DeleteCommandMethod(object arg)
        {
            entity.DeleteEntity();
            RefreshAction();
            CloseAction();
        }
        bool CanDeleteCommand(object arg)
        {
            return true;
        }
        #endregion
    }
}