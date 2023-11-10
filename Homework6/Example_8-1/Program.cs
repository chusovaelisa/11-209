using System;
using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Username=postgres;Password=kbpf;Host=localhost;Port=5432;Database=AdoNet.Metanit";

        string sqlExpressionCount = "SELECT COUNT(*) FROM Users";
        string sqlExpressionMinAge = "SELECT MIN(Age) FROM Users";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            // Запрос для получения количества записей
            using (NpgsqlCommand countCommand = new NpgsqlCommand(sqlExpressionCount, connection))
            {
                object count = countCommand.ExecuteScalar();
                Console.WriteLine("В таблице {0} объектов", count);
            }

            // Запрос для получения минимального возраста
            using (NpgsqlCommand minAgeCommand = new NpgsqlCommand(sqlExpressionMinAge, connection))
            {
                object minAge = minAgeCommand.ExecuteScalar();
                Console.WriteLine("Минимальный возраст: {0}", minAge);
            }
        }
    }
}