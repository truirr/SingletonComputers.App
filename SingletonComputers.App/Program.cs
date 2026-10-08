using SingletonComputers.Library.Singletons;

namespace SingletonComputers.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Logger.Instance.Log(
                "Запуск програми.");

            Application.Run(
                new MainForm());

            Logger.Instance.Log(
                "Завершення роботи програми.");
        }
    }
}