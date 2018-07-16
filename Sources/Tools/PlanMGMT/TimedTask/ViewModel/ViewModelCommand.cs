using System;

namespace PlanMGMT.ViewModel
{
    public class ViewModelCommand : System.Windows.Input.ICommand
    {
        private Action<Object> _action;

        public ViewModelCommand(Action<Object> doWork)
        {
            this._action = doWork;
        }
        public bool CanExecute(Object parameter)
        {
            return true;
        }
        public void Execute(Object parameter)
        {
            if (this._action != null)
                this._action(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}
