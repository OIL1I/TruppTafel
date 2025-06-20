using System.Windows;
using System.Windows.Controls;

namespace TruppTafel.Logic.Helper
{
    public class RemoveChildHelper
    {
        public static void RemoveChild(DependencyObject parent, FrameworkElement child)
        {
            if (parent is Panel panel)
            {
                panel.Children.Remove(child);
                return;
            }
            
            var decorator = parent as Decorator;
            if (decorator != null && decorator.Child == child)
            {
                decorator.Child = null;
                return;
            }
        }
    }
}