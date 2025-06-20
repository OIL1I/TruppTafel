using System.Windows;
using System.Windows.Controls;

namespace TruppTafel.View.Controls;

public class FahrzeugeStackPanel: StackPanel
{
    public event EventHandler ChildrenCountChanged;

    public void AddChild(UIElement Child)
    {
        Children.Add(Child);
        ChildrenCountChanged?.Invoke(this, EventArgs.Empty);
    }
    
    public void RemoveChild(UIElement Child)
    {
        Children.Remove(Child);
        ChildrenCountChanged?.Invoke(this, EventArgs.Empty);
    }
}