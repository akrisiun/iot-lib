### editable-combobox

http://stackoverflow.com/questions/16025064/equivalent-of-editable-combobox-in-winrt

```
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

```
