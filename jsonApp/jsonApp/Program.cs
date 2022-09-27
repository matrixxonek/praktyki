using System.IO;
using System.Text.Json;
Console.WriteLine("Json file maker");
string folder = "C:\\Users\\Admin\\Source\\Repos\\praktyki\\jsonApp";
StreamWriter write = new StreamWriter(folder + "\\dane.json");
var dane = new Dane
{
    liczba = 5,
    tekst = "Zjadlem cale maslo orzechowe.",
    tekst2 = "Kto zjadl cale maslo orzechowe?"
};
string jsonString = JsonSerializer.Serialize(dane);
Console.WriteLine(jsonString);
write.WriteLine(jsonString);
write.Close();
string odczytane = File.ReadAllText("C:\\Users\\Admin\\Source\\Repos\\praktyki\\jsonApp\\dane.json");
Dane dane2 = JsonSerializer.Deserialize<Dane>(odczytane);

Console.WriteLine(dane2.liczba);
Console.WriteLine(dane2.tekst);
Console.WriteLine(dane2.tekst2);
Console.ReadKey();

public class Dane
{
    public int liczba { get; set; }
    public string tekst { get; set; }
    public string tekst2 { get; set; }
};