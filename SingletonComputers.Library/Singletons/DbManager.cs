using Microsoft.Data.Sqlite;
using SingletonComputers.Library.Models;
using System.IO;

namespace SingletonComputers.Library.Singletons
{
    public sealed class DbManager
    {
        private static readonly Lazy<DbManager> _instance =
            new(() => new DbManager());

        public static DbManager Instance => _instance.Value;

        private readonly string _databasePath;
        private readonly string _connectionString;

        public Guid InstanceId { get; }

        private DbManager()
        {
            InstanceId = Guid.NewGuid();

            string folder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "SingletonComputers");

            Directory.CreateDirectory(folder);

            _databasePath =
                Path.Combine(folder, "computers.db");

            _connectionString =
                $"Data Source={_databasePath}";

            InitializeDatabase();

            Logger.Instance.Log(
                "Створено єдиний екземпляр DbManager.");
        }

        private void InitializeDatabase()
        {
            using SqliteConnection connection =
                new(_connectionString);

            connection.Open();

            string sql = """
                CREATE TABLE IF NOT EXISTS Computers
                (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ComputerName TEXT NOT NULL,
                    IpAddress TEXT NOT NULL,
                    OperatingSystem TEXT NOT NULL,
                    InstalledSoftware TEXT,
                    Notes TEXT
                );
                """;

            using SqliteCommand command =
                new(sql, connection);

            command.ExecuteNonQuery();
        }

        public List<Computer> GetComputers()
        {
            List<Computer> computers = new();

            using SqliteConnection connection =
                new(_connectionString);

            connection.Open();

            const string sql = """
                SELECT
                    Id,
                    ComputerName,
                    IpAddress,
                    OperatingSystem,
                    InstalledSoftware,
                    Notes
                FROM Computers
                ORDER BY Id DESC;
                """;

            using SqliteCommand command =
                new(sql, connection);

            using SqliteDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                computers.Add(new Computer
                {
                    Id = reader.GetInt32(0),
                    ComputerName = reader.GetString(1),
                    IpAddress = reader.GetString(2),
                    OperatingSystem = reader.GetString(3),

                    InstalledSoftware =
                        reader.IsDBNull(4)
                            ? ""
                            : reader.GetString(4),

                    Notes =
                        reader.IsDBNull(5)
                            ? ""
                            : reader.GetString(5)
                });
            }

            return computers;
        }

        public Computer? GetComputer(int id)
        {
            using SqliteConnection connection =
                new(_connectionString);

            connection.Open();

            const string sql = """
                SELECT
                    Id,
                    ComputerName,
                    IpAddress,
                    OperatingSystem,
                    InstalledSoftware,
                    Notes
                FROM Computers
                WHERE Id = @id;
                """;

            using SqliteCommand command =
                new(sql, connection);

            command.Parameters.AddWithValue(
                "@id",
                id);

            using SqliteDataReader reader =
                command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new Computer
            {
                Id = reader.GetInt32(0),
                ComputerName = reader.GetString(1),
                IpAddress = reader.GetString(2),
                OperatingSystem = reader.GetString(3),

                InstalledSoftware =
                    reader.IsDBNull(4)
                        ? ""
                        : reader.GetString(4),

                Notes =
                    reader.IsDBNull(5)
                        ? ""
                        : reader.GetString(5)
            };
        }

        public void AddComputer(Computer computer)
        {
            using SqliteConnection connection =
                new(_connectionString);

            connection.Open();

            const string sql = """
                INSERT INTO Computers
                (
                    ComputerName,
                    IpAddress,
                    OperatingSystem,
                    InstalledSoftware,
                    Notes
                )
                VALUES
                (
                    @name,
                    @ip,
                    @os,
                    @software,
                    @notes
                );
                """;

            using SqliteCommand command =
                new(sql, connection);

            command.Parameters.AddWithValue(
                "@name",
                computer.ComputerName);

            command.Parameters.AddWithValue(
                "@ip",
                computer.IpAddress);

            command.Parameters.AddWithValue(
                "@os",
                computer.OperatingSystem);

            command.Parameters.AddWithValue(
                "@software",
                computer.InstalledSoftware);

            command.Parameters.AddWithValue(
                "@notes",
                computer.Notes);

            command.ExecuteNonQuery();

            Logger.Instance.Log(
                $"Додано комп'ютер: {computer.ComputerName}, IP: {computer.IpAddress}.");
        }

        public void UpdateComputer(Computer computer)
        {
            using SqliteConnection connection =
                new(_connectionString);

            connection.Open();

            const string sql = """
                UPDATE Computers
                SET
                    ComputerName = @name,
                    IpAddress = @ip,
                    OperatingSystem = @os,
                    InstalledSoftware = @software,
                    Notes = @notes
                WHERE Id = @id;
                """;

            using SqliteCommand command =
                new(sql, connection);

            command.Parameters.AddWithValue(
                "@name",
                computer.ComputerName);

            command.Parameters.AddWithValue(
                "@ip",
                computer.IpAddress);

            command.Parameters.AddWithValue(
                "@os",
                computer.OperatingSystem);

            command.Parameters.AddWithValue(
                "@software",
                computer.InstalledSoftware);

            command.Parameters.AddWithValue(
                "@notes",
                computer.Notes);

            command.Parameters.AddWithValue(
                "@id",
                computer.Id);

            command.ExecuteNonQuery();

            Logger.Instance.Log(
                $"Змінено інформацію про комп'ютер ID={computer.Id}.");
        }

        public void DeleteComputer(int id)
        {
            Computer? computer = GetComputer(id);

            using SqliteConnection connection =
                new(_connectionString);

            connection.Open();

            const string sql =
                "DELETE FROM Computers WHERE Id = @id;";

            using SqliteCommand command =
                new(sql, connection);

            command.Parameters.AddWithValue(
                "@id",
                id);

            command.ExecuteNonQuery();

            Logger.Instance.Log(
                $"Видалено комп'ютер ID={id}" +
                $"{(computer != null ? $" ({computer.ComputerName})" : "")}.");
        }

        public string GetDatabasePath()
        {
            return _databasePath;
        }
    }
}