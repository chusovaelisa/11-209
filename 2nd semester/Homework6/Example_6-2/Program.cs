using System;
using Npgsql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Username=postgres;Password=kbpf;Host=localhost;Port=5432;Database=AdoNet.Metanit";

        string sqlExpression = "SELECT * FROM Users";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                while (reader.Read()) // построчно считываем данные
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object age = reader.GetValue(2);

                    Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
                }
            }

            reader.Close();
        }

        Console.Read();
    }
}