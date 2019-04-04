using Laba_2.Controls;
using OP_ClassLib;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Laba_2
{
    public partial class InvoiceConstructorWindow : Form
    {
        public bool toEdit;
        public BindingList<Document> docList;
        public Invoice invoice = new Invoice();
        BindingList<Product> pList;
        public MainWindow.Services serviceToUse;

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
            if (SideWorker.ValidationForm(InvoicePanel.Controls))
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
            DataGridViewCellCollection dataCells = productRow.Cells;
            if (dataCells[0].Value != null)
            {
                dataCells[4].Value = invoice.CalcProductSum(dataCells[0].Value.ToString()).ToString();
                invoice.CalcGoodsSum();
                ProductSumLable.Text = invoice.GoodsSum.ToString();
            }
        }

        private void InvoiceConstructorWindow_Shown(object sender, EventArgs e)
        {
            pList = new BindingList<Product>(invoice.Products);
            dataGridViewProducts.DataSource = pList;
            invoice.SetProductList(pList.ToList());

            TextBoxBinding();
            textBoxProviderId.DataBindings.Add("Text", invoice, "ProviderId");
            textBoxClientId.DataBindings.Add("Text", invoice, "ClientId");
        }
    }
}
