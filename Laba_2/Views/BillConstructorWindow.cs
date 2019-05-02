using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Laba_2.Controls;
using OP_ClassLib;

namespace Laba_2
{
    public partial class BillConstructorWindow : Form
    {
        public bool toEdit;
        public SideWorker.ServicesSwitcher serviceToUse;
        public BindingList<Document> docList;
        public Bill bill = new Bill();
        BindingList<Product> pList;
        MyAsmxService.DocumentsWebService asmxService = MainWindow.asmxService;
        MyWcfService.DocumentsWebServiceWcf wcfService = MainWindow.wcfService;
        public BillConstructorWindow()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (SideWorker.ValidationForm(BillPanel.Controls))
            {
                if(serviceToUse == SideWorker.ServicesSwitcher.asmx) // веб-служба
                {
                    // заносим все из формы в массив для отправки
                    string[] docData = new string[]
                    {
                        textBoxDocId.Text,
                        textBoxDocDate.Text,
                        textBoxProviderName.Text,
                        textBoxClientName.Text,
                        textBoxClientId.Text
                    };
                    // конвертируем список продуктов в подходящий тип
                    asmxService.SetDocumentBillAsync(docData, bill.Products.Select(SideWorker.CastToAsmxProducts).ToArray());
                }
                else if (serviceToUse == SideWorker.ServicesSwitcher.wcf) // веб-служба
                {
                    // заносим все из формы в массив для отправки
                    string[] docData = new string[]
                    {
                        textBoxDocId.Text,
                        textBoxDocDate.Text,
                        textBoxProviderName.Text,
                        textBoxClientName.Text,
                        textBoxClientId.Text
                    };
                    // конвертируем список продуктов в подходящий тип
                    
                    wcfService.SetDocumentBillAsync(docData, bill.Products.Select(SideWorker.CastToWcfProducts).ToArray());
                }
                else if (!toEdit)
                    docList.Add(bill);
                this.Close();
            }
        }
        private void dataGridViewProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int pIndx = e.RowIndex;
            DataGridViewRow productRow = dataGridViewProducts.Rows[pIndx];
            ProductInitialize(productRow);
        }
        private void BillConstructorWindow_Shown(object sender, EventArgs e)
        {
                pList = new BindingList<Product>(bill.Products);
                dataGridViewProducts.DataSource = pList;
                bill.SetProductList(pList.ToList());

                TextBoxBinding();
                textBoxClientId.DataBindings.Add("Text", bill, "ClientId");
        }
        private void TextBoxBinding()
        {
            textBoxDocId.DataBindings.Add("Text", bill, "DocId");
            textBoxDocDate.DataBindings.Add("Text", bill, "DocDate");
            textBoxProviderName.DataBindings.Add("Text", bill, "Provider");
            textBoxClientName.DataBindings.Add("Text", bill, "Client");
        }
        private void ProductInitialize(DataGridViewRow productRow)
        {
            DataGridViewCellCollection dataCells = productRow.Cells;
            if(dataCells[0].Value != null)
            {
                dataCells[4].Value = bill.CalcProductSum(dataCells[0].Value.ToString()).ToString();
                bill.CalcGoodsSum();
                ProductSumLable.Text = bill.GoodsSum.ToString();
            }
        }
    }
}
