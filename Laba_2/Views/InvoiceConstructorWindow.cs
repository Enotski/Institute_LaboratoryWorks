using Laba_2.Controls;
using OP_ClassLib;
using System;
using System.Collections.Generic;
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
        public SideWorker.ServicesSwitcher serviceToUse;
        MyAsmxService.DocumentsWebService asmxService = MainWindow.asmxService;
        MyWcfService.DocumentsWebServiceWcfClient wcfService = MainWindow.wcfClient;
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
        private async void button1_Click(object sender, EventArgs e)
        {
            if (SideWorker.ValidationForm(InvoicePanel.Controls))
            {
                if (serviceToUse == SideWorker.ServicesSwitcher.asmx) // веб-служба
                {
                    string[] docData = new string[]
                    {
                        textBoxDocId.Text,
                        textBoxDocDate.Text,
                        textBoxProviderName.Text,
                        textBoxClientName.Text,
                        textBoxClientId.Text,
                        textBoxProviderId.Text
                    };
                    asmxService.SetDocumentInvoiceAsync(docData, invoice.Products.Select(SideWorker.CastToAsmxProducts).ToArray());
                }
                else if (serviceToUse == SideWorker.ServicesSwitcher.wcf) // веб-служба
                {
                    MyWcfService.ArrayOfString toWcf = new MyWcfService.ArrayOfString
                    {
                        textBoxDocId.Text,
                        textBoxDocDate.Text,
                        textBoxProviderName.Text,
                        textBoxClientName.Text,
                        textBoxClientId.Text,
                        textBoxProviderId.Text
                    };
                    await wcfService.SetDocumentInvoiceAsync(toWcf, invoice.Products.Select(SideWorker.CastToWcfProducts).ToArray());
                }
                else if (!toEdit)
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
