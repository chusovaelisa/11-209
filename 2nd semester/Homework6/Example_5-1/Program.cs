using Npgsql;
using System;

class Program
{
    public static void Main()
    {
        string connectionString = "Username=postgres;Password=kbpf;Host=localhost;Port=5432;Database=AdoNet.Metanit";
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandText = "SELECT * FROM Clients";
            command.Connection = connection;

            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string gender = reader.GetString(1);
                string fullName = reader.GetString(2);
                int age = reader.GetInt32(3);
                string contactInfo = reader.GetString(4);
                string status = reader.GetString(5);
                bool isAnonymous = reader.GetBoolean(6);
                bool isBlocked = reader.GetBoolean(7);

                Console.WriteLine($"ID: {id}, Gender: {gender}, Full Name: {fullName}, Age: {age}, Contact Info: {contactInfo}, Status: {status}, Is Anonymous: {isAnonymous}, Is Blocked: {isBlocked}");
            }

            reader.Close();
        }
    }
}