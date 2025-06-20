using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents.Serialization;
using TruppTafel.Logic.Ausbildung;
using TruppTafel.Logic.Besatzung;
using TruppTafel.Logic.Interfaces;
using TruppTafel.Logic.ViewModels;
using TruppTafel.View.Controls;
using TruppTafel.View.Windows;

namespace TruppTafel.Data;

public static class FileManager
{
    private static string _dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                      "/TruppTafel/Data/";

    private static string _filePathPersonen = _dataPath + "Personen.data";
    private static string _filePathFahrzuege = _dataPath + "Fahrzeuge.data";

    public static void Save(StackPanel stackFahrzeuge, WrapPanel wrapPersonen)
    {
        if (Directory.Exists(_dataPath) == false)
        {
            Directory.CreateDirectory(_dataPath);
        }

        RemoveExistingFiles();


        foreach (UIElement tafel in wrapPersonen.Children)
        {
            if (tafel is PersonenTafel person)
            {
                FileStream fs = new FileStream(_filePathPersonen, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
                var personvm = person.DataContext as PersonenTafelViewModel;
                sw.Write($"{personvm.PersonenName}:{personvm.Ausbildung.Name}!");
                sw.Flush();
                sw.Close();
                fs.Dispose();
                fs.Close();
            }
        }

        foreach (FahrzeugAnsicht fahrzeug in stackFahrzeuge.Children)
        {
            var fahrzeugvm = fahrzeug.DataContext as FahrzeugAnsichtViewModel;
            FileStream fs = new FileStream(_filePathFahrzuege, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Unicode);
            sw.Write($"{fahrzeugvm.FahrzeugName}:{fahrzeugvm.Besatzung.BesatzungName}!");
            sw.Flush();
            sw.Close();
            fs.Dispose();
            fs.Close();
        }
    }

    public static void Load(FahrzeugeStackPanel stackFahrzeuge, PersonenWrapPanel wrapPersonen)
    {
        if (Directory.Exists(_dataPath) == false)
        {
            return;
        }

        if (File.Exists(_filePathPersonen))
        {
            //Personen
            FileStream fs = new FileStream(_filePathPersonen, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Unicode);
            var fileContent = sr.ReadToEnd();
            sr.Close();
            fs.Dispose();
            fs.Close();
            string[] lines = fileContent.Split('!', StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                var lineParts = line.Split(':');
                IAusbildungsgrad ausbildung = null;
                switch (lineParts[1])
                {
                    case "Zugführer":
                        ausbildung = new ZF();
                        break;
                    case "Gruppenführer":
                        ausbildung = new GF();
                        break;
                    case "Angriffstrupp":
                        ausbildung = new AGT();
                        break;
                    case "Truppmann":
                        ausbildung = new TM();
                        break;
                    case "Truppmann 1/2":
                        ausbildung = new GK();
                        break;
                }

                var personvm = new PersonenTafelViewModel(lineParts[0], ausbildung);
                var person = new PersonenTafel(personvm);
                wrapPersonen.AddChild(person);
            }
        }

        if (File.Exists(_filePathFahrzuege))
        {
            //Fahrzeuge
            FileStream fs = new FileStream(_filePathFahrzuege, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Unicode);
            var fileContent = sr.ReadToEnd();
            sr.Close();
            fs.Dispose();
            fs.Close();
            var lines = fileContent.Split('!', StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                var lineParts = line.Split(":");
                IBesatzung besatzung = null;
                switch (lineParts[1])
                {
                    case "Selbständiger Trupp":
                        besatzung = new SelbstaendigerTrupp();
                        break;
                    case "Staffel":
                        besatzung = new Staffel();
                        break;
                    case "Gruppe":
                        besatzung = new Gruppe();
                        break;
                }

                var fahrzeugvm = new FahrzeugAnsichtViewModel(lineParts[0], besatzung);
                var fahrzeug = new FahrzeugAnsicht(fahrzeugvm);
                stackFahrzeuge.AddChild(fahrzeug);
            }
        }
    }

    private static void RemoveExistingFiles()
    {
        if (File.Exists(_filePathPersonen)) File.Delete(_filePathPersonen);
        if (File.Exists(_filePathFahrzuege)) File.Delete(_filePathFahrzuege);
    }
}