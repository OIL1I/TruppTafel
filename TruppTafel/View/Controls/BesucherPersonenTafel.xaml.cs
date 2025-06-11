using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TruppTafel.Logic.Helper;

namespace TruppTafel.View.Controls;

public partial class BesucherPersonenTafel : UserControl
{
    public BesucherPersonenTafel()
    {
        InitializeComponent();
        ContextMenu = new ContextMenu();
        MenuItem mi = new MenuItem { Header = "Löschen" };
        mi.Click += (sender, args) => RemoveChildHelper.RemoveChild(this.Parent, this);
        ContextMenu.Items.Add(mi);
    }
    
    protected override void OnMouseEnter(MouseEventArgs e)
    {
        base.OnMouseEnter(e);
        this.Cursor = Cursors.Hand;
    }

    protected override void OnMouseLeave(MouseEventArgs e)
    {
        base.OnMouseLeave(e);
        this.Cursor = Cursors.Arrow;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DataObject data = new DataObject();
            {
                data.SetData(typeof(BesucherPersonenTafel), this);
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }
    }
}