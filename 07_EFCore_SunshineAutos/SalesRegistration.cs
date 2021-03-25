using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos
{
    public static class SalesRegistration
    {
        public static void ListItems()
        {
            Console.WriteLine("0. Annuleren");
            Console.WriteLine("1. Factuur opmaken");

            int keuze = Helpers.NumericInput("Keuze");
            switch (keuze)
            {
                case 1:
                    CreateInvoice();
                    break;
            }
        }


        // TODO:
        // - Context opendoen
        // - Opzoeken van wagen adhv chassisnummer
        //      - Error indien deze niet bestaat
        // - Wagen kan maar één keer verkocht worden
        // - Klant & verkoper koppelen aan factuur (ook opvragen)
        // - Datum ook invullen (automatisch op vandaag instellen) via DateTime.Now
        private static void CreateInvoice()
        {
            Helpers.Info("# Factuur opmaken");
            string chassisnummer = Helpers.TextInput("Chassisnummer");
        }
    }
}
