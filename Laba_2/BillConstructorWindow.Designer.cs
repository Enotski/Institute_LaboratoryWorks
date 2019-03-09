namespace Laba_2
{
    partial class BillConstructorWindow
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
            this.BillPanel = new System.Windows.Forms.Panel();
            this.ProductSumLable = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textBoxClientId = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.textBoxProviderName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxDocDate = new System.Windows.Forms.TextBox();
            this.textBoxDocId = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.BillPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // BillPanel
            // 
            this.BillPanel.AutoScroll = true;
            this.BillPanel.Controls.Add(this.ProductSumLable);
            this.BillPanel.Controls.Add(this.label27);
            this.BillPanel.Controls.Add(this.textBoxClientId);
            this.BillPanel.Controls.Add(this.label25);
            this.BillPanel.Controls.Add(this.dataGridViewProducts);
            this.BillPanel.Controls.Add(this.label1);
            this.BillPanel.Controls.Add(this.textBoxClientName);
            this.BillPanel.Controls.Add(this.textBoxProviderName);
            this.BillPanel.Controls.Add(this.label11);
            this.BillPanel.Controls.Add(this.label12);
            this.BillPanel.Controls.Add(this.textBoxDocDate);
            this.BillPanel.Controls.Add(this.textBoxDocId);
            this.BillPanel.Controls.Add(this.label13);
            this.BillPanel.Controls.Add(this.label14);
            this.BillPanel.Controls.Add(this.label15);
            this.BillPanel.Controls.Add(this.label16);
            this.BillPanel.Location = new System.Drawing.Point(12, 8);
            this.BillPanel.Name = "BillPanel";
            this.BillPanel.Size = new System.Drawing.Size(568, 430);
            this.BillPanel.TabIndex = 20;
            // 
            // ProductSumLable
            // 
            this.ProductSumLable.AutoSize = true;
            this.ProductSumLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductSumLable.Location = new System.Drawing.Point(485, 359);
            this.ProductSumLable.Name = "ProductSumLable";
            this.ProductSumLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ProductSumLable.Size = new System.Drawing.Size(0, 20);
            this.ProductSumLable.TabIndex = 26;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(401, 359);
            this.label27.Name = "label27";
            this.label27.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label27.Size = new System.Drawing.Size(58, 20);
            this.label27.TabIndex = 25;
            this.label27.Text = "Сумма";
            // 
            // textBoxClientId
            // 
            this.textBoxClientId.Location = new System.Drawing.Point(56, 169);
            this.textBoxClientId.Name = "textBoxClientId";
            this.textBoxClientId.Size = new System.Drawing.Size(183, 20);
            this.textBoxClientId.TabIndex = 20;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(8, 170);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 17);
            this.label25.TabIndex = 19;
            this.label25.Text = "ИНН:";
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(14, 241);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewProducts.Size = new System.Drawing.Size(552, 115);
            this.dataGridViewProducts.TabIndex = 18;
            this.dataGridViewProducts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellEndEdit);
            this.dataGridViewProducts.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewProducts_UserAddedRow);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Товар/услуга";
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(88, 143);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(183, 20);
            this.textBoxClientName.TabIndex = 14;
            // 
            // textBoxProviderName
            // 
            this.textBoxProviderName.Location = new System.Drawing.Point(113, 95);
            this.textBoxProviderName.Name = "textBoxProviderName";
            this.textBoxProviderName.Size = new System.Drawing.Size(183, 20);
            this.textBoxProviderName.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(8, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "Заказчик:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(8, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "Исполнитель:";
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
            this.textBoxDocId.Location = new System.Drawing.Point(74, 10);
            this.textBoxDocId.Name = "textBoxDocId";
            this.textBoxDocId.Size = new System.Drawing.Size(183, 20);
            this.textBoxDocId.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(9, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 17);
            this.label13.TabIndex = 8;
            this.label13.Text = "От";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(46, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 17);
            this.label14.TabIndex = 7;
            this.label14.Text = "№";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(9, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 17);
            this.label15.TabIndex = 6;
            this.label15.Text = "Счет";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(3, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 17);
            this.label16.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(12, 444);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 53);
            this.button3.TabIndex = 22;
            this.button3.Text = "Назад";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(490, 444);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(90, 53);
            this.buttonSave.TabIndex = 21;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // BillConstructorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 509);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.BillPanel);
            this.Name = "BillConstructorWindow";
            this.Text = "BillConstructorWindow";
            this.Shown += new System.EventHandler(this.BillConstructorWindow_Shown);
            this.BillPanel.ResumeLayout(false);
            this.BillPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BillPanel;
        private System.Windows.Forms.TextBox textBoxClientId;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.TextBox textBoxProviderName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDocDate;
        private System.Windows.Forms.TextBox textBoxDocId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label ProductSumLable;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonSave;
    }
}