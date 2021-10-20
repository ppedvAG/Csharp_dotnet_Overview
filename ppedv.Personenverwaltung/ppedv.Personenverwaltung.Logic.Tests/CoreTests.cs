using Moq;
using ppedv.Personenverwaltung.Model;
using ppedv.Personenverwaltung.Model.Contracts;
using System.Linq;
using Xunit;

namespace ppedv.Personenverwaltung.Logic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void GetMitarbeiterWithTheMostCustomers_Empty_DB()
        {
            var mock = new Mock<IRepository>();

            Core core = new Core(mock.Object);

            var result = core.GetMitarbeiterWithTheMostCustomers();

            Assert.Null(result);
        }

        [Fact]
        public void GetMitarbeiterWithTheMostCustomers_2_Mitarbeiter_Barney_has_more_customer()
        {
            Core core = new Core(new TestRepo());

            var result = core.GetMitarbeiterWithTheMostCustomers();

            Assert.Equal("Barney", result.Name);
        }

        [Fact]
        public void GetMitarbeiterWithTheMostCustomers_2_Mitarbeiter_Barney_has_more_customer_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Mitarbeiter>()).Returns(() =>
              {
                  var m1 = new Mitarbeiter() { Name = "Fred" };
                  var m2 = new Mitarbeiter() { Name = "Barney" };

                  m1.Kunden.Add(new Kunde());
                  m1.Kunden.Add(new Kunde());

                  m2.Kunden.Add(new Kunde());
                  m2.Kunden.Add(new Kunde());
                  m2.Kunden.Add(new Kunde());

                  return new[] { m1, m2 }.AsQueryable();
              });

            Core core = new Core(mock.Object);

            var result = core.GetMitarbeiterWithTheMostCustomers();

            Assert.Equal("Barney", result.Name);

            mock.Verify(x => x.Query<Mitarbeiter>(), Times.Once());
        }
    }
}