﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AHDB.UI.Common
{
    public class CommandBase<T> : ICommand
    {
        #region Constructors
        public CommandBase(Action<T> execute, Predicate<T> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }
        public CommandBase(Action<T> execute) : this(execute, null) { }
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

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            this._execute.Invoke((T)parameter);
        }
        #endregion ICommand interface members
    }
}