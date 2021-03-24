using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos.Entities
{
    public class Model
    {
        // Uit te breiden met andere velden adhv. ERD
        public int Id { get; set; }
        public string Naam { get; set; }

        // Navigational properties
        public long MerkId { get; set; }
        public Merk Merk { get; set; }
    }
}
