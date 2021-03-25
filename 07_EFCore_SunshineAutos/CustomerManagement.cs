using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos
{
    public static class CustomerManagement
    {
        public static void ListItems()
        {
            Console.WriteLine("0. Annuleren");
            Console.WriteLine("1. Klant opzoeken via naam");
            Console.WriteLine("2. Klant toevoegen");
            
            int keuze = Helpers.NumericInput("Keuze");
            switch (keuze)
            {
                case 1:
                    SearchCustomer();
                    break;
                case 2:
                    AddCustomer();
                    break;
            }
        }


        // TODO:
        // - Context opendoen
        // - Opzoeking doen van klanten die voldoen aan de naam
        //   - TIP: ik wil een LIKE query hier krijgen, dus gebruik .Contains() ipv ==
        //      - Dwz ik wil bv. Jeroen, Jan ... zien als ik op 'J' zoek
        //   - https://docs.microsoft.com/en-us/ef/core/querying/#filtering
        //   - Een lijst tonen van alle gevonden resultaat of gepaste melding indien geen klanten gevonden werden
        private static void SearchCustomer()
        {
            Helpers.Info("# Klant opzoeken");
            string naam = Helpers.TextInput("Naam");
        }

        // TODO:
        // - Context opendoen
        // - Kijk of deze klant al bestaat (combinatie naam & adres)
        //   - Ja: error tonen
        //   - Nee: toevoegen
        private static void AddCustomer()
        {
            Helpers.Info("# Klant toevoegen");
            string naam = Helpers.TextInput("Naam");
        }
    }
}
