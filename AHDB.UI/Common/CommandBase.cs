using System;
using System.Windows.Input;

namespace AHDB.UI.Common
{
    public class CommandBase<T> : ICommand
    {
        #region Constructors
        public CommandBase(Action<T> execute) : this(execute, null, null) { }

        public CommandBase(Action<T> execute, Predicate<T> canExecute) : this(execute, canExecute, null) { }

        public CommandBase(Action<T> execute, Predicate<T> canExecute, string label)
        {
            this._execute = execute;
            this._canExecute = canExecute;
            this.Label = label;
        }
        #endregion Constructors

        #region Fields
        readonly Action<T> _execute;
        readonly Predicate<T> _canExecute;
        #endregion Fields

        #region Properties
        public string Label { get; set; }
        #endregion Properties

        #region ICommand interface members
        public bool CanExecute(object parameter)
        {
            if (this._canExecute == null)
            {
                return true;
            }
            else
            {
                bool result = _canExecute((T)parameter);
                return result;
            }
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            this._execute.Invoke((T)parameter);
        }
        #endregion ICommand interface members
    }
}
