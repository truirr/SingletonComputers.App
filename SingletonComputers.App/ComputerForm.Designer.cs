namespace SingletonComputers.App
{
    partial class ComputerForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;

        private Label lblComputerName;
        private Label lblIpAddress;
        private Label lblOperatingSystem;
        private Label lblSoftware;
        private Label lblNotes;

        private TextBox txtComputerName;
        private TextBox txtIpAddress;
        private TextBox txtOperatingSystem;
        private TextBox txtSoftware;
        private TextBox txtNotes;

        private Button btnSave;
        private Button btnCancel;

        private Label lblSingleton;

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
            lblTitle = new Label();

            lblComputerName = new Label();
            lblIpAddress = new Label();
            lblOperatingSystem = new Label();
            lblSoftware = new Label();
            lblNotes = new Label();

            txtComputerName = new TextBox();
            txtIpAddress = new TextBox();
            txtOperatingSystem = new TextBox();
            txtSoftware = new TextBox();
            txtNotes = new TextBox();

            btnSave = new Button();
            btnCancel = new Button();

            lblSingleton = new Label();

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
                new Point(28, 22);

            lblTitle.Text =
                "Новий комп'ютер";

            // lblComputerName
            lblComputerName.AutoSize =
                true;

            lblComputerName.Location =
                new Point(30, 86);

            lblComputerName.Text =
                "Назва комп'ютера";

            // txtComputerName
            txtComputerName.Location =
                new Point(30, 110);

            txtComputerName.Size =
                new Size(470, 27);

            // lblIpAddress
            lblIpAddress.AutoSize =
                true;

            lblIpAddress.Location =
                new Point(30, 155);

            lblIpAddress.Text =
                "IP-адреса";

            // txtIpAddress
            txtIpAddress.Location =
                new Point(30, 179);

            txtIpAddress.Size =
                new Size(470, 27);

            // lblOperatingSystem
            lblOperatingSystem.AutoSize =
                true;

            lblOperatingSystem.Location =
                new Point(30, 224);

            lblOperatingSystem.Text =
                "Операційна система";

            // txtOperatingSystem
            txtOperatingSystem.Location =
                new Point(30, 248);

            txtOperatingSystem.Size =
                new Size(470, 27);

            // lblSoftware
            lblSoftware.AutoSize =
                true;

            lblSoftware.Location =
                new Point(30, 293);

            lblSoftware.Text =
                "Встановлене програмне забезпечення";

            // txtSoftware
            txtSoftware.Location =
                new Point(30, 317);

            txtSoftware.Multiline =
                true;

            txtSoftware.ScrollBars =
                ScrollBars.Vertical;

            txtSoftware.Size =
                new Size(470, 100);

            // lblNotes
            lblNotes.AutoSize =
                true;

            lblNotes.Location =
                new Point(30, 435);

            lblNotes.Text =
                "Примітки";

            // txtNotes
            txtNotes.Location =
                new Point(30, 459);

            txtNotes.Multiline =
                true;

            txtNotes.ScrollBars =
                ScrollBars.Vertical;

            txtNotes.Size =
                new Size(470, 75);

            // lblSingleton
            lblSingleton.AutoSize =
                true;

            lblSingleton.Font =
                new Font(
                    "Consolas",
                    8F);

            lblSingleton.ForeColor =
                Color.DimGray;

            lblSingleton.Location =
                new Point(30, 550);

            lblSingleton.Text =
                "DbManager Instance:";

            // btnSave
            btnSave.Location =
                new Point(268, 585);

            btnSave.Size =
                new Size(110, 40);

            btnSave.Text =
                "Зберегти";

            btnSave.UseVisualStyleBackColor =
                true;

            btnSave.Click +=
                btnSave_Click;

            // btnCancel
            btnCancel.Location =
                new Point(390, 585);

            btnCancel.Size =
                new Size(110, 40);

            btnCancel.Text =
                "Скасувати";

            btnCancel.UseVisualStyleBackColor =
                true;

            btnCancel.Click +=
                btnCancel_Click;

            // ComputerForm
            AutoScaleDimensions =
                new SizeF(8F, 20F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
                new Size(540, 650);

            Controls.Add(lblTitle);

            Controls.Add(lblComputerName);
            Controls.Add(txtComputerName);

            Controls.Add(lblIpAddress);
            Controls.Add(txtIpAddress);

            Controls.Add(lblOperatingSystem);
            Controls.Add(txtOperatingSystem);

            Controls.Add(lblSoftware);
            Controls.Add(txtSoftware);

            Controls.Add(lblNotes);
            Controls.Add(txtNotes);

            Controls.Add(lblSingleton);

            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            Font =
                new Font(
                    "Segoe UI",
                    9F);

            FormBorderStyle =
                FormBorderStyle.FixedDialog;

            MaximizeBox =
                false;

            MinimizeBox =
                false;

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "Новий комп'ютер";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}