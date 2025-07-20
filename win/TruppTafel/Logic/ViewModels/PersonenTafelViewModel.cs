using System.ComponentModel;
using System.Runtime.CompilerServices;
using TruppTafel.Logic.Interfaces;

namespace TruppTafel.Logic.ViewModels;

[Serializable]
public class PersonenTafelViewModel(string personenName, IAusbildungsgrad ausbildung) : INotifyPropertyChanged
{
    private string _personenName = personenName;
    private IAusbildungsgrad _ausbildung = ausbildung;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string PersonenName
    {
        get => _personenName;
        set
        {
            _personenName = value;
            OnPropertyChanged();
        }
    }

    public IAusbildungsgrad Ausbildung
    {
        get => _ausbildung;
        set
        {
            _ausbildung = value;
            OnPropertyChanged();
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}