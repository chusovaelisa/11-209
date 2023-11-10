using System;
using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Username=postgres;Password=kbpf;Host=localhost;Port=5432;Database=AdoNet.Metanit";

        int age = 23;
        string name = "Kenny";
        string sqlExpression = "INSERT INTO Users (Name, Age) VALUES (@name, @age) RETURNING ID";

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection))
            {
                // создаем параметр для имени
                NpgsqlParameter nameParam = new NpgsqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                NpgsqlParameter ageParam = new NpgsqlParameter("@age", age);
                command.Parameters.Add(ageParam);

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    int newUserId = Convert.ToInt32(result);
                    Console.WriteLine("Id нового объекта: {0}", newUserId);
                }
            }
        }
    }
}