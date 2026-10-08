using SingletonComputers.Library.Singletons;

namespace SingletonComputers.App
{
    public partial class LogsForm : Form
    {
        private readonly Logger _logger;

        public LogsForm()
        {
            InitializeComponent();

            _logger =
                Logger.Instance;

            lblInstance.Text =
                $"Logger Instance: {_logger.InstanceId}";

            lblPath.Text =
                $"Файл: {_logger.GetLogFilePath()}";

            LoadLogs();
        }

        private void LoadLogs()
        {
            txtLogs.Text =
                _logger.ReadAll();

            txtLogs.SelectionStart =
                txtLogs.Text.Length;

            txtLogs.ScrollToCaret();
        }

        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            _logger.Log(
                "Оновлено відображення журналу.");

            LoadLogs();
        }

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Очистити журнал?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result !=
                DialogResult.Yes)
            {
                return;
            }

            _logger.Clear();

            LoadLogs();
        }

        private void btnClose_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}