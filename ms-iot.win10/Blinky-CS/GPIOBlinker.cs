using IoTOnboardingService.Utils;
using System;
using Windows.Devices.Gpio;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
// using IoTCoreDefaultApp.Utils;

namespace Blinky
{
    public static class GPIOBlinker
    {
        public class Data
        {
            // const int LED_PIN = 5;
            public static int LED_PIN = 47; // on-board LED on the Rpi2
            public GpioPin pin;
            public GpioPinValue pinValue;
            public DispatcherTimer Timer;

            private SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            private SolidColorBrush greenBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            private SolidColorBrush grayBrush = new SolidColorBrush(Windows.UI.Colors.LightGray);

            public MainPage Page { get; set; }

            public void Timer_Tick(object sender, object e)
            {
                if (pinValue == GpioPinValue.High)
                {
                    pinValue = GpioPinValue.Low;
                    pin.Write(pinValue);
                    Page.LED.Fill = greenBrush;
                }
                else
                {
                    pinValue = GpioPinValue.High;
                    pin.Write(pinValue);
                    Page.LED.Fill = grayBrush;
                }
            }
        }

        public static void Load(this MainPage page)
        {
            page.btnShutdown.Command = AppCommands.AddAction(() => App.Current.Exit());
            var data = new Data { Page = page };

            data.Timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
            data.Timer.Tick += data.Timer_Tick;


            Exception lastError = null;
            page.GpioStatus.Text = "Loading device information...";
            try
            {
                var processors = Environment.ProcessorCount;
                var envVariables = Environment.GetEnvironmentVariables();
                DeviceTypes type = DeviceTypeInformation.Type;

                var product = String.Empty;
                if (DeviceTypeInformation.DeviceInfo != null)
                    product = String.Format(", {0}", DeviceTypeInformation.DeviceInfo.SystemProductName);

                page.GpioDevice.Text = string.Format("Device: {0} {1}, processors {2}", type.ToString(), product, processors);

                InitGPIO(page, data);
            }
            catch (Exception ex) { lastError = ex; }

            if (lastError != null)
            {
                var text = page.GpioStatus.Text;
                if (!string.IsNullOrWhiteSpace(text))
                    text += text + Environment.NewLine;

                page.GpioStatus.Text = text + lastError.Message;
            }
        }

        static void InitGPIO(this MainPage page, Data data)
        {
            GpioController gpio = GpioController.GetDefault();
            page.GpioPinInfo.Text = "Led pin: " + Data.LED_PIN.ToString();

            // Show an error if there is no GPIO controller
            if (gpio == null)
            {
                data.pin = null;
                page.GpioStatus.Text = "There is no GPIO controller on this device.";
                return;
            }

            data.pin = gpio.OpenPin(Data.LED_PIN);
            GpioPin pin = data.pin;

            data.pinValue = GpioPinValue.High;
            pin.Write(data.pinValue);
            pin.SetDriveMode(GpioPinDriveMode.Output);

            page.GpioStatus.Text = "GPIO pin initialized correctly.";

            var timer = data.Timer;
            if (pin != null)
            {
                timer.Start();
            }
        }
    }
}