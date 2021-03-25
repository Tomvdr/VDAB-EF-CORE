using System;
    
namespace _07_EFCore_SunshineAutos
{

    // Oefeningen
    // - Vereiste: alle slides doorlopen voor de opbouw
    // - Klantbeheer
    //      - Klant opzoeken via naam
    //      - Klant toevoegen
    //      - Lijst klanten die één of meerdere wagens heeft gekocht + toon aantal wagens (UITBREIDING)
    // - Hulptabellen
    //      - Toevoegen van merk
    //      - Toevoegen van model aan merk
    //      - Toevoegen van kleur
    //      - Toevoegen van verkoper
    // - Wagenbeheer
    //      - Wagen toevoegen (invoervalidatie, chassisnummer 17 karakters, merk, model & kleur zijn verplicht ...)
    // - Verkoopregistratie
    //      - Factuur opmaken (een wagen kan maar één keer verkocht worden!)
    // - Statistieken
    //      - Voeg een menu item toe waarin ik kan zien hoeveel wagens er per jaar verkocht worden (gebruik database om datums aan te passen)
    class Program
    {
        static void Main(string[] args)
        {
            ListMenuItems();
        }
        private static void ListMenuItems()
        {
            Console.WriteLine("1. Klantbeheer");
            Console.WriteLine("2. Hulptabellen");
            Console.WriteLine("3. Wagenbeheer");
            Console.WriteLine("4. Verkoopregistratie");

            int keuze = Helpers.NumericInput("Keuze");
            switch(keuze)
            {
                case 1:
                    CustomerManagement.ListItems();
                    break;
                case 2:
                    TableManagement.ListItems();
                    break;
                case 3:
                    CarManagement.ListItems();
                    break;
                case 4:
                    SalesRegistration.ListItems();
                    break;
            }
            ListMenuItems();
        }

      
    }
}
