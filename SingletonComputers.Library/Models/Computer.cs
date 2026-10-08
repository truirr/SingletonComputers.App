namespace SingletonComputers.Library.Models
{
    public class Computer
    {
        public int Id { get; set; }

        public string ComputerName { get; set; } = "";

        public string IpAddress { get; set; } = "";

        public string OperatingSystem { get; set; } = "";

        public string InstalledSoftware { get; set; } = "";

        public string Notes { get; set; } = "";
    }
}