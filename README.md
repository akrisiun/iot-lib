### Git clone + build

```
git clone https://github.com/akrisiun/iot-lib.git iot-lib
iot-lib

cd win10
nuget.exe restore project.json -NonInteractive -Source https://api.nuget.org/v3/index.json
call msbuild
```

### Deploy, install AppX

standalone SDK download : Windows Kits\10\StandaloneSDK\Installers
https://dev.windows.com/en-us/downloads/windows-10-sdk

Powershell:
```
cd win10\bin\
Set-ExecutionPolicy Unrestricted
Show-WindowsDeveloperLicenseRegistration
./Add-AppDevPackage.ps1
```

### Iot links

good intro:
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

### Binding UAP

http://blog.galasoft.ch/posts/category/universal-app-platform-uap/
https://msdn.microsoft.com/en-us/library/windows/apps/mt204776.aspx

The advantage of compiled bindings over normal bindings is that (wait for it) they are compiled. So there is syntax check by the compiler when you build your project. Also, the bindings will be resolved much faster because they do not rely on reflection during runtime.
For example, if you have the following property in a Windows 10 Universal application page:

### Optimize ListView and GridView

https://channel9.msdn.com/Events/Build/2013/3-158  //build/ session Dramatically Increase Performance when Users Interact with Large Amounts of Data in GridView and ListView.
https://channel9.msdn.com/
http://igrali.com/
http://igrali.com/2015/06/21/full-screen-mode-in-windows-10-universal-apps/

### PickFilesToTranscode helper 

method uses a FileOpenPicker and a FileSavePicker to open the input and output files for transcoding. The user may select files in a location that your app does not have access to. To make sure your background task can open the files, add them to the FutureAccessList for your app.
Finally, set entries for the input and output file names in the LocalSettings for your app. The background task retrieves the file names from this location.
```
private async void PickFilesToTranscode()
{
    var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

    openPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.VideosLibrary;
    openPicker.FileTypeFilter.Add(".wmv");
    openPicker.FileTypeFilter.Add(".mp4");

    StorageFile source = await openPicker.PickSingleFileAsync();

    var savePicker = new Windows.Storage.Pickers.FileSavePicker();

    savePicker.SuggestedStartLocation =
        Windows.Storage.Pickers.PickerLocationId.VideosLibrary;

    savePicker.DefaultFileExtension = ".mp4";
    savePicker.SuggestedFileName = "New Video";

    savePicker.FileTypeChoices.Add("MPEG4", new string[] { ".mp4" });

    StorageFile destination = await savePicker.PickSaveFileAsync();

    if(source == null || destination == null)
    {
        return;
    }

    var storageItemAccessList = Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList;
    storageItemAccessList.Add(source);
    storageItemAccessList.Add(destination);

    ApplicationData.Current.LocalSettings.Values["InputFileName"] = source.Path;
    ApplicationData.Current.LocalSettings.Values["OutputFileName"] = destination.Path;
}
```

https://msdn.microsoft.com/en-us/library/windows/apps/xaml/mt282146.aspx

```
var deviceInformation = Windows.Devices.Enumeration.DeviceInformation;

< AutoSuggestBox PlaceholderText = "Search" QueryIcon = "Find" Width = "200"
    TextChanged = "AutoSuggestBox_TextChanged"

< RelativePanel >
    < TextBox x: Name = "textBox1" RelativePanel.AlignLeftWithPanel = "True" />
        < Button Content = "Submit" RelativePanel.Below = "textBox1" />
        </ RelativePanel >
```

http://thenappingkat.azurewebsites.net/windows-10-top-3-xamlui-changes-from-8-1-state-triggers/
https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.splitview.aspx

```
<SplitView IsPaneOpen="True"
           DisplayMode="Inline"
           OpenPaneLength="296">
    <SplitView.Pane>
        <TextBlock Text="Pane"
                   FontSize="24"
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"/>
    </SplitView.Pane>

    <Grid>
        <TextBlock Text="Content"
                   FontSize="24"
                   VerticalAlignment="Center"
                   HorizontalAlignment="Center"/>
    </Grid>
</SplitView>
```

http://stackoverflow.com/questions/16025064/equivalent-of-editable-combobox-in-winrt