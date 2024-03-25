using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SqlToXSDSchema.Behaviors
{
    public class DataGridAutoGeneratingColumnBehavior
    {
        public static readonly DependencyProperty AutoGeneratingColumnCommandProperty =
            DependencyProperty.RegisterAttached("AutoGeneratingColumnCommand", typeof(ICommand),
                typeof(DataGridAutoGeneratingColumnBehavior), new PropertyMetadata(null, OnAutoGeneratingColumnCommandChanged));

        public static ICommand GetAutoGeneratingColumnCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(AutoGeneratingColumnCommandProperty);
        }

        public static void SetAutoGeneratingColumnCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(AutoGeneratingColumnCommandProperty, value);
        }

        private static void OnAutoGeneratingColumnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataGrid dataGrid)
            {
                if (e.NewValue is ICommand command)
                {
                    dataGrid.AutoGeneratingColumn += (sender, args) =>
                    {
                        command.Execute(args);
                    };
                }
            }
        }
    }
}
