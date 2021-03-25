using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos.Entities
{
    public class Verkoper
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }


        // Navigational properties

        // Een verkoper kan meerdere wagens verkopen (= factuur)
        public List<Factuur> Facturen { get; set; }
    }
}
