using System.ComponentModel;
using System.Runtime.CompilerServices;
using TruppTafel.Logic.Interfaces;

namespace TruppTafel.Logic.ViewModels;

[Serializable]
public class FahrzeugAnsichtViewModel(string fahrzeugName, IBesatzung besatzung) : INotifyPropertyChanged
{
    private string _fahrzeugName = fahrzeugName;
    private IBesatzung _besatzung = besatzung;
    
    public event PropertyChangedEventHandler? PropertyChanged;

    public string FahrzeugName
    {
        get => _fahrzeugName;
        set
        {
            _fahrzeugName = value;
            OnPropertyChanged();
        }
    }

    public IBesatzung Besatzung
    {
        get => _besatzung;
        set
        {
            _besatzung = value;
            OnPropertyChanged();
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}