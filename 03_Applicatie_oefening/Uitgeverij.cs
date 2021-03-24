using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace _03_Applicatie_oefening
{

    [Table("Uitgeverij")]
    public class Uitgeverij
    { 
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }


        public List<Boek> Boeken { get; set; }
    }
}
