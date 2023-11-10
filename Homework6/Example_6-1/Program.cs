using System;
using System.Threading.Tasks;
using Npgsql;

class Program
{
    static async Task Main(string[] args)
    {
        await ReadDataAsync();

        Console.Read();
    }

    private static async Task ReadDataAsync()
    {
        string connectionString = "Username=postgres;Password=kbpf;Host=localhost;Port=5432;Database=AdoNet.Metanit";

        string sqlExpression = "SELECT * FROM Users";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            await connection.OpenAsync();
            NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
            NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                // выводим названия столбцов
                Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                while (await reader.ReadAsync())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object age = reader.GetValue(2);
                    Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
                }
            }
            reader.Close();
        }
    }
}