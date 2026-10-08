using SingletonComputers.Library.Models;
using SingletonComputers.Library.Singletons;

namespace SingletonComputers.App
{
    public partial class MainForm : Form
    {
        private readonly DbManager _db;
        private readonly Logger _logger;
        private readonly DocumentSaver _documentSaver;

        public MainForm()
        {
            InitializeComponent();

            _db = DbManager.Instance;
            _logger = Logger.Instance;
            _documentSaver = DocumentSaver.Instance;

            _logger.Log(
                "Відкрито головну форму.");

            LoadComputers();
            ShowSingletonInformation();
        }

        private void ShowSingletonInformation()
        {
            lblSingletonInfo.Text =
                $"DbManager: {_db.InstanceId}\n" +
                $"DocumentSaver: {_documentSaver.InstanceId}\n" +
                $"Logger: {_logger.InstanceId}";
        }

        private void LoadComputers()
        {
            List<Computer> computers =
                _db.GetComputers();

            dgvComputers.DataSource = null;
            dgvComputers.DataSource = computers;

            if (dgvComputers.Columns["Id"] != null)
                dgvComputers.Columns["Id"].HeaderText = "ID";

            if (dgvComputers.Columns["ComputerName"] != null)
                dgvComputers.Columns["ComputerName"].HeaderText =
                    "Комп'ютер";

            if (dgvComputers.Columns["IpAddress"] != null)
                dgvComputers.Columns["IpAddress"].HeaderText =
                    "IP-адреса";

            if (dgvComputers.Columns["OperatingSystem"] != null)
                dgvComputers.Columns["OperatingSystem"].HeaderText =
                    "Операційна система";

            if (dgvComputers.Columns["InstalledSoftware"] != null)
                dgvComputers.Columns["InstalledSoftware"].HeaderText =
                    "Програмне забезпечення";

            if (dgvComputers.Columns["Notes"] != null)
                dgvComputers.Columns["Notes"].HeaderText =
                    "Примітки";

            lblCount.Text =
                $"Комп'ютерів у базі: {computers.Count}";
        }

        private int? GetSelectedComputerId()
        {
            if (dgvComputers.CurrentRow == null)
                return null;

            object? value =
                dgvComputers.CurrentRow.Cells["Id"].Value;

            if (value == null)
                return null;

            return Convert.ToInt32(value);
        }

        private void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            _logger.Log(
                "Користувач натиснув кнопку додавання комп'ютера.");

            using ComputerForm form =
                new();

            if (form.ShowDialog() ==
                DialogResult.OK)
            {
                LoadComputers();
            }
        }

        private void btnEdit_Click(
            object sender,
            EventArgs e)
        {
            int? id =
                GetSelectedComputerId();

            if (id == null)
            {
                MessageBox.Show(
                    "Оберіть комп'ютер у таблиці.",
                    "Редагування",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            _logger.Log(
                $"Відкрито редагування комп'ютера ID={id}.");

            using ComputerForm form =
                new(id.Value);

            if (form.ShowDialog() ==
                DialogResult.OK)
            {
                LoadComputers();
            }
        }

        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            int? id =
                GetSelectedComputerId();

            if (id == null)
            {
                MessageBox.Show(
                    "Оберіть комп'ютер у таблиці.",
                    "Видалення",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Видалити вибраний комп'ютер?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            _db.DeleteComputer(
                id.Value);

            LoadComputers();
        }

        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            _logger.Log(
                "Оновлено список комп'ютерів.");

            LoadComputers();
        }

        private void btnSaveReport_Click(
            object sender,
            EventArgs e)
        {
            using SaveFileDialog dialog =
                new()
                {
                    Filter =
                        "Текстовий документ (*.txt)|*.txt",

                    FileName =
                        $"Computers_{DateTime.Now:yyyy-MM-dd}.txt"
                };

            if (dialog.ShowDialog() !=
                DialogResult.OK)
            {
                return;
            }

            _documentSaver.SaveComputerReport(
                _db.GetComputers(),
                dialog.FileName);

            MessageBox.Show(
                "Документ успішно збережено.",
                "DocumentSaver",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnExportCsv_Click(
            object sender,
            EventArgs e)
        {
            using SaveFileDialog dialog =
                new()
                {
                    Filter =
                        "CSV файл (*.csv)|*.csv",

                    FileName =
                        $"Computers_{DateTime.Now:yyyy-MM-dd}.csv"
                };

            if (dialog.ShowDialog() !=
                DialogResult.OK)
            {
                return;
            }

            _documentSaver.SaveCsv(
                _db.GetComputers(),
                dialog.FileName);

            MessageBox.Show(
                "CSV успішно збережено.",
                "DocumentSaver",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnLogs_Click(
            object sender,
            EventArgs e)
        {
            _logger.Log(
                "Відкрито журнал дій.");

            using LogsForm form =
                new();

            form.ShowDialog();
        }

        private void MainForm_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            _logger.Log(
                "Закрито головну форму.");
        }
    }
}