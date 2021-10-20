using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ppedv.Personenverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace ppedv.Personenverwaltung.Data.EfCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_db()
        {
            var con = new EfContext();

            con.Database.EnsureDeleted();

            Assert.True(con.Database.EnsureCreated());
        }

        [Fact]
        public void Can_CRUD_Mitarbeiter()
        {
            var m = new Mitarbeiter() { Name = $"Fred_{Guid.NewGuid()}", Beruf = "Macht dinge" };
            var newName = $"Wilma_{Guid.NewGuid()}";

            using (var con = new EfContext())
            {
                //CREATE
                con.Mitarbeiter.Add(m);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Mitarbeiter.Find(m.Id);

                //READ
                Assert.NotNull(loaded);
                Assert.Equal(m.Name, loaded.Name);

                //UDATE
                loaded.Name = newName;
                con.SaveChanges();
            }

            //check UPDATE
            using (var con = new EfContext())
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                //Assert.Equal(newName, loaded.Name);
                loaded.Name.Should().Be(newName);

                //DELETE
                con.Mitarbeiter.Remove(loaded);
                con.SaveChanges();
            }

            //check DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                //Assert.Null(loaded);
                loaded.Should().BeNull();
            }
        }

        [Fact]
        public void Can_CRUD_Mitarbeiter_AutoFix()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter("Id"));

            var m = fix.Create<Mitarbeiter>();

            using (var con = new EfContext())
            {
                con.Mitarbeiter.Add(m);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Mitarbeiter.Find(m.Id);

                loaded.Should().BeEquivalentTo(m, c => c.IgnoringCyclicReferences());
            }
        }
    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;
        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }
        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();
            return new NoSpecimen();
        }
    }
}