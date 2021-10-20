
using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contracts;

namespace ppedv.Personenverwaltung.Logic
{
    public class Core
    {
        public IRepository Repository { get; }

        public Core(IRepository repository)
        {
            Repository = repository;
        }

        public IEnumerable<Mitarbeiter> GetMitarbeiterThatHaveBirthOfMonth(int month)
        {
            return Repository.Query<Mitarbeiter>().Where(x => x.GebDatum.Month == month);
        }

        public Mitarbeiter GetMitarbeiterWithTheMostCustomers()
        {
            return Repository.Query<Mitarbeiter>()
                             .OrderByDescending(x => x.Kunden.Count())
                             .FirstOrDefault();
        }

    }
}