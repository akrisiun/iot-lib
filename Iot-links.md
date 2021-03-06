### Iot links

Good intro:
http://hackaday.com/2015/08/13/raspberry-pi-and-windows-10-iot-core-a-huge-letdown/
Starting with RPI
http://ms-iot.github.io/content/en-US/win10/SetupPCRPI.htm

IoT device family - Windows apps Develop Reference API reference Device family and API contract reference Device families
https://msdn.microsoft.com/en-us/library/windows/apps/mt282212.aspx

### .NET UAP : UniversalWindowsPlatform

`
Install-Package Microsoft.NETCore.UniversalWindowsPlatform 
`

http://dotnet.github.io/core/

The required version of Visual Studio Tools for Universal Windows Apps is 14.0.23121.00 D14OOB.

Install Windows IoT Core Project Templates from here
WindowsIoTCoreProjectTemplates.vsix https://visualstudiogallery.msdn.microsoft.com/06507e74-41cf-47b2-b7fe-8a2624202d36

```
var deviceInformation = Windows.Devices.Enumeration.DeviceInformation;

    "runtimes": {
        "win10-arm": { },,
        
        "win10-x86": { },
        "win10-x86-aot": { },
        "win10-x64-aot": { }


"dependencies": {
        "microsoft.csharp": "4.0.0",
        "Microsoft.NETCore": "5.0.0",
        "Microsoft.NETCore.UniversalWindowsPlatform": "5.0.0",
        "System.AppContext": "4.0.0",
        "System.ComponentModel.Annotations": "4.0.10",
        "System.Data.Common": "4.0.0",
        "System.IO.Compression.ZipFile": "4.0.0",
        "System.IO.FileSystem": "4.0.0",
        "System.Linq": "4.0.0",
        "System.Runtime.WindowsRuntime": "4.0.10",
        "System.Runtime.WindowsRuntime.UI.Xaml": "4.0.0"

 },
  "frameworks": {
        "uap10.0": { }
  },
  "runtimes": {
        "win10-arm": { },
        "win10-arm-aot": { },
        "win10-x86": { },
        "win10-x86-aot": { },
        "win10-x64": { },
        "win10-x64-aot": { }
  }

https://www.nuget.org/packages/Windows.IoT.Native/

Windows.IoTlib compile

  "dependencies": {
    "Microsoft.NETCore.UniversalWindowsPlatform": "5.0.0"
  },
  "frameworks": {
    "uap10.0": {}
  },
  "runtimes": {
    "win10-arm": {},
    "win10-arm-aot": {},
```

### Links

https://github.com/onovotny/ReferenceGenerator
https://github.com/StackExchange/dapper-dot-net
https://github.com/tdecroyere/Windows.IoT.Native

https://github.com/ms-iot?
https://github.com/ms-iot/samples/tree/develop/HelloWorld/CS
https://github.com/arduino/wifishield
https://github.com/ms-iot/build2015-iot-workshop

### NodeJS

Chackra JS (V8 ms alternative)
https://github.com/ms-iot/node-uwp-wrapper



### Tools

https://github.com/t0x0/random/wiki/ffu2img
http://go.microsoft.com/fwlink/?LinkID=532616&clcid=0x409
https://www.nuget.org/packages/Windows.IoT/1.0.0-alpha-4

Windows.IoT 1.0.0-alpha-4 Windows IoT .Net Library.
To install Windows.IoT, run the following command in the Package Manager Console
PM> Install-Package Windows.IoT -Pre

### IOT framework source code

Microsoft.Windows.UI.Xaml.CSharp.targets
Wifi-dongle
http://swag.raspberrypi.org/collections/frontpage/products/official-raspberry-pi-Wifi-dongle
