using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos.Entities
{
    public class Klant
    {
        public int KlantNr { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        // Adres zou in principe ook een aparte klasse kunnnen zijn (indien een klant meerdere adressen heeft)
        // Voor de oefening makkelijker te houden, zetten we alles in 1 veldje
        public string Adres { get; set; }
        public string TelefoonNr { get; set; }
        
        // Een klant kan meerdere wagens kopen (= facturen)
        public List<Factuur> Facturen { get; set; }
    }
}
