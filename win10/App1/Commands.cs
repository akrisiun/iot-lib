using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace App1
{

//    var binding = new CommandBinding(MyCommands.DoSomethingCommand, DoSomething, CanDoSomething);

//    // Register CommandBinding for all windows.
//    CommandManager.RegisterClassCommandBinding(typeof(Window), binding);
//        }

//private void DoSomething(object sender, ExecutedRoutedEventArgs e)
//{

    public abstract class Command : ICommand
    {
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public abstract void Execute(object parameter);
    }

    public class CmdShutdown : Command, ICommand
    {
        // Singleton for the simple cases, may be replaced with your own factory if needed.
        static CmdShutdown()
        {
            Instance = new CmdShutdown();
        }

        public static ICommand Instance { get; private set; }

        public override void Execute(object parameter)
        {
            App.Current.Exit();
        }
    }

    public class CmdGo : Command, ICommand
    {
        static CmdGo()
        {
            Instance = new CmdGo();
        }

        public static ICommand Instance { get; private set; }

        public override void Execute(object parameter)
        {
            var w = MainPage.Instance;
            var web = w.Web1 as WebView;
            var url = new Uri(w.Url.Text);

            // if (web.ExecutionMode)
            web.Source = url;
        }
    }

    public class CmdBack : Command, ICommand
    {
        static CmdBack()
        {
            Instance = new CmdBack();
        }

        public static ICommand Instance { get; private set; }

        public override void Execute(object parameter)
        {
            var web = MainPage.Instance.Web1 as WebView;
            if (web.CanGoBack)
                web.GoBack();
        }
    }

}