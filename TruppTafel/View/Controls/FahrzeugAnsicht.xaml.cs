using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TruppTafel.Logic.Helper;
using TruppTafel.Logic.Interfaces;
using TruppTafel.Logic.ViewModels;
using TruppTafel.View.Dialogs;

namespace TruppTafel.View.Controls;

public partial class FahrzeugAnsicht : UserControl
{
    public FahrzeugAnsicht(FahrzeugAnsichtViewModel ViewModel)
    {
        InitializeComponent();
        DataContext = ViewModel;
        ErstelleTabelle(ViewModel.Besatzung);
        
        ContextMenu = new ContextMenu();
        MenuItem mi1 = new MenuItem { Header = "Bearbeiten" };
        mi1.Click += (sender, args) =>
        {
            var result = new ManageFahrzeugeDialog(ViewModel, ManageFahrzeugeDialog.ManageFahrzeugeDialogModus.Change).ShowDialog();
            if ((bool)!result)
            {
                ViewModel.FahrzeugName = ManageFahrzeugeDialog.AltesFahrzeug.FahrzeugName;
                ViewModel.Besatzung = ManageFahrzeugeDialog.AltesFahrzeug.Besatzung;
                ManagePersonenDialog.AltePerson = null;
            }
            ErstelleTabelle((DataContext as FahrzeugAnsichtViewModel).Besatzung);
        };
        MenuItem mi2 = new MenuItem { Header = "Löschen" };
        mi2.Click += (sender, args) => RemoveChildHelper.RemoveChild(this.Parent, this);
        ContextMenu.Items.Add(mi1);
        ContextMenu.Items.Add(mi2);
        
    }
    
    public void ErstelleTabelle(IBesatzung besatzung)
    {
        MainGrid.Children.Clear();
        MainGrid.RowDefinitions.Clear();
        MainGrid.ColumnDefinitions.Clear();
        
        MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(250)});
        MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(250)});

        int i = 0;
        foreach (string s in besatzung.BesatzungsPlätze)
        {
            MainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100)});
            var txtblock = new TextBlock()
            {
                Text = s,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 20,
                FontWeight = FontWeights.Bold
            };
            Grid.SetColumn(txtblock, 0);
            Grid.SetRow(txtblock, i);
            MainGrid.Children.Add(txtblock);

            var border = new Border()
            {
                Background = new SolidColorBrush(Color.FromRgb(255, 255, 255)),
                AllowDrop = true
            };
            border.DragEnter += (object sender, DragEventArgs e) =>
            {
                border.Background = new SolidColorBrush(Color.FromRgb(185, 185, 205));
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(185, 185, 255));
                border.BorderThickness = new Thickness(1);
            };
            border.DragLeave += (object sender, DragEventArgs e) =>
            {
                border.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                border.BorderThickness = new Thickness(0);
            };
            border.Drop += (object sender, DragEventArgs e) =>
            {
                if (e.Data.GetDataPresent(typeof(PersonenTafel)))
                {
                    PersonenTafel tafel = (PersonenTafel)e.Data.GetData(typeof(PersonenTafel));
                    RemoveChildHelper.RemoveChild(tafel.Parent, tafel);
                    border.Child = tafel;
                    
                }
                else if (e.Data.GetDataPresent(typeof(BesucherPersonenTafel)))
                {
                    BesucherPersonenTafel tafel = (BesucherPersonenTafel)e.Data.GetData(typeof(BesucherPersonenTafel));
                    RemoveChildHelper.RemoveChild(tafel.Parent, tafel);
                    border.Child = tafel;
                }
                border.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                border.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                border.BorderThickness = new Thickness(0);
            };
            Grid.SetColumn(border, 1);
            Grid.SetRow(border, i);
            MainGrid.Children.Add(border);
            
            i++;
        }
    }

    private void TextBlockFahrzeugName_OnSourceUpdated(object? sender, DataTransferEventArgs e)
    {
        TextBlockFahrzeugName.Text = (DataContext as FahrzeugAnsichtViewModel).FahrzeugName;
    }
}