### Git clone + build

```
git clone https://github.com/akrisiun/iot-lib.git iot-lib
iot-lib

cd win10
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

`
Install-Package Microsoft.IoT.SDKFromArduino
`

``
   https://github.com/tdecroyere/Windows.IoT.Native

   "Windows.IoT.Native":  {},

   "authors": [ "Thomas Decroyère" ],
    "description": "Windows IoT .Net Library.",
    "dependencies": {
        "Windows.IoT.Native": "1.0.1-alpha-4",
        "GalileoCoreCLR": "1.0.0-alpha-1"
    },

	"GalileoCoreCLR": "1.0.0-alpha-1",

  "aspnetcore50" : { 
            "dependencies": {
                "System.Runtime": "4.0.20-beta-22523",
                "System.Runtime.InteropServices": "4.0.20-beta-22605",
                "System.Console": "4.0.0-beta-22605"
            }
        }
```

https://github.com/ms-iot?
https://github.com/ms-iot/samples/tree/develop/HelloWorld/CS
https://github.com/arduino/wifishield
https://github.com/ms-iot/build2015-iot-workshop

### NodeJS

Chackra JS (V8 ms alternative)
https://github.com/ms-iot/node-uwp-wrapper


### Tools

https://github.com/t0x0/random/wiki/ffu2img

Universal"
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

The advantage of compiled bindings over normal bindings is that (wait for it) they are compiled. So there is syntax check by the compiler when you build your project. Also, the bindings will be resolved much faster because they do not rely on reflection during runtime.

For example, if you have the following property in a Windows 10 Universal application page:

public string TimeWhenLoadingPage
{
    get
    {
        return DateTime.Now.ToString("HH:mm:ss");
    }
}
Then you can consume this property in the XAML with:
<TextBlock HorizontalAlignment="Center"
           VerticalAlignment="Center"
           FontSize="18"
           Text="{x:Bind TimeWhenLoadingPage}" />


 <Grid Background="{StaticResource ApplicationPageBackgroundThemeBrush}"> 

        <Grid:GridControl x:Name="grid" AutoGenerateColumns="False" > 
            <Grid:GridControl.Columns> 
                <Grid:GridTextColumn FieldName="ProductName" /> 
                <Grid:GridTextColumn FieldName="UnitPrice" /> 
                <Grid:GridTextColumn FieldName="Quantity" /> 
            </Grid:GridControl.Columns> 
        </Grid:GridControl> 
    </Grid> 

https://msdn.microsoft.com/en-us/library/windows/apps/mt204776.aspx
Optimize ListView and GridView

https://channel9.msdn.com/Events/Build/2013/3-158  //build/ session Dramatically Increase Performance when Users Interact with Large Amounts of Data in GridView and ListView.


https://channel9.msdn.com/
http://igrali.com/

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

http://igrali.com/2015/06/21/full-screen-mode-in-windows-10-universal-apps/

ApplicationView view = ApplicationView.GetForCurrentView();
 
bool isInFullScreenMode = view.IsFullScreenMode;
 
if (isInFullScreenMode) 
{
    view.ExitFullScreenMode();
}
else 
{
    view.TryEnterFullScreenMode();
}


e PickFilesToTranscode helper method uses a FileOpenPicker and a FileSavePicker to open the input and output files for transcoding. The user may select files in a location that your app does not have access to. To make sure your background task can open the files, add them to the FutureAccessList for your app.
Finally, set entries for the input and output file names in the LocalSettings for your app. The background task retrieves the file names from this location.
C#

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

https://msdn.microsoft.com/en-us/library/windows/apps/xaml/mt282146.aspx

var deviceInformation = Windows.Devices.Enumeration.DeviceInformation;



            //< AutoSuggestBox PlaceholderText = "Search" QueryIcon = "Find" Width = "200"
            //    TextChanged = "AutoSuggestBox_TextChanged"

//< RelativePanel >
//    < TextBox x: Name = "textBox1" RelativePanel.AlignLeftWithPanel = "True" />
//        < Button Content = "Submit" RelativePanel.Below = "textBox1" />
//       </ RelativePanel >


http://thenappingkat.azurewebsites.net/windows-10-top-3-xamlui-changes-from-8-1-state-triggers/
https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.splitview.aspx

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


/*
http://stackoverflow.com/questions/16025064/equivalent-of-editable-combobox-in-winrt

<Setter Property = "MinWidth" Value="{ThemeResource TextControlThemeMinWidth}"/>
    <Setter Property = "MinHeight" Value="{ThemeResource TextControlThemeMinHeight}"/>
    <Setter Property = "Foreground" Value="{ThemeResource TextBoxForegroundThemeBrush}"/>
    <Setter Property = "Background" Value="{StaticResource TransparentBrush}"/>
    <Setter Property = "BorderBrush" Value="{StaticResource TransparentBrush}"/>
    <Setter Property = "SelectionHighlightColor" Value="{ThemeResource TextSelectionHighlightColorThemeBrush}"/>
    <Setter Property = "BorderThickness" Value="0"/>
    <Setter Property = "FontFamily" Value="{ThemeResource ContentControlThemeFontFamily}"/>
    <Setter Property = "FontSize" Value="{ThemeResource ControlContentThemeFontSize}"/>
    <Setter Property = "ScrollViewer.HorizontalScrollBarVisibility" Value="Hidden"/>
    <Setter Property = "ScrollViewer.VerticalScrollBarVisibility" Value="Hidden"/>
    <Setter Property = "ScrollViewer.IsDeferredScrollingEnabled" Value="False"/>
    <Setter Property = "Padding" Value="{ThemeResource TextControlThemePadding}"/>
    <Setter Property = "Margin" Value="-10,0,0,0"/>
    <Setter Property = "Template" >
        < Setter.Value >
            < ControlTemplate TargetType="TextBox">
                <Grid>
                    <Grid.Resources>
                        <Style x:Name="DeleteButtonStyle" TargetType="Button">
                            <Setter Property = "Template" >
                                < Setter.Value >
                                    < ControlTemplate TargetType="Button">
                                        <Grid>
                                            <VisualStateManager.VisualStateGroups>
                                                <VisualStateGroup x:Name="CommonStates">
                                                    <VisualState x:Name="Normal"/>
                                                    <VisualState x:Name="PointerOver">
                                                        <Storyboard>
                                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName= "BackgroundElement" >
                                                                < DiscreteObjectKeyFrame KeyTime= "0" Value= "{ThemeResource TextBoxButtonPointerOverBackgroundThemeBrush}" />
                                                            </ ObjectAnimationUsingKeyFrames >
                                                            < ObjectAnimationUsingKeyFrames Storyboard.TargetProperty= "BorderBrush" Storyboard.TargetName= "BorderElement" >
                                                                < DiscreteObjectKeyFrame KeyTime= "0" Value= "{ThemeResource TextBoxButtonPointerOverBorderThemeBrush}" />
                                                            </ ObjectAnimationUsingKeyFrames >
                                                            < ObjectAnimationUsingKeyFrames Storyboard.TargetProperty= "Foreground" Storyboard.TargetName= "GlyphElement" >
                                                                < DiscreteObjectKeyFrame KeyTime= "0" Value= "{ThemeResource TextBoxButtonPointerOverForegroundThemeBrush}" />
                                                            </ ObjectAnimationUsingKeyFrames >
                                                        </ Storyboard >
                                                    </ VisualState >
                                                    < VisualState x:Name= "Pressed" >
                                                        < Storyboard >
                                                            < ObjectAnimationUsingKeyFrames Storyboard.TargetProperty= "Background" Storyboard.TargetName= "BackgroundElement" >
                                                                < DiscreteObjectKeyFrame KeyTime= "0" Value= "{ThemeResource TextBoxButtonPressedBackgroundThemeBrush}" />
                                                            </ ObjectAnimationUsingKeyFrames >
                                                            < ObjectAnimationUsingKeyFrames Storyboard.TargetProperty= "BorderBrush" Storyboard.TargetName= "BorderElement" >
                                                                < DiscreteObjectKeyFrame KeyTime= "0" Value= "{ThemeResource TextBoxButtonPressedBorderThemeBrush}" />
                                                            </ ObjectAnimationUsingKeyFrames >
                                                            < ObjectAnimationUsingKeyFrames Storyboard.TargetProperty= "Foreground" Storyboard.TargetName= "GlyphElement" >
                                                                < DiscreteObjectKeyFrame KeyTime= "0" Value= "{ThemeResource TextBoxButtonPressedForegroundThemeBrush}" />
                                                            </ ObjectAnimationUsingKeyFrames >
                                                        </ Storyboard >
                                                    </ VisualState >
                                                    < VisualState x:Name= "Disabled" >
                                                        < Storyboard >
                                                            < DoubleAnimation Duration= "0" To= "0" Storyboard.TargetProperty= "Opacity" Storyboard.TargetName= "BackgroundElement" />
                                                            < DoubleAnimation Duration= "0" To= "0" Storyboard.TargetProperty= "Opacity" Storyboard.TargetName= "BorderElement" />
                                                        </ Storyboard >
                                                    </ VisualState >
                                                </ VisualStateGroup >
                                            </ VisualStateManager.VisualStateGroups >
                                            < Border x:Name= "BorderElement" BorderBrush= "{ThemeResource TextBoxButtonBorderThemeBrush}" BorderThickness= "{TemplateBinding BorderThickness}" />
                                            < Border x:Name= "BackgroundElement" Background= "{ThemeResource TextBoxButtonBackgroundThemeBrush}" Margin= "{TemplateBinding BorderThickness}" >
                                                < TextBlock x:Name= "GlyphElement" AutomationProperties.AccessibilityView= "Raw" Foreground= "{ThemeResource TextBoxButtonForegroundThemeBrush}" FontStyle= "Normal" FontFamily= "{ThemeResource SymbolThemeFontFamily}" HorizontalAlignment= "Center" Text= "&#xE0A4;" VerticalAlignment= "Center" />
                                            </ Border >
                                        </ Grid >
                                    </ ControlTemplate >
                                </ Setter.Value >
                            </ Setter >
                        </ Style >
                    </ Grid.Resources >

                    < Grid.ColumnDefinitions >
                        < ColumnDefinition Width= "*" />
                        < ColumnDefinition Width= "Auto" />
                    </ Grid.ColumnDefinitions >
                    < Grid.RowDefinitions >
                        < RowDefinition Height= "Auto" />
                        < RowDefinition Height= "*" />
                    </ Grid.RowDefinitions >
                    < VisualStateManager.VisualStateGroups >
                        < VisualStateGroup x:Name= "CommonStates" >
                            < VisualState x:Name= "Disabled" >
                                < Storyboard >
                                    < ObjectAnimationUsingKeyFrames Storyboard.TargetProperty= "Background" Storyboard.TargetName= "BackgroundElement" >
                                        < DiscreteObjectKeyFrame KeyTime= "0" Value= "{ThemeResource TextBoxDisabledBackgroundThemeBrush}" />
                                    </ ObjectAnimationUsingKeyFrames >
                                    < ObjectAnimationUsingKeyFrames Storyboard.TargetProperty= "BorderBrush" Storyboard.TargetName= "BorderElement" >
                                        < DiscreteObjectKeyFrame KeyTime= "0" Value= "{ThemeResource TextBoxDisabledBorderThemeBrush}" />
                                    </ ObjectAnimationUsingKeyFrames >
                                    < ObjectAnimationUsingKeyFrames Storyboard.TargetProperty= "Foreground" Storyboard.TargetName= "ContentElement" >
                                        < DiscreteObjectKeyFrame KeyTime= "0" Value= "{ThemeResource TextBoxDisabledForegroundThemeBrush}" />
                                    </ ObjectAnimationUsingKeyFrames >
                                    < ObjectAnimationUsingKeyFrames Storyboard.TargetProperty= "Foreground" Storyboard.TargetName= "PlaceholderTextContentPresenter" >
                                        < DiscreteObjectKeyFrame KeyTime= "0" Value= "{ThemeResource TextBoxDisabledForegroundThemeBrush}" />
                                    </ ObjectAnimationUsingKeyFrames >
                                </ Storyboard >
                            </ VisualState >
                            < VisualState x:Name= "Normal" >
                                < Storyboard >
                                    < DoubleAnimation Duration= "0" To= "{ThemeResource TextControlBackgroundThemeOpacity}" Storyboard.TargetProperty= "Opacity" Storyboard.TargetName= "BackgroundElement" />
                                    < DoubleAnimation Duration= "0" To= "{ThemeResource TextControlBorderThemeOpacity}" Storyboard.TargetProperty= "Opacity" Storyboard.TargetName= "BorderElement" />
                                </ Storyboard >
                            </ VisualState >
                            < VisualState x:Name= "PointerOver" >
                                < Storyboard >
                                    < DoubleAnimation Duration= "0" To= "{ThemeResource TextControlPointerOverBackgroundThemeOpacity}" Storyboard.TargetProperty= "Opacity" Storyboard.TargetName= "BackgroundElement" />
                                    < DoubleAnimation Duration= "0" To= "{ThemeResource TextControlPointerOverBorderThemeOpacity}" Storyboard.TargetProperty= "Opacity" Storyboard.TargetName= "BorderElement" />
                                </ Storyboard >
                            </ VisualState >
                            < VisualState x:Name= "Focused" />
                        </ VisualStateGroup >
                        < VisualStateGroup x:Name= "ButtonStates" >
                            < VisualState x:Name= "ButtonVisible" />
                            < VisualState x:Name= "ButtonCollapsed" />
                        </ VisualStateGroup >
                    </ VisualStateManager.VisualStateGroups >
                    < Border x:Name= "BackgroundElement" Background= "{TemplateBinding Background}" Grid.ColumnSpan= "2" Margin= "{TemplateBinding BorderThickness}" Grid.Row= "1" Grid.RowSpan= "1" />
                    < Border x:Name= "BorderElement" BorderBrush= "{TemplateBinding BorderBrush}" BorderThickness= "{TemplateBinding BorderThickness}" Grid.ColumnSpan= "2" Grid.Row= "1" Grid.RowSpan= "1" />
                    < ContentPresenter x:Name= "HeaderContentPresenter" Grid.ColumnSpan= "2" ContentTemplate= "{TemplateBinding HeaderTemplate}" Content= "{TemplateBinding Header}" Foreground= "{ThemeResource TextBoxForegroundHeaderThemeBrush}" FontWeight= "Semilight" Margin= "0,4,0,4" Grid.Row= "0" />
                    < ScrollViewer x:Name= "ContentElement" AutomationProperties.AccessibilityView= "Raw" HorizontalScrollMode= "{TemplateBinding ScrollViewer.HorizontalScrollMode}" HorizontalScrollBarVisibility= "{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" IsTabStop= "False" IsHorizontalRailEnabled= "{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" IsVerticalRailEnabled= "{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" IsDeferredScrollingEnabled= "{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" Margin= "{TemplateBinding BorderThickness}" Padding= "{TemplateBinding Padding}" Grid.Row= "1" VerticalScrollBarVisibility= "{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" VerticalScrollMode= "{TemplateBinding ScrollViewer.VerticalScrollMode}" ZoomMode= "Disabled" />
                    < ContentControl x:Name= "PlaceholderTextContentPresenter" Grid.ColumnSpan= "2" Content= "{TemplateBinding PlaceholderText}" Foreground= "{ThemeResource TextBoxPlaceholderTextThemeBrush}" IsHitTestVisible= "False" IsTabStop= "False" Margin= "{TemplateBinding BorderThickness}" Padding= "{TemplateBinding Padding}" Grid.Row= "1" />
                    < Button x:Name= "DeleteButton" BorderThickness= "{TemplateBinding BorderThickness}" Grid.Column= "1" FontSize= "{TemplateBinding FontSize}" IsTabStop= "False" Grid.Row= "1" Style= "{StaticResource DeleteButtonStyle}" Visibility= "Collapsed" VerticalAlignment= "Stretch" />
                </ Grid >
            </ ControlTemplate >
        </ Setter.Value >
    </ Setter >

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (e.AddedItems.Count == 1 && e.AddedItems[0] != (sender as ComboBox).Items[0])
    {
        (sender as ComboBox).SelectedIndex = 0;
        tbComboBox.Text = (e.AddedItems[0] as ComboBoxItem).Content as String;
    }
}


 <VisualStateGroup x:Name="ButtonStates">
                            <VisualState x:Name="ButtonVisible"/>
                            <VisualState x:Name="ButtonCollapsed"/>
                        </VisualStateGroup>
*/
