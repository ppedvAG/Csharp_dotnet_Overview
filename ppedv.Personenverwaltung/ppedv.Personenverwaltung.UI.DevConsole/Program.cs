// See https://aka.ms/new-console-template for more information
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ppedv.Personenverwaltung.Data.EfCore;
using ppedv.Personenverwaltung.Logic;
using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contracts;
using System.Reflection;

Console.WriteLine("Hello, World!");




//DI per Hand
//var pfadZurDLL = @"C:\Users\Fred\source\repos\Csharp_dotnet_Overview\ppedv.Personenverwaltung\ppedv.Personenverwaltung.Data.EfCore\bin\Debug\net6.0\ppedv.Personenverwaltung.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(pfadZurDLL);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//IRepository repo = (IRepository)Activator.CreateInstance(typeMitRepo);

//DI mit Castle Windsor
var container = new WindsorContainer();
container.Register(Component.For<IRepository>().ImplementedBy<EfRepository>());


var core = new Core(container.Resolve<IRepository>());

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