using System;
using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace App1
{
    public enum DropDownStyle
    {
        Editable = 1,
        List = 2
    }

    public class ComboBoxEditable : ComboBox
    {
        public static DependencyProperty DropDownStyleProperty =
             DependencyProperty.Register("DropDownStyle", typeof(DropDownStyle), typeof(ComboBoxEditable),
                null); //new PropertyMetadata(null, DropDownStyleChanged));

        public static DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(IEnumerable), typeof(ComboBoxEditable),
                null); //new PropertyMetadata(null, DropDownStyleChanged));

        public DropDownStyle DropDownStyle
        {
            get { return (DropDownStyle)GetValue(DropDownStyleProperty); }
            set {; }
        }

        public IEnumerable Source {
            get { return GetValue(SourceProperty) as IEnumerable; }
            set { SetValue(SourceProperty, value as IEnumerable);
                BindSource();
            }
        }

        public string[] ItemsContent
        {
            get { return GetValue(SourceProperty) as string[]; }
            set
            {
                var selected = this.SelectedIndex;
                SetValue(SourceProperty, value);
                if (selected > 0)
                {
                    var itemSel = Items[selected];
                    if (itemSel is ComboBoxItem)
                        (itemSel as ComboBoxItem).Content = value[selected];
                }
            }
        }

        public void SetItem(int index, string content)
        {
            if (index == 0)
                TextBox.Text = content;
            else
            {
                var itemSel = Items[index];
                if (itemSel is ComboBoxItem)
                    (itemSel as ComboBoxItem).Content = content;
            }
        }


        public TextBox TextBox { get; protected set; }
        public ComboBoxItem Item { get; protected set; }

        public ComboBoxEditable() { }

        public void Bind(TextBox box, ComboBoxItem item)
        {
            TextBox = box;
            Item = item; // item one
            this.SelectionChanged += ComboBoxEditable_SelectionChanged;
            box.KeyDown += Box_KeyDown;
        }

        protected void BindSource()
        {
            var data = Source as string[];
            TextBox.Text = data[0];
            for (int i = 1; i < Items.Count; i++)
                (Items[i] as ComboBoxItem).Content = data[i];

            while (Items.Count < data.Length)
                Items.Add(new ComboBoxItem { Content = data[Items.Count] });
        }

        void Box_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Space)
            {
                var box = sender as TextBox;
                if (box.SelectionLength > 0)
                {
                    box.Text = box.Text.Remove(box.SelectionStart, box.SelectionLength);
                    box.SelectionLength = 0;
                }
                int pos = box.SelectionStart;
                box.Text = box.Text.Insert(pos, " ");
                box.SelectionStart = pos + 1;
                e.Handled = true;
            }
        }

        //string FilterString = "";
        //protected override void OnKeyDown(KeyRoutedEventArgs e)
        //{
        //    if (IsLetterOrSpace(e.Key))
        //    {
        //        if (e.Key == VirtualKey.Space)
        //            FilterString += " ";
        //        else
        //            FilterString += e.Key.ToString();
        //        FilterList(FilterString);
        //        this.ItemsSource = ItemsSourceList;
        //        if (ItemsSourceList.Count > 0)
        //            this.SelectedIndex = 0;
        //    }
        //    else if (e.Key == VirtualKey.Back)
        //    {
        //        if (FilterString.Length > 0)
        //        {
        //            FilterString = FilterString.Substring(0, FilterString.Length - 1);
        //            FilterList(FilterString);
        //            this.ItemsSource = ItemsSourceList;
        //            if (ItemsSourceList.Count > 0)
        //                this.SelectedIndex = 0;
        //        }
        //    }

        //    if (e.Key != VirtualKey.Space)
        //    {
        //        base.OnKeyDown(e);
        //    }
        //}

        void ComboBoxEditable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var text = this.SelectedValue as string;
            if (TextBox == null || text == null)
                return;

            Text = text;
        }

        public string Text
        {
            get { return TextBox == null ? null : TextBox.Text; }
            set
            {
                if (TextBox == null || TextBox.Text.Equals(value))
                    return;

                TextBox.Text = value;
                //var items = ItemsSource as string[];
                //items[0] = value;
                //ItemsSource = items;
            }
        }
    }
}
