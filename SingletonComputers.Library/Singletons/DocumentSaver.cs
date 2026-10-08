using System.Text;
using SingletonComputers.Library.Models;

namespace SingletonComputers.Library.Singletons
{
    public sealed class DocumentSaver
    {
        private static readonly Lazy<DocumentSaver> _instance =
            new(() => new DocumentSaver());

        public static DocumentSaver Instance => _instance.Value;

        public Guid InstanceId { get; }

        private DocumentSaver()
        {
            InstanceId = Guid.NewGuid();

            Logger.Instance.Log(
                "Створено єдиний екземпляр DocumentSaver.");
        }

        public void SaveComputerReport(
            IEnumerable<Computer> computers,
            string filePath)
        {
            StringBuilder builder = new();

            builder.AppendLine(
                "БАЗА ДАНИХ КОМП'ЮТЕРІВ ЛОКАЛЬНОЇ МЕРЕЖІ");

            builder.AppendLine(
                $"Дата формування: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");

            builder.AppendLine(
                new string('=', 80));

            foreach (Computer computer in computers)
            {
                builder.AppendLine(
                    $"ID: {computer.Id}");

                builder.AppendLine(
                    $"Назва комп'ютера: {computer.ComputerName}");

                builder.AppendLine(
                    $"IP-адреса: {computer.IpAddress}");

                builder.AppendLine(
                    $"Операційна система: {computer.OperatingSystem}");

                builder.AppendLine(
                    $"Програмне забезпечення:");

                builder.AppendLine(
                    computer.InstalledSoftware);

                builder.AppendLine(
                    $"Примітки: {computer.Notes}");

                builder.AppendLine(
                    new string('-', 80));
            }

            File.WriteAllText(
                filePath,
                builder.ToString(),
                Encoding.UTF8);

            Logger.Instance.Log(
                $"Збережено документ: {filePath}");
        }

        public void SaveCsv(
            IEnumerable<Computer> computers,
            string filePath)
        {
            StringBuilder builder = new();

            builder.AppendLine(
                "Id;ComputerName;IpAddress;OperatingSystem;InstalledSoftware;Notes");

            foreach (Computer computer in computers)
            {
                builder.AppendLine(
                    $"{computer.Id};" +
                    $"{Escape(computer.ComputerName)};" +
                    $"{Escape(computer.IpAddress)};" +
                    $"{Escape(computer.OperatingSystem)};" +
                    $"{Escape(computer.InstalledSoftware)};" +
                    $"{Escape(computer.Notes)}");
            }

            File.WriteAllText(
                filePath,
                builder.ToString(),
                Encoding.UTF8);

            Logger.Instance.Log(
                $"Експортовано базу даних у CSV: {filePath}");
        }

        private static string Escape(string value)
        {
            return value
                .Replace(";", ",")
                .Replace("\r", " ")
                .Replace("\n", " ");
        }
    }
}