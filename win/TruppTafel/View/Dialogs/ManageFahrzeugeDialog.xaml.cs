using System.Windows;
using System.Windows.Controls;
using TruppTafel.Logic.Besatzung;
using TruppTafel.Logic.ViewModels;
using TruppTafel.View.Controls;

namespace TruppTafel.View.Dialogs;

public partial class ManageFahrzeugeDialog : Window
{
    public enum ManageFahrzeugeDialogModus
    {
        New,
        Change
    }

    public static FahrzeugAnsichtViewModel? AltesFahrzeug;
    public static FahrzeugAnsichtViewModel? NeuesFahrzeug;
    private FahrzeugAnsicht ansicht;
    
    public ManageFahrzeugeDialog(FahrzeugAnsichtViewModel? fahrzeug, ManageFahrzeugeDialogModus modus)
    {
        InitializeComponent();

        NeuesFahrzeug = fahrzeug;
        
        switch (modus)
        {
            case ManageFahrzeugeDialogModus.New:
                ButtonAcceptDialog.Content = "Erstellen";
                NeuesFahrzeug = new FahrzeugAnsichtViewModel("Musterfahrzeug", new Staffel());
                break;
            case ManageFahrzeugeDialogModus.Change:
                ButtonAcceptDialog.Content = "Speichern";
                AltesFahrzeug = new FahrzeugAnsichtViewModel(fahrzeug.FahrzeugName, fahrzeug.Besatzung);
                break;
        }
        
        ansicht = new FahrzeugAnsicht(NeuesFahrzeug);
        Grid.SetColumn(ansicht, 0);
        Grid.SetRow(ansicht, 0);
        ansicht.VerticalAlignment = VerticalAlignment.Center;
        ansicht.HorizontalAlignment = HorizontalAlignment.Stretch;
        MainGrid.Children.Add(ansicht);
        
        TextBoxFahrzeugName.Text = NeuesFahrzeug.FahrzeugName;
        
        if (NeuesFahrzeug.Besatzung is SelbstaendigerTrupp) ComboBoxBesatzung.SelectedIndex = 0;
        else if (NeuesFahrzeug.Besatzung is Staffel) ComboBoxBesatzung.SelectedIndex = 1;
        else if (NeuesFahrzeug.Besatzung is Gruppe) ComboBoxBesatzung.SelectedIndex = 2;
    }

    private void ButtonAcceptDialog_OnClick(object sender, RoutedEventArgs e)
    {
        NeuesFahrzeug.FahrzeugName = TextBoxFahrzeugName.Text;
        DialogResult = true;
    }

    private void ButtonCancelDialog_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }

    private void ComboBoxBesatzung_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (ComboBoxBesatzung.SelectedIndex)
        {
            case 0: //Zugführer
                NeuesFahrzeug.Besatzung = new SelbstaendigerTrupp();
                break;
            case 1: //Gruppenführer
                NeuesFahrzeug.Besatzung = new Staffel();
                break;
            case 2: //Angriffstrupp
                NeuesFahrzeug.Besatzung = new Gruppe();
                break;
        }
        ansicht.ErstelleTabelle(NeuesFahrzeug.Besatzung);
    }

    private void TextBoxFahrzeugName_OnLostFocus(object sender, RoutedEventArgs e)
    {
        if (TextBoxFahrzeugName.Text == string.Empty) TextBoxFahrzeugName.Text = "Musterfahrzeug"; 
    }
}