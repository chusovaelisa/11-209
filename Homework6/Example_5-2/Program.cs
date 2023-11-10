using Npgsql;
using System;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Username=postgres;Password=kbpf;Host=localhost;Port=5432;Database=AdoNet.Metanit";
        string sqlExpression = "INSERT INTO Clients (gender, full_name, age, contact_info, status, isAnonymous, isBlocked) " +
                               "VALUES ('Male', 'John Doe', 30, 'john@example.com', 'Gold', false, false)";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
            Console.WriteLine("Добавлено объектов: {0}", number);
        }

        Console.Read();
    }
}