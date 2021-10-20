using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Personenverwaltung.Data.EfCore
{
    public class EfRepository : IRepository
    {
        EfContext con = new EfContext();

        public void Add<T>(T entity) where T : class
        {
            //   if(typeof(T) == typeof(Mitarbeiter))
            //       con.Mitarbeiter.Add(entity as Mitarbeiter);

            con.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            con.Set<T>().Remove(entity);

        }

        public IQueryable<T> Query<T>() where T : class
        {
            return con.Set<T>();
        }

        public T GetById<T>(int id) where T : class
        {
            return con.Set<T>().Find(id);
        }

        public void SaveAll()
        {
            con.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            con.Set<T>().Update(entity);

        }
    }
}
