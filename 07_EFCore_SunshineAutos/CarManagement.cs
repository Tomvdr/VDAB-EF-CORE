using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos
{
    public static class CarManagement
    {
        public static void ListItems()
        {
            Console.WriteLine("0. Annuleren");
            Console.WriteLine("1. Wagen toevoegen");
            
            int keuze = Helpers.NumericInput("Keuze");
            switch (keuze)
            {
                case 1:
                    AddCar();
                    break;
            }
        }


        // TODO:
        // - Context opendoen
        // - Toevoegen van wagen
        // - Chassisnummer is uniek. Dwz als er al een wagen bestaat met deze chassisnummer: error
        // - Toewijzen van kleur & model
        private static void AddCar()
        {
            Helpers.Info("# Wagen toevoegen");
            string chassisnummer = Helpers.TextInput("Chassisnummer");
        }
    }
}
