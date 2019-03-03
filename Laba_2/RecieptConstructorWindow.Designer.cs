namespace Laba_2
{
    partial class RecieptConstructorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RecieptPanel = new System.Windows.Forms.Panel();
            this.ProductSumLable = new System.Windows.Forms.Label();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.dataGridViewColumnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnMUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label27 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxPaymentName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.textBoxProviderName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDocDate = new System.Windows.Forms.TextBox();
            this.textBoxDocId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.RecieptPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // RecieptPanel
            // 
            this.RecieptPanel.AutoScroll = true;
            this.RecieptPanel.Controls.Add(this.ProductSumLable);
            this.RecieptPanel.Controls.Add(this.dataGridViewProducts);
            this.RecieptPanel.Controls.Add(this.label27);
            this.RecieptPanel.Controls.Add(this.label9);
            this.RecieptPanel.Controls.Add(this.textBoxPaymentName);
            this.RecieptPanel.Controls.Add(this.label8);
            this.RecieptPanel.Controls.Add(this.textBoxClientName);
            this.RecieptPanel.Controls.Add(this.textBoxProviderName);
            this.RecieptPanel.Controls.Add(this.label7);
            this.RecieptPanel.Controls.Add(this.label6);
            this.RecieptPanel.Controls.Add(this.textBoxDocDate);
            this.RecieptPanel.Controls.Add(this.textBoxDocId);
            this.RecieptPanel.Controls.Add(this.label5);
            this.RecieptPanel.Controls.Add(this.label4);
            this.RecieptPanel.Controls.Add(this.label3);
            this.RecieptPanel.Controls.Add(this.label2);
            this.RecieptPanel.Location = new System.Drawing.Point(12, 12);
            this.RecieptPanel.Name = "RecieptPanel";
            this.RecieptPanel.Size = new System.Drawing.Size(564, 430);
            this.RecieptPanel.TabIndex = 1;
            // 
            // ProductSumLable
            // 
            this.ProductSumLable.AutoSize = true;
            this.ProductSumLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductSumLable.Location = new System.Drawing.Point(479, 382);
            this.ProductSumLable.Name = "ProductSumLable";
            this.ProductSumLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ProductSumLable.Size = new System.Drawing.Size(0, 20);
            this.ProductSumLable.TabIndex = 24;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewColumnProductName,
            this.dataGridViewColumnMUnit,
            this.dataGridViewColumnCount,
            this.dataGridViewColumnPrice,
            this.dataGridViewColumnSum});
            this.dataGridViewProducts.Location = new System.Drawing.Point(3, 264);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewProducts.Size = new System.Drawing.Size(552, 115);
            this.dataGridViewProducts.TabIndex = 23;
            this.dataGridViewProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellEndEdit);
            // 
            // dataGridViewColumnProductName
            // 
            this.dataGridViewColumnProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewColumnProductName.Frozen = true;
            this.dataGridViewColumnProductName.HeaderText = "Наименование";
            this.dataGridViewColumnProductName.Name = "dataGridViewColumnProductName";
            this.dataGridViewColumnProductName.Width = 106;
            // 
            // dataGridViewColumnMUnit
            // 
            this.dataGridViewColumnMUnit.Frozen = true;
            this.dataGridViewColumnMUnit.HeaderText = "ед.";
            this.dataGridViewColumnMUnit.Name = "dataGridViewColumnMUnit";
            this.dataGridViewColumnMUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewColumnCount
            // 
            this.dataGridViewColumnCount.Frozen = true;
            this.dataGridViewColumnCount.HeaderText = "кол-во";
            this.dataGridViewColumnCount.Name = "dataGridViewColumnCount";
            // 
            // dataGridViewColumnPrice
            // 
            this.dataGridViewColumnPrice.Frozen = true;
            this.dataGridViewColumnPrice.HeaderText = "Стоимость ед.";
            this.dataGridViewColumnPrice.Name = "dataGridViewColumnPrice";
            // 
            // dataGridViewColumnSum
            // 
            this.dataGridViewColumnSum.Frozen = true;
            this.dataGridViewColumnSum.HeaderText = "Сумма";
            this.dataGridViewColumnSum.Name = "dataGridViewColumnSum";
            this.dataGridViewColumnSum.ReadOnly = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(395, 382);
            this.label27.Name = "label27";
            this.label27.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label27.Size = new System.Drawing.Size(58, 20);
            this.label27.TabIndex = 22;
            this.label27.Text = "Сумма";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(14, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Товар/услуга";
            // 
            // textBoxPaymentName
            // 
            this.textBoxPaymentName.Location = new System.Drawing.Point(185, 194);
            this.textBoxPaymentName.Name = "textBoxPaymentName";
            this.textBoxPaymentName.Size = new System.Drawing.Size(183, 20);
            this.textBoxPaymentName.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(9, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Наименование платежа:";
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(89, 145);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(183, 20);
            this.textBoxClientName.TabIndex = 14;
            // 
            // textBoxProviderName
            // 
            this.textBoxProviderName.Location = new System.Drawing.Point(114, 97);
            this.textBoxProviderName.Name = "textBoxProviderName";
            this.textBoxProviderName.Size = new System.Drawing.Size(183, 20);
            this.textBoxProviderName.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(9, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Заказчик:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Исполнитель:";
            // 
            // textBoxDocDate
            // 
            this.textBoxDocDate.Location = new System.Drawing.Point(41, 41);
            this.textBoxDocDate.Name = "textBoxDocDate";
            this.textBoxDocDate.Size = new System.Drawing.Size(183, 20);
            this.textBoxDocDate.TabIndex = 10;
            // 
            // textBoxDocId
            // 
            this.textBoxDocId.Location = new System.Drawing.Point(116, 9);
            this.textBoxDocId.Name = "textBoxDocId";
            this.textBoxDocId.Size = new System.Drawing.Size(183, 20);
            this.textBoxDocId.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "От";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(88, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "№";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Квитанция";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(486, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(12, 448);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 53);
            this.button3.TabIndex = 4;
            this.button3.Text = "Назад";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // RecieptConstructorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 509);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RecieptPanel);
            this.Name = "RecieptConstructorWindow";
            this.Text = "RecieptConstructorWindowcs";
            this.RecieptPanel.ResumeLayout(false);
            this.RecieptPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel RecieptPanel;
        private System.Windows.Forms.Label ProductSumLable;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPaymentName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.TextBox textBoxProviderName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDocDate;
        private System.Windows.Forms.TextBox textBoxDocId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnMUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnSum;
    }
}