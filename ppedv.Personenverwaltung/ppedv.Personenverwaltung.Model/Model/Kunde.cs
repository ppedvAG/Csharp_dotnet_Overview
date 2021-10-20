using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ppedv.Personenverwaltung.Model
{
    public class Kunde : Person
    {
        public DateTime ErsterKauf { get; set; }

        public string Kundennummer { get; set; }

        public virtual Mitarbeiter Ansprechpartner { get; set; }

    }
}
