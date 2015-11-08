using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Blinky
{
    public class CommandBase : ICommand
    {
        public Action Execute { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return Execute != null;
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }
    }

    public static class AppCommands
    {
        public static ICollection<ICommand> commands { get; private set; }
        static AppCommands() { commands = new Collection<ICommand>(); }

        public static ICommand Add(ICommand cmd)
        {
            commands.Add(cmd);
            return cmd;
        }

        public static ICommand AddAction(Action execute)
        {
            var cmd = new CommandBase { Execute = execute };
            Add(cmd);
            return cmd;
        }

    }

}
