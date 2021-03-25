using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos.Entities
{
    public class Factuur
    {
        public int FactuurNr { get; set; }

        public DateTime FactuurDatum { get; set; }

        public double Bedrag { get; set; }

        // foreign keys
        public int KlantNr { get; set; }
        public string ChassisNr { get; set; }
        public int VerkoperId { get; set; }



        // navigational properties in functie van de bovenstaande foreign keys

        // Een wagen wordt verkocht aan een klant
        public Klant Klant { get; set; }
        // Een factuur heeft een gekoppelde wagen
        public Wagen Wagen { get; set; }
        // Een factuur wordt verkocht door een verkoper
        public Verkoper Verkoper { get; set; }
    }
}
