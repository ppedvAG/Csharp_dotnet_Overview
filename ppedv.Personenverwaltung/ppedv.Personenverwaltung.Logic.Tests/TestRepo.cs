using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contracts;
using System.Linq;

namespace ppedv.Personenverwaltung.Logic.Tests
{
    class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public T GetById<T>(int id) where T : class
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : class
        {
            if (typeof(T) == typeof(Mitarbeiter))
            {
                var m1 = new Mitarbeiter() { Name = "Fred" };
                var m2 = new Mitarbeiter() { Name = "Barney" };

                m1.Kunden.Add(new Kunde());
                m1.Kunden.Add(new Kunde());

                m2.Kunden.Add(new Kunde());
                m2.Kunden.Add(new Kunde());
                m2.Kunden.Add(new Kunde());

                return new[] { m1, m2 }.Cast<T>().AsQueryable();
            }

            throw new System.NotImplementedException();
        }

        public void SaveAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}