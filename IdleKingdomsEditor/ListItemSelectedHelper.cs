using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IdleKingdomsEditor
{
    public static class ListItemSelectedHelper
    {
        public static DependencyProperty SelectedCommandProperty = DependencyProperty.RegisterAttached("Selected",
                   typeof(ICommand),
                   typeof(ListItemSelectedHelper),
                   new FrameworkPropertyMetadata(null, new PropertyChangedCallback(ListItemSelectedHelper.SelectedChanged)));

        public static void SetSelected(DependencyObject target, ICommand value)
        {
            target.SetValue(ListItemSelectedHelper.SelectedCommandProperty, value);
        }

        public static ICommand GetSelected(DependencyObject target)
        {
            return (ICommand)target.GetValue(SelectedCommandProperty);
        }

        private static void SelectedChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            ListViewItem element = target as ListViewItem;
            if (element != null)
            {
                if ((e.NewValue != null) && (e.OldValue == null))
                {
                    element.Selected += Element_Selected;
                }
                else if ((e.NewValue == null) && (e.OldValue != null))
                {
                    element.Selected -= Element_Selected;
                }
            }
        }

        private static void Element_Selected(object sender, RoutedEventArgs e)
        {
            var element = (UIElement)sender;
            var command = (ICommand)element.GetValue(ListItemSelectedHelper.SelectedCommandProperty);
            command.Execute(element);
        }
    }
}
