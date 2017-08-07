using System;
using System.Windows.Input;

namespace WpfApplication1.Commands
{
    class ClickCommand : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;
        public ClickCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute need to be set");
            if (canExecute == null)
                throw new ArgumentNullException("canExecute need to be set");
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public ClickCommand(Action<object> execute)
            : this(execute, DefaultCanExecute)
        {

        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }


    }
}
