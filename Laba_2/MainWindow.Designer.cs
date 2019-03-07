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
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.DocSelectComboBox = new System.Windows.Forms.ComboBox();
            this.button_RefreshFile = new System.Windows.Forms.Button();
            this.DocumentPrintLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_LoadFromFile = new System.Windows.Forms.Button();
            this.button_Remove = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
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
            this.DataGirdViewDocumentsTable.ReadOnly = true;
            this.DataGirdViewDocumentsTable.RowTemplate.ReadOnly = true;
            this.DataGirdViewDocumentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGirdViewDocumentsTable.Size = new System.Drawing.Size(402, 283);
            this.DataGirdViewDocumentsTable.TabIndex = 0;
            this.DataGirdViewDocumentsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.DocSelectComboBox.Location = new System.Drawing.Point(219, 432);
            this.DocSelectComboBox.Name = "DocSelectComboBox";
            this.DocSelectComboBox.Size = new System.Drawing.Size(195, 21);
            this.DocSelectComboBox.TabIndex = 10;
            this.DocSelectComboBox.Text = "Счет";
            // 
            // button_RefreshFile
            // 
            this.button_RefreshFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_RefreshFile.Location = new System.Drawing.Point(12, 371);
            this.button_RefreshFile.Name = "button_RefreshFile";
            this.button_RefreshFile.Size = new System.Drawing.Size(95, 48);
            this.button_RefreshFile.TabIndex = 11;
            this.button_RefreshFile.Text = "Обновить файл";
            this.button_RefreshFile.UseVisualStyleBackColor = true;
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
            // button_LoadFromFile
            // 
            this.button_LoadFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_LoadFromFile.Location = new System.Drawing.Point(12, 432);
            this.button_LoadFromFile.Name = "button_LoadFromFile";
            this.button_LoadFromFile.Size = new System.Drawing.Size(95, 48);
            this.button_LoadFromFile.TabIndex = 16;
            this.button_LoadFromFile.Text = "Обновить список";
            this.button_LoadFromFile.UseVisualStyleBackColor = true;
            // 
            // button_Remove
            // 
            this.button_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Remove.Location = new System.Drawing.Point(219, 371);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(89, 55);
            this.button_Remove.TabIndex = 17;
            this.button_Remove.Text = "Удалить документ";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // button_Add
            // 
            this.button_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Add.Location = new System.Drawing.Point(325, 371);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(89, 55);
            this.button_Add.TabIndex = 18;
            this.button_Add.Text = "Добавить документ";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 492);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.button_LoadFromFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DocumentPrintLabel);
            this.Controls.Add(this.button_RefreshFile);
            this.Controls.Add(this.DocSelectComboBox);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.DataGirdViewDocumentsTable);
            this.Name = "MainWindow";
            this.Text = "Laba_2";
            ((System.ComponentModel.ISupportInitialize)(this.DataGirdViewDocumentsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGirdViewDocumentsTable;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox DocSelectComboBox;
        private System.Windows.Forms.Button button_RefreshFile;
        private System.Windows.Forms.Label DocumentPrintLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_LoadFromFile;
        private System.Windows.Forms.Button button_Remove;
        private System.Windows.Forms.Button button_Add;
    }
}

