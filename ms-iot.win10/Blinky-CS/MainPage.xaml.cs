// Copyright (c) Microsoft. All rights reserved.

using Windows.UI.Xaml.Controls;

namespace Blinky
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            GPIOBlinker.Load(this);
        }
    }
}
