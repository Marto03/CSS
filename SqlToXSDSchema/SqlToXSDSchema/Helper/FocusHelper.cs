using System.Windows;

namespace SqlToXSDSchema.Helper
{
    public class FocusHelper
    {
        public static readonly DependencyProperty FocusOnLoadProperty =
            DependencyProperty.RegisterAttached("FocusOnLoad", typeof(bool), typeof(FocusHelper), new PropertyMetadata(false, OnFocusOnLoadChanged));

        public static bool GetFocusOnLoad(DependencyObject obj)
        {
            return (bool)obj.GetValue(FocusOnLoadProperty);
        }

        public static void SetFocusOnLoad(DependencyObject obj, bool value)
        {
            obj.SetValue(FocusOnLoadProperty, value);
        }

        private static void OnFocusOnLoadChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element && (bool)e.NewValue)
            {
                element.Loaded += (sender, args) => element.Focus();
            }
        }
    }
}
