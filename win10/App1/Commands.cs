using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace App1
{

    // TOOD via CommandBinding
    //  var binding = new CommandBinding(MyCommands.DoSomethingCommand, DoSomething, CanDoSomething);
    //  // Register CommandBinding for all windows.
    //  CommandManager.RegisterClassCommandBinding(typeof(Window), binding);
    //  private void DoSomething(object sender, ExecutedRoutedEventArgs e)

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

        public static async void ExecuteAsync(CoreDispatcher dispatcher)
        {
            var task = dispatcher.RunAsync(CoreDispatcherPriority.High, ()
                 => CmdGo.Instance.Execute(null));

            //TaskScheduler.Current
            await task;
        }

        public override void Execute(object parameter)
        {
            var w = MainPage.Instance;
            //if (!w.Dispatcher  as DispacherObject).CheckAccess())
            //    return;
            if (!w.Dispatcher.HasThreadAccess)
            {
                ExecuteAsync(w.Dispatcher);
                return;
            }

            var web = w.Web1 as WebView;

            var urlText = w.url.Text;
            if (string.IsNullOrWhiteSpace(urlText))
                return;

            var url = new Uri(urlText);

            w.url.Text = urlText;
            w.url.SelectedIndex = 0;
            w.url.TextBox.Focus(Windows.UI.Xaml.FocusState.Programmatic);

            // if (web.ExecutionMode)
            try
            {
                web.Source = url;
            }
            catch (Exception ex) {
                App.MessageBox(ex.Message); }
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