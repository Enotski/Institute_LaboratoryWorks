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
            this.DocumentsTableList = new System.Windows.Forms.DataGridView();
            this.AddBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.DocSelectComboBox = new System.Windows.Forms.ComboBox();
            this.ReloadFile = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.DocumentPrintLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentsTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // DocumentsTableList
            // 
            this.DocumentsTableList.AllowUserToAddRows = false;
            this.DocumentsTableList.AllowUserToResizeColumns = false;
            this.DocumentsTableList.AllowUserToResizeRows = false;
            this.DocumentsTableList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DocumentsTableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DocumentsTableList.Location = new System.Drawing.Point(12, 69);
            this.DocumentsTableList.Name = "DocumentsTableList";
            this.DocumentsTableList.RowTemplate.ReadOnly = true;
            this.DocumentsTableList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DocumentsTableList.Size = new System.Drawing.Size(402, 283);
            this.DocumentsTableList.TabIndex = 0;
            this.DocumentsTableList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 20);
            this.textBox1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(12, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 26);
            this.button2.TabIndex = 9;
            this.button2.Text = "Поиск:";
            this.button2.UseVisualStyleBackColor = true;
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
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(113, 371);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 48);
            this.button3.TabIndex = 12;
            this.button3.Text = "Обновить таблицу";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // DocumentPrintLabel
            // 
            this.DocumentPrintLabel.AutoSize = true;
            this.DocumentPrintLabel.Location = new System.Drawing.Point(469, 69);
            this.DocumentPrintLabel.Name = "DocumentPrintLabel";
            this.DocumentPrintLabel.Size = new System.Drawing.Size(48, 13);
            this.DocumentPrintLabel.TabIndex = 14;
            this.DocumentPrintLabel.Text = "DocPrint";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 492);
            this.Controls.Add(this.DocumentPrintLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ReloadFile);
            this.Controls.Add(this.DocSelectComboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.DocumentsTableList);
            this.Name = "MainWindow";
            this.Text = "Laba_2";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DocumentsTableList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DocumentsTableList;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox DocSelectComboBox;
        private System.Windows.Forms.Button ReloadFile;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label DocumentPrintLabel;
    }
}

