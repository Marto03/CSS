using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public static class TextBoxPlaceHolder
    {
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.RegisterAttached("PlaceHolder", typeof(string), typeof(TextBoxPlaceHolder), new PropertyMetadata(null, OnPlaceHolderChanged));

        public static string GetPlaceholder(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceHolderProperty);
        }

        public static void SetPlaceholder(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceHolderProperty, value);
        }

        private static void OnPlaceHolderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                if (e.NewValue != null)
                {
                    textBox.GotFocus += TextBox_GotFocus;
                    textBox.LostFocus += TextBox_LostFocus;
                    UpdatePlaceHolderVisibility(textBox);
                }
                else
                {
                    textBox.GotFocus -= TextBox_GotFocus;
                    textBox.LostFocus -= TextBox_LostFocus;
                }
            }
        }

        private static void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text == GetPlaceholder(textBox))
            {
                textBox.Text = string.Empty;
            }
        }

        private static void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = GetPlaceholder(textBox);
            }
        }

        private static void UpdatePlaceHolderVisibility(TextBox textBox)
        {
            if (textBox.IsFocused || !string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.ClearValue(TextBox.ForegroundProperty);
            }
            else
            {
                textBox.Foreground = SystemColors.GrayTextBrush;
            }
        }
    }


}