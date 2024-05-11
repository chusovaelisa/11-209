using System;
using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Username=postgres;Password=kbpf;Host=localhost;Port=5432;Database=AdoNet.Metanit";

        int age = 23;
        string name = "T',10);INSERT INTO Users (Name, Age) VALUES('H";
        string sqlExpression = "INSERT INTO Users (Name, Age) VALUES (@name, @age)";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection))
            {
                NpgsqlParameter nameParam = new NpgsqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                NpgsqlParameter ageParam = new NpgsqlParameter("@age", age);
                command.Parameters.Add(ageParam);

                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number); // 1
            }
        }
    }
}