using System.IO;
using System.Text;

namespace SingletonComputers.Library.Singletons
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> _instance =
            new(() => new Logger());

        public static Logger Instance => _instance.Value;

        private readonly object _lock = new();

        private readonly string _logFilePath;

        public Guid InstanceId { get; }

        private Logger()
        {
            InstanceId = Guid.NewGuid();

            string folder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "SingletonComputers");

            Directory.CreateDirectory(folder);

            _logFilePath = Path.Combine(folder, "application.log");

            Log("Створено єдиний екземпляр Logger.");
        }

        public void Log(string message)
        {
            lock (_lock)
            {
                string line =
                    $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] {message}";

                File.AppendAllText(
                    _logFilePath,
                    line + Environment.NewLine,
                    Encoding.UTF8);
            }
        }

        public string ReadAll()
        {
            lock (_lock)
            {
                if (!File.Exists(_logFilePath))
                    return "Журнал поки що порожній.";

                return File.ReadAllText(
                    _logFilePath,
                    Encoding.UTF8);
            }
        }

        public void Clear()
        {
            lock (_lock)
            {
                File.WriteAllText(
                    _logFilePath,
                    "",
                    Encoding.UTF8);
            }

            Log("Журнал очищено користувачем.");
        }

        public string GetLogFilePath()
        {
            return _logFilePath;
        }
    }
}