using System.Collections.Generic;

namespace EfCoreCodeFirst.Model
{
    public class Mitarbeiter : Person
    {
        public int Nummer { get; set; }

        public string Beruf { get; set; }
        public virtual ICollection<Kunde> Kunden { get; set; } = new HashSet<Kunde>();
        public virtual ICollection<Abteilung> Abteilungen { get; set; } = new HashSet<Abteilung>();
    }
}
