using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreCodeFirst.Model
{
    
    public class Kunde : Person
    {

        public DateTime ErsterKauf { get; set; }

        [MaxLength(49)]
        [Required()]
        public string Kundennummer { get; set; }

        public virtual Mitarbeiter Ansprechpartner { get; set; }

    }
}
