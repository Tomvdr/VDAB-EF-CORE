using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _03_Applicatie_oefening
{
    [Table("Boek")]
    public class Boek
    {
        [Key]
        public string ISBNNr { get; set; }
        public string Title { get; set; }
        public int PaginaAantal { get; set; }
        


        public int AuteurId { get; set; }
        public Auteur Auteur { get; set; }

        public int UitgeverijId { get; set; }
        public Uitgeverij Uitgeverij { get; set; }
    }
}
