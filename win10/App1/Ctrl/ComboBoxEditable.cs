using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            set {
                SetValue(SourceProperty, value as IEnumerable);
                BindSource();
            }
        }

        public string[] ItemsContent
        {
            get { return GetValue(SourceProperty) as string[]; }
            set
            {
                SetValue(SourceProperty, value);

                var selected = this.SelectedIndex;
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
            var dataSrc = Source as IEnumerable<string>;
            if (dataSrc == null)
                return;

            var data = dataSrc.ToList();
            TextBox.Text = data[0];
            string[] array = new string[] { };
            Array.Resize(ref array, data.Count);

            int i = 0;
            array[i] = data[i];

            for (i = 1;i < Items.Count; i++)
            {
                string value = data[i] as string;
                byte[] bytes = UTF8Encoding.Unicode.GetBytes(value);
                array[i] = UTF8Encoding.Unicode.GetString(bytes);
                (Items[i] as ComboBoxItem).Content = array[i];
            }

            while (Items.Count < data.Count - 1)
            {
                i++;
                string value = data[i] as string;
                array[i] = value;
                Items.Add(new ComboBoxItem { Content = array[Items.Count] });
            }

            ItemsContent = array;
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

                this.TextBox.Focus(FocusState.Keyboard);
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

        protected string lastText;
        public string Text
        {
            get { return TextBox == null ? lastText : TextBox.Text; }
            set
            {
                if (TextBox == null || TextBox.Text.Equals(value))
                    return;

                lastText = value;
                TextBox.Text = lastText;
                this.TextBox.Focus(FocusState.Keyboard);
            }
        }
    }
}
