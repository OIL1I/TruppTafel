using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TruppTafel.Data;
using TruppTafel.Logic.Ausbildung;
using TruppTafel.Logic.Besatzung;
using TruppTafel.Logic.Helper;
using TruppTafel.Logic.ViewModels;
using TruppTafel.View.Controls;
using TruppTafel.View.Dialogs;

namespace TruppTafel.View.Windows;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        FileManager.Load(StackPanelFahrzeuge, WrapPanelPersonen);
        ValidateEmptyPanelHint();
    }

    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        base.OnClosing(e);
        FileManager.Save(StackPanelFahrzeuge, WrapPanelPersonen);
    }

    private void ValidateEmptyPanelHint()
    {
        if (StackPanelFahrzeuge.Children.Count != 0)
        {
            StackPanelKeineFahrzeuge.Visibility = Visibility.Collapsed;
        }
        else StackPanelKeineFahrzeuge.Visibility = Visibility.Visible;

        if (WrapPanelPersonen.Children.Count != 0)
        {
            StackPanelKeinePersonen.Visibility = Visibility.Collapsed;
        }
        else StackPanelKeinePersonen.Visibility = Visibility.Visible;
    }

    private void BtnAddPerson_OnClick(object sender, RoutedEventArgs e)
    {
        var result = new ManagePersonenDialog(null, ManagePersonenDialog.ManagePersonenDialogModus.New).ShowDialog();
        if ((bool)result)
        {
            var neuePerson = new PersonenTafel(new PersonenTafelViewModel(ManagePersonenDialog.NeuePerson.PersonenName,
                ManagePersonenDialog.NeuePerson.Ausbildung));
            ManagePersonenDialog.NeuePerson = null;
            WrapPanelPersonen.Children.Add(neuePerson);
            //TODO: Ordne PersonenTafeln
        }

        ValidateEmptyPanelHint();
    }

    private void BtnAddFahrzeug_OnClick(object sender, RoutedEventArgs e)
    {
        var result = new ManageFahrzeugeDialog(null, ManageFahrzeugeDialog.ManageFahrzeugeDialogModus.New).ShowDialog();
        if ((bool)result)
        {
            var neuesFahrzeug = new FahrzeugAnsicht(new FahrzeugAnsichtViewModel(
                ManageFahrzeugeDialog.NeuesFahrzeug.FahrzeugName, ManageFahrzeugeDialog.NeuesFahrzeug.Besatzung));
            StackPanelFahrzeuge.Children.Add(neuesFahrzeug);
        }

        ValidateEmptyPanelHint();
    }

    private void WrapPanelPersonen_OnDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(PersonenTafel)))
        {
            PersonenTafel tafel = (PersonenTafel)e.Data.GetData(typeof(PersonenTafel));

            RemoveChildHelper.RemoveChild(tafel.Parent, tafel);
            WrapPanelPersonen.Children.Add(tafel);
            ValidateEmptyPanelHint();
            WrapPanelPersonen.Background = Brushes.White;
            //TODO: Ordne PersonenTafeln
        }
        else if (e.Data.GetDataPresent(typeof(BesucherPersonenTafel)))
        {
            BesucherPersonenTafel tafel = (BesucherPersonenTafel)e.Data.GetData(typeof(BesucherPersonenTafel));
            RemoveChildHelper.RemoveChild(tafel.Parent, tafel);
            WrapPanelPersonen.Children.Add(tafel);
        }
    }

    private void WrapPanelPersonen_OnDragEnter(object sender, DragEventArgs e)
    {
        WrapPanelPersonen.Background = Brushes.LightBlue;
    }

    private void WrapPanelPersonen_OnDragLeave(object sender, DragEventArgs e)
    {
        WrapPanelPersonen.Background = Brushes.White;
    }

    private void ButtonNeuePerson_OnClick(object sender, RoutedEventArgs e)
    {
        var result = new ManagePersonenDialog(null, ManagePersonenDialog.ManagePersonenDialogModus.New).ShowDialog();
        if ((bool)result)
        {
            var neuePerson = new PersonenTafel(new PersonenTafelViewModel(ManagePersonenDialog.NeuePerson.PersonenName,
                ManagePersonenDialog.NeuePerson.Ausbildung));
            ManagePersonenDialog.NeuePerson = null;
            WrapPanelPersonen.Children.Add(neuePerson);
            //TODO: Ordne PersonenTafeln
        }

        ValidateEmptyPanelHint();
    }

    private void ButtonNeuerBesucher_OnClick(object sender, RoutedEventArgs e)
    {
        WrapPanelPersonen.Children.Add(new BesucherPersonenTafel());
    }

    private void ButtonNeuesFahrzeug_OnClick_OnClick(object sender, RoutedEventArgs e)
    {
        var result = new ManageFahrzeugeDialog(null, ManageFahrzeugeDialog.ManageFahrzeugeDialogModus.New).ShowDialog();
        if ((bool)result)
        {
            var neuesFahrzeug = new FahrzeugAnsicht(new FahrzeugAnsichtViewModel(
                ManageFahrzeugeDialog.NeuesFahrzeug.FahrzeugName, ManageFahrzeugeDialog.NeuesFahrzeug.Besatzung));
            ManageFahrzeugeDialog.NeuesFahrzeug = null;
            StackPanelFahrzeuge.Children.Add(neuesFahrzeug);
        }
        ValidateEmptyPanelHint();
    }
}