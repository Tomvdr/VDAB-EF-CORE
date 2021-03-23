using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_EFCore_Boekendatabase
{
    [Table("Auteur")]
    public class Auteur
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }
        public virtual List<Boek> Boeken { get; set;}
    }
}
