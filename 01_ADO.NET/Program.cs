using _00_Configuration;
using System;
using System.Data.SqlClient;

namespace _01_ADO.NET
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
            // Aanmaken van nieuwe SqlConnection
            // Via de Using wordt er automatisch `connection.Dispose()` uitgevoerd op het einde
            // want SqlConnection implementeert de IDisposable interface
            using (var connection = new SqlConnection(connectionString))
            {
                // Open de connectie
                connection.Open();

                // We maken een commando object richting de database
                SqlCommand command = connection.CreateCommand();

                // We geven deze een CommandText, nl. onze query
                command.CommandText = "SELECT Id, Naam FROM Auteur";

                // Commando uitvoeren. Ook deze implementeert de IDisposable interface, 
                // dus ofwel roepen we Dispose() op, ofwel gebruiken we using
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // reader.Read() blijft 'true' geven zolang er nog rijen beschikbaar zijn om te raadplegen
                    // indien geen rijen meer beschikbaar, wordt het resultaat 'false' en stopt onze while-loop
                    while(reader.Read())
                    {
                        Console.WriteLine("ID: {0}, Naam {1}", reader["Id"], reader["Naam"]);
                    }
                }
            }
        }
    }
}
