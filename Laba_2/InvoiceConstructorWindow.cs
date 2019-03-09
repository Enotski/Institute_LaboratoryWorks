using OP_ClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_2
{
    public partial class InvoiceConstructorWindow : Form
    {
        public bool toEdit;
        public BindingList<Document> docList;
        public List<Product> productList = new List<Product>();
        public Invoice invoice = new Invoice();

        Product _p;
        BindingList<Product> iList;
        BindingSource source;

        public InvoiceConstructorWindow()
        {
            InitializeComponent();
        }
        private void TextBoxBinding()
        {
            textBoxDocId.DataBindings.Add("Text", invoice, "DocId");
            textBoxDocDate.DataBindings.Add("Text", invoice, "DocDate");
            textBoxProviderName.DataBindings.Add("Text", invoice, "Provider");
            textBoxClientName.DataBindings.Add("Text", invoice, "Client");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidationForm())
            {
                if (!toEdit)
                    docList.Add(invoice);
                this.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int pIndx = e.RowIndex;
            DataGridViewRow productRow = dataGridViewProducts.Rows[pIndx];
            ProductInitialize(productRow);
        }

        private void ProductInitialize(DataGridViewRow productRow)
        {
            foreach(DataGridViewCell cell in productRow.Cells)
            {
                if (!cell.ReadOnly && cell.Value == null)
                    return;
            }
            DataGridViewCellCollection dataCells = productRow.Cells;

            double priceCell = invoice.CalcProductSum(dataCells[0].Value.ToString());
            dataCells[4].Value = priceCell;
            invoice.CalcGoodsSum();
            ProductSumLable.Text = invoice.GoodsSum.ToString();
        }
        private bool ValidationForm()
        {
            foreach (var control in InvoicePanel.Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrWhiteSpace(((TextBox)control).Text))
                    {
                        MessageBox.Show("Заполните все поля");
                        return false;
                    }
                }
            }
            return true;
        }

        private void InvoiceConstructorWindow_Shown(object sender, EventArgs e)
        {
            iList = new BindingList<Product>(productList);
            source = new BindingSource(iList, null);
            dataGridViewProducts.DataSource = source;
            invoice.SetProductList(productList);

            TextBoxBinding();
            textBoxProviderId.DataBindings.Add("Text", invoice, "ProviderId");
            textBoxClientId.DataBindings.Add("Text", invoice, "ClientId");
        }

        private void dataGridViewProducts_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _p = new Product();
            invoice.SetProduct(_p);
        }
    }
}
