using System;

namespace _00_Configuration
{
    public static class ConnectionString
    {
        // Boekendatabase files zitten mee in deze repository
        public static string Boekendatabase = "Data Source=.\\SQLEXPRESS01;Initial Catalog=Boekendatabase;Integrated Security=True;Trusted_Connection=True";
        // AdventureWorks is een sample database van Microsoft
        // https://docs.microsoft.com/en-us/sql/samples/adventureworks-install-configure?view=sql-server-ver15&tabs=ssms
        public static string AdventureWorks = "Data Source=.\\SQLEXPRESS01;Initial Catalog=AdventureWorks;Integrated Security=True;Trusted_Connection=True";
    }
}
