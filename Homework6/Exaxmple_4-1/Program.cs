using System;
using Npgsql;

class Program
{
    public static void Main()
    {
        string connectionString = "Username=postgres;Password=kbpf;Host=localhost;Port=5432;Database=AdoNet.Metanit";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string connectionId = Guid.NewGuid().ToString(); 
            Console.WriteLine("Connection ID: " + connectionId);
            
        }
    }
}