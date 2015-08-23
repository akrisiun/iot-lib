using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI;

namespace App1
{
    public static class BrowserEvents
    {
        public static void Bind(this MainPage @this)
        {
            @this.btnShutdown.Command = CmdShutdown.Instance;
            @this.btnGO.Command = CmdGo.Instance;
            @this.btnBack.Command = CmdBack.Instance;

            var web = @this.Web1;
            var items = Conf.UrlList;

            var url = @this.url;
            url.Bind(@this.urlText, @this.urlItem);
            url.Item.DataContext = url;
            url.Item.GotFocus += Item_GotFocus;
            @this.urlText.KeyDown += UrlText_KeyDown;

            // url.ItemsSource = items;
            url.Source = items;
            url.SelectedIndex = 0;
            url.PointerPressed += Url_PointerPressed;
            url.SelectionChanged += Url_SelectionChanged;

            var urlString = items[0] as string;
            if (!String.IsNullOrWhiteSpace(urlString))
                web.Source = new Uri(urlString);

            web.NavigationCompleted += Web_NavigationCompleted;

            var keyCheck = @this.keyboard as CheckBox;
            keyCheck.Click += KeyCheck_Click;

            var fullScr = @this.fullScreen as Button;
            fullScr.Click += FullScreen;
        }

        static void FullScreen(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            ApplicationView view = ApplicationView.GetForCurrentView();
            bool isInFullScreenMode = view.IsFullScreenMode;


            if (isInFullScreenMode)
            {
                view.ExitFullScreenMode();
                button.Content = "FullScr";
                view.ShowStandardSystemOverlays();
            }
            else
            {
                view.FullScreenSystemOverlayMode = FullScreenSystemOverlayMode.Minimal;
                view.TryEnterFullScreenMode(); //  .FullScreenSystemOverlayMode = FullScreenSystemOverlayMode.Minimal;
                var bar = view.TitleBar;
                bar.BackgroundColor = Color.FromArgb(0, 0, 0, 0);
                button.Content = "Windowed";
            }

            //if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            //    StatusBar statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();

        }

        static void UrlText_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                e.Handled = true;
                CmdGo.ExecuteAsync((sender as FrameworkElement).Dispatcher);
            }
        }

        static void KeyCheck_Click(object sender, RoutedEventArgs e)
        {
            var chk = sender as CheckBox;
            bool isChk = chk.IsChecked ?? false;

            try
            {
                var pane = InputPane.GetForCurrentView();
                if (isChk)
                    pane.TryShow();
                else
                    pane.TryHide();
            }
            catch (Exception ex)
            {
                App.MessageBox(ex.Message + Environment.NewLine + ex.StackTrace);
            }

            // TODO
            //  System.InvalidCastException: Unable to cast object of type 'Windows.UI.ViewManagement.InputPane' to type 'Windows.UI.ViewManagement.IInputPane2'.
            //at System.StubHelpers.StubHelpers.GetCOMIPFromRCW_WinRT(Object objSrc, IntPtr pCPCMD, IntPtr & ppTarget)
            //at Windows.UI.ViewManagement.InputPane.TryShow()
        }

        static void Item_GotFocus(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var ctrl = (sender as FrameworkElement).DataContext as ComboBoxEditable;
            ctrl.TextBox.Focus(FocusState.Programmatic);
        }

        static void Url_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cbo = sender as ComboBoxEditable;
            if (cbo.SelectedIndex >= 1)
            {
                // cbo.SelectedValue as ComboBoxItem
                cbo.Text = cbo.ItemsContent[cbo.SelectedIndex];
                cbo.SelectedIndex = 0;
                var cmd = MainPage.Instance.btnGO.Command as CmdGo;
                Task.Factory.StartNew(() =>
                    cmd.Execute(null));
            }
        }

        static void Url_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var url = sender as ComboBoxEditable;
            if (url.SelectedIndex == 0)
            {
                url.TextBox.Focus(Windows.UI.Xaml.FocusState.Pointer);
                e.Handled = true;
            }
        }

        static void Web_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            var url = MainPage.Instance.url;
            var newUrlText = sender.Source.AbsoluteUri;
            if (newUrlText == null)
                return;

            url.SetItem(0, newUrlText);
            url.SelectedIndex = 0;
        }
    }
}
