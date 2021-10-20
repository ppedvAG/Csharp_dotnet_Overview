using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreCodeFirst.Model
{
    
    //[Table("Customers")]
    public class Kunde : Person
    {

        public DateTime ErsterKauf { get; set; }

        [Required()]
        [MaxLength(49)]
        public string Kundennummer { get; set; }

        public virtual Mitarbeiter Ansprechpartner { get; set; }

    }
}
