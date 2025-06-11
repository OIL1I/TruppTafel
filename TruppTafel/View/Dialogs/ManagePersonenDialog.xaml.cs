using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TruppTafel.Logic.Ausbildung;
using TruppTafel.Logic.ViewModels;
using TruppTafel.View.Controls;

namespace TruppTafel.View.Dialogs;

public partial class ManagePersonenDialog : Window
{
    public enum ManagePersonenDialogModus
    {
        New,
        Change
    }

    public static PersonenTafelViewModel? NeuePerson;
    public static PersonenTafelViewModel? AltePerson;
    
    public ManagePersonenDialog(PersonenTafelViewModel? person, ManagePersonenDialogModus modus)
    {
        InitializeComponent();

        NeuePerson = person;
        
        switch (modus)
        {
            case ManagePersonenDialogModus.New:
                ButtonAcceptDialog.Content = "Erstellen";
                NeuePerson = new PersonenTafelViewModel("M.Mustermann", new ZF());
                break;
            case ManagePersonenDialogModus.Change:
                ButtonAcceptDialog.Content = "Speichern";
                AltePerson = new PersonenTafelViewModel(person.PersonenName, person.Ausbildung);
                break;
        }
        PersonenTafel tafel = new PersonenTafel(NeuePerson);
        Grid.SetRow(tafel, 0);
        MainGrid.Children.Add(tafel);
        
        TextBoxPersonenName.Text = NeuePerson.PersonenName;

        if (NeuePerson.Ausbildung is ZF) ComboBoxAusbildung.SelectedIndex = 0;
        else if (NeuePerson.Ausbildung is GF) ComboBoxAusbildung.SelectedIndex = 1;
        else if (NeuePerson.Ausbildung is AGT) ComboBoxAusbildung.SelectedIndex = 2;
        else if (NeuePerson.Ausbildung is TM) ComboBoxAusbildung.SelectedIndex = 3;
        else if (NeuePerson.Ausbildung is GK) ComboBoxAusbildung.SelectedIndex = 4;

    }

    private void ButtonAcceptDialog_OnClick(object sender, RoutedEventArgs e)
    {
        NeuePerson.PersonenName = TextBoxPersonenName.Text;
        DialogResult = true;
    }

    private void ButtonCancelDialog_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }

    private void ComboBoxAusbildung_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (ComboBoxAusbildung.SelectedIndex)
        {
            case 0: //Zugführer
                NeuePerson.Ausbildung = new ZF();
                break;
            case 1: //Gruppenführer
                NeuePerson.Ausbildung = new GF();
                break;
            case 2: //Angriffstrupp
                NeuePerson.Ausbildung = new AGT();
                break;
            case 3: //Truppmann
                NeuePerson.Ausbildung = new TM();
                break;
            case 4: //Truppmann 1/2
                NeuePerson.Ausbildung = new GK();
                break;
        }
    }

    private void TextBlockPersonenName_OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (TextBoxPersonenName.Text == string.Empty) TextBoxPersonenName.Text = "M.Mustermann";
    }
}