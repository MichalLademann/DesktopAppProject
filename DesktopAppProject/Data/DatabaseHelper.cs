using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using TaskManagerDesktop.Models;
using Task = TaskManagerDesktop.Models.Task;

namespace TaskManagerDesktop.Data
{
    public static class DatabaseHelper
    {
        private static string connectionString = GetConnectionString();

        private static string GetConnectionString()
        {
            // Prefer environment variables if present
            var host = Environment.GetEnvironmentVariable("PGHOST") ?? "ep-solitary-cell-agkblgtu-pooler.c-2.eu-central-1.aws.neon.tech";
            var db = Environment.GetEnvironmentVariable("PGDATABASE") ?? "neondb";
            var user = Environment.GetEnvironmentVariable("PGUSER") ?? "neondb_owner";
            var pass = Environment.GetEnvironmentVariable("PGPASSWORD") ?? "npg_8kBR5whUmWGi";
            var ssl = Environment.GetEnvironmentVariable("PGSSLMODE") ?? "Require";
            var channel = Environment.GetEnvironmentVariable("PGCHANNELBINDING") ?? "Require";

            // Npgsql connection string
            return $"Host={host};Database={db};Username={user};Password={pass};SSL Mode={ssl};Trust Server Certificate=true;";
        }

        public static void InitializeDatabase()
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Tasks (
                    Id SERIAL PRIMARY KEY,
                    Tytul TEXT,
                    Kategoria TEXT,
                    Priorytet TEXT,
                    Ukoñczone BOOLEAN,
                    Termin TIMESTAMP
                );";
            cmd.ExecuteNonQuery();
        }

        public static List<Task> PobierzZadania()
        {
            var lista = new List<Task>();
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT Id, Tytul, Kategoria, Priorytet, Ukoñczone, Termin FROM Tasks ORDER BY Termin ASC", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Task
                {
                    Id = reader.GetInt32(0),
                    Tytul = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                    Kategoria = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                    Priorytet = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                    Ukoñczone = !reader.IsDBNull(4) && reader.GetBoolean(4),
                    Termin = reader.IsDBNull(5) ? DateTime.Now : reader.GetDateTime(5)
                });
            }
            return lista;
        }

        public static void DodajZadanie(Task task)
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand("INSERT INTO Tasks (Tytul, Kategoria, Priorytet, Ukoñczone, Termin) VALUES (@t, @k, @p, @u, @d)", conn);
            cmd.Parameters.AddWithValue("@t", task.Tytul ?? string.Empty);
            cmd.Parameters.AddWithValue("@k", task.Kategoria ?? string.Empty);
            cmd.Parameters.AddWithValue("@p", task.Priorytet ?? string.Empty);
            cmd.Parameters.AddWithValue("@u", task.Ukoñczone);
            cmd.Parameters.AddWithValue("@d", task.Termin);
            cmd.ExecuteNonQuery();
        }

        public static void AktualizujZadanie(Task task)
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand("UPDATE Tasks SET Tytul=@t, Kategoria=@k, Priorytet=@p, Ukoñczone=@u, Termin=@d WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@t", task.Tytul ?? string.Empty);
            cmd.Parameters.AddWithValue("@k", task.Kategoria ?? string.Empty);
            cmd.Parameters.AddWithValue("@p", task.Priorytet ?? string.Empty);
            cmd.Parameters.AddWithValue("@u", task.Ukoñczone);
            cmd.Parameters.AddWithValue("@d", task.Termin);
            cmd.Parameters.AddWithValue("@id", task.Id);
            cmd.ExecuteNonQuery();
        }

        public static void UsunZadanie(int id)
        {
            using var conn = new NpgsqlConnection(connectionString);
            conn.Open();
            using var cmd = new NpgsqlCommand("DELETE FROM Tasks WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
