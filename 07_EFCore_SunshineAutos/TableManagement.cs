using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos
{
    public static class TableManagement
    {
        public static void ListItems()
        {
            Console.WriteLine("0. Annuleren");
            Console.WriteLine("1. Toevoegen merk");
            Console.WriteLine("2. Toevoegen model aan merk");
            Console.WriteLine("3. Toevoegen kleur");
            Console.WriteLine("4. Toevoegen verkoper");

            int keuze = Helpers.NumericInput("Keuze");
            switch (keuze)
            {
                case 1:
                    AddMerk();
                    break;
                case 2:
                    AddModel();
                    break;
                case 3:
                    AddColor();
                    break;
                case 4:
                    AddSalesPerson();
                    break;
            }
        }


        // TODO:
        // - Context opendoen
        // - Kijken of er al een merk bestaat met deze naam
        //   - Ja: error tonen
        //   - Nee: toevoegen en melding tonen
        private static void AddMerk()
        {
            Helpers.Info("# Toevoegen van merk");
            string naam = Helpers.TextInput("Naam");
        }

        // TODO:
        // - Context opendoen
        // - Kijken of er al een model bestaat met deze naam
        //   - Ja: error tonen
        //   - Nee: toevoegen en melding tonen
        private static void AddModel()
        {
            Helpers.Info("# Toevoegen van model");
            string naam = Helpers.TextInput("Naam");
        }

        // TODO:
        // - Context opendoen
        // - Kijken of er al een kleur bestaat met deze naam
        //   - Ja: error tonen
        //   - Nee: toevoegen en melding tonen
        private static void AddColor()
        {
            Helpers.Info("# Toevoegen van kleur");
            string naam = Helpers.TextInput("Naam");
        }

        // TODO:
        // - Context opendoen
        // - Kijken of er al een verkoper bestaat met deze naam
        //   - Ja: error tonen
        //   - Nee: toevoegen en melding tonen
        private static void AddSalesPerson()
        {
            Helpers.Info("# Toevoegen van verkoper");
            string naam = Helpers.TextInput("Naam");
        }
    }
}
