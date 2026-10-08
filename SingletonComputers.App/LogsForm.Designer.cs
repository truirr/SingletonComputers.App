namespace SingletonComputers.App
{
    partial class LogsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblInstance;
        private Label lblPath;

        private TextBox txtLogs;

        private Button btnRefresh;
        private Button btnClear;
        private Button btnClose;

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
            lblTitle =
                new Label();

            lblInstance =
                new Label();

            lblPath =
                new Label();

            txtLogs =
                new TextBox();

            btnRefresh =
                new Button();

            btnClear =
                new Button();

            btnClose =
                new Button();

            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize =
                true;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    18F,
                    FontStyle.Bold);

            lblTitle.Location =
                new Point(25, 20);

            lblTitle.Text =
                "Журнал операцій";

            // lblInstance
            lblInstance.AutoSize =
                true;

            lblInstance.Font =
                new Font(
                    "Consolas",
                    9F);

            lblInstance.Location =
                new Point(28, 68);

            lblInstance.Text =
                "Logger Instance:";

            // lblPath
            lblPath.AutoSize =
                true;

            lblPath.Font =
                new Font(
                    "Segoe UI",
                    8F);

            lblPath.ForeColor =
                Color.DimGray;

            lblPath.Location =
                new Point(28, 93);

            lblPath.Text =
                "Файл:";

            // txtLogs
            txtLogs.Font =
                new Font(
                    "Consolas",
                    9F);

            txtLogs.Location =
                new Point(28, 125);

            txtLogs.Multiline =
                true;

            txtLogs.ReadOnly =
                true;

            txtLogs.ScrollBars =
                ScrollBars.Both;

            txtLogs.Size =
                new Size(820, 425);

            txtLogs.WordWrap =
                false;

            // btnRefresh
            btnRefresh.Location =
                new Point(480, 570);

            btnRefresh.Size =
                new Size(110, 38);

            btnRefresh.Text =
                "Оновити";

            btnRefresh.Click +=
                btnRefresh_Click;

            // btnClear
            btnClear.Location =
                new Point(600, 570);

            btnClear.Size =
                new Size(110, 38);

            btnClear.Text =
                "Очистити";

            btnClear.Click +=
                btnClear_Click;

            // btnClose
            btnClose.Location =
                new Point(720, 570);

            btnClose.Size =
                new Size(128, 38);

            btnClose.Text =
                "Закрити";

            btnClose.Click +=
                btnClose_Click;

            // LogsForm
            AutoScaleDimensions =
                new SizeF(8F, 20F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(880, 635);

            Controls.Add(lblTitle);
            Controls.Add(lblInstance);
            Controls.Add(lblPath);

            Controls.Add(txtLogs);

            Controls.Add(btnRefresh);
            Controls.Add(btnClear);
            Controls.Add(btnClose);

            Font =
                new Font(
                    "Segoe UI",
                    9F);

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "Журнал операцій";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}