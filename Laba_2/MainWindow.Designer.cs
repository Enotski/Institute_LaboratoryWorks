﻿namespace Laba_2
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
            this.DocumentList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddBtn = new System.Windows.Forms.Button();
            this.Count = new System.Windows.Forms.Label();
            this.BillCount = new System.Windows.Forms.Label();
            this.InvoiceCount = new System.Windows.Forms.Label();
            this.RecieptCount = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.DocSelectComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentList)).BeginInit();
            this.SuspendLayout();
            // 
            // DocumentList
            // 
            this.DocumentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DocumentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Date,
            this.DocType});
            this.DocumentList.Location = new System.Drawing.Point(12, 12);
            this.DocumentList.Name = "DocumentList";
            this.DocumentList.Size = new System.Drawing.Size(494, 426);
            this.DocumentList.TabIndex = 0;
            this.DocumentList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 200;
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            // 
            // DocType
            // 
            this.DocType.HeaderText = "Тип документа";
            this.DocType.Name = "DocType";
            this.DocType.Width = 150;
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.Location = new System.Drawing.Point(543, 401);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(167, 37);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "Добавить документ";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Count
            // 
            this.Count.AutoSize = true;
            this.Count.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Count.Location = new System.Drawing.Point(539, 12);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(68, 24);
            this.Count.TabIndex = 4;
            this.Count.Text = "Всего:";
            // 
            // BillCount
            // 
            this.BillCount.AutoSize = true;
            this.BillCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BillCount.Location = new System.Drawing.Point(539, 73);
            this.BillCount.Name = "BillCount";
            this.BillCount.Size = new System.Drawing.Size(81, 24);
            this.BillCount.TabIndex = 5;
            this.BillCount.Text = "Счетов:";
            // 
            // InvoiceCount
            // 
            this.InvoiceCount.AutoSize = true;
            this.InvoiceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InvoiceCount.Location = new System.Drawing.Point(539, 113);
            this.InvoiceCount.Name = "InvoiceCount";
            this.InvoiceCount.Size = new System.Drawing.Size(113, 24);
            this.InvoiceCount.TabIndex = 6;
            this.InvoiceCount.Text = "Накладных:";
            // 
            // RecieptCount
            // 
            this.RecieptCount.AutoSize = true;
            this.RecieptCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RecieptCount.Location = new System.Drawing.Point(539, 155);
            this.RecieptCount.Name = "RecieptCount";
            this.RecieptCount.Size = new System.Drawing.Size(113, 24);
            this.RecieptCount.TabIndex = 7;
            this.RecieptCount.Text = "Квитанций:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(591, 258);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(524, 254);
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
            this.DocSelectComboBox.Location = new System.Drawing.Point(543, 339);
            this.DocSelectComboBox.Name = "DocSelectComboBox";
            this.DocSelectComboBox.Size = new System.Drawing.Size(167, 21);
            this.DocSelectComboBox.TabIndex = 10;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 450);
            this.Controls.Add(this.DocSelectComboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RecieptCount);
            this.Controls.Add(this.InvoiceCount);
            this.Controls.Add(this.BillCount);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.DocumentList);
            this.Name = "MainWindow";
            this.Text = "Laba_2";
            ((System.ComponentModel.ISupportInitialize)(this.DocumentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DocumentList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocType;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label Count;
        private System.Windows.Forms.Label BillCount;
        private System.Windows.Forms.Label InvoiceCount;
        private System.Windows.Forms.Label RecieptCount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox DocSelectComboBox;
    }
}

