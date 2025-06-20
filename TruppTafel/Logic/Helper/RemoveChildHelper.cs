using System.Windows;
using System.Windows.Controls;

namespace TruppTafel.Logic.Helper
{
    public class RemoveChildHelper
    {
        public static void RemoveChild(DependencyObject parent, FrameworkElement child)
        {
            if (parent is PersonenWrapPanel pPanel)
            {
                pPanel.RemoveChild(child);
                return;
            }
            if (parent is FahrzeugeStackPanel fPanel)
            {
                fPanel.RemoveChild(child);
                return;
            }
            if (parent is Panel panel)
            {
                panel.Children.Remove(child);
                return;
            }
            if (parent is Decorator decorator && decorator.Child == child)
            {
                decorator.Child = null;
                return;
            }
        }
    }
}