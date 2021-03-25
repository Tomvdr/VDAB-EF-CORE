using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos.Entities
{
    public class Kleur
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        // Navigational properties
        // Een kleur kan gebruikt worden in verschillende wagens
        public List<Wagen> Wagens { get; set; }
    }
}
