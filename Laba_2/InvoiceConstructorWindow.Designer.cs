namespace Laba_2
{
    partial class InvoiceConstructorWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.InvoicePanel = new System.Windows.Forms.Panel();
            this.ProductSumLable = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxClientId = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.textBoxProviderId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxClientName = new System.Windows.Forms.TextBox();
            this.textBoxProviderName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxDocDate = new System.Windows.Forms.TextBox();
            this.textBoxDocId = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.InvoicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(489, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 53);
            this.button1.TabIndex = 1;
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
            this.button3.TabIndex = 3;
            this.button3.Text = "Назад";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // InvoicePanel
            // 
            this.InvoicePanel.AutoScroll = true;
            this.InvoicePanel.Controls.Add(this.ProductSumLable);
            this.InvoicePanel.Controls.Add(this.label27);
            this.InvoicePanel.Controls.Add(this.dataGridViewProducts);
            this.InvoicePanel.Controls.Add(this.textBoxClientId);
            this.InvoicePanel.Controls.Add(this.label28);
            this.InvoicePanel.Controls.Add(this.textBoxProviderId);
            this.InvoicePanel.Controls.Add(this.label10);
            this.InvoicePanel.Controls.Add(this.label17);
            this.InvoicePanel.Controls.Add(this.textBoxClientName);
            this.InvoicePanel.Controls.Add(this.textBoxProviderName);
            this.InvoicePanel.Controls.Add(this.label19);
            this.InvoicePanel.Controls.Add(this.label20);
            this.InvoicePanel.Controls.Add(this.textBoxDocDate);
            this.InvoicePanel.Controls.Add(this.textBoxDocId);
            this.InvoicePanel.Controls.Add(this.label21);
            this.InvoicePanel.Controls.Add(this.label22);
            this.InvoicePanel.Controls.Add(this.label23);
            this.InvoicePanel.Controls.Add(this.label24);
            this.InvoicePanel.Location = new System.Drawing.Point(12, 12);
            this.InvoicePanel.Name = "InvoicePanel";
            this.InvoicePanel.Size = new System.Drawing.Size(569, 430);
            this.InvoicePanel.TabIndex = 20;
            // 
            // ProductSumLable
            // 
            this.ProductSumLable.AutoSize = true;
            this.ProductSumLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductSumLable.Location = new System.Drawing.Point(480, 382);
            this.ProductSumLable.Name = "ProductSumLable";
            this.ProductSumLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ProductSumLable.Size = new System.Drawing.Size(0, 20);
            this.ProductSumLable.TabIndex = 27;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(396, 382);
            this.label27.Name = "label27";
            this.label27.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label27.Size = new System.Drawing.Size(58, 20);
            this.label27.TabIndex = 26;
            this.label27.Text = "Сумма";
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGridViewProducts.Location = new System.Drawing.Point(12, 264);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewProducts.Size = new System.Drawing.Size(552, 115);
            this.dataGridViewProducts.TabIndex = 25;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 106;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "ед.";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.Frozen = true;
            this.dataGridViewTextBoxColumn8.HeaderText = "кол-во";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.Frozen = true;
            this.dataGridViewTextBoxColumn9.HeaderText = "Стоимость ед.";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.Frozen = true;
            this.dataGridViewTextBoxColumn10.HeaderText = "Сумма";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // textBoxClientId
            // 
            this.textBoxClientId.Location = new System.Drawing.Point(60, 194);
            this.textBoxClientId.Name = "textBoxClientId";
            this.textBoxClientId.Size = new System.Drawing.Size(183, 20);
            this.textBoxClientId.TabIndex = 24;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label28.Location = new System.Drawing.Point(12, 195);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(42, 17);
            this.label28.TabIndex = 23;
            this.label28.Text = "ИНН:";
            // 
            // textBoxProviderId
            // 
            this.textBoxProviderId.Location = new System.Drawing.Point(60, 120);
            this.textBoxProviderId.Name = "textBoxProviderId";
            this.textBoxProviderId.Size = new System.Drawing.Size(183, 20);
            this.textBoxProviderId.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(12, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "ИНН:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(12, 244);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 17);
            this.label17.TabIndex = 17;
            this.label17.Text = "Товар/услуга";
            // 
            // textBoxClientName
            // 
            this.textBoxClientName.Location = new System.Drawing.Point(91, 170);
            this.textBoxClientName.Name = "textBoxClientName";
            this.textBoxClientName.Size = new System.Drawing.Size(183, 20);
            this.textBoxClientName.TabIndex = 14;
            // 
            // textBoxProviderName
            // 
            this.textBoxProviderName.Location = new System.Drawing.Point(116, 98);
            this.textBoxProviderName.Name = "textBoxProviderName";
            this.textBoxProviderName.Size = new System.Drawing.Size(183, 20);
            this.textBoxProviderName.TabIndex = 13;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(11, 171);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 17);
            this.label19.TabIndex = 12;
            this.label19.Text = "Заказчик:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(11, 99);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 17);
            this.label20.TabIndex = 11;
            this.label20.Text = "Исполнитель:";
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
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(9, 42);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 17);
            this.label21.TabIndex = 8;
            this.label21.Text = "От";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(88, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(22, 17);
            this.label22.TabIndex = 7;
            this.label22.Text = "№";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(9, 10);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(81, 17);
            this.label23.TabIndex = 6;
            this.label23.Text = "Накладная";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(3, 10);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(0, 17);
            this.label24.TabIndex = 5;
            // 
            // InvoiceConstructorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 507);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.InvoicePanel);
            this.Name = "InvoiceConstructorWindow";
            this.Text = "Constructor";
            this.InvoicePanel.ResumeLayout(false);
            this.InvoicePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel InvoicePanel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxClientName;
        private System.Windows.Forms.TextBox textBoxProviderName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxDocDate;
        private System.Windows.Forms.TextBox textBoxDocId;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxClientId;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBoxProviderId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label ProductSumLable;
        private System.Windows.Forms.Label label27;
    }
}