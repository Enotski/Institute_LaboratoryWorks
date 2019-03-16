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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridViewDocumentsTable = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.DocSelectComboBox = new System.Windows.Forms.ComboBox();
            this.button_RefreshFile = new System.Windows.Forms.Button();
            this.DocumentPrintLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_LoadFromFile = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDocumentsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewDocumentsTable
            // 
            this.DataGridViewDocumentsTable.AllowUserToAddRows = false;
            this.DataGridViewDocumentsTable.AllowUserToResizeColumns = false;
            this.DataGridViewDocumentsTable.AllowUserToResizeRows = false;
            this.DataGridViewDocumentsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewDocumentsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewDocumentsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewDocumentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewDocumentsTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewDocumentsTable.GridColor = System.Drawing.SystemColors.GrayText;
            this.DataGridViewDocumentsTable.Location = new System.Drawing.Point(26, 69);
            this.DataGridViewDocumentsTable.Name = "DataGridViewDocumentsTable";
            this.DataGridViewDocumentsTable.ReadOnly = true;
            this.DataGridViewDocumentsTable.RowTemplate.Height = 24;
            this.DataGridViewDocumentsTable.RowTemplate.ReadOnly = true;
            this.DataGridViewDocumentsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewDocumentsTable.Size = new System.Drawing.Size(402, 283);
            this.DataGridViewDocumentsTable.TabIndex = 0;
            this.DataGridViewDocumentsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGirdViewDocumentsTable_CellClick);
            this.DataGridViewDocumentsTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGirdViewDocumentsTable_CellDoubleClick);
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
            this.button_RefreshFile.Click += new System.EventHandler(this.button_RefreshFile_Click);
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
            this.button_LoadFromFile.Click += new System.EventHandler(this.button_LoadFromFile_Click);
            // 
            // button_Add
            // 
            this.button_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Add.Location = new System.Drawing.Point(219, 371);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(195, 55);
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
            this.Controls.Add(this.button_LoadFromFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DocumentPrintLabel);
            this.Controls.Add(this.button_RefreshFile);
            this.Controls.Add(this.DocSelectComboBox);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.DataGridViewDocumentsTable);
            this.Name = "MainWindow";
            this.Text = "Laba_2";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDocumentsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewDocumentsTable;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ComboBox DocSelectComboBox;
        private System.Windows.Forms.Button button_RefreshFile;
        private System.Windows.Forms.Label DocumentPrintLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_LoadFromFile;
        private System.Windows.Forms.Button button_Add;
    }
}

