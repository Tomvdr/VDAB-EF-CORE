using _00_Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace _02_Insert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Applicatie wordt opgestart...");

            OpenConnection(ConnectionString.Boekendatabase);
        }

        public static void OpenConnection(string connectionString)
        {
            const string Naam = "J.K. Rowling";
            
            // Aanmaken van nieuwe SqlConnection
            // Via de Using wordt er automatisch `connection.Dispose()` uitgevoerd op het einde
            // SqlConnection implementeert de IDisposable interface
            using (var connection = new SqlConnection(connectionString))
            {
                // Open de connectie
                connection.Open();

                /*// We maken een commando object richting de database
                SqlCommand command = connection.CreateCommand();

                // We geven deze een CommandText, nl. onze query
                command.CommandText = "INSERT INTO Auteur (Naam) VALUES (@Naam)";

                // Maak een nieuwe parameter: voor onze 'naam' mee te geven
                var parameter = new SqlParameter("@Naam", SqlDbType.NVarChar);
                parameter.Value = Naam;

                // Voeg onze parameter toe aan het commando
                command.Parameters.Add(parameter);

                // We voeren een query uit die geen resultaat gaat teruggeven -- het is namelijk een INSERT en geen SELECT.
                // Bijgevolg moeten we ook niet over de data lussen, want die is er niet
                // Het enigste dat we moeten doen om dit commando te lanceren is het volgende
                Console.WriteLine("Aantal rijen aangepast: {0}", command.ExecuteNonQuery());

                */

                SqlCommand command2 = connection.CreateCommand();
                command2.CommandText = "INSERT INTO Uitgeverij (Naam) VALUES (@test)";

                SqlParameter parameter2 = new SqlParameter("@test", SqlDbType.NVarChar);
                parameter2.Value = "BERND";

                command2.Parameters.Add(parameter2); 

                Console.WriteLine(command2.ExecuteNonQuery());


            }
        }
    }
}
