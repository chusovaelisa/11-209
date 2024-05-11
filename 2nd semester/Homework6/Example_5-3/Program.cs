using Npgsql;
using System;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Username=postgres;Password=kbpf;Host=localhost;Port=5432;Database=AdoNet.Metanit";
 
        Console.WriteLine("Введите имя:");
        string name = Console.ReadLine();
 
        Console.WriteLine("Введите возраст:");
        int age = Int32.Parse(Console.ReadLine());
 
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            string insertSql =
                $"INSERT INTO Clients (gender, full_name, age, contact_info, status, isAnonymous, isBlocked) " +
                $"VALUES ('Male', '{name}', {age}, 'example@example.com', 'Gold', false, false)";
            NpgsqlCommand insertCommand = new NpgsqlCommand(insertSql, connection);
            int insertCount = insertCommand.ExecuteNonQuery();
            Console.WriteLine($"Добавлено объектов: {insertCount}");
 
            Console.WriteLine("Введите новое имя:");
            name = Console.ReadLine();
            string updateSql = $"UPDATE Clients SET full_name = '{name}' WHERE age = {age}";
            NpgsqlCommand updateCommand = new NpgsqlCommand(updateSql, connection);
            int updateCount = updateCommand.ExecuteNonQuery();
            Console.WriteLine($"Обновлено объектов: {updateCount}");
        }       
        Console.Read();
    }
}