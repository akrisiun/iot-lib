using System;
using Windows.UI.Xaml.Controls;

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Instance { get; set; }

        public WebView Web1 { get { return web1; } }

        public MainPage()
        {
            Instance = this;

            this.InitializeComponent();

            BrowserEvents.Bind(this);
        }
    }
}
