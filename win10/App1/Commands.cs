using System;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using System.Threading.Tasks;
using Windows.UI.Core;
using System.Net.Http;
using System.Collections.Generic;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http.Filters;
using System.Reflection;

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
            var w = MainPage.Instance as MainPage;
            var web = w.Web1 as WebView;
            var urlText = w.url.Text;

            if (urlText.StartsWith("https"))
            {
                Uri targetUri = new Uri(urlText);
                string certificateOK = await TestCertificate(targetUri, targetUri.Host);
            }

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
            catch (Exception ex)
            {
                App.MessageBox(ex.Message);
            }
        }

        public static async Task<string> TestCertificate(Uri theUri, string theExpectedIssuer)

        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, theUri);
            HttpResponseMessage response = null;

            string retVal = null;
            HttpClient httpClient = null;
            try
            {
                //using (HttpBaseProtocolFilter bpf = new HttpBaseProtocolFilter())
                //    HttpClient(HttpMessageHandler handler);

                httpClient = new HttpClient();

                // HttpResponseMessage 
                // Task<HttpResponseMessage> GetAsync

                // SendRequestAsync
                response = await httpClient.SendAsync(request);

                // hit here if no exceptions! 
                retVal = "No Cert errors";
            }
            catch (Exception ex)
            {
                retVal = ex.Message;

                // Mask the HResult and if this is error code 12045 which means there was a certificate error 
                if ((ex.HResult & 65535) == 12045)
                {
                    // Google: 
                    // UWP httpClient.SendRequestAsync get HttpRequestMessage TransportInformation.ServerCertificateErrors
                    // Get a list of the server cert errors 

                    //IReadOnlyList<ChainValidationResult> errors = request.TransportInformation.ServerCertificateErrors;

                    //// I expect that the cert is expired and it is untrusted for my scenario... 

                    //if ((errors != null) && (errors.Contains(ChainValidationResult.Expired)
                    //     && errors.Contains(ChainValidationResult.Untrusted)))

                    //{
                    //    // Specifically validate that this came from a particular Issuer 
                    //    if (request.TransportInformation.ServerCertificate.Issuer == theExpectedIssuer)
                    //    {
                    //        // Create a Base Protocol Filter to add certificate errors I want to ignore... 
                    //        httpBaseProtocolFilter = new HttpBaseProtocolFilter();
                    //        // I purposefully have an expired cert to show setting multiple Ignorable Errors 
                    //        httpBaseProtocolFilter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
                    //        // Untrused because this is a self signed cert that is not installed 
                    //        httpBaseProtocolFilter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
                    //        // OK to retry since I expected these errors from this host! 
                    //        retryIgnoreCertErrors = true;
                    //    }
                    //}

                }
            }

            return retVal;
        }


        #region Try 2

        // https://noise.paulos.cz/post/windows10-14283-HttpClient-improvements/

        public static // async Task<string> 
            string TestCertificate2(Uri theUri, string theExpectedIssuer)
        {
            //HttpBaseProtocolFilter hbpf = new HttpBaseProtocolFilter();
            //HttpClient hc = new HttpClient(hbpf);
            //// Ignore wrong DNS name of certificate - but still process it
            //hbpf.IgnorableServerCertificateErrors.Insert(0, ChainValidationResult.InvalidName);
            //// Subscribe to the event by name
            //eventHandler =
            //    Observable.FromEventPattern<object>(hbpf, "ServerCustomValidationRequested")
            //        .Subscribe(p => ServerValidationHandler(p.EventArgs));
            //try
            //{
            //    HttpResponseMessage hrm = await hc.GetAsync(new Uri("https://paulos.cz"));
            //    string repsonse = await hrm.Content.ReadAsStringAsync();
            //}
            //       catch (Exception ex)
            //        {
            //            SocketErrorStatus eSocketErrorStatus = SocketError.GetStatus(ex.HResult);
            //    Status = eSocketErrorStatus.ToString();
            //            Status = req?.TransportInformation?.ServerCertificate?.ToString() ?? "No server certificate.";
            //        }
            //req?.Dispose();

            return null;
        }

        public void ServerValidationHandler(object args, EventArgs eventArgs)
        {
            // args object is HttpServerCustomValidationRequestedEventArgs
            MethodInfo methodInfo = args.GetType().GetRuntimeMethod("Reject", new Type[0]);
            if (methodInfo != null)
            {
                // By invoking this, the request will throw an exception and won't complete.
                methodInfo.Invoke(eventArgs, null);
            }
        }

        #endregion

        // http://stackoverflow.com/questions/40633143/uwp-httprequestmessage-transportinformation-missing
        public static string ServerCustomValidationRequested(HttpBaseProtocolFilter sender,
            EventArgs customValidationArgs)
        // HttpServerCustomValidationRequestedEventArgs
        {
            var Status = new StringBuilder(300);
            Status.Append("-----ServerCustomValidationRequested-----");
            Status.Append("Certificate details:");
            //Status.Append("Friendly name: " + customValidationArgs.ServerCertificate.FriendlyName);
            //Status.Append("Issuer: " + customValidationArgs.ServerCertificate.Issuer);
            //Status.Append("SignatureAlgorithmName: " + customValidationArgs.ServerCertificate.SignatureAlgorithmName);
            //Status.Append("SignatureHashAlgorithmName: " + customValidationArgs.ServerCertificate.SignatureHashAlgorithmName);
            //Status.Append("Subject: " + customValidationArgs.ServerCertificate.Subject);
            //Status.Append("ValidFrom: " + customValidationArgs.ServerCertificate.ValidFrom.ToString());
            //Status.Append("ValidTo: " + customValidationArgs.ServerCertificate.ValidTo.ToString());

            //ServerCert = customValidationArgs.ServerCertificate;
            // Validate the server certificate as required.
            //            customValidationArgs.Reject();

            return Status.ToString();
        }

        public static HttpBaseProtocolFilter httpBaseProtocolFilter { get; set; }
        public static bool retryIgnoreCertErrors { get; set; }
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