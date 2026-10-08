namespace SingletonComputers.App
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;

        private Panel panelActions;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnSaveReport;
        private Button btnExportCsv;
        private Button btnLogs;

        private DataGridView dgvComputers;

        private Panel panelBottom;
        private Label lblCount;
        private Label lblSingletonTitle;
        private Label lblSingletonInfo;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();

            panelActions = new Panel();

            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnSaveReport = new Button();
            btnExportCsv = new Button();
            btnLogs = new Button();

            dgvComputers = new DataGridView();

            panelBottom = new Panel();
            lblCount = new Label();
            lblSingletonTitle = new Label();
            lblSingletonInfo = new Label();

            panelHeader.SuspendLayout();
            panelActions.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                dgvComputers).BeginInit();

            panelBottom.SuspendLayout();

            SuspendLayout();

            // panelHeader
            panelHeader.BackColor =
                Color.FromArgb(31, 36, 48);

            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);

            panelHeader.Dock =
                DockStyle.Top;

            panelHeader.Height =
                105;

            // lblTitle
            lblTitle.AutoSize = true;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    20F,
                    FontStyle.Bold);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.Location =
                new Point(24, 18);

            lblTitle.Text =
                "База комп'ютерів локальної мережі";

            // lblSubtitle
            lblSubtitle.AutoSize =
                true;

            lblSubtitle.Font =
                new Font(
                    "Segoe UI",
                    10F);

            lblSubtitle.ForeColor =
                Color.FromArgb(
                    180,
                    185,
                    195);

            lblSubtitle.Location =
                new Point(27, 65);

            lblSubtitle.Text =
                "Singleton: DbManager • DocumentSaver • Logger";

            // panelActions
            panelActions.BackColor =
                Color.FromArgb(
                    245,
                    246,
                    248);

            panelActions.Dock =
                DockStyle.Top;

            panelActions.Height =
                72;

            // btnAdd
            btnAdd.Location =
                new Point(20, 17);

            btnAdd.Size =
                new Size(120, 38);

            btnAdd.Text =
                "Додати";

            btnAdd.UseVisualStyleBackColor =
                true;

            btnAdd.Click +=
                btnAdd_Click;

            // btnEdit
            btnEdit.Location =
                new Point(148, 17);

            btnEdit.Size =
                new Size(120, 38);

            btnEdit.Text =
                "Редагувати";

            btnEdit.UseVisualStyleBackColor =
                true;

            btnEdit.Click +=
                btnEdit_Click;

            // btnDelete
            btnDelete.Location =
                new Point(276, 17);

            btnDelete.Size =
                new Size(120, 38);

            btnDelete.Text =
                "Видалити";

            btnDelete.UseVisualStyleBackColor =
                true;

            btnDelete.Click +=
                btnDelete_Click;

            // btnRefresh
            btnRefresh.Location =
                new Point(404, 17);

            btnRefresh.Size =
                new Size(110, 38);

            btnRefresh.Text =
                "Оновити";

            btnRefresh.UseVisualStyleBackColor =
                true;

            btnRefresh.Click +=
                btnRefresh_Click;

            // btnSaveReport
            btnSaveReport.Location =
                new Point(535, 17);

            btnSaveReport.Size =
                new Size(145, 38);

            btnSaveReport.Text =
                "Зберегти звіт";

            btnSaveReport.UseVisualStyleBackColor =
                true;

            btnSaveReport.Click +=
                btnSaveReport_Click;

            // btnExportCsv
            btnExportCsv.Location =
                new Point(688, 17);

            btnExportCsv.Size =
                new Size(120, 38);

            btnExportCsv.Text =
                "Експорт CSV";

            btnExportCsv.UseVisualStyleBackColor =
                true;

            btnExportCsv.Click +=
                btnExportCsv_Click;

            // btnLogs
            btnLogs.Location =
                new Point(816, 17);

            btnLogs.Size =
                new Size(120, 38);

            btnLogs.Text =
                "Журнал";

            btnLogs.UseVisualStyleBackColor =
                true;

            btnLogs.Click +=
                btnLogs_Click;

            panelActions.Controls.Add(btnAdd);
            panelActions.Controls.Add(btnEdit);
            panelActions.Controls.Add(btnDelete);
            panelActions.Controls.Add(btnRefresh);
            panelActions.Controls.Add(btnSaveReport);
            panelActions.Controls.Add(btnExportCsv);
            panelActions.Controls.Add(btnLogs);

            // dgvComputers
            dgvComputers.AllowUserToAddRows =
                false;

            dgvComputers.AllowUserToDeleteRows =
                false;

            dgvComputers.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvComputers.BackgroundColor =
                Color.White;

            dgvComputers.BorderStyle =
                BorderStyle.None;

            dgvComputers.ColumnHeadersHeight =
                38;

            dgvComputers.Dock =
                DockStyle.Fill;

            dgvComputers.Location =
                new Point(0, 177);

            dgvComputers.MultiSelect =
                false;

            dgvComputers.ReadOnly =
                true;

            dgvComputers.RowHeadersVisible =
                false;

            dgvComputers.RowTemplate.Height =
                36;

            dgvComputers.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // panelBottom
            panelBottom.BackColor =
                Color.FromArgb(
                    245,
                    246,
                    248);

            panelBottom.Dock =
                DockStyle.Bottom;

            panelBottom.Height =
                105;

            // lblCount
            lblCount.AutoSize =
                true;

            lblCount.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            lblCount.Location =
                new Point(20, 20);

            lblCount.Text =
                "Комп'ютерів у базі: 0";

            // lblSingletonTitle
            lblSingletonTitle.AutoSize =
                true;

            lblSingletonTitle.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblSingletonTitle.Location =
                new Point(350, 12);

            lblSingletonTitle.Text =
                "Ідентифікатори Singleton-об'єктів:";

            // lblSingletonInfo
            lblSingletonInfo.AutoSize =
                true;

            lblSingletonInfo.Font =
                new Font(
                    "Consolas",
                    8.5F);

            lblSingletonInfo.Location =
                new Point(350, 35);

            lblSingletonInfo.Text =
                "Singleton information";

            panelBottom.Controls.Add(
                lblCount);

            panelBottom.Controls.Add(
                lblSingletonTitle);

            panelBottom.Controls.Add(
                lblSingletonInfo);

            // MainForm
            AutoScaleDimensions =
                new SizeF(8F, 20F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.White;

            ClientSize =
                new Size(1100, 700);

            Controls.Add(dgvComputers);
            Controls.Add(panelBottom);
            Controls.Add(panelActions);
            Controls.Add(panelHeader);

            Font =
                new Font(
                    "Segoe UI",
                    9F);

            MinimumSize =
                new Size(950, 600);

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "База комп'ютерів локальної мережі";

            FormClosing +=
                MainForm_FormClosing;

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();

            panelActions.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                dgvComputers).EndInit();

            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();

            ResumeLayout(false);
        }
    }
}