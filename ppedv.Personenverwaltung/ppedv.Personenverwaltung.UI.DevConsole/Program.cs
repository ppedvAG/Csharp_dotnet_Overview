// See https://aka.ms/new-console-template for more information
using ppedv.Personenverwaltung.Logic;
using ppedv.Personenverwaltung.Model;

Console.WriteLine("Hello, World!");

var core = new Core();

var query = core.Repository.Query<Mitarbeiter>()
                           .Where(x => x.Name.StartsWith("F"))
                           .OrderBy(x => x.GebDatum.Year);


foreach (var m in query)
{
    Console.WriteLine($"{m.Name}");
}

Console.WriteLine($"Meiste Kunden hat: {core.GetMitarbeiterWithTheMostCustomers()?.Name}");


Console.WriteLine("Ende");
Console.ReadLine();