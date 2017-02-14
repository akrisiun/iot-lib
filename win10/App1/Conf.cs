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
                  { @"https://localhost/",
                    @"about:blank",
                    @"http://youtube.com",
                    @"https://channel9.msdn.com/",
                    @"https://msdn.microsoft.com/library/windows/apps/xaml/mt244352.aspx",
                    @"https://www.raspberrypi.org/forums/viewforum.php?f=12",
                    @"https://msdn.microsoft.com/en-us/",
                    @"http://igrali.com/",
                    @"http://www.eurosportplayer.com/live-light.shtml",
                    @"https://github.com/akrisiun/iot-lib",
                    @"http://localhost:8080/",
                    @"http://localhost:8000/",
                    @"http://localhost:8088/",
                    @"http://localhost:5000/",
                    @"http://localhost:8045/",
                    @"http://localhost:8022/",
                    @"http://localhost:8023/",
                    @"http://localhost:8024/",
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
