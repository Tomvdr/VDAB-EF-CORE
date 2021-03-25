﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        

        // Foreign keys
        public int MerkId { get; set; }


        // Navigational properties
        // Een model heeft een merk
        public Merk Merk { get; set; }


        // Een model kan gebruikt worden door meerdere wagens
        public List<Wagen> Wagens { get; set; }
    }
}
