using SingletonComputers.Library.Models;
using SingletonComputers.Library.Singletons;

namespace SingletonComputers.App
{
    public partial class ComputerForm : Form
    {
        private readonly DbManager _db;
        private readonly Logger _logger;

        private readonly int? _computerId;

        public ComputerForm(
            int? computerId = null)
        {
            InitializeComponent();

            _db = DbManager.Instance;
            _logger = Logger.Instance;

            _computerId =
                computerId;

            lblSingleton.Text =
                $"DbManager Instance: {_db.InstanceId}";

            _logger.Log(
                computerId == null
                    ? "Відкрито форму додавання комп'ютера."
                    : $"Відкрито форму редагування комп'ютера ID={computerId}.");

            if (computerId != null)
            {
                Text =
                    "Редагування комп'ютера";

                lblTitle.Text =
                    "Редагування комп'ютера";

                LoadComputer(
                    computerId.Value);
            }
        }

        private void LoadComputer(
            int id)
        {
            Computer? computer =
                _db.GetComputer(id);

            if (computer == null)
            {
                MessageBox.Show(
                    "Комп'ютер не знайдено.");

                Close();

                return;
            }

            txtComputerName.Text =
                computer.ComputerName;

            txtIpAddress.Text =
                computer.IpAddress;

            txtOperatingSystem.Text =
                computer.OperatingSystem;

            txtSoftware.Text =
                computer.InstalledSoftware;

            txtNotes.Text =
                computer.Notes;
        }

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtComputerName.Text))
            {
                MessageBox.Show(
                    "Введіть назву комп'ютера.");

                txtComputerName.Focus();

                return;
            }

            if (string.IsNullOrWhiteSpace(
                txtIpAddress.Text))
            {
                MessageBox.Show(
                    "Введіть IP-адресу.");

                txtIpAddress.Focus();

                return;
            }

            if (string.IsNullOrWhiteSpace(
                txtOperatingSystem.Text))
            {
                MessageBox.Show(
                    "Введіть операційну систему.");

                txtOperatingSystem.Focus();

                return;
            }

            Computer computer =
                new()
                {
                    Id =
                        _computerId ?? 0,

                    ComputerName =
                        txtComputerName.Text.Trim(),

                    IpAddress =
                        txtIpAddress.Text.Trim(),

                    OperatingSystem =
                        txtOperatingSystem.Text.Trim(),

                    InstalledSoftware =
                        txtSoftware.Text.Trim(),

                    Notes =
                        txtNotes.Text.Trim()
                };

            if (_computerId == null)
            {
                _db.AddComputer(
                    computer);
            }
            else
            {
                _db.UpdateComputer(
                    computer);
            }

            DialogResult =
                DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            _logger.Log(
                "Користувач скасував редагування.");

            DialogResult =
                DialogResult.Cancel;

            Close();
        }
    }
}