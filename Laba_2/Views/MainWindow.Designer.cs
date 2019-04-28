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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridViewDocumentsTable = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.DocSelectComboBox = new System.Windows.Forms.ComboBox();
            this.button_RefreshFile = new System.Windows.Forms.Button();
            this.DocumentPrintLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_LoadFromFile = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.radioButtonAsmxService = new System.Windows.Forms.RadioButton();
            this.radioButtonClientService = new System.Windows.Forms.RadioButton();
            this.radioButtonWcfService = new System.Windows.Forms.RadioButton();
            this.radioButtonGetReciepts = new System.Windows.Forms.RadioButton();
            this.radioButtonGetInvoices = new System.Windows.Forms.RadioButton();
            this.radioButtonGetBills = new System.Windows.Forms.RadioButton();
            this.radioButtonGetAllDocs = new System.Windows.Forms.RadioButton();
            this.panelLoadDocumentsRbts = new System.Windows.Forms.Panel();
            this.textBoxServiceUrl = new System.Windows.Forms.TextBox();
            this.radioButtonGetSpecialDoc = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewDocumentsTable)).BeginInit();
            this.panelLoadDocumentsRbts.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridViewDocumentsTable
            // 
            this.DataGridViewDocumentsTable.AllowUserToAddRows = false;
            this.DataGridViewDocumentsTable.AllowUserToResizeColumns = false;
            this.DataGridViewDocumentsTable.AllowUserToResizeRows = false;
            this.DataGridViewDocumentsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewDocumentsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewDocumentsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewDocumentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewDocumentsTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridViewDocumentsTable.GridColor = System.Drawing.SystemColors.GrayText;
            this.DataGridViewDocumentsTable.Location = new System.Drawing.Point(15, 69);
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
            this.textBoxSearch.Size = new System.Drawing.Size(318, 20);
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
            this.DocSelectComboBox.Location = new System.Drawing.Point(222, 425);
            this.DocSelectComboBox.Name = "DocSelectComboBox";
            this.DocSelectComboBox.Size = new System.Drawing.Size(195, 21);
            this.DocSelectComboBox.TabIndex = 10;
            this.DocSelectComboBox.Text = "Счет";
            // 
            // button_RefreshFile
            // 
            this.button_RefreshFile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button_RefreshFile.FlatAppearance.BorderSize = 0;
            this.button_RefreshFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_RefreshFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_RefreshFile.Location = new System.Drawing.Point(12, 372);
            this.button_RefreshFile.Name = "button_RefreshFile";
            this.button_RefreshFile.Size = new System.Drawing.Size(95, 48);
            this.button_RefreshFile.TabIndex = 11;
            this.button_RefreshFile.Text = "Обновить файл";
            this.button_RefreshFile.UseVisualStyleBackColor = false;
            this.button_RefreshFile.Click += new System.EventHandler(this.button_RefreshFile_Click);
            // 
            // DocumentPrintLabel
            // 
            this.DocumentPrintLabel.AutoSize = true;
            this.DocumentPrintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DocumentPrintLabel.Location = new System.Drawing.Point(439, 69);
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
            this.button_LoadFromFile.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button_LoadFromFile.FlatAppearance.BorderSize = 0;
            this.button_LoadFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_LoadFromFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_LoadFromFile.Location = new System.Drawing.Point(12, 425);
            this.button_LoadFromFile.Name = "button_LoadFromFile";
            this.button_LoadFromFile.Size = new System.Drawing.Size(95, 48);
            this.button_LoadFromFile.TabIndex = 16;
            this.button_LoadFromFile.Text = "Загрузить из файла";
            this.button_LoadFromFile.UseVisualStyleBackColor = false;
            this.button_LoadFromFile.Click += new System.EventHandler(this.button_LoadFromFile_Click);
            // 
            // button_Add
            // 
            this.button_Add.BackColor = System.Drawing.Color.LightGreen;
            this.button_Add.FlatAppearance.BorderSize = 0;
            this.button_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_Add.Location = new System.Drawing.Point(222, 372);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(195, 47);
            this.button_Add.TabIndex = 18;
            this.button_Add.Text = "Добавить документ";
            this.button_Add.UseVisualStyleBackColor = false;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // radioButtonAsmxService
            // 
            this.radioButtonAsmxService.AutoSize = true;
            this.radioButtonAsmxService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAsmxService.Location = new System.Drawing.Point(443, 398);
            this.radioButtonAsmxService.Name = "radioButtonAsmxService";
            this.radioButtonAsmxService.Size = new System.Drawing.Size(145, 21);
            this.radioButtonAsmxService.TabIndex = 19;
            this.radioButtonAsmxService.Text = "Веб-Служба  asmx";
            this.radioButtonAsmxService.UseVisualStyleBackColor = true;
            this.radioButtonAsmxService.CheckedChanged += new System.EventHandler(this.radioButtonAsmxService_CheckedChanged);
            // 
            // radioButtonClientService
            // 
            this.radioButtonClientService.AutoSize = true;
            this.radioButtonClientService.Checked = true;
            this.radioButtonClientService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonClientService.Location = new System.Drawing.Point(443, 453);
            this.radioButtonClientService.Name = "radioButtonClientService";
            this.radioButtonClientService.Size = new System.Drawing.Size(155, 21);
            this.radioButtonClientService.TabIndex = 20;
            this.radioButtonClientService.TabStop = true;
            this.radioButtonClientService.Text = "Клиентская служба";
            this.radioButtonClientService.UseVisualStyleBackColor = true;
            this.radioButtonClientService.CheckedChanged += new System.EventHandler(this.RadioButtonClientService_CheckedChanged);
            // 
            // radioButtonWcfService
            // 
            this.radioButtonWcfService.AutoSize = true;
            this.radioButtonWcfService.BackColor = System.Drawing.SystemColors.Control;
            this.radioButtonWcfService.Enabled = false;
            this.radioButtonWcfService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonWcfService.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.radioButtonWcfService.Location = new System.Drawing.Point(443, 426);
            this.radioButtonWcfService.Name = "radioButtonWcfService";
            this.radioButtonWcfService.Size = new System.Drawing.Size(139, 21);
            this.radioButtonWcfService.TabIndex = 21;
            this.radioButtonWcfService.Text = "Веб-Служба WCF";
            this.radioButtonWcfService.UseVisualStyleBackColor = false;
            this.radioButtonWcfService.CheckedChanged += new System.EventHandler(this.RadioButtonWcfService_CheckedChanged);
            // 
            // radioButtonGetReciepts
            // 
            this.radioButtonGetReciepts.AutoSize = true;
            this.radioButtonGetReciepts.BackColor = System.Drawing.SystemColors.Control;
            this.radioButtonGetReciepts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonGetReciepts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButtonGetReciepts.Location = new System.Drawing.Point(8, 31);
            this.radioButtonGetReciepts.Name = "radioButtonGetReciepts";
            this.radioButtonGetReciepts.Size = new System.Drawing.Size(165, 21);
            this.radioButtonGetReciepts.TabIndex = 24;
            this.radioButtonGetReciepts.Text = "Загрузить квитанции";
            this.radioButtonGetReciepts.UseVisualStyleBackColor = false;
            this.radioButtonGetReciepts.CheckedChanged += new System.EventHandler(this.RadioButtonGetReciepts_CheckedChanged);
            // 
            // radioButtonGetInvoices
            // 
            this.radioButtonGetInvoices.AutoSize = true;
            this.radioButtonGetInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonGetInvoices.Location = new System.Drawing.Point(8, 58);
            this.radioButtonGetInvoices.Name = "radioButtonGetInvoices";
            this.radioButtonGetInvoices.Size = new System.Drawing.Size(169, 21);
            this.radioButtonGetInvoices.TabIndex = 23;
            this.radioButtonGetInvoices.Text = "Загрузить накладные";
            this.radioButtonGetInvoices.UseVisualStyleBackColor = true;
            this.radioButtonGetInvoices.CheckedChanged += new System.EventHandler(this.RadioButtonGetInvoices_CheckedChanged);
            // 
            // radioButtonGetBills
            // 
            this.radioButtonGetBills.AutoSize = true;
            this.radioButtonGetBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonGetBills.Location = new System.Drawing.Point(8, 4);
            this.radioButtonGetBills.Name = "radioButtonGetBills";
            this.radioButtonGetBills.Size = new System.Drawing.Size(134, 21);
            this.radioButtonGetBills.TabIndex = 22;
            this.radioButtonGetBills.Text = "Загрузить счета";
            this.radioButtonGetBills.UseVisualStyleBackColor = true;
            this.radioButtonGetBills.CheckedChanged += new System.EventHandler(this.RadioButtonGetBills_CheckedChanged);
            // 
            // radioButtonGetAllDocs
            // 
            this.radioButtonGetAllDocs.AutoSize = true;
            this.radioButtonGetAllDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonGetAllDocs.Location = new System.Drawing.Point(8, 85);
            this.radioButtonGetAllDocs.Name = "radioButtonGetAllDocs";
            this.radioButtonGetAllDocs.Size = new System.Drawing.Size(194, 21);
            this.radioButtonGetAllDocs.TabIndex = 25;
            this.radioButtonGetAllDocs.Text = "Загрузить все документы";
            this.radioButtonGetAllDocs.UseVisualStyleBackColor = true;
            this.radioButtonGetAllDocs.CheckedChanged += new System.EventHandler(this.RadioButtonGetAllDocs_CheckedChanged);
            // 
            // panelLoadDocumentsRbts
            // 
            this.panelLoadDocumentsRbts.Controls.Add(this.radioButtonGetSpecialDoc);
            this.panelLoadDocumentsRbts.Controls.Add(this.radioButtonGetBills);
            this.panelLoadDocumentsRbts.Controls.Add(this.radioButtonGetAllDocs);
            this.panelLoadDocumentsRbts.Controls.Add(this.radioButtonGetInvoices);
            this.panelLoadDocumentsRbts.Controls.Add(this.radioButtonGetReciepts);
            this.panelLoadDocumentsRbts.Enabled = false;
            this.panelLoadDocumentsRbts.Location = new System.Drawing.Point(12, 479);
            this.panelLoadDocumentsRbts.Name = "panelLoadDocumentsRbts";
            this.panelLoadDocumentsRbts.Size = new System.Drawing.Size(272, 138);
            this.panelLoadDocumentsRbts.TabIndex = 26;
            this.panelLoadDocumentsRbts.Visible = false;
            // 
            // textBoxServiceUrl
            // 
            this.textBoxServiceUrl.Enabled = false;
            this.textBoxServiceUrl.Location = new System.Drawing.Point(443, 372);
            this.textBoxServiceUrl.Name = "textBoxServiceUrl";
            this.textBoxServiceUrl.Size = new System.Drawing.Size(388, 20);
            this.textBoxServiceUrl.TabIndex = 27;
            this.textBoxServiceUrl.Text = "URL службы";
            this.textBoxServiceUrl.Visible = false;
            this.textBoxServiceUrl.TextChanged += new System.EventHandler(this.TextBoxServiceUrl_TextChanged);
            // 
            // radioButtonGetSpecialDoc
            // 
            this.radioButtonGetSpecialDoc.AutoSize = true;
            this.radioButtonGetSpecialDoc.Checked = true;
            this.radioButtonGetSpecialDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonGetSpecialDoc.Location = new System.Drawing.Point(8, 112);
            this.radioButtonGetSpecialDoc.Name = "radioButtonGetSpecialDoc";
            this.radioButtonGetSpecialDoc.Size = new System.Drawing.Size(260, 21);
            this.radioButtonGetSpecialDoc.TabIndex = 26;
            this.radioButtonGetSpecialDoc.Text = "Загрузить определенный документ";
            this.radioButtonGetSpecialDoc.UseVisualStyleBackColor = true;
            this.radioButtonGetSpecialDoc.CheckedChanged += new System.EventHandler(this.RadioButtonGetSpecialDoc_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 620);
            this.Controls.Add(this.textBoxServiceUrl);
            this.Controls.Add(this.panelLoadDocumentsRbts);
            this.Controls.Add(this.radioButtonWcfService);
            this.Controls.Add(this.radioButtonClientService);
            this.Controls.Add(this.radioButtonAsmxService);
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
            this.panelLoadDocumentsRbts.ResumeLayout(false);
            this.panelLoadDocumentsRbts.PerformLayout();
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
        private System.Windows.Forms.RadioButton radioButtonAsmxService;
        private System.Windows.Forms.RadioButton radioButtonClientService;
        private System.Windows.Forms.RadioButton radioButtonWcfService;
        private System.Windows.Forms.RadioButton radioButtonGetReciepts;
        private System.Windows.Forms.RadioButton radioButtonGetInvoices;
        private System.Windows.Forms.RadioButton radioButtonGetBills;
        private System.Windows.Forms.RadioButton radioButtonGetAllDocs;
        private System.Windows.Forms.Panel panelLoadDocumentsRbts;
        private System.Windows.Forms.TextBox textBoxServiceUrl;
        private System.Windows.Forms.RadioButton radioButtonGetSpecialDoc;
    }
}

