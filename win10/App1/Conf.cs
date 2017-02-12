using System;
using System.Collections.Generic;

namespace App1
{
    class Conf
    {
        public static IEnumerable<string> UrlList
        {
            get
            {
                string[] list = new string[]
                  { @"http://localhost/",
                    @"about:blank",
                    @"http://youtube.com",
                    @"https://msdn.microsoft.com/library/windows/apps/xaml/mt244352.aspx",
                    @"https://www.raspberrypi.org/forums/viewforum.php?f=12",
                    @"https://msdn.microsoft.com/en-us/",
                    @"https://channel9.msdn.com/",
                    @"http://igrali.com/",
                    @"http://www.eurosportplayer.com/live-light.shtml",
                    @"https://github.com/akrisiun/iot-lib",
                    @"http://localhost:8080/",
                    @"http://192.168.1.12:8080/",
					@"https://www.hackster.io/raspberry-pi?ref=topnav",
                    @"about:flags",
					@"http://pi.gadgetoid.com/pinout/spi"
                  };

                foreach (string item in list)
                    yield return item;
            }
        }
    }
}
