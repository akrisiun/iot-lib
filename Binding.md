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

# Equivalent-of-editable-combobox-in-winrt
http://stackoverflow.com/questions/16025064/equivalent-of-editable-combobox-in-winrt
