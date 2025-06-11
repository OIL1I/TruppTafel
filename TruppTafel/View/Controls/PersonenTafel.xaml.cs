using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TruppTafel.Logic.Ausbildung;
using TruppTafel.Logic.Helper;
using TruppTafel.Logic.Interfaces;
using TruppTafel.Logic.ViewModels;
using TruppTafel.View.Dialogs;

namespace TruppTafel.View.Controls;

public partial class PersonenTafel : UserControl
{
    public PersonenTafel(PersonenTafelViewModel ViewModel)
    {
        InitializeComponent();
        Panel.SetZIndex(this, 1);
        this.DataContext = ViewModel;
        ContextMenu = new ContextMenu();
        MenuItem mi1 = new MenuItem { Header = "Bearbeiten" };
        mi1.Click += (sender, args) =>
        {
            var result = new ManagePersonenDialog(ViewModel, ManagePersonenDialog.ManagePersonenDialogModus.Change).ShowDialog();
            if ((bool)!result)
            {
                ViewModel.PersonenName = ManagePersonenDialog.AltePerson.PersonenName;
                ViewModel.Ausbildung = ManagePersonenDialog.AltePerson.Ausbildung;
                ManagePersonenDialog.AltePerson = null;
            }
        };
        MenuItem mi2 = new MenuItem { Header = "Löschen" };
        mi2.Click += (sender, args) => RemoveChildHelper.RemoveChild(this.Parent, this);
        ContextMenu.Items.Add(mi1);
        ContextMenu.Items.Add(mi2);
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
                data.SetData(typeof(PersonenTafel), this);
                // data.SetData(typeof(PersonenTafelViewModel), this.DataContext);

                DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }
    }
}