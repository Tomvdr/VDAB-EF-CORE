using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07_EFCore_SunshineAutos.Entities
{
    public class Merk
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public List<Model> Modellen { get; set; }
    }
}
