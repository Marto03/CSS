using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SqlToXSDSchema.Behaviors
{
    public static class TextBoxEnterKeyBehavior
    {
        public static readonly DependencyProperty EnterCommandProperty =
            DependencyProperty.RegisterAttached("EnterCommand", typeof(ICommand), typeof(TextBoxEnterKeyBehavior), new PropertyMetadata(null, OnEnterCommandChanged));

        public static ICommand GetEnterCommand(TextBox textBox)
        {
            return (ICommand)textBox.GetValue(EnterCommandProperty);
        }

        public static void SetEnterCommand(TextBox textBox, ICommand value)
        {
            textBox.SetValue(EnterCommandProperty, value);
        }

        private static void OnEnterCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = (TextBox)d;
            if (e.NewValue is ICommand command)
            {
                textBox.KeyDown += (sender, args) =>
                {
                    if (args.Key == Key.Enter && command.CanExecute(null))
                    {
                        command.Execute(null);
                    }
                };
            }
        }
    }
}
