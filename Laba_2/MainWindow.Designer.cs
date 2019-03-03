namespace Laba_2
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGirdViewDocumentsTable = new System.Windows.Forms.DataGridView();
            this.AddBtn = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.DocSelectComboBox = new System.Windows.Forms.ComboBox();
            this.ReloadFile = new System.Windows.Forms.Button();
            this.DocumentPrintLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGirdViewDocumentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGirdViewDocumentsTable
            // 
            this.DataGirdViewDocumentsTable.AllowUserToAddRows = false;
            this.DataGirdViewDocumentsTable.AllowUserToResizeColumns = false;
            this.DataGirdViewDocumentsTable.AllowUserToResizeRows = false;
            this.DataGirdViewDocumentsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGirdViewDocumentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGirdViewDocumentsTable.Location = new System.Drawing.Point(12, 69);
            this.DataGirdViewDocumentsTable.Name = "DataGirdViewDocumentsTable";
            this.DataGirdViewDocumentsTable.RowTemplate.ReadOnly = true;
            this.DataGirdViewDocumentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGirdViewDocumentsTable.Size = new System.Drawing.Size(402, 283);
            this.DataGirdViewDocumentsTable.TabIndex = 0;
            this.DataGirdViewDocumentsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.Location = new System.Drawing.Point(219, 371);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(195, 40);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "Добавить документ";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(99, 21);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(315, 20);
            this.textBoxSearch.TabIndex = 8;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // DocSelectComboBox
            // 
            this.DocSelectComboBox.FormattingEnabled = true;
            this.DocSelectComboBox.Items.AddRange(new object[] {
            "Счет",
            "Квитанция",
            "Накладная"});
            this.DocSelectComboBox.Location = new System.Drawing.Point(219, 417);
            this.DocSelectComboBox.Name = "DocSelectComboBox";
            this.DocSelectComboBox.Size = new System.Drawing.Size(195, 21);
            this.DocSelectComboBox.TabIndex = 10;
            this.DocSelectComboBox.Text = "Счет";
            // 
            // ReloadFile
            // 
            this.ReloadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReloadFile.Location = new System.Drawing.Point(12, 371);
            this.ReloadFile.Name = "ReloadFile";
            this.ReloadFile.Size = new System.Drawing.Size(95, 48);
            this.ReloadFile.TabIndex = 11;
            this.ReloadFile.Text = "Обновить файл";
            this.ReloadFile.UseVisualStyleBackColor = true;
            // 
            // DocumentPrintLabel
            // 
            this.DocumentPrintLabel.AutoSize = true;
            this.DocumentPrintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DocumentPrintLabel.Location = new System.Drawing.Point(469, 69);
            this.DocumentPrintLabel.Name = "DocumentPrintLabel";
            this.DocumentPrintLabel.Size = new System.Drawing.Size(0, 20);
            this.DocumentPrintLabel.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Введите №";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 492);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DocumentPrintLabel);
            this.Controls.Add(this.ReloadFile);
            this.Controls.Add(this.DocSelectComboBox);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.DataGirdViewDocumentsTable);
            this.Name = "MainWindow";
            this.Text = "Laba_2";
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGirdViewDocumentsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGirdViewDocumentsTable;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox DocSelectComboBox;
        private System.Windows.Forms.Button ReloadFile;
        private System.Windows.Forms.Label DocumentPrintLabel;
        private System.Windows.Forms.Label label1;
    }
}

