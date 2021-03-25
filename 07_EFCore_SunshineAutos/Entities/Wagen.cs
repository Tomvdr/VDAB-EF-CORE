using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos.Entities
{
    public class Wagen
    {
        public string ChassisNr { get; set; }
        public int Bouwjaar { get; set; }

        // Foreign keys
        public int ModelId { get; set; }
        public int KleurId { get; set; }

        // Navigational properties
        // Een wagen heeft één kleur
        public Kleur Kleur { get; set; }
        // Een wagen heeft één model
        public Model Model { get; set; }

        public Factuur Factuur { get; set; }
    }
}
